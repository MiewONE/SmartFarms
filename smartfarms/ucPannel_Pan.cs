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
    public partial class ucPannel_Pan : UserControl
    {
        private static ucPannel_Pan _instance;
        public static ucPannel_Pan Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucPannel_Pan();
                }
                return _instance;
            }
        }
        public ucPannel_Pan()
        {
            InitializeComponent();
        }
    }
}
