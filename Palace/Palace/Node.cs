using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palace
{


   
   public class Node
    {
        public Palace p
        {
            get;
            private set;
        }

        public int HASH
        {
            get
            {
                return p.HASH;
            }
            
        }

        public int DestHash
        {
            get
            {
                return Palace.DestHash;
            }           
        }

        public Node (Palace pp, Action pact)
        {
            this.p = pp.Swap(pact);                    
            act = pact;
            Children = new List<Node>();        
        }

        public bool IsDest()
        {
            if (HASH == DestHash) return true;
            return false; 
        }


        public Node Parent
        {
            get;
            private set;
        }


        public List<Node> Children
        {
            get;
            private set;
        }

        /// <summary>
        /// 当前节点是如何从父节点到达此处的。
        /// </summary>
        public Action act
        {
            get;
            private set;
        }


        public void Expand(LinkedList <Node >Open,HashSet <Node >Open2,HashSet <Node>Close)
        {
            Cell nullCell = this.p.NullCell;
            if( nullCell.upNei != null)
            {
                Node newNode = new Node(this.p ,new Action (nullCell,nullCell.upNei ));
                this.Conduct(newNode, Open, Open2, Close);
            }
            if (nullCell.downNei != null)
            {
                Node newNode = new Node(this.p, new Action(nullCell, nullCell.downNei));
                this.Conduct(newNode, Open, Open2, Close);
            }
            if (nullCell.leftNei != null)
            {
                Node newNode = new Node(this.p, new Action(nullCell, nullCell.leftNei));
                this.Conduct(newNode, Open, Open2, Close);
            }
            if (nullCell.rightNei != null)
            {
                Node newNode = new Node(this.p, new Action(nullCell, nullCell.rightNei));
                this.Conduct(newNode, Open, Open2, Close);
            }


        }


        /// <summary>
        /// 已经选择了某节点next后，将其在数据结构中进行安置。
        /// Open 必须为双向链表。
        /// Open2 是为了定位效率。
        /// </summary>
        /// <param name="next"></param>
        /// <param name="Open"></param>
        /// <param name="Open2"></param>
        /// <param name="Close"></param>
        public void Conduct(Node next, LinkedList<Node> Open, HashSet<Node> Open2, HashSet<Node> Close)
        {
            if (!Open2.Contains(next) && !Close.Contains(next))
            {
                Open.AddLast(next);
                Open2.Add(next); 
                this.Children.Add(next);
                next.Parent = this;
            }
        }


        public override string ToString()
        {
            return this.p.ToString();
        }


        public override int GetHashCode()
        {
            return this.HASH;
        }

        public override bool Equals(object obj)
        {
            Node n = (Node)obj;
            if (this.GetHashCode() == n.GetHashCode()) return true;
            return false;
        }



    }
}
