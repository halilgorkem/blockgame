using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blockgame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static int metin;
        int ilk = 1;
        TextBox txt = new TextBox();
        Label lbl = new Label();
        Panel pnl = new Panel();
        private void Form2_Load(object sender, EventArgs e)
        {
            if (ilk == 1)
            {
                this.Controls.Add(pnl);
                pnl.Dock = DockStyle.Fill;
 
                //metin = int.Parse(txt.Text);
                pnl.Controls.Add(txt);
                txt.Top = 78;
                txt.Left = 150;
                txt.Text = Form1.zaman_degiskeni.ToString();

                ilk = 0;
                pnl.Controls.Add(lbl);
                lbl.Text = "Topların hareket hızı";
                lbl.Top = 80;
                lbl.Left = 30;
                lbl.Width = 150;
            }
        }
    }
}
