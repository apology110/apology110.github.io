using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunny.UI.Forms
{
    public partial class UITestForm : UIPage
    {
        public UITestForm()
        {
            InitializeComponent();
            uiucLabel4.Image = imageList1.Images[0];
            uiucLabel5.Image = imageList1.Images[1];
            uiucLabel6.Image = imageList1.Images[2];
            Thread td = new Thread(method);
            td.Start();
        }

        private void uiucLabel1_MouseEnter(object sender, EventArgs e)
        {
            uiucLabel1.BackColor = Color.Blue;
            //将控件带到Z顺序的前面，最后画这个控件，相当于控件置顶
            uiucLabel1.BringToFront();
            //将控件带到Z顺序的后面，最先画这个控件，相当于控件置底
            uiucLabel2.SendToBack();
        }

        private void uiucLabel2_MouseEnter(object sender, EventArgs e)
        {
            uiucLabel2.BackColor = Color.Red;
            //将控件带到Z顺序的前面，最后画这个控件，相当于控件置顶
            uiucLabel2.BringToFront();
            //将控件带到Z顺序的后面，最先画这个控件，相当于控件置底
            uiucLabel1.SendToBack();
        }

        private void uiucLabel1_MouseLeave(object sender, EventArgs e)
        {
            uiucLabel1.BackColor = Color.Transparent;
        }

        private void uiucLabel2_MouseLeave(object sender, EventArgs e)
        {
            uiucLabel2.BackColor = Color.Transparent;
        }

        public string MyMessage = "状态1： 这是一段描述信息1 \n" +
                          "状态2： 这是一段描述信息2 \n" +
                          "状态3： 这是一段描述信息3 \n" +
                          "状态4： 这是一段描述信息4 \n" +
                          "状态5： 这是一段描述信息5 ";
        private void uiucLabel3_MouseEnter(object sender, EventArgs e)
        {
            uiucLabel3.MessageGreen(MyMessage);
        }
        public void method() {
           
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                uiucLabel7.Image = imageList1.Images[i];
                uiArcLabel8.Image = imageList1.Images[i];
                Thread.Sleep(1000);
                if (i == imageList1.Images.Count-1)
                { i = -1; }
            }
        }

        private void uiArcLabel2_MouseEnter(object sender, EventArgs e)
        {
            uiArcLabel2.MessageOrange(MyMessage);
        }

        private void uiucLabel6_MouseEnter(object sender, EventArgs e)
        {
            uiucLabel6.MessageRed(MyMessage);
        }
    }
}
