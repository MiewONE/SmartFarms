using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace smartfarms
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }

        private void pB_temp_MouseDown(object sender, MouseEventArgs e)
        {
            //버튼효과 이미지 삽입하기
        }

        private void pB_temp_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Test");
            if (!pl_settingBack.Controls.Contains(ucPanel_temp.Instance))
            {
                pl_settingBack.Controls.Add(ucPanel_temp.Instance);
                ucPanel_temp.Instance.BackColor = Color.White;
                ucPanel_temp.Instance.Dock = DockStyle.Fill;
                ucPanel_temp.Instance.BringToFront();
            }
            else
                ucPanel_temp.Instance.BringToFront();
        }
        private void pB_Led_MouseDown(object sender, MouseEventArgs e)
        {
            //버튼효과 이미지 삽입하기
        }

        private void pB_Led_MouseUp(object sender, MouseEventArgs e)
        {
            if (!pl_settingBack.Controls.Contains(ucPanel_led.Instance))
            {
                pl_settingBack.Controls.Add(ucPanel_led.Instance);
                ucPanel_led.Instance.BackColor = Color.White;
                ucPanel_led.Instance.Dock = DockStyle.Fill;
                ucPanel_led.Instance.BringToFront();
            }
            else
                ucPanel_led.Instance.BringToFront();
        }
        private void pB_Water_MouseDown(object sender, MouseEventArgs e)
        {
            //버튼효과 이미지 삽입하기
        }

        private void pB_Water_MouseUp(object sender, MouseEventArgs e)
        {
            if (!pl_settingBack.Controls.Contains(ucPanel_Water.Instance))
            {
                pl_settingBack.Controls.Add(ucPanel_Water.Instance);
                ucPanel_Water.Instance.BackColor = Color.White;
                ucPanel_Water.Instance.Dock = DockStyle.Fill;
                ucPanel_Water.Instance.BringToFront();
            }
            else
                ucPanel_Water.Instance.BringToFront();
        }
        private void pB_Humi_MouseDown(object sender, MouseEventArgs e)
        {
            //버튼효과 이미지 삽입하기
        }

        private void pB_Humi_MouseUp(object sender, MouseEventArgs e)
        {
            if (!pl_settingBack.Controls.Contains(ucPanel_Humi.Instance))
            {
                pl_settingBack.Controls.Add(ucPanel_Humi.Instance);
                ucPanel_Humi.Instance.BackColor = Color.White;
                ucPanel_Humi.Instance.Dock = DockStyle.Fill;
                ucPanel_Humi.Instance.BringToFront();
            }
            else
                ucPanel_Humi.Instance.BringToFront();
        }
    }
}
