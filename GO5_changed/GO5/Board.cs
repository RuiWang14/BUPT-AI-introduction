using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GO5
{
    /// <summary>
    /// 五子棋盘
    /// </summary>
    public class Board
    {

        /// <summary>
        /// 一般15*15
        /// </summary>
        public int size
        {
            get;
            private set;

        }

        /// <summary>
        /// 所有的点。
        /// </summary>
        Point[,] points;

        /// <summary>
        /// 当前该谁下。
        /// </summary>
        public Color turn
        {
            get;
            private set;
        }
        public Graphics g
        {
            get;
            private set;
        }

        public Pen pen
        {
            get;
            private set;
        }
        public Pen whitePen
        {
            get;
            private set;

        }
        public SolidBrush blackBrush
        {
            get;
            private set;
        }
        public SolidBrush redBrush
        {
            get;
            private set;
        }
        public SolidBrush whiteBrush
        {
            get;
            private set;
        }
        public int cellLength
        {
            get;
            private set;
        }
        public int margine
        {
            get;
            private set;
        }

        /// <summary>
        /// 所有的黑子。
        /// </summary>
        public HashSet<Point> blacks
        {
            get;
            private set;
        }

        /// <summary>
        /// 所有的红子。
        /// </summary>
        public HashSet<Point> reds
        {
            get;
            private set;
        }

        /// <summary>
        /// 初始化棋盘。所有的点均已经生成。但无颜色。即没下下去。
        /// 黑子集合和红子集合均为空。
        /// </summary>
        /// <param name="psize"></param>
        /// <param name="pg"></param>
        /// <param name="pmargin"></param>
        /// <param name="pcellLength"></param>
        public Board (int psize,Graphics pg,int pmargin,int pcellLength)
        {
            size = psize;
            g = pg;
            pen = new Pen(System.Drawing.Color.Black);
            whitePen = new Pen(System.Drawing.Color.White);
            redBrush = new SolidBrush(System.Drawing.Color.Red);
            blackBrush = new SolidBrush(System.Drawing.Color.Black);
            whiteBrush = new SolidBrush(System.Drawing.Color.White);
            margine = pmargin;
            cellLength = pcellLength;
            points = new Point[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    this[i, j] = new Point(this,i, j);
                }
            blacks = new HashSet<Point>();
            reds = new HashSet<Point>();
            turn = Color.red;

        }

        /// <summary>
        /// 索引。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
       public Point this[int x, int y]
        {
            get
            {
                return points[x, y];
            }
            set
            {
                points[x, y] = value;
            }
        }

        /// <summary>
        /// 该下一个下子。
        /// </summary>
       public  void ChangeTurn()
        {
            if (turn == Color.red)
                turn = Color.black;
            else if (turn == Color.black)
                turn = Color.red;
        }

        public  void Draw()
        {
            for (int i = 0; i < size; i++)
            {
                g.DrawLine(pen, X(this[0, i]), Y(this[0, i]), X(this[size - 1, i]), Y(this[size - 1, i]));
                g.DrawLine(pen, X(this[i, 0]), Y(this[i, 0]), X(this[i, size - 1]), Y(this[i, size - 1]));
            }
            DrawCircle(this[3, 3]);
            DrawCircle(this[3, 11]);
            DrawCircle(this[11, 3]);
            DrawCircle(this[11, 11]);
            DrawCircle(this[7, 7]);
        }

        void DrawCircle(Point p)
        {
            g.DrawEllipse(pen, X(p) - (float)(0.125) * cellLength, Y(p) - (float)(0.125) * cellLength,
                (float)(0.25) * cellLength, (float)(0.25) * cellLength);
        }

        /// <summary>
        /// 从屏幕位置找到最近的点。
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <returns></returns>
        public  Point getPoint(int sx, int sy)
        {
            int inix = sx;
            int iniy = sy;
            sx -= margine;
            sy -= margine;
            int x = (int)((sx * 1.0 / cellLength) + 0.5);
            int y = (int)((sy * 1.0 / cellLength) + 0.5);
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x > size - 1) x = size - 1;
            if (y > size - 1) y = size - 1;
            Point p = this[x, y];
            return p;
        }

        /// <summary>
        /// 从点返回其屏幕X坐标。
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        int X(Point p)
        {
            return (margine + p.x * cellLength);
        }

        /// <summary>
        ///从点返回其屏幕Y坐标。 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        int Y(Point p)
        {
            return (margine + p.y * cellLength);
        }

     
        /// <summary>
        /// 当前局面的估值函数，对当前turn而言。
        /// </summary>
        public double Evaluate            
        {
            get
            {
                HashSet<Group> redGroups = this.GetRedLives();
                HashSet<Group> blackGroups = this.GetBlackLives();
                int red = 0;
                foreach (Group g in redGroups)
                {
                    red += g.Evaluate;
                }
                int black = 0;
                foreach (Group g in blackGroups)
                {
                    black += g.Evaluate;
                }
                if (this.turn == Color.red)
                    return red - black;
                else
                    return black - red;
            }

        }


       // double Evaluate(HashSet<>)

        HashSet <Group> GetRedLives()
        {
            HashSet<Group> groups = new HashSet<Group>();
            foreach (Point p in reds)
            {
                HashSet<Group> lives = p.GetLives();
                foreach (Group group in lives)
                    if (!groups.Contains(group))
                        groups.Add(group);
            }
            return groups;
        }

        HashSet<Group> GetBlackLives()
        {
            HashSet<Group> groups = new HashSet<Group>();
            foreach (Point p in blacks)
            {
                HashSet<Group> lives = p.GetLives();
                foreach (Group group in lives)
                    if (!groups.Contains(group))
                        groups.Add(group);
            }
            return groups;
        }


       

        //public int isLive(Point p)
        //{
        //    if ()
        //    if (p.board[p.x - 1, p.y-1].color == Color.nul)

                 
        //}

    }
}
