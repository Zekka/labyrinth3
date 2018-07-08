// Decompiled with JetBrains decompiler
// Type: Labyrinth.Controls.TimelineGrid
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Collections;
using Labyrinth.Plot;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Controls
{
    public class TimelineGrid : UserControl
    {
        private Container components = (Container)null;
        private Timeline fTimeline = (Timeline)null;
        private SizeF fCellSize = new SizeF(0.0f, 0.0f);
        private Guid fSelectedElementID = Guid.Empty;
        private TimelinePoint fSelectedPoint = (TimelinePoint)null;
        private Guid fHoverElementID = Guid.Empty;
        private TimelinePoint fHoverPoint = (TimelinePoint)null;
        private StringFormat fColHdrFormat = (StringFormat)null;
        private StringFormat fRowHdrFormat = (StringFormat)null;
        private StringFormat fMsgFormat = (StringFormat)null;
        private Font fBoldFont = (Font)null;

        public TimelineGrid()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.create_renderers();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.Name = nameof(TimelineGrid);
            this.Size = new Size(288, 176);
        }

        public Timeline Timeline
        {
            get
            {
                return this.fTimeline;
            }
            set
            {
                this.fTimeline = value;
                this.Refresh();
            }
        }

        public SizeF CellSize
        {
            get
            {
                return this.fCellSize;
            }
        }

        public Element SelectedElement
        {
            get
            {
                return this.get_element(this.fSelectedElementID);
            }
        }

        public TimelinePoint SelectedPoint
        {
            get
            {
                return this.fSelectedPoint;
            }
        }

        public Element HoverElement
        {
            get
            {
                return this.get_element(this.fHoverElementID);
            }
        }

        public TimelinePoint HoverPoint
        {
            get
            {
                return this.fHoverPoint;
            }
        }

        private void create_renderers()
        {
            this.fColHdrFormat = new StringFormat();
            this.fColHdrFormat.Alignment = StringAlignment.Center;
            this.fColHdrFormat.LineAlignment = StringAlignment.Far;
            this.fColHdrFormat.Trimming = StringTrimming.EllipsisWord;
            this.fColHdrFormat.FormatFlags |= StringFormatFlags.LineLimit;
            this.fRowHdrFormat = new StringFormat();
            this.fRowHdrFormat.Alignment = StringAlignment.Near;
            this.fRowHdrFormat.LineAlignment = StringAlignment.Center;
            this.fRowHdrFormat.Trimming = StringTrimming.EllipsisWord;
            this.fRowHdrFormat.FormatFlags |= StringFormatFlags.LineLimit;
            this.fMsgFormat = new StringFormat();
            this.fMsgFormat.Alignment = StringAlignment.Center;
            this.fMsgFormat.LineAlignment = StringAlignment.Center;
            this.fMsgFormat.Trimming = StringTrimming.EllipsisWord;
            this.fMsgFormat.FormatFlags |= StringFormatFlags.LineLimit;
            this.fBoldFont = new Font(this.Font, this.Font.Style | FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.Render(e.Graphics, this.ClientRectangle);
        }

        public void Render(Graphics g, Rectangle rect)
        {
            try
            {
                if (this.fTimeline == null)
                    return;
                if (this.fTimeline.ElementIDs.Count == 0 || this.fTimeline.Points.Count == 0)
                {
                    string s = "";
                    if (this.fTimeline.ElementIDs.Count == 0)
                        s += "No elements in this timeline";
                    if (this.fTimeline.Points.Count == 0)
                    {
                        if (s != "")
                            s += "\n";
                        s += "No points in this timeline";
                    }
                    g.DrawString(s, this.Font, SystemBrushes.ControlText, (RectangleF)rect, this.fMsgFormat);
                }
                else
                {
                    this.calc_cell_size(rect);
                    this.draw_column_headers(g, rect);
                    this.draw_row_headers(g, rect);
                    foreach (Guid elementId in this.fTimeline.ElementIDs)
                    {
                        foreach (TimelinePoint point in this.fTimeline.Points)
                            this.draw_cell(g, elementId, point, rect);
                    }
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void draw_column_headers(Graphics g, Rectangle rect)
        {
            for (int p_index = 0; p_index != this.fTimeline.Points.Count; ++p_index)
            {
                TimelinePoint point = this.fTimeline.Points[p_index];
                RectangleF layoutRectangle = this.rect_for_cell(-1, p_index, rect);
                string s = point.Name;
                switch (point.UseSchedule)
                {
                    case ScheduleType.Date:
                        s = s + "\n" + point.Schedule.ToShortDateString();
                        break;

                    case ScheduleType.DateTime:
                        s = s + "\n" + point.Schedule.ToShortDateString() + " " + point.Schedule.ToString("HH:mm");
                        break;
                }
                g.DrawRectangle(SystemPens.ControlDark, layoutRectangle.X, layoutRectangle.Y, layoutRectangle.Width, layoutRectangle.Height);
                Font font = point == this.SelectedPoint ? this.fBoldFont : this.Font;
                g.DrawString(s, font, SystemBrushes.ControlText, layoutRectangle, this.fColHdrFormat);
            }
        }

        private void draw_row_headers(Graphics g, Rectangle rect)
        {
            for (int e_index = 0; e_index != this.fTimeline.ElementIDs.Count; ++e_index)
            {
                Element element = this.get_element(this.fTimeline.ElementIDs[e_index]);
                RectangleF layoutRectangle = this.rect_for_cell(e_index, -1, rect);
                Image image = LabyrinthData.ElementImages.Images[LabyrinthData.GetImageIndex(element.Type)];
                Rectangle rect1 = new Rectangle(new Point((int)layoutRectangle.X, (int)layoutRectangle.Top + ((int)layoutRectangle.Height - image.Height) / 2), image.Size);
                g.DrawImage(image, rect1);
                g.DrawRectangle(SystemPens.ControlDark, layoutRectangle.X, layoutRectangle.Y, layoutRectangle.Width, layoutRectangle.Height);
                Font font = element == this.SelectedElement ? this.fBoldFont : this.Font;
                layoutRectangle.X += (float)rect1.Width;
                layoutRectangle.Width -= (float)rect1.Width;
                g.DrawString(element.Name, font, SystemBrushes.ControlText, layoutRectangle, this.fRowHdrFormat);
            }
        }

        private void draw_cell(Graphics g, Guid element_id, TimelinePoint tlp, Rectangle rect)
        {
            RectangleF rect1 = this.rect_for_cell(this.fTimeline.ElementIDs.IndexOf(element_id), this.fTimeline.Points.IndexOf(tlp), rect);
            rect1.Offset(1f, 1f);
            rect1.Inflate(-1f, -1f);
            ArrayList arrayList = new ArrayList();
            foreach (TimelineItem timelineItem in tlp.Items)
            {
                if (timelineItem.ElementID == element_id)
                    arrayList.Add((object)timelineItem.Annotation);
            }
            if (arrayList.Count != 0)
            {
                int count = arrayList.Count;
                bool selected = element_id == this.fSelectedElementID && tlp == this.fSelectedPoint;
                g.FillRectangle(selected ? SystemBrushes.Highlight : SystemBrushes.Window, rect1);
                for (int index = 0; index != arrayList.Count; ++index)
                {
                    Annotation a = arrayList[index] as Annotation;
                    int height = (int)((double)rect1.Height / (double)arrayList.Count);
                    int y = (int)((double)rect1.Y + (double)(height * index));
                    Rectangle rect2 = new Rectangle((int)rect1.X, y, (int)rect1.Width, height);
                    Annotations.Render(a, rect2, this.Font, g, selected, false);
                }
            }
            else
            {
                bool flag = element_id == this.fSelectedElementID && tlp == this.fSelectedPoint;
                g.FillRectangle(flag ? SystemBrushes.Highlight : SystemBrushes.ControlLight, rect1);
                if (!(element_id == this.fHoverElementID) || tlp != this.fHoverPoint)
                    return;
                g.DrawRectangle(SystemPens.Highlight, rect1.X, rect1.Y, rect1.Width, rect1.Height);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.fSelectedPoint = (TimelinePoint)null;
            this.fSelectedElementID = Guid.Empty;
            if (this.fTimeline != null)
            {
                Point client = this.PointToClient(Cursor.Position);
                int index1 = (int)((double)client.X / (double)this.fCellSize.Width) - 1;
                if (index1 >= 0 && index1 < this.fTimeline.Points.Count)
                    this.fSelectedPoint = this.fTimeline.Points[index1];
                int index2 = (int)((double)client.Y / (double)this.fCellSize.Height) - 1;
                if (index2 >= 0 && index2 < this.fTimeline.ElementIDs.Count)
                    this.fSelectedElementID = this.fTimeline.ElementIDs[index2];
            }
            this.Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.RecalculateHover();
        }

        public void RecalculateHover()
        {
            this.fHoverElementID = Guid.Empty;
            this.fHoverPoint = (TimelinePoint)null;
            if (this.fTimeline != null && this.fTimeline.Points.Count != 0 && this.fTimeline.ElementIDs.Count != 0)
            {
                Point client = this.PointToClient(Cursor.Position);
                int index1 = (int)((double)client.X / (double)this.fCellSize.Width) - 1;
                int index2 = (int)((double)client.Y / (double)this.fCellSize.Height) - 1;
                if (index1 >= 0 && index2 >= 0 && (index1 < this.fTimeline.Points.Count && index2 < this.fTimeline.ElementIDs.Count))
                {
                    this.fHoverElementID = this.fTimeline.ElementIDs[index2];
                    this.fHoverPoint = this.fTimeline.Points[index1];
                }
            }
            this.Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.fHoverElementID = Guid.Empty;
            this.fHoverPoint = (TimelinePoint)null;
            this.Refresh();
        }

        public override void Refresh()
        {
            this.calc_cell_size(this.ClientRectangle);
            base.Refresh();
        }

        private Element get_element(Guid id)
        {
            int index = LabyrinthData.Project.Elements.IndexOf(id);
            if (index != -1)
                return LabyrinthData.Project.Elements[index];
            return (Element)null;
        }

        private RectangleF rect_for_cell(int e_index, int p_index, Rectangle rect)
        {
            float num1 = (float)(p_index + 1) * this.fCellSize.Width;
            float num2 = (float)(e_index + 1) * this.fCellSize.Height;
            return new RectangleF(num1 + (float)rect.Left, num2 + (float)rect.Top, this.fCellSize.Width, this.fCellSize.Height);
        }

        private void calc_cell_size(Rectangle rect)
        {
            if (this.fTimeline == null || this.fTimeline.ElementIDs.Count == 0 || this.fTimeline.Points.Count == 0)
                return;
            this.fCellSize.Width = (float)rect.Width / (float)(this.fTimeline.Points.Count + 1);
            this.fCellSize.Height = (float)rect.Height / (float)(this.fTimeline.ElementIDs.Count + 1);
        }

        public Image CreateImage()
        {
            Image image = (Image)new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(this.BackColor);
            this.OnPaint(new PaintEventArgs(graphics, new Rectangle(0, 0, this.Width, this.Height)));
            return image;
        }
    }
}