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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int yyon = 1;
        int ilk = 1;
        int hak = 3;
        int puan = 0;
        Panel mainmenu = new Panel();
        Panel oyunalani = new Panel();
        Button ball1 = new Button();
        Button ball2 = new Button();
        Button ball3 = new Button();
        Button baslat = new Button();
        Button cikis = new Button();
        MenuStrip menuler = new MenuStrip();
        Label skor = new Label();
        Timer zaman = new Timer();
        Random rastgele = new Random();

        public void Form1_Load(object sender, EventArgs e)
        {
            if(ilk == 1)
            {
                // oyun alanı
                ball1.Click += ball1_Click;
                ball2.Click += ball2_Click;
                ball3.Click += ball3_Click;
                baslat.Click += baslat_Click;
                cikis.Click += cikis_Click;
                ilk = 0;

                //menü kodu
                oyunalani.Controls.Add(mainmenu);
                mainmenu.BackColor = Color.Gray;
                mainmenu.Height = 24;
                mainmenu.BorderStyle = BorderStyle.FixedSingle;
                mainmenu.Dock = DockStyle.Top;

                // menü yeni oyun butonu
                mainmenu.Controls.Add(baslat);
                baslat.BackColor = Color.White;
                baslat.Text = "Yeni Oyun";

                // menü ayarlar butonu

                mainmenu.Controls.Add(cikis);
                cikis.BackColor = Color.White;
                cikis.Left = 100;
                cikis.Text = "Çıkış";


                //Toplarin hizi
                zaman.Tick += zaman_Tick;
                zaman.Interval = 1;
                zaman.Enabled = true;

                this.Controls.Add(oyunalani);
                oyunalani.BorderStyle = BorderStyle.FixedSingle;
                oyunalani.Dock = DockStyle.Fill;
                oyunalani.BackColor = Color.Aquamarine;

                // birinci top
                ball1.Top = 24;
                ball1.Left = 10;
                oyunalani.Controls.Add(ball1);
                ball1.BackgroundImageLayout = ImageLayout.Stretch;
                ball1.BackgroundImage = Image.FromFile("soccer_ball.png");
                ball1.FlatStyle = FlatStyle.Flat;
                ball1.FlatAppearance.BorderColor = Color.Aquamarine;

                // ikinci top
                oyunalani.Controls.Add(ball2);
                ball2.Top = 24;
                ball2.Left = 150;
                ball2.BackgroundImageLayout = ImageLayout.Stretch;
                ball2.BackgroundImage = Image.FromFile("soccer_ball.png");
                ball2.FlatStyle = FlatStyle.Flat;
                ball2.FlatAppearance.BorderColor = Color.Aquamarine;

                // üçüncü top
                oyunalani.Controls.Add(ball3);
                ball3.Top = 24;
                ball3.Left = 280;
                ball3.BackgroundImageLayout = ImageLayout.Stretch;
                ball3.BackgroundImage = Image.FromFile("soccer_ball.png");
                ball3.FlatStyle = FlatStyle.Flat;
                ball3.FlatAppearance.BorderColor = Color.Aquamarine;

                //skor tablosu
                oyunalani.Controls.Add(skor);
                skor.BackColor = Color.Yellow;
                skor.Top = 24;
                skor.Left = 470;
                skor.Width = 130;
                skor.Text = "Skor = " + puan.ToString() + "  Can Sayısı = " + hak.ToString();

            }

        }

        //topların tıklama olayları
        public void ball1_Click(object sender, EventArgs e)
        {
            int boyuten = rastgele.Next(15, 50);
            int boyutboy = rastgele.Next(15, 50);
            puan = 1 + puan;
            ball1.Left = 10;
            ball1.Top = 24;
            ball1.Height = boyutboy;
            ball1.Width = boyuten;
            skor.Text = "Skor = " + puan.ToString() + "  Can Sayısı = " + hak.ToString();
        }
        public void ball2_Click(object sender, EventArgs e)
        {
            int boyuten = rastgele.Next(15, 50);
            int boyutboy = rastgele.Next(15, 50);
            puan = 1 + puan;
            ball2.Left = 150;
            ball2.Top = 24;
            ball2.Height = boyutboy;
            ball2.Width = boyuten;
            skor.Text = "Skor = " + puan.ToString() + "  Can Sayısı = " + hak.ToString();
        }
        public void ball3_Click(object sender, EventArgs e)
        {
            int boyuten = rastgele.Next(15, 50);
            int boyutboy = rastgele.Next(15, 50);
            puan = 1 + puan;
            ball3.Left = 280;
            ball3.Top = 24;
            ball3.Height = boyutboy;
            ball3.Width = boyuten;
            skor.Text = "Skor = " + puan.ToString() + "  Can Sayısı = " + hak.ToString();
        }

        //oyun menüsü ayarları
        
        public void baslat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oyun yeniden başlatılsın mı ?", "Yeniden Oyna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
            else Application.ExitThread();
        }

        public void cikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oyundan çıkmak istediğinize emin misiniz?", "Oyundan Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //topların aşağı düşmesi ile ilgili durumlar
        public void zaman_Tick(object sender, EventArgs e)
        {   
            ball1.Top = ball1.Top + yyon;
            if (ball1.Bottom == oyunalani.Bottom)
            {
                if (oyunalani.Left < ball1.Left + ball1.Width / 2 &&
                      oyunalani.Right > ball1.Left + ball1.Width / 2)
                {
                    hak = hak - 1;
                    skor.Text = "Skor = " + puan.ToString() + "  Can Sayısı = " + hak.ToString();
                    ball1.Left = 10;
                    ball1.Top = 24;
                    if (hak == 0)
                    {
                        zaman.Enabled = false;
                        MessageBox.Show(skor.Text, "Oyun Bitti !");
                    }
                }
                
            }

            ball2.Top = ball2.Top + yyon;
            if (ball2.Bottom == oyunalani.Bottom)
            {
                if (oyunalani.Left < ball2.Left + ball2.Width / 2 &&
                      oyunalani.Right > ball2.Left + ball2.Width / 2)
                {
                    hak = hak - 1;
                    skor.Text = "Skor = " + puan.ToString() + "  Can Sayısı = " + hak.ToString();
                    ball2.Left = 150;
                    ball2.Top = 24;
                    if (hak == 0)
                    {
                        zaman.Enabled = false;
                        MessageBox.Show(skor.Text, "Oyun Bitti !");
                    }
                }
            }

            ball3.Top = ball3.Top + yyon;
            if (ball3.Bottom == oyunalani.Bottom)
            {
                if (oyunalani.Left < ball3.Left + ball3.Width / 2 &&
                      oyunalani.Right > ball3.Left + ball3.Width / 2)
                {
                    hak = hak - 1;
                    skor.Text = "Skor = " + puan.ToString() + "  Can Sayısı = " + hak.ToString();
                    ball3.Left = 280;
                    ball3.Top = 24;
                    if (hak == 0)
                    {
                        zaman.Enabled = false;
                        MessageBox.Show(skor.Text, "Oyun Bitti !");
                    }
                }
            }
        }
    }
}
