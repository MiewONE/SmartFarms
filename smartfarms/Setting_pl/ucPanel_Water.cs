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
    public partial class ucPanel_Water : UserControl
    {
        private static ucPanel_Water _instance;
        public static ucPanel_Water Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucPanel_Water();
                }
                return _instance;
            }
        }
        public ucPanel_Water()
        {
            InitializeComponent();
        }
    }
}
