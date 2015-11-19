using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace GO5
{
   public  class RandomEngine : Engine 
    {
       public override Point GetBestPoint(Board b)
       {
           Thread.Sleep(1000);
           while(b.reds .Count +b.blacks.Count <b.size *b.size )
           {
                 Random r = new Random(DateTime.Now.Millisecond);
                 int x = r.Next(b.size );
                 int y = r.Next(b.size );
                 Point p = b[x, y]; 
                 if (p.color == Color.nul)
                 return p;
           }
           return null;         

       }

       public override string ToString()
       {
           return "随机引擎";
       }
    }
}
