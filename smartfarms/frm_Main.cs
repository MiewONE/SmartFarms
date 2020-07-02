﻿using System;
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

        DateTime dt = new DateTime();
        public const int thermo = 0;
        public const int led = 1;
        public const int fan = 2;
        public const int radi = 3;
        public const int hum = 4;
        public const int pump = 5;
        Font font = null;
        Color cr = new Color();
        public frm_Main()
        {
            cr = Color.FromArgb(255,233,219);
            PrivateFontCollection fnt = new PrivateFontCollection();
            fnt.AddFontFile(".\\font\\NanumSquareRoundEB.ttf");
            font = new Font(fnt.Families[0],18F);

            img[0] = new Image[3];
            img[1] = new Image[3];
            img[2] = new Image[2];
            img[3] = new Image[3];
            img[4] = new Image[2];
            img[5] = new Image[2];

            img[0][ 0] = Properties.Resources.온습도계_black;
            img[0][ 1] = Properties.Resources.온도계_red;
            img[0][ 2] = Properties.Resources.온도계_yellow;

            img[1][0] = Properties.Resources.led_2_black;
            img[1][ 1] = Properties.Resources.color_led_greenYellow;
            img[1][ 2] = Properties.Resources.color_led_greenorange;

            img[2][0] = Properties.Resources.fan_black;
            img[2][1] = Properties.Resources.Color_fan_white;

            img[3][0] = Properties.Resources.난방기;
            img[3][ 1] = Properties.Resources.Color_난방기_red;
            img[3][ 2] = Properties.Resources.Color_난방기_orange;

            img[4][ 0] = Properties.Resources.습도_black;
            img[4][ 1] = Properties.Resources.습도_color;

            //img[5][ 0] = Properties.Resources.펌프_2_black;
            //img[5][ 1] = Properties.Resources.Color_펌프_2;

            
            InitializeComponent();

            
            tbar_humi.Maximum = 100;
            tbar_temp.Maximum = 100;
            lb_time_humi.Font = font;
            lb_time_led.Font = font;
            lb_time_pan.Font = font;
            lb_time_pump.Font = font;
            lb_time_radi.Font = font;
            label1.Font = font;
            label8.Font = font;

            //Control[,] backclr = new Control[4, 2]
            //{
            //    { pl_icon_first, pl_time_first}
            //};
            pl_icon_first.BackColor = cr;
            pl_time_first.BackColor = cr;
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 480);
            if(!DB.Instance.DBcon())
            {
                tb_db.AppendText("False");
                    //.Text = "False";//데이터베이스 연결확인을 위한 라벨 삭제 상관없음.
            }
            else
            {
                tb_db.AppendText("true");
                DB.Instance.DBorTable_Create();
                tb_db.AppendText("테이블 생성완료.");
            }
            bwork_data.RunWorkerAsync();
            
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

        private void pb_btn_setting_MouseDown(object sender, MouseEventArgs e)
        {
            pb_btn_setting.Image = global::smartfarms.Properties.Resources.se_2_back;
        }

        private void pb_btn_setting_MouseUp(object sender, MouseEventArgs e)
        {
            var set = new setting();
            pb_btn_setting.Image = global::smartfarms.Properties.Resources.se_2;
            set.Show();
            
        }

        private void pb_btn_mode_MouseDown(object sender, MouseEventArgs e)
        {
            pb_btn_mode.Image = global::smartfarms.Properties.Resources.mode_change;
        }

        private void pb_btn_mode_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (variable.Instance.Mode == 0)
            {
                pb_btn_mode.Image = global::smartfarms.Properties.Resources.mode_autoo;
                variable.Instance.Mode = 1;
                pl_button.Visible = false;
            }
            else
            {
                pb_btn_mode.Image = global::smartfarms.Properties.Resources.mode_3;
                variable.Instance.Mode = 0;
                pl_button.Visible = true;
            }
                
        }

        private void bwork_data_DoWork(object sender, DoWorkEventArgs e)
        {
            //MessageBox.Show(DateTime.Now.ToString());
            while(true)
            {
                if (tbar_temp.InvokeRequired && tbar_humi.InvokeRequired)
                {
                    tbar_temp.Invoke(new MethodInvoker(delegate ()
                    {
                        DB.Instance.query_execute($"insert into save_state(temperature,humidity,Datetimes) values({tbar_temp.Value},{tbar_humi.Value},'{DateTime.Now.ToString()}')", "insert");
                        //시간이 PRI기 때문에 꼭 넣어줘야함 - 아님 
                    }));
                }
                else
                {
                    DB.Instance.query_execute($"insert into save_state(temperature,humidity) values({tbar_temp.Value},{tbar_humi.Value})", "insert");
                }
                Thread.Sleep(variable.Instance.set_savetime);//데이터 저장 주기 지정해야함. 기본 주기 1초
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bwork_data.IsBusy)
            {
                //bwork_data.CancelAsync();
                bwork_data.Dispose();
            }
            Application.Exit();
        }
    }
}
