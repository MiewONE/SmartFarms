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
using System.Drawing.Text;
using smartfarms.Properties;

namespace smartfarms
{
    public partial class frm_Main : Form
    {
        Image[][] img = new Image[7][];
        

        public const int thermo = 0;
        public const int led = 1;
        public const int fan = 2;
        public const int radi = 3;
        public const int hum = 4;
        public const int pump = 5;
        //Font font = null;
        Color cr = new Color();
        public frm_Main()
        {
            cr = Color.FromArgb(255,233,219);
            //PrivateFontCollection fnt = new PrivateFontCollection();
            //fnt.AddFontFile(".\\font\\NanumSquareRoundEB.ttf");
            //font = new Font(fnt.Families[0],18F);

            //img[5][ 0] = Properties.Resources.펌프_2_black;
            //img[5][ 1] = Properties.Resources.Color_펌프_2;

            InitializeComponent();

            pl_humi.Location = new Point(527, 114);
            pl_fan.Location = new Point(527, 314);
            pl_heater.Location = new Point(527, 214);
            pl_inhumi.Location = new Point(2, 314);
            pl_pump.Location = new Point(2, 114);
            pl_temp.Location = new Point(2, 214);
            pb_logo.Location = new Point(300, 230);
            pb_title.Location = new Point(191, 0);
            pb_mode.Location = new Point(300, 56);
            pb_auto.Location = new Point(417, 56);
            pb_usercontrol.Location = new Point(417, 56);
            //lb_time_humi.Font = font;
            //lb_time_led.Font = font;
            //lb_time_pan.Font = font;
            //lb_time_pump.Font = font;
            //lb_time_radi.Font = font;
            //label1.Font = font;
            //label8.Font = font;

            //Control[,] backclr = new Control[4, 2] 
            //{ 
            //    { pl_icon_first, pl_time_first} 
            //};
            //pl_icon_first.BackColor = cr;
            //pl_time_first.BackColor = cr;
            InitializeComponent();

            //timer1.Interval = 1000;
            //timer1.Enabled = true;
            //timer1.Tick += Timer1_Tick;

            // this는 Form1을 가리킴
            //this.BackColor = Color.LightSteelBlue;
            this.Text = "myDigitalClock";

            label6.Text = DateTime.Now.ToString();
            label6.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 480);
            
        }



        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }





        private void pb_btn_mode_MouseDown(object sender, MouseEventArgs e)
        {
            //pb_btn_mode.Image = global::smartfarms.Properties.Resources.mode_change;
        }

        private void pb_btn_mode_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (variable.Mode == 0)
            {
                //pb_btn_mode.Image = global::smartfarms.Properties.Resources.mode_autoo;
                variable.Mode = 1;
                //pl_button.Visible = false;
            }
            else
            {
                //pb_btn_mode.Image = global::smartfarms.Properties.Resources.mode_3;
                variable.Mode = 0;
                //pl_button.Visible = true;
            }
                
        }
        private void pb_logo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pb_setting_Click(object sender, EventArgs e)
        {

        }

        private void pb_setting_MouseDown(object sender, MouseEventArgs e)
        {
            pb_setting.Image = global::smartfarms.Properties.Resources.btn_on;
        }

        private void pb_setting_MouseUp(object sender, MouseEventArgs e)
        {
            pb_setting.Image = global::smartfarms.Properties.Resources.btn_off;
        }
    }
}
