using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GO5
{
    public partial class SetupEngine : Form
    {
        public SetupEngine()
        {
            InitializeComponent();
        }

        public event SetEngine evt;
        private void OKbutton1_Click(object sender, EventArgs e)
        {
            Engine red = null;
            Engine black = null;
            if (this.RedHumanradioButton1.Checked)
                red = new HumanEngine();
            if (this.RedRandomradioButton1.Checked)
                red = new RandomEngine();
            if (this.RedABradioButton1.Checked)
                red = new ABEngine();
            if (this.BlackHumanradioButton3.Checked)
                black = new HumanEngine();
            if (this.BlackRandomradioButton2.Checked)
                black = new RandomEngine();
            if (this.BlackABradioButton1.Checked)
                black = new ABEngine();
            evt(red, black);
            this.Close();           
        }

        private void Cancelbutton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
