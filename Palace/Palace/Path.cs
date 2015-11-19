using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palace
{
  public  class Path
    {
        public LinkedList<Action >acts
        {
            get;
            private set;
        }
        public Path()
        {
            acts = new LinkedList<Action>();
        }
        public void play( Palace p)
        {
            foreach (Action act in acts)               
                p.Swap(act, true);
            MessageBox.Show("ok");
            
        }
    }
}
