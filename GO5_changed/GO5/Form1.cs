using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GO5
{
    public partial class Form1 : Form
    {
        int size;       
        Graphics g;
        Board board;     
        Point last;
        Engine redEngine;
        Engine blackEngine;       
      
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.White;            
            g = this.CreateGraphics();
            size = 15;
            init();           
        }

      
        void init()
        {           
            int boardLengh = Math.Min(this.Width, this.Height);
            int margine = boardLengh / (size-2);
            margine+=20;
            int cellLength = (boardLengh - 2 * margine) / (size+1);
            board = new Board(15, g,margine,cellLength);           
        }

       
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            board.Draw();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point curr = board. getPoint(e.X, e.Y);
            if (last != null)
                last.RemoveRectangle();
            curr.DrawRectangle();
            last = curr;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Point p= board.getPoint(e.X, e.Y);
            p.play();
            this.MouseUp -= this.Form1_MouseUp;
            PrepareForEngine();
       
        }      
       

        private void 设置对弈方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupEngine form2 = new SetupEngine();

            form2.evt += new SetEngine(set);
            form2.ShowDialog();
        }
        public void set(Engine red,Engine black)
        {
            this.redEngine = red;
            this.blackEngine = black;  
            PrepareForEngine();
        }

        void PrepareForEngine()
        {   
            ShowEngineInfo();
            if (this.CurrentEngine is HumanEngine)
            {
                 
                this.MouseUp += this.Form1_MouseUp;                
                return;
            }
            else
            {
                this.MouseUp -= this.Form1_MouseUp;                  
                ThreadFun();//开辟新线程方式
                PrepareForEngine();
            }
        }

        void ShowEngineInfo()
        {
            if (board.turn == Color.red)
                this.toolStripStatusLabel1.Text = "红方：";
            else
                this.toolStripStatusLabel1.Text = "黑方：";
            this.toolStripStatusLabel0.Text = CurrentEngine.ToString();
        }


        void ThreadFun()
        {
           Point p= CurrentEngine.GetBestPoint(board);
           p.play();
        }



        public Engine CurrentEngine
        {
            get
            {
                if (board.turn == Color.red)
                    return redEngine;
                else
                    return blackEngine;
            }
        }

    }
}
