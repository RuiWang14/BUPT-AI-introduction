using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO5
{
    public static class Constant
    {
        public static int lose = -10000;
        public static int win = 10000;
    }
   public  class ABEngine:Engine 
    {
      // static readonly double  lose =-10000;
      // static readonly double win = 10000;
       public override Point GetBestPoint(Board b)
       {
           DateTime start = DateTime.Now;
           int d=0;
           Point point = null;
           while(TimeLeft (start,30)) // 30秒。
           {              
               AB(b, d, Constant .lose , Constant.win, out point);
               d++;
           }
           return point;
       }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
       bool TimeLeft(DateTime start,int seconds)
       {
           DateTime now = DateTime.Now;
           TimeSpan  gap = now - start;
           if (gap.Seconds < seconds)
               return true;
           return false;
       }

       double  AB(Board board, int d,double a,double b,out Point point)
       {          
           List<Point> list = SortPossiblePoint(GetPossiblePoint(board));
           if(d ==0)
           {
               point=list[0];
               return point.Evaluate;
           }
           point = list[0];
           foreach (Point p in list)
           {
               p.PurePlay();
               Point bestPoint;
               double v = -1 * AB(board, d - 1, -1 * b, -1 * a, out bestPoint);
               p.UnPurePlay();
               if(v>a)
               {
                   a = v;
                   point = p;
               }
                if (v >= b)
                    return b; //break;
               }
           return a;
       }

        double FAB(Board board, int d, double a, double b, out Point point)
        {
            double current = Constant.lose;
            List<Point> list = SortPossiblePoint(GetPossiblePoint(board));
            if (d == 0)
            {
                point = list[0];
                return point.Evaluate;
            }
            point = list[0];
            foreach (Point p in list)
            {
                p.PurePlay();
                Point bestPoint;
                double v = -1 * FAB(board, d - 1, -1 * b, -1 * a, out bestPoint);
                p.UnPurePlay();
                if (v > current)
                {
                    current = v;
                    if (v > a)
                    {
                        a = v;
                        point = p;
                    }
                    if (v >= b)
                        break;
                }               
            }
            return current;
        }


        /// <summary>
        ///  在当前局面下寻找可行点。
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
       public HashSet<Point> GetPossiblePoint(Board b)
       {
           return null;
       }

        /// <summary>
        ///  对可行点进行排序。排序的依据为每个点的评分。
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
       public List<Point> SortPossiblePoint(HashSet<Point> set)
       {
           List<Point >list=new List<Point> ();
           IEnumerable<Point> ie = set.OrderBy(p => p.Evaluate);
           foreach (Point p in ie)
               list.Add(p);
           return list;
       }    

       public override string ToString()
       {
           return "AB引擎";
       }
    }
}
