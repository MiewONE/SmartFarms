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
    public partial class ucPannel_temp : UserControl
    {
        private static ucPannel_temp _instance;
        public static ucPannel_temp Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucPannel_temp();
                }
                return _instance;
            }
        }
        public ucPannel_temp()
        {
            InitializeComponent();
        }
    }
}
