using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunny.UI.Forms
{
    public partial class UITestLabelForm : UIPage
    {
        public UITestLabelForm()
        {
            InitializeComponent();
        }
        public string MyMessage = "状态1： 这是一段描述信息1 \n" +
                         "状态2： 这是一段描述信息2 \n" +
                         "状态3： 这是一段描述信息3 \n" +
                         "状态4： 这是一段描述信息4 \n" +
                         "状态5： 这是一段描述信息5 ";
        private void uiucLabel1_MouseEnter(object sender, EventArgs e)
        {
            uiucLabel1.MessageOrange(MyMessage);
        }
    }
}
