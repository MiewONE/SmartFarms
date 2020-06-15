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
    public partial class ucPanel_led : UserControl
    {
        private static ucPanel_led _instance;
        public static ucPanel_led Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucPanel_led();
                }
                return _instance;
            }
        }
        public ucPanel_led()
        {
            InitializeComponent();
        }
    }
}
