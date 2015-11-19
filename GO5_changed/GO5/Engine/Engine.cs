using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO5
{


    public delegate void SetEngine(Engine red,Engine black);

   public abstract class Engine
    {
       public abstract Point GetBestPoint(Board b);
     
    }
}
