using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Palace
{
    public partial class Form1 : Form
    {
        Palace p;
        int scale;
        int MaxScale;
        int margin;
        int width;
        int height;
        Graphics g;
        Cell c1;
        Cell c2;
        Thread th;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            MaxScale = 10;
            scale =3;
            margin = 50;
            width = this.Width;
            height = this.Height;
            g = CreateGraphics();
            Palace.InitStaticPalace(scale, g, margin, width, height);
            p = Palace.GenerateTheDestinationPalace();
            th = new Thread(new ThreadStart(ThreadFun));

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (p != null) p.Undraw();
            Palace.InitStaticPalace(scale, g, margin, width, height);            
            p = Palace.GenerateTheDestinationPalace();
            p.ReDraw();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = this.toolStripTextBox1.Text.Trim();
            int newscale = 0;
            try
            {
                newscale = System.Convert.ToInt32(str);
                if (newscale > MaxScale) return;
                scale = newscale;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + " please input a valid scale!");
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            p.ReDraw();
        }

        private void 生成九宫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p=Palace.GeneratePalaceByRandom();
            p.ReDraw();         
        }  

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           Cell c= p.CheckMouse(e.X, e.Y);
            if (c == null) return;           
            c1 = c;
            this.Cursor = Cursors.Hand;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow; 
            if (c1 == null)
                return;
            Cell c = p.CheckMouse(e.X, e.Y);
            if (c == null)
            {               
                c1 = null;
                return;
            }         
            c2 = c;
            p.Swap(new Action(c1, c2), true);          
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            p=Palace.GenerateTheDestinationPalace();
            p.ReDraw();
        }      
        private void 广度优先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            th = new Thread(new ThreadStart(ThreadFun));
            th.Start();
            this.Cursor = Cursors.Arrow;             
        }

        void ThreadFun()
        {
            Engine eng = new Engine(p);
            Path path=eng.Resolve();
            if (path == null) MessageBox.Show("无解");
            else
            {
                MessageBox.Show("需要 " + path.acts.Count.ToString() + "步");
                path.play(p);
            }

        }

        private void 终止计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (th != null)
            {

                th.Abort();
                th.Join();
                MessageBox.Show("计算已经被终止");
            }
        }
    }
}
