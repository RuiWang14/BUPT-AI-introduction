using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Palace
{
   public class Action
    {

        public Cell LH
        {
            get;
            private set;
        }

        public Cell RH
        {
            get;
            private set;
        }

        public Action(Cell lh,Cell rh)
        {
            LH = lh;
            RH = rh;
        }          
    }
}
