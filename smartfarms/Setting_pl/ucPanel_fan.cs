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
    public partial class ucPanel_fan : UserControl
    {
        private static ucPanel_fan _instance;
        public static ucPanel_fan Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucPanel_fan();
                }
                return _instance;
            }
        }
        public ucPanel_fan()
        {
            InitializeComponent();
        }
    }
}
