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
 * 文件名称: UILabel.cs
 * 文件说明: 标签
 * 当前版本: V3.0
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-23: V2.2.4 增加UISymbolLabel
 * 2020-04-25: V2.2.4 更新主题配置类
 * 2020-11-12: V3.0.8 增加文字旋转角度
******************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Sunny.UI
{
    [ToolboxItem(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    public class UILabel : Label, IStyleInterface
    {
        public UILabel()
        {
            base.Font = UIFontColor.Font;
            Version = UIGlobal.Version;
            base.TextAlign = ContentAlignment.MiddleLeft;
            ForeColorChanged += UILabel_ForeColorChanged;
        }

        private int angle;

        [DefaultValue(0),Category("SunnyUI"),Description("居中时旋转角度")]
        public int Angle
        {
            get => angle;
            set
            {
                angle = value;
                Invalidate();
            }
        }

        private int bgangle;

        [DefaultValue(0), Category("SunnyUI"), Description("背景居中时旋转角度")]
        public int BgAngle
        {
            get => bgangle;
            set
            {
                // Image = ImageEx.RotateAngle(Image, value);
                //Bitmap map = new Bitmap(Image);
                //map = KiRotate(map, value, Color.Transparent);
                //Image = map;
                Image = RotateFormCenter(Image, value);
                bgangle = value;
                Invalidate();
            }
        }

        //public static Bitmap KiRotate(Bitmap bmp, float angle, Color bkColor)
        //{
        //    int w = bmp.Width + 2;
        //    int h = bmp.Height + 2;

        //    PixelFormat pf;

        //    if (bkColor == Color.Transparent)
        //    {
        //        pf = PixelFormat.Format32bppArgb;
        //    }
        //    else
        //    {
        //        pf = bmp.PixelFormat;
        //    }

        //    Bitmap tmp = new Bitmap(w, h, pf);
        //    Graphics g = Graphics.FromImage(tmp);
        //    g.Clear(bkColor);
        //    g.DrawImageUnscaled(bmp, 1, 1);
        //    g.Dispose();

        //    GraphicsPath path = new GraphicsPath();
        //    path.AddRectangle(new RectangleF(0f, 0f, w, h));
        //    Matrix mtrx = new Matrix();
        //    mtrx.Rotate(angle);
        //    RectangleF rct = path.GetBounds(mtrx);

        //    Bitmap dst = new Bitmap((int)rct.Width, (int)rct.Height, pf);
        //    g = Graphics.FromImage(dst);
        //    g.Clear(bkColor);
        //    g.TranslateTransform(-rct.X, -rct.Y);
        //    g.RotateTransform(angle);
        //    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
        //    g.DrawImageUnscaled(tmp, 0, 0);
        //    g.Dispose();
        //    tmp.Dispose();
        //    return dst;
        //}
        private static Bitmap RotateFormCenter(Image pb, int angle)
        {

            //装入图片
            Bitmap image = new Bitmap(pb);

            Graphics graphics = Graphics.FromImage(image);
            //获取当前窗口的中心点
            Rectangle rect = new Rectangle(0, 0, pb.Width, pb.Height);
            PointF center = new PointF(rect.Width / 2, rect.Height / 2);
            float offsetX = 0;
            float offsetY = 0;
            offsetX = center.X - image.Width / 2;
            offsetY = center.Y - image.Height / 2;
            //构造图片显示区域:让图片的中心点与窗口的中心点一致
            RectangleF picRect = new RectangleF(offsetX, offsetY, image.Width, image.Height);
            PointF Pcenter = new PointF(picRect.X + picRect.Width / 2,
                picRect.Y + picRect.Height / 2);
            // 绘图平面以图片的中心点旋转
            graphics.TranslateTransform(Pcenter.X, Pcenter.Y);
            graphics.RotateTransform(angle);
            //恢复绘图平面在水平和垂直方向的平移
            graphics.TranslateTransform(-Pcenter.X, -Pcenter.Y);
            //绘制图片
            graphics.DrawImage(image, new Point(0,0));
            return image;
        }

        [Browsable(false)]
        public bool IsScaled { get; private set; }

        public void SetDPIScale()
        {
            if (!IsScaled)
            {
                this.SetDPIScaleFont();
                IsScaled = true;
            }
        }

        private void UILabel_ForeColorChanged(object sender, EventArgs e)
        {
            _style = UIStyle.Custom;
        }

        private Color foreColor = UIStyles.GetStyleColor(UIStyle.Blue).LabelForeColor;

        /// <summary>
        /// Tag字符串
        /// </summary>
        [DefaultValue(null)]
        [Description("获取或设置包含有关控件的数据的对象字符串"), Category("SunnyUI")]
        public string TagString { get; set; }

        /// <summary>
        /// 字体颜色
        /// </summary>
        [Description("字体颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "48, 48, 48")]
        public override Color ForeColor
        {
            get => foreColor;
            set
            {
                foreColor = value;
                Invalidate();
            }
        }

        public string Version { get; }

        public void SetStyle(UIStyle style)
        {
            UIBaseStyle uiColor = UIStyles.GetStyleColor(style);
            if (!uiColor.IsCustom()) SetStyleColor(uiColor);
            _style = style;
        }

        /// <summary>
        /// 自定义主题风格
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置可以自定义主题风格"), Category("SunnyUI")]
        public bool StyleCustomMode { get; set; }

        public virtual void SetStyleColor(UIBaseStyle uiColor)
        {
            ForeColor = uiColor.LabelForeColor;
            Invalidate();
        }

        private UIStyle _style = UIStyle.Blue;

        /// <summary>
        /// 主题样式
        /// </summary>
        [DefaultValue(UIStyle.Blue), Description("主题样式"), Category("SunnyUI")]
        public UIStyle Style
        {
            get => _style;
            set => SetStyle(value);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            _style = UIStyle.Custom;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (TextAlign == ContentAlignment.MiddleCenter && Angle != 0 && !AutoSize)
            {
                e.Graphics.DrawStringRotateAtCenter(Text, Font, ForeColor, this.ClientRectangle.Center(), Angle);
            }
            else
            {
                base.OnPaint(e);
            }
        }
        [DefaultValue(false)]
        [Description("设备运行"), Category("SunnyUI")]
        public bool MachineRun { get; set; }


        [DefaultValue(false)]
        [Description("设备报警"), Category("SunnyUI")]
        public bool MachineError { get; set; }

        [DefaultValue(false)]
        [Description("是否支持动画"), Category("SunnyUI")]
        public bool IsAnimation { get; set; }
    }

    [ToolboxItem(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    public sealed class UILinkLabel : LinkLabel, IStyleInterface
    {
        public UILinkLabel()
        {
            Font = UIFontColor.Font;
            LinkBehavior = LinkBehavior.AlwaysUnderline;
            Version = UIGlobal.Version;

            ActiveLinkColor = UIColor.Orange;
            VisitedLinkColor = UIColor.Red;
            LinkColor = UIColor.Blue;
        }

        [Browsable(false)]
        public bool IsScaled { get; private set; }

        public void SetDPIScale()
        {
            if (!IsScaled)
            {
                this.SetDPIScaleFont();
                IsScaled = true;
            }
        }

        /// <summary>
        /// Tag字符串
        /// </summary>
        [DefaultValue(null)]
        [Description("获取或设置包含有关控件的数据的对象字符串"), Category("SunnyUI")]
        public string TagString { get; set; }

        public string Version { get; }

        /// <summary>
        /// 自定义主题风格
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置可以自定义主题风格"), Category("SunnyUI")]
        public bool StyleCustomMode { get; set; }

        public void SetStyle(UIStyle style)
        {
            UIBaseStyle uiColor = UIStyles.GetStyleColor(style);
            if (!uiColor.IsCustom()) SetStyleColor(uiColor);
            _style = style;
        }

        public void SetStyleColor(UIBaseStyle uiColor)
        {
            ForeColor = uiColor.LabelForeColor;
            LinkColor = uiColor.LabelForeColor;
            Invalidate();
        }

        private UIStyle _style = UIStyle.Blue;

        /// <summary>
        /// 主题样式
        /// </summary>
        [DefaultValue(UIStyle.Blue), Description("主题样式"), Category("SunnyUI")]
        public UIStyle Style
        {
            get => _style;
            set => SetStyle(value);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            _style = UIStyle.Custom;
        }
    }
}