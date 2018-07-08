// Decompiled with JetBrains decompiler
// Type: Labyrinth.Controls.ColorPanel
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Controls
{
    public class ColorPanel : Panel
    {
        private Container components = (Container)null;
        private Color fColor1 = Color.Black;
        private Color fColor2 = Color.White;

        public ColorPanel()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        public Color Color1
        {
            get
            {
                return this.fColor1;
            }
            set
            {
                this.fColor1 = value;
                this.Refresh();
            }
        }

        public Color Color2
        {
            get
            {
                return this.fColor2;
            }
            set
            {
                this.fColor2 = value;
                this.Refresh();
            }
        }

        public event EventHandler ForeColorClick;

        protected void OnForeColorClick(EventArgs e)
        {
            try
            {
                if (this.ForeColorClick == null)
                    return;
                this.ForeColorClick((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        public event EventHandler BackColorClick;

        protected void OnBackColorClick(EventArgs e)
        {
            try
            {
                if (this.BackColorClick == null)
                    return;
                this.BackColorClick((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Point client = this.PointToClient(Cursor.Position);
            if (this.get_fore_rect().Contains(client))
            {
                this.OnForeColorClick(new EventArgs());
            }
            else
            {
                if (!this.get_back_rect().Contains(client))
                    return;
                this.OnBackColorClick(new EventArgs());
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                Rectangle backRect = this.get_back_rect();
                e.Graphics.FillRectangle((Brush)new SolidBrush(this.fColor2), backRect);
                e.Graphics.DrawRectangle(SystemPens.ControlText, backRect);
                Rectangle foreRect = this.get_fore_rect();
                e.Graphics.FillRectangle((Brush)new SolidBrush(this.fColor1), foreRect);
                e.Graphics.DrawRectangle(SystemPens.ControlText, foreRect);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private Rectangle get_fore_rect()
        {
            Rectangle clientRectangle1 = this.ClientRectangle;
            int x1 = clientRectangle1.X;
            clientRectangle1 = this.ClientRectangle;
            int num1 = clientRectangle1.Width / 7;
            int x2 = x1 + num1;
            Rectangle clientRectangle2 = this.ClientRectangle;
            int y1 = clientRectangle2.Y;
            clientRectangle2 = this.ClientRectangle;
            int num2 = clientRectangle2.Height / 7;
            int y2 = y1 + num2;
            int width = this.ClientRectangle.Width * 3 / 7;
            int height = this.ClientRectangle.Height * 3 / 7;
            return new Rectangle(x2, y2, width, height);
        }

        private Rectangle get_back_rect()
        {
            Rectangle clientRectangle1 = this.ClientRectangle;
            int x1 = clientRectangle1.X;
            clientRectangle1 = this.ClientRectangle;
            int num1 = clientRectangle1.Width * 3 / 7;
            int x2 = x1 + num1;
            Rectangle clientRectangle2 = this.ClientRectangle;
            int y1 = clientRectangle2.Y;
            clientRectangle2 = this.ClientRectangle;
            int num2 = clientRectangle2.Height * 3 / 7;
            int y2 = y1 + num2;
            int width = this.ClientRectangle.Width * 3 / 7;
            int height = this.ClientRectangle.Height * 3 / 7;
            return new Rectangle(x2, y2, width, height);
        }
    }
}