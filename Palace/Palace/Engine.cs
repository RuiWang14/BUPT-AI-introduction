using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palace
{
   public class Engine
    {
        public Palace p
        {
            get;
            private set;
        }
        public Engine(Palace pp)
        {
            p = pp;
        }

        /// <summary>
        /// 求解
        /// </summary>
        /// <returns></returns>
        public Path Resolve()
        {
            Path path = new Path();
            Node start = new Node(p,null);
            LinkedList<Node> Open = new LinkedList<Node>();
            HashSet<Node> Open2 = new HashSet<Node>();
            HashSet<Node> Close = new HashSet<Node>();
            Open.AddFirst(start);  // 起始点。
            Open2.Add(start);
            bool flag = false;
            Node curr = null;
            while (Open.Count > 0)
            {
                curr = Open.First();  // 取出第一个。
                Open.RemoveFirst();
                Open2.Remove(curr);
                Close.Add(curr);     // 放入闭集合，后面会做重复性检查。
                if(curr.IsDest ())
                {
                    flag = true;
                    break;
                }
                curr.Expand(Open, Open2, Close); 
                //展开此节点：其所有的不在Open和Close的子节点，加入到队列尾部。               
            }
            if (flag)
            {
                while (curr.Parent != null)//记录下所有的结果。
                {
                    path.acts.AddFirst (curr.act);                   
                    curr = curr.Parent;
                }
                return path;          
            }
            return null;           
            
        }
    }
}
