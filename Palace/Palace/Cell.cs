using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Palace
{

    public enum Direction
    {
        up, down, left, right
    }


    public  class Cell
    {

        //int number;
        //public int Number
        //{
        //    get
        //    {
        //        return number;
        //    }
        //    set
        //    {
        //        number = value;
        //        this.DrawNumber();
        //    }

        //}
       

        /// <summary>
        /// 在宫殿中的坐标，最小值为0，最大为9.  原点在左上角。
        /// </summary>
        public int x
        {
            get;
            private set;
        }
        /// <summary>
        /// 最小值为0.
        /// </summary>
        public int y
        {
            get;
            private set;
        }

        /// <summary>
        /// 初始的随机hash值。
        /// </summary>
        public int InitHash
        {
            get;
            set;
        }
        Graphics g;

        /// <summary>
        /// 四个邻居
        /// </summary>
        public Cell upNei
        {
            get;
            private set;
        }
        public Cell downNei
        {
            get;
            private set;
        }
        public Cell leftNei
        {
            get;
            private set;
        }
        public Cell rightNei
        {
            get;
            private set;
        }

        /// <summary>
        /// 反指向宫殿，借此可以访问其他格子。
        /// </summary>
        //Palace p;
        public Cell(int px, int py, Graphics pg)
        {
            x = px;
            y = py;
            g = pg;
          
        }

        /// <summary>
        /// 初始化邻居
        /// </summary>
        public void setNeighbours()
        {
            if (this.y > 0)
                this.upNei = Palace.Cells[this.x, this.y - 1];
            if (this.x > 0)
                this.leftNei = Palace.Cells[this.x - 1, this.y];
            if (this.y < this.Scale - 1)
                this.downNei = Palace.Cells[this.x, this.y + 1];
            if (this.x < this.Scale - 1)
                this.rightNei = Palace.Cells[this.x + 1, this.y];
        }

        /// <summary>
        /// 迷宫的规模。
        /// </summary>
        int Scale
        {
            get
            {
                return Palace.scale;
            }
        }

        Pen blackPen
        {
            get
            { return Palace.blackPen; }
        }

        Pen whitePen
        {
            get
            { return Palace .whitePen; }
        }

        Brush blackBrush
        {
            get
            {
                return Palace.blackBrush;
            }
        }

        Brush whiteBrush
        {
            get
            {
                return Palace.whiteBrush;
            }
        }

        Brush blueBrush
        {
            get
            {
                return Palace.blueBrush;
            }
        }

        Brush greenBrush
        {
            get
            { return Palace.greenBrush; }
        }

        /// <summary>
        /// 重绘该格子。注意墙的状态。
        /// </summary>
        public void Redraw()
        {
            this.Draw(blackPen, Direction.up);
            this.Draw(blackPen, Direction.down);
            this.Draw(blackPen, Direction.left);
            this.Draw(blackPen, Direction.right);         
        }


        /// <summary>
        /// 屏幕上抹掉该格子。
        /// </summary>
        public void UnDraw()
        {
            this.Draw(whitePen, Direction.up);
            this.Draw(whitePen, Direction.down);
            this.Draw(whitePen, Direction.left);
            this.Draw(whitePen, Direction.right);
            this.UnDrawNumber();       
        }


        /// <summary>
        /// 画墙
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="dir"></param>
        void Draw(Pen pen, Direction dir)
        {
            switch (dir)
            {
                case Direction.up:
                    g.DrawLine(pen, LEFT, UP, RIGHT, UP);
                    break;
                case Direction.down:
                    g.DrawLine(pen, LEFT, DOWN, RIGHT, DOWN);
                    break;
                case Direction.left:
                    g.DrawLine(pen, LEFT, UP, LEFT, DOWN);
                    break;
                case Direction.right:
                    g.DrawLine(pen, RIGHT, UP, RIGHT, DOWN);
                    break;
            }
        }

        /// <summary>
        /// 屏幕坐标。
        /// </summary>
        int UP
        {
            get { return margin + y * length; }
        }
        int DOWN
        {
            get
            { return margin + (y + 1) * length; }
        }
        int LEFT
        {
            get
            { return margin + x * length; }
        }
        int RIGHT
        {
            get
            { return margin + (x + 1) * length; }
        }

        int margin
        {
            get { return Palace.margin; }
        }
        int length
        {
            get { return Palace.lenth; }
        }

        int CenterX
        {
            get
            {
                return (LEFT + RIGHT) / 2;
            }
        }
        int CenterY
        {
            get
            { return (UP + DOWN) / 2; }
        }
        /// <summary>
        /// 画数字
        /// </summary>
      public  void DrawNumber(Palace p)
        {
            this.UnDrawNumber();
            int fontSize = 200 / this.Scale;
            Font f=new Font("Arial", fontSize);
            int num = p.Numbers[this.x, this.y];
            string s = num.ToString();          
            if (num < 10) s = "0" + s;
            if (num == 0) s = "";
            this.g.DrawString(s, f, blackBrush, this.LEFT, this.UP);
        }

        /// <summary>
        ///  抹去数字
        /// </summary>
       public void UnDrawNumber()
        {            
            this.g.FillRectangle(whiteBrush, this.LEFT + 1, this.UP + 1, length - 1, length - 1);           
        }


        //public override bool Equals(object obj)
        //{
        //    Cell c = (Cell)obj;
        //    if (this.Number == c.Number) return true;
        //    else
        //        return false;
        //  //  return base.Equals(obj);
        //}


        //public override int GetHashCode()
        //{

        //    int hash = 10 * this.x + y;
        //    hash *= 100;
        //    hash += Number;
        //    return hash;
        //}

        public override string ToString()
        {
            string s = "x=";
            s += this.x.ToString() + "  y=";
            s += this.y.ToString();
            return s;
            //return base.ToString();
        }

    }
}
