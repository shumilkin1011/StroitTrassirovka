using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace StroitTrass
{
    public partial class Form1 : Form
    {
        const int INF = 9999; // константа-бесконечность для ал. Дейкстры
        static bool newPolFlag = false; // режим доб. нов. эл-та
        static List<Polygon> pols; // все полигоны
        static List<Point> pts; // точки для полигона
        static List<Point> pts_all; // все точки на экране
        static MouseEventArgs ms; // отслеживание состояния мыши
        static Graphics g; // граф. объект
        static Double[,] Matr; // матрица расстояний.
        static bool newDistPtFl = false; // флаш добав. новой конечной точки
        static bool newStPtFl = false; // флаг добавления новой точки-старта

        public Form1()
        {
            InitializeComponent(); // создаётся форма
            pts = new List<Point>(); // инициализируются списки
            pts_all = new List<Point>();
            pols = new List<Polygon>();
            g = pictureBox1.CreateGraphics(); // создаем объект, необходимый для рисования.

        }
        static void VisibilityGraph()
        {
            Matr = new double[pts_all.Count, pts_all.Count];
            for(int i = 0; i<pts_all.Count;i++)
            {
                for(int j =0;j<pts_all.Count;j++)
                {
                    if (!Intercept(pts_all[i],pts_all[j]))
                    {
                        Matr[i, j] = Distance(pts_all[i], pts_all[j]); // записываем длину ребра в матр. расст.
                        g.DrawLine(new Pen(Color.Pink, 2), pts_all[i], pts_all[j]);
                    }
                    else
                    {
                        Matr[i, j] = INF; // записываем INF, если пути нет
                    }
                }
            }

        }
        static void Deikstra()
        {
            
            int[] a = new int[pts_all.Count];
            int[] c = new int[pts_all.Count]; 
            double[] b = new double[pts_all.Count]; // массив с мин. путём до данной вершины
            double dmin; // мин. расстояние в массиве b
            int i, k, z, j, m;
            // i - номер исх. вершины, k,z,j,m - вспомог. перем-ые

            i = 0;

            for (j = 0; j < pts_all.Count; j++)
            {
                a[j] = 0; c[j] = i; b[j] = Matr[i, j];
                // заполняем массивы числами
                // a заполняем нулями, в b копируем строку расстояний из исх
                // матрицы. В массив c пишем номер исходной вершины
            }
            a[i] = 1; c[i] = -1; // помечаем исх. вершину в массивах a и c

            for (m = 0; m < pts_all.Count; m++)
            {
                dmin = 300000;
                for (k = 0; k < pts_all.Count; k++)
                    if ((a[k] == 0) && (b[k] < dmin))
                    {   // если вершина не помечена и расстояние до неё < минимума
                        j = k; dmin = b[k];
                    }

                a[j] = 1; // помечаем выбранную вершину

                for (k = 0; k < pts_all.Count; k++)
                    if (b[k] > b[j] + Matr[j, k])
                    {
                        // если текущ расст. до вершины больше, чем 
                        // расстояние до неё через выбранную вершину
                        b[k] = b[j] + Matr[j, k];
                        c[k] = j;
                    }
            }

            k = pts_all.Count - 1; // выбираем посл. вершину
            if (b[pts_all.Count - 1] == INF) return;
            else
            {
                g.DrawLine(new Pen(Color.Green, 3), pts_all[k], pts_all[c[k]]);
            }

            int d = 0;
            z = c[k];
            while (c[z] != -1 && d < pts_all.Count)
            {   // пока не встретим метку 1-ой вершины
                d++;
                g.DrawLine(new Pen(Color.Green, 3), pts_all[z], pts_all[c[z]]);
                z = c[z];
            }
            
        }
        static void DrawPolCont()
        {
            // рисуем контуры полигонов

            foreach (Polygon pg in pols)
            {
                for (int i = 0; i < pg.pts.Count - 1; i++)
                {
                    g.DrawLine(new Pen(Color.Black, 2), pg.pts[i], pg.pts[i + 1]);
                }
                if(pg.pts.Count > 2)
                {
                    g.DrawLine(new Pen(Color.Black, 2), pg.pts[0], pg.pts[pg.pts.Count-1]);
                }
            }
        }
        static bool CheckIfNear(Polygon p, Point a, Point b)
        {
            // проверяем, принадлежат ли точки а и b полигону
            bool flag = false;
            if (p.pts.Contains(a) && p.pts.Contains(b) && p.pts.Count > 3)
            {
                // проходим по всем точкам и проверяем, лежат ли они на краях существующей грани
                for (int i = 0; i < p.pts.Count - 1; i++)
                {
                    if ((p.pts[i] == a) && (p.pts[i + 1] == b)) flag = true;
                    if ((p.pts[i] == b) && (p.pts[i + 1] == a)) flag = true;
                }
                if ((p.pts[p.pts.Count - 1] == a) && (p.pts[0] == b)) flag = true;
                if ((p.pts[0] == a) && (p.pts[p.pts.Count - 1] == b)) flag = true;
                if (flag == true) return true;
                else return false;
            }
            else return true;
            
        }
        static double Distance(Point a, Point b)
        {
            // расстояние между двумя точками
            return Math.Sqrt(Math.Pow((b.X - a.X), 2) + Math.Pow((b.Y - a.Y),2) );
        }
        static bool Intercept(Point a, Point b)
        {
            double A1= a.Y - b.Y; 
            double B1 = b.X - a.X;
            double C1 = A1 * a.X + B1 * a.Y; // создаем уравнение прямой
            foreach (Polygon pg in pols)
            {
                if (!CheckIfNear(pg, a, b)) return true;
                for (int i = 0; i < pg.pts.Count - 1; i++)
                {
                    double A2 = pg.pts[i].Y - pg.pts[i+1].Y;
                    double B2 = pg.pts[i+1].X - pg.pts[i].X;
                    double C2 = A2 * pg.pts[i].X + B2 * pg.pts[i].Y; // уравнение прямой - грани полигона
                    double det = A1 * B2 - A2 * B1;
                    if (det == 0) return false; // проверка на коллинеарность
                    else
                    {
                        double x = (B2 * C1 - B1 * C2) / det; // находим коорд. пересечения
                        double y = (A1 * C2 - A2 * C1) / det;

                        // проверяем принадлежит ли найденная точка обоим ОТРЕЗКАМ
                        if (Math.Min(a.X, b.X) < x && x < Math.Max(a.X, b.X))
                        {
                            if (Math.Min(a.Y, b.Y) < y && y < Math.Max(a.Y, b.Y))
                            {
                                if( Math.Min(pg.pts[i].X, pg.pts[i+1].X) < x && x < Math.Max(pg.pts[i].X, pg.pts[i + 1].X) )
                                    if (Math.Min(pg.pts[i].Y, pg.pts[i + 1].Y) < y && y < Math.Max(pg.pts[i].Y, pg.pts[i + 1].Y))
                                        return true;
                            }

                        }
                    }

                }

                // аналогично проверяем прямую [перв. точка полигона; посл. точкаполигона]
                if (pg.pts.Count > 2)
                {
                    double A2 = pg.pts[pg.pts.Count - 1].Y - pg.pts[0].Y;
                    double B2 = pg.pts[0].X - pg.pts[pg.pts.Count - 1].X;
                    double C2 = A2 * pg.pts[pg.pts.Count - 1].X + B2 * pg.pts[pg.pts.Count - 1].Y;
                    double det = A1 * B2 - A2 * B1;
                    if (det == 0) return false;
                    else
                    {
                        double x = (B2 * C1 - B1 * C2) / det;
                        double y = (A1 * C2 - A2 * C1) / det;
                        if (Math.Min(a.X, b.X) < x && x < Math.Max(a.X, b.X))
                        {
                            if (Math.Min(a.Y, b.Y) < y && y < Math.Max(a.Y, b.Y))
                                if (Math.Min(pg.pts[0].X, pg.pts[pg.pts.Count - 1].X) < x && x < Math.Max(pg.pts[0].X, pg.pts[pg.pts.Count - 1].X))
                                    if (Math.Min(pg.pts[0].Y, pg.pts[pg.pts.Count - 1].Y) < y && y < Math.Max(pg.pts[0].Y, pg.pts[pg.pts.Count - 1].Y))
                                        return true;
                        }
                    }
                }
            }
            return false;
        }
        static void DrawEdges()
        {
            // прорисовываем все возможные грани между точками ВО ВРЕМЯ РИСОВАНИЯ
            for (int i = 0; i < pts.Count - 1; i++)
            {
                g.DrawLine(Pens.Black, pts[i], pts[i + 1]);
            }

            if(newPolFlag == false)
            for (int i = 0; i<pols.Count; i++)
            {
                for (int j = 0; j < pols[i].pts.Count-1; j++)
                {
                    g.DrawLine(new Pen(Color.Black,4), pols[i].pts[j], pols[i].pts[j + 1]);
                }
                g.DrawLine(new Pen(Color.Black, 4), pols[i].pts[pols[i].pts.Count-1], pols[i].pts[0]);
            }

        }
        static void Redraw()
        {
            g.Clear(SystemColors.Window); // очищаем экран
            DrawEdges(); // прорисовка граней полигонов  во время рисования
            DrawPolys(); // прорисовка полигонов
            DrawPolCont(); // прорисовка контуров полигонов
            if(newPolFlag==false) VisibilityGraph(); // рисуем граф видимости
            DrawDots(); // прорисовка точек
        }
        static void Clear()
        {
            // очищаем экран и массивы
            pts.Clear(); 
            pts_all.Clear();
            g.Clear(SystemColors.Window);
            pols.Clear();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // при движении мыши сохраняем информацию о положении
            ms = e;
            if (newPolFlag == true && pts.Count != 0)
            {
                // если мы в режиме добавления нов. полигона, то постоянно перерисовываем
                // потенциальную новую грань полигона для лучшего восприятия
                Redraw();
                g.DrawLine(Pens.Blue, pts[pts.Count-1], new Point(ms.X, ms.Y));
            }
            
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // обработка нажатий кнопок переключения режимов

            if (e.KeyChar == (char)Keys.Escape)
            {
                newPolFlag = false;
                lb_pol.ForeColor = Color.DarkRed;
                pols.Add(new Polygon(pts));
                pts.Clear();
                Redraw();
            }
            if(e.KeyChar.ToString().ToLower() == Keys.N.ToString().ToLower())
            {
                newPolFlag = true;
                lb_pol.ForeColor = Color.DarkGreen;
            }
            if (e.KeyChar.ToString().ToLower() == Keys.C.ToString().ToLower())
            {
                Clear();
            }
            if(e.KeyChar.ToString().ToLower() == Keys.D.ToString().ToLower())
            {
                if (pols.Count > 1)
                {
                    Deikstra();
                    DrawDots();
                }
            }
            if (e.KeyChar.ToString().ToLower() == Keys.S.ToString().ToLower())
            {
                newStPtFl = true;
                lb_st.ForeColor = Color.DarkGreen;
            }
            if (e.KeyChar.ToString().ToLower() == Keys.F.ToString().ToLower())
            {
                newDistPtFl = true;
                lb_fin.ForeColor = Color.DarkGreen;
            }

        }
        static void DrawPolys()
        {
            foreach (Polygon pl in pols)
            {   // перерисовка полигонов
                g.FillPolygon(Brushes.SlateGray, pl.GetPts());
            }
        }
        static void DrawDots()
        {
            foreach (Point pnt in pts_all)
            {
                // перерисовка всех точек
                g.FillEllipse(Brushes.Red, new Rectangle(pnt.X - 3, pnt.Y - 3, 5, 5));
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // обработка события "нажатие левой кнопки мыши", в зависимости от режима
            if (newPolFlag == true)
            {
                pts.Add(new Point(ms.X, ms.Y));
                pts_all.Add(new Point(ms.X, ms.Y));
                DrawEdges();
            }
            if (newStPtFl == true)
            {
                pts.Add(new Point(ms.X, ms.Y));
                pts_all.Insert(0, new Point(ms.X, ms.Y));
                pols.Insert(0, new Polygon(pts));
                pts.Clear();
                newStPtFl = false;
                lb_st.ForeColor = Color.DarkRed;
            }
            if (newDistPtFl == true)
            {
                pts.Add(new Point(ms.X, ms.Y));
                pts_all.Add(new Point(ms.X, ms.Y));
                pols.Add(new Polygon(pts));
                pts.Clear();
                newDistPtFl = false;
                lb_fin.ForeColor = Color.DarkRed;
            }
            Redraw();
        }

    }

    class Polygon
    {
        public List<Point> pts; // массив точек полигона
        public Polygon()
        {
            pts = new List<Point>();
        }

        public Polygon(List<Point> newPts)
        {
            pts = new List<Point>(newPts.Count);
            pts.AddRange(newPts);
        }

        public void AddPt(Point pt)
        {
            this.pts.Add(pt);
        }

        public Point[] GetPts()
        {
            // возвращаем МАССИВ с точками полигона
            Point[] pts_temp = new Point[pts.Count];
            pts.CopyTo(pts_temp);
            return pts_temp;
        }
          
    }

}

