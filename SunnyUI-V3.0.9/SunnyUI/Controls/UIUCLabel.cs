/******************************************************************************
 * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
 * 
 * 
 *
 * 
 * 
 * 
 *
 * SunnyUI.dll can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 文件名称: UITrackBar.cs
 * 文件说明: 进度指示条
 * 当前版本: V3.0
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
 * 2021-04-11: V3.0.2 增加垂直显示方式
******************************************************************************/

using System;
using Sunny.UI;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sunny.UI
{
    public class UIUCLabel : UILabel
    {
        private ImageList imageList1;
        private IContainer components;
        UIToolTip Tip = new UIToolTip();
        public UIUCLabel()
        {
            //默认为透明色
            this.BackColor = Color.Transparent;
        }
        public  void MessageRed(string message) {
            Tip.SetToolTip(this, message, "信息", 61546, 32, UIColor.Red);
        }

        public void MessageGreen(string message)
        {
            Tip.SetToolTip(this, message, "信息", 61529, 32, UIColor.Green);
        }
        public void MessageOrange(string message)
        {
            Tip.SetToolTip(this, message, "信息", 61527, 32, UIColor.RegularOrange);
        }
    }
}