using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO5
{
   public  class HumanEngine:Engine 
    {
       public override Point GetBestPoint(Board b)
       {
           throw new NotImplementedException();
       }

       public override string ToString()
       {
           return "人类引擎";
       }
    }
}
