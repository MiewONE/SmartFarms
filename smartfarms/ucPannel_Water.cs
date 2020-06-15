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
    public partial class ucPannel_Water : UserControl
    {
        private static ucPannel_Water _instance;
        public static ucPannel_Water Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucPannel_Water();
                }
                return _instance;
            }
        }
        public ucPannel_Water()
        {
            InitializeComponent();
        }
    }
}
