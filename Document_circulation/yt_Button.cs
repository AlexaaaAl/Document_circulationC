using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document_circulation
{
    public class yt_Button : Control
    {
        private StringFormat SF = new StringFormat();
        private bool MouseEntered = false;
        private bool MousePressed = false;
        private bool roundingEnable = false;
        public bool RoundingEnable
        {
            get => roundingEnable;
            set
            {
                roundingEnable = value;
                Refresh();
            }
        }
        private int roundingPercent = 100;
        public int Rounding 
        {
            get => roundingPercent;
            set
            {
                if(value>=0 && value <= 100)
                {
                    roundingPercent = value;
                    Refresh();
                }
            }
        }
        public yt_Button()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(30, 30);
            BackColor = Color.Tomato;
            ForeColor = Color.White;
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);
            Rectangle rect = new Rectangle(0 ,0,Width-1,Height-1);
            
            // Закругление
            float roundingValue = 0.1F;
            if (RoundingEnable && roundingPercent > 0)
            {
                roundingValue = Height / 100F * roundingPercent;
            }
            GraphicsPath rectPath = Drawer.RoundedRectangle(rect, roundingValue);


            /*Brush headerBrush = new SolidBrush(BackColor);
            if (BackColorGradientEnabled)
            {
                if (rect.Width > 0 && rect.Height > 0)
                    headerBrush = new LinearGradientBrush(rect, BackColor, BackColorAdditional, BackColorGradientMode);
            }

            Brush borderBrush = headerBrush;
            if (BorderColorEnabled)
            {
                borderBrush = new SolidBrush(BorderColor);

                if (MouseEntered && BorderColorOnHoverEnabled)
                    borderBrush = new SolidBrush(BorderColorOnHover);
            }*/
            //омновной прямоугольник
            graph.DrawPath(new Pen(BackColor), rectPath);
            graph.FillPath(new SolidBrush(BackColor), rectPath);
            if (MouseEntered)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(60, Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), rect);
            }
            if (MousePressed)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(30, Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
            }
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = false;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            Invalidate();
        }
    }
}
