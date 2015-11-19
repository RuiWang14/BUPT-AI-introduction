using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GO5
{
    public enum Color
    {
        nul,black,red
    }
    /// <summary>
    /// 既表明棋盘上的一个位置，也表明一个子。
    /// </summary>
   public class Point
    {
        /// <summary>
        /// 反指向棋盘。
        /// </summary>
        public Board board
        {
            get;
            private set;
        }

        public int size
        {
            get
            {
                return board.size;
            }
        }
        /// <summary>
        /// 逻辑坐标。 0~size-1
        /// </summary>
        public int x
        {
            get;
            private set;
               
        }
        /// <summary>
        /// 逻辑y坐标。
        /// </summary>
        public int y
        {
            get;
            private set;
        }
        
        public Point(Board b,int px,int py)
        {
            board = b;
            x = px;
            y = py;
            color = Color.nul;
        }
        /// <summary>
        /// 未下子时为nul，否则为红或黑。
        /// </summary>
        public Color color
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否要考虑颜色？ 是否要hash？
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Point other=(Point)obj;
            if (this.x == other.x && this.y == other.y)
                return true;
            return false;
        }

        public override string ToString()
        {
            string str = "(" + x.ToString() + "," + y.ToString() + ")";
            return str;
        }

        /// <summary>
        /// 在界面上下子。
        /// </summary>
        public  void play()
        {
            color = board.turn;
            if (color == Color.nul)
                return;
            if (color == Color.black)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(blackBrush, X- (float)0.45 * cellLength, Y - (float)0.45 * cellLength,
                     (float)0.9 * cellLength, (float)0.9 * cellLength);
                g.SmoothingMode = SmoothingMode.Default;
                board.blacks.Add(this);
            }
            if (color == Color.red)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(redBrush, X - (float)0.45 * cellLength, Y - (float)0.45 * cellLength,
                     (float)0.9 * cellLength, (float)0.9 * cellLength);
                g.SmoothingMode = SmoothingMode.Default;
                board.reds.Add(this);
            }
            board.ChangeTurn();
        }


        /// <summary>
        /// 逻辑上下子，但不在界面上画子。
        /// </summary>
       public void PurePlay()
        {
            color = board.turn;
            if (color == Color.nul)
                return;
            if (color == Color.black)
            {              
                board.blacks.Add(this);
            }
            if (color == Color.red)
            {               
                board.reds.Add(this);
            }
            board.ChangeTurn();
        }

        /// <summary>
        /// 取消逻辑下子。
        /// </summary>
       public void UnPurePlay()
        {
            color = Color.nul;
            if (color == Color.black)
            {
                board.blacks.Remove (this);
            }
            if (color == Color.red)
            {
                board.reds.Remove (this);
            }
            board.ChangeTurn();          
        }




      
        /// <summary>
        /// 该子的屏幕x坐标
        /// </summary>
        int X
        {
           get
           { 
               return (board.margine + x * board.cellLength);
           }
        }
        /// <summary>
        /// 该子的屏幕y坐标。
        /// </summary>
        int Y
        {
            get
            {
                return (board.margine + y * board.cellLength);
            }
        }
        public Graphics g
        {
            get
            {
                return board.g;
            }
        }
       public SolidBrush blackBrush
        {
            get { return board.blackBrush; }
        }

       public int cellLength
       {
           get
           { 
               return board.cellLength;
           }
       }

       public SolidBrush redBrush
       {
           get
           {
               return board.redBrush;
           }
       }

       public SolidBrush whiteBrush
       {
           get
           { 
               return board.whiteBrush;
           }
       }
       public Pen pen
       {
           get
           { return board.pen; }
       }

       public Pen whitePen
       {
           get
           {
               return board.whitePen;
           }
       }
      public  void DrawRectangle()
       {
           g.DrawRectangle(pen, X - (float)(0.5) * cellLength, Y - (float)(0.5) * cellLength,
              (float)(1) * cellLength, (float)(1) * cellLength);
       }
      public  void RemoveRectangle()
       {
           g.DrawRectangle(whitePen, X - (float)(0.5) * cellLength, Y - (float)(0.5) * cellLength,
             (float)(1) * cellLength, (float)(1) * cellLength);
       }

      public override int GetHashCode()
      {
          return base.GetHashCode();
      }


        /// <summary>
        /// 对下该子的一方的评估。
        /// </summary>
      public double Evaluate
      {
          get
          {
              this.PurePlay();
              double v = board.Evaluate; // 这是对方的评估
              this.UnPurePlay();
              return -1*v; // 己方的评估
          }

      }

    /// <summary>
    /// 西北角
    /// </summary>
       public Point NW
      {
           get
          {
              if (this.x > 0 && this.y > 0)
                  return board[x - 1, y - 1];
              return null;
          }
      }

        /// <summary>
        ///  北
        /// </summary>
       public Point N
       {
           get
           {
               if (this.y > 0)
                   return board[x , y - 1];
               return null;
           }
       }


        /// <summary>
        /// 东北
        /// </summary>
       public Point NE
       {
           get
           {
               if (this.x < size - 1 && this.y > 0)
                   return board[x + 1, y - 1];
               return null;
           }
       }

        /// <summary>
        /// 东
        /// </summary>
       public Point E
       {
           get
           {
               if (this.x < size - 1  )
                   return board[x + 1, y];
               return null;
           }
       }

        /// <summary>
        /// 东南
        /// </summary>
       public Point SE
       {
           get
           {
               if (this.x < size - 1  && this.y < size - 1)
                   return board[x + 1, y + 1];
               return null;
           }
       }

        /// <summary>
        /// 南
        /// </summary>
       public Point S
       {
           get
           {
               if (this.x < size - 1 )
                   return board[x , y + 1];
               return null;
           }
       }

        /// <summary>
        /// 西南
        /// </summary>
       public Point SW
       {
           get
           {
               if (this.x > 0 && this.y < size - 1)
                   return board[x - 1, y + 1];
               return null;
           }
       }

        /// <summary>
        /// 西
        /// </summary>
       public Point W
       {
           get
           {
               if (this.x > 0 )
                   return board[x - 1, y ];
               return null;
           }
       }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public  HashSet<Group> GetLives()
       {
           HashSet<Group> groups = new HashSet<Group>();
# region NorthWest
           Group nw = new Group(this);
           int nws=0;
           
           Point current = this;
           while (current.NW != null)
           {
               Point n = current.NW;
               if (this.color == n.color)
               {
                   nw.points.Add(n);
               }
               else
                   break;
               current = current.NW;
           }
           if((current .NW != null)&&(current .NW.color == Color .nul))
               nws++;

           current = this;
           while (current.SE != null)
           {
               Point n = current.SE;
               if (this.color == n.color)
               {
                   nw.points.Add(n);
               }
               else
                   break;
               current = current.SE;
           }
           if((current .SE != null)&&(current .SE.color == Color .nul))
               nws++;

           if(nw.count+nws>4)
               groups .Add (nw);
#endregion 
# region NorthEast
           Group ne = new Group(this);
           int nes=0;
           
           current = this;
           while (current.NE != null)
           {
               Point n = current.NE;
               if (this.color == n.color)
               {
                   ne.points.Add(n);
               }
               else
                   break;
               current = current.NE;
           }
           if((current .NE != null)&&(current .NE.color == Color .nul))
               nes++;

           current = this;
           while (current.SW != null)
           {
               Point n = current.SW;
               if (this.color == n.color)
               {
                   ne.points.Add(n);
               }
               else
                   break;
               current = current.SW;
           }
           if((current .SW != null)&&(current .SW.color == Color .nul))
               nes++;

           if(ne.count+nes>4)
               groups .Add (ne);
#endregion 
# region North
           Group north = new Group(this);
           int ns=0;
           
           current = this;
           while (current.N != null)
           {
               Point n = current.N;
               if (this.color == n.color)
               {
                   north.points.Add(n);
               }
               else
                   break;
               current = current.N;
           }
           if((current .N != null)&&(current .N.color == Color .nul))
               ns++;

           current = this;
           while (current.S != null)
           {
               Point n = current.S;
               if (this.color == n.color)
               {
                   north.points.Add(n);
               }
               else
                   break;
               current = current.S;
           }
           if((current .S != null)&&(current .S.color == Color .nul))
               ns++;

           if(north.count+ns>4)
               groups .Add (north);
#endregion 
# region East
           Group east = new Group(this);
           int es=0;
           
           current = this;
           while (current.E != null)
           {
               Point n = current.E;
               if (this.color == n.color)
               {
                   east.points.Add(n);
               }
               else
                   break;
               current = current.E;
           }
           if((current .E != null)&&(current .E.color == Color .nul))
               es++;

           current = this;
           while (current.W != null)
           {
               Point n = current.W;
               if (this.color == n.color)
               {
                   east.points.Add(n);
               }
               else
                   break;
               current = current.W;
           }
           if((current .W != null)&&(current .W.color == Color .nul))
               es++;

           if(east.count+es>4)
               groups .Add (east);
#endregion 
           return groups ;
       }
    }
}
