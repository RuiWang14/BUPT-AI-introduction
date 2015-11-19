using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO5
{

   public  class Group
    {
        /// <summary>
        /// 几个同颜色的棋子连在一起，形成一个组。
        /// </summary>
        /// <param name="p"></param>
       public Group(Point p) 
       { 
           points = new HashSet<Point>();
           points.Add(p);
       }
       public HashSet<Point> points
       {
           get;
           private set;
       }
       public int count
       {
           get
           {
               return points.Count;
           }
       }

        /// <summary>
        /// 好像有问题？
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
       public override bool Equals(object obj)
       {
           Group other = (Group)obj;
           foreach (Point p in this.points)
           {
               if (!other.points.Contains(p))
                   return false;
           }
           return true;
           
       }

       public override int GetHashCode()
       {
           int hash = 0;
           foreach (Point p in this.points )
           {
               hash ^= p.GetHashCode();
           }
           return hash;
       }

        /// <summary>
        /// 对该组的评估。 此函数很关键。未必合理。
        /// </summary>
       public int Evaluate
       {
           get
           {
               if (this.count == 4) return Constant.win;
               if (this.count == 3) return 100;
                return 10;
           }
       }

    }
}
