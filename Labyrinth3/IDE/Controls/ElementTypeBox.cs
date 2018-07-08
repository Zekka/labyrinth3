// Decompiled with JetBrains decompiler
// Type: Labyrinth.Controls.ElementTypeBox
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Controls
{
    public class ElementTypeBox : ComboBox
    {
        private Container components = (Container)null;
        private StringFormat fFormat = new StringFormat();

        public ElementTypeBox()
        {
            this.InitializeComponent();
            this.fFormat.Alignment = StringAlignment.Near;
            this.fFormat.LineAlignment = StringAlignment.Center;
            this.fFormat.Trimming = StringTrimming.EllipsisWord;
            foreach (ElementType elementType in Enum.GetValues(typeof(ElementType)))
                this.Items.Add((object)elementType);
            this.SelectedIndex = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public ElementType SelectedElementType
        {
            get
            {
                return (ElementType)this.SelectedItem;
            }
            set
            {
                this.SelectedItem = (object)value;
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            Image image = LabyrinthData.ElementImages.Images[LabyrinthData.GetImageIndex((ElementType)this.Items[e.Index])];
            e.ItemHeight = image.Height;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index == -1)
                return;
            e.DrawBackground();
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e.DrawFocusRectangle();
            ElementType type = (ElementType)this.Items[e.Index];
            string s = type.ToString();
            Image image = LabyrinthData.ElementImages.Images[LabyrinthData.GetImageIndex(type)];
            e.Graphics.DrawImage(image, e.Bounds.Location);
            Rectangle bounds = e.Bounds;
            bounds.X += LabyrinthData.ElementImages.ImageSize.Width;
            bounds.Width -= LabyrinthData.ElementImages.ImageSize.Width;
            SolidBrush solidBrush = new SolidBrush(e.ForeColor);
            e.Graphics.DrawString(s, e.Font, (Brush)solidBrush, (RectangleF)bounds, this.fFormat);
        }
    }
}