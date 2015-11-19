using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Palace
{

    /// <summary>
    /// 表示一个九宫格。
    /// </summary>
  public class Palace
    {
        static int MaxScale = 10;

        /// <summary>
        /// 正方形宫殿。边长最大10；
        /// </summary>
        public  static int scale
        {
            get;
            private set;
        }
        /// <summary>
        /// 静态的格子数组
        /// </summary>
        public  static  Cell[,] Cells
        {
            get;
            private set;
        }

        /// <summary>
        /// 实例的数据数组
        /// </summary>
        public  int[,]Numbers 
        {
            get;
            private set;
        }

        public  static Graphics g
        {
            get;
            private set;
        }

        public  static Pen blackPen
        {
            get;
            private set;
        }
        public static Pen whitePen
        {
            get;
            private set;
        }

        public static Brush blackBrush
        {
            get;
            private set;
        }

        public static Brush whiteBrush
        {
            get;
            private set;
        }

        public static Brush blueBrush
        {
            get;
            private set;
        }

        public static Brush greenBrush
        {
            get;
            private set;
        }


        /// <summary>
        /// 屏幕上的高和宽。
        /// </summary>
      static  int width, height;

        /// <summary>
        /// 格子的宽度
        /// </summary>
        public static int lenth
        {
            get;
            private set;
        }

        /// <summary>
        /// 屏幕的边沿宽度。
        /// </summary>
        public static  int margin
        {
            get;
            private set;
        }


        /// <summary>
        /// 空格子
        /// </summary>
        public Cell NullCell
        {
            get;
            private set;
        }


        public static int[] InitHash
        {
            get;
            private set;
        } 
     


        public static void InitStaticPalace(int pscale, Graphics pg, int pmargin, int pwidth, int pheight) 
        {
            Random r = new Random(20151030);
            InitHash = new int[pscale*pscale ];
            for (int i = 0; i < pscale*pscale ; i++)
                InitHash[i] = r.Next(int.MaxValue);
            g = pg;
            scale = pscale;
            blackPen = new Pen(Color.Black);
            whitePen = new Pen(Color.White);
            blackBrush = new SolidBrush(Color.Black);
            whiteBrush = new SolidBrush(Color.White);
            blueBrush = new SolidBrush(Color.Blue);
            greenBrush = new SolidBrush(Color.Green);            
            width = pwidth;
            height = pheight;
            margin = pmargin;
            lenth = Math.Min(width, height);
            lenth /= scale;
            Cells = new Cell[scale, scale];
            for (int i = 0; i < scale; i++)
            {
                for (int j = 0; j < scale; j++)
                {
                    Cells[i, j] = new Cell(i, j, g);
                    Cells[i, j].InitHash = r.Next(int.MaxValue);
                }
            }
            for (int i = 0; i < scale; i++)
            {
                for (int j = 0; j < scale; j++)
                    Cells[i, j].setNeighbours();
            }          
        }

        public void Undraw()
        {
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                    Cells[i, j].UnDraw();
        }

        public void ReDraw()
        {
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                    Cells[i, j].Redraw();
            DrawNumber();
        }


        public void DrawNumber()
        {
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                    Cells[i, j].DrawNumber(this);
                    
        }



        public Palace()
        {
            Numbers = new int[scale, scale];
        }

        public Palace(Palace p)
        {
            Numbers = new int[scale, scale];
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                    Numbers[i, j] = p.Numbers[i, j];
            this.HASH = p.HASH;
            this.NullCell = p.NullCell;
        }



        public static  Palace  GeneratePalaceByRandom()
        {
            Palace p = new Palace();
            HashSet<int> set = new HashSet<int>();
            int M = scale * scale;           
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                {
                    int n = r.Next(M );
                    while (set.Contains(n))
                        n = r.Next(M );
                    p.Numbers [i, j] = n;
                    if (n == 0) p.NullCell = Cells[i, j];
                    set.Add(n);
                }
            p.HASH = p.GetHashCode();
            return p;
        }

       public static  int DestHash
        {
            get;
            private set;
        }      
     

        public static Palace GenerateTheDestinationPalace()
        {
            Palace p = new Palace();
            int n = 1;
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                {
                    if (n != scale * scale)
                    { p.Numbers[j, i] = n; }
                    n++;                   
                }
            p.NullCell = Cells[scale-1, scale-1];
            DestHash = p.GetHashCode();
            p.HASH = DestHash;
            return p;
        }

       

        /// <summary>
        /// 根据当前鼠标位置，找到最近的格子。
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public Cell CheckMouse(int X, int Y)
        {
            int x = (X - margin) / lenth;
            int y = (Y - margin) / lenth;
            if (x > scale - 1) return null;
            if (y > scale - 1) return null;

            return Cells[(X - margin) / lenth, (Y - margin) / lenth];
        }

        public int this[int i,int j]
        {
            get
            {
                return Numbers[i, j];
            }
        }

        //int hash;
        public int HASH
        {
            get;
            private set;
        }


        public override bool Equals(object obj)
        {
            Palace p = (Palace)obj;
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                {
                    if (this[i, j].Equals(p[i, j]) == false)
                        return false;
                }
            return true;           
        }

        public override int GetHashCode()
        {
            int hash = 0;   
            for (int i = 0; i < scale; i++)
                for (int j = 0; j < scale; j++)
                {
                    int num = GetHash4ACell(i, j);
                    hash ^= num;
                }
            return hash;
        }

        int GetHash4ACell(int i,int j)
        {
            int num = 10 * i + j;
            num *= 100;
            num += InitHash [ Numbers[i, j]];
            num += Cells[i, j].InitHash;
            return num;
        }


        int GetHash4ACell(Cell c)
        {
          return   GetHash4ACell(c.x, c.y);
        }




        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < scale; i++)
            {
                //s += Environment.NewLine;
                s += " #:  ";
                for (int j = 0; j < scale; j++)
                    s += this[j,i].ToString() + " , ";
            }
            return s;           
        }

        /// <summary>
        /// 交换两个格子的数字，play 为真，则操作有延时。
        /// </summary>
        /// <param name="play"></param>
        public void Swap(Action act, bool play)
        {
            if (act == null) return;
            Cell LH = act.RH;
            Cell RH = act.LH;
            int n1 = Numbers[LH.x, LH.y];
            int n2 = Numbers[RH.x, RH.y];           
            int h= GetHash4ACell(LH);
            HASH ^= h;          
            h= GetHash4ACell(RH);
            HASH ^= h; 
            Numbers[LH.x, LH.y] = n2;
            Numbers[RH.x, RH.y] = n1;
            if (n2 == 0) this.NullCell = LH;
            if (n1 == 0) this.NullCell = RH;           
            h = GetHash4ACell(LH);
            HASH ^= h;
            h = GetHash4ACell(RH);
            HASH ^= h;
            if (play)
            {
                Thread.Sleep(800);
                LH.DrawNumber(this);
                Thread.Sleep(800);
                RH.DrawNumber(this);
            }
        }

        /// <summary>
        /// 经过交换后，产生另一个节点。
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        public Palace Swap(Action act)
        {
            Palace p = new Palace(this);
            p.Swap(act,false );
            return p;
        }
    }
}
