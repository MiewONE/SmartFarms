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
    public partial class ucPanel_temp : UserControl
    {
        private static ucPanel_temp _instance;
        public static ucPanel_temp Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucPanel_temp();
                }
                return _instance;
            }
        }
        public ucPanel_temp()
        {
            InitializeComponent();
        }
    }
}
