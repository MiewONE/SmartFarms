using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartfarms
{
    public partial class ucPannel_Humi : UserControl
    {
        private static ucPannel_Humi _instance;
        public static ucPannel_Humi Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucPannel_Humi();
                }
                return _instance;
            }
        }
        public ucPannel_Humi()
        {
            InitializeComponent();
        }
    }
}
