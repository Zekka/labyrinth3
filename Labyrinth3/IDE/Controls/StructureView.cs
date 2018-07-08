// Decompiled with JetBrains decompiler
// Type: Labyrinth.Controls.StructureView
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Collections;
using Labyrinth.Forms;
using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Controls
{
    public class StructureView : UserControl
    {
        private Container components = (Container)null;
        private Structure fStructure = (Structure)null;
        private Node fSelectedNode = (Node)null;
        private bool fShowArrows = true;
        private bool fShowText = true;
        private bool fAddingLink = false;
        private Node fFirstNode = (Node)null;
        private StringFormat fStringFormat = (StringFormat)null;
        private Font fSmallFont = (Font)null;
        private Font fBoldFont = (Font)null;
        private Node fHoverNode = (Node)null;
        private const int fArrowSize = 8;
        private const int fNodePadding = 3;
        private const int fShadowSize = 3;
        private Size fOffset;

        public StructureView()
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
            this.AllowDrop = true;
            this.BackColor = SystemColors.ControlDark;
            this.Name = nameof(StructureView);
            this.Size = new Size(312, 240);
        }

        public Structure Structure
        {
            get
            {
                return this.fStructure;
            }
            set
            {
                if (this.fStructure == value)
                    return;
                this.fStructure = value;
                this.Refresh();
            }
        }

        public Node SelectedNode
        {
            get
            {
                return this.fSelectedNode;
            }
        }

        public bool ShowArrows
        {
            get
            {
                return this.fShowArrows;
            }
            set
            {
                this.fShowArrows = value;
            }
        }

        public bool ShowText
        {
            get
            {
                return this.fShowText;
            }
            set
            {
                this.fShowText = value;
            }
        }

        public bool AddingLink
        {
            get
            {
                return this.fAddingLink;
            }
            set
            {
                if (this.fAddingLink == value)
                    return;
                this.fAddingLink = value;
                if (!this.fAddingLink)
                    this.fFirstNode = (Node)null;
                this.Refresh();
            }
        }

        public event EventHandler StructureModified;

        protected void OnStructureModified(EventArgs e)
        {
            try
            {
                if (this.StructureModified == null)
                    return;
                this.StructureModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void create_renderers()
        {
            this.fStringFormat = new StringFormat();
            this.fStringFormat.Alignment = StringAlignment.Center;
            this.fStringFormat.LineAlignment = StringAlignment.Center;
            this.fStringFormat.Trimming = StringTrimming.EllipsisCharacter;
            this.fStringFormat.FormatFlags = this.fStringFormat.FormatFlags;
            this.fSmallFont = new Font(this.Font.FontFamily, this.Font.Size * 0.8f);
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
                if (this.fStructure == null)
                {
                    string s = "No structure to view.";
                    g.DrawString(s, this.Font, SystemBrushes.WindowText, (RectangleF)rect, this.fStringFormat);
                }
                else if (this.fStructure.Nodes.Count == 0)
                {
                    string s = "There are no elements in this structure.";
                    g.DrawString(s, this.Font, SystemBrushes.WindowText, (RectangleF)rect, this.fStringFormat);
                }
                else
                {
                    foreach (Node node in this.fStructure.Nodes)
                        this.draw_shadow(node, g, rect);
                    foreach (Labyrinth.Plot.Link link in this.fStructure.Links)
                        this.draw_link(link, g, rect);
                    if (this.fAddingLink && this.fFirstNode != null)
                        this.draw_new_link(g, rect);
                    foreach (Node node in this.fStructure.Nodes)
                        this.draw_node(node, g, rect);
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void draw_link(Labyrinth.Plot.Link l, Graphics g, Rectangle rect)
        {
            Node node1 = this.find_node(l.LHS);
            Node node2 = this.find_node(l.RHS);
            if (node1 == null || node2 == null)
                return;
            int num1 = (int)((double)node1.Position.X * (double)rect.Width) + rect.Left;
            PointF position = node1.Position;
            int num2 = (int)((double)position.Y * (double)rect.Height) + rect.Top;
            PointF pointF1 = new PointF((float)num1, (float)num2);
            position = node2.Position;
            int num3 = (int)((double)position.X * (double)rect.Width) + rect.Left;
            position = node2.Position;
            int num4 = (int)((double)position.Y * (double)rect.Height) + rect.Top;
            PointF pointF2 = new PointF((float)num3, (float)num4);
            g.DrawLine(SystemPens.ControlText, pointF1, pointF2);
            if (this.fShowText)
            {
                PointF pointF3 = this.get_intersection(pointF2, pointF1, this.rect_for_node(node1, rect));
                PointF pointF4 = this.get_intersection(pointF1, pointF2, this.rect_for_node(node2, rect));
                if (this.fShowArrows)
                {
                    if (l.Direction == LinkDirection.Single || l.Direction == LinkDirection.Double)
                        pointF4 = this.find_arrow_point(pointF3, pointF4);
                    if (l.Direction == LinkDirection.Double)
                        pointF3 = this.find_arrow_point(pointF4, pointF3);
                }
                SizeF textSize = this.get_text_size(l.Description, this.fSmallFont);
                RectangleF rectangleF = new RectangleF(new PointF((float)(((double)pointF3.X + (double)pointF4.X) / 2.0 - (double)textSize.Width / 2.0), (float)(((double)pointF3.Y + (double)pointF4.Y) / 2.0 - (double)textSize.Height / 2.0)), textSize);
                g.FillRectangle(SystemBrushes.FromSystemColor(this.BackColor), rectangleF);
                g.DrawString(l.Description, this.fSmallFont, SystemBrushes.WindowText, rectangleF, this.fStringFormat);
            }
            if (!this.fShowArrows)
                return;
            if (l.Direction == LinkDirection.Single || l.Direction == LinkDirection.Double)
                this.draw_arrow(node1, node2, g, rect);
            if (l.Direction != LinkDirection.Double)
                return;
            this.draw_arrow(node2, node1, g, rect);
        }

        private void draw_arrow(Node lhs_item, Node rhs_item, Graphics g, Rectangle rect)
        {
            Rectangle rectangle = this.rect_for_node(lhs_item, rect);
            Rectangle rect1 = this.rect_for_node(rhs_item, rect);
            if (rectangle.IsEmpty || rect1.IsEmpty)
                return;
            PointF pointF1 = new PointF((float)(rectangle.X + rectangle.Width / 2), (float)(rectangle.Y + rectangle.Height / 2));
            PointF pt2 = new PointF((float)(rect1.X + rect1.Width / 2), (float)(rect1.Y + rect1.Height / 2));
            PointF intersection = this.get_intersection(pointF1, pt2, rect1);
            if (rectangle.Contains((int)intersection.X, (int)intersection.Y))
                return;
            PointF arrowPoint = this.find_arrow_point(pointF1, intersection);
            if (rectangle.Contains((int)arrowPoint.X, (int)arrowPoint.Y))
                return;
            double num1 = Math.Atan(((double)pt2.Y - (double)pointF1.Y) / ((double)pt2.X - (double)pointF1.X));
            double num2 = 4.0 * Math.Sin(num1);
            double num3 = 4.0 * Math.Cos(num1);
            PointF pointF2 = new PointF(arrowPoint.X + (float)num2, arrowPoint.Y - (float)num3);
            PointF pointF3 = new PointF(arrowPoint.X - (float)num2, arrowPoint.Y + (float)num3);
            if (rectangle.Contains((int)pointF2.X, (int)pointF2.Y) || rectangle.Contains((int)pointF3.X, (int)pointF3.Y))
                return;
            PointF[] points = new PointF[3]
            {
        intersection,
        pointF2,
        pointF3
            };
            g.FillPolygon(SystemBrushes.ControlText, points);
        }

        private PointF find_arrow_point(PointF lhs, PointF rhs)
        {
            double num1 = Math.Atan(((double)rhs.Y - (double)lhs.Y) / ((double)rhs.X - (double)lhs.X));
            double num2 = 8.0 * Math.Cos(num1) * ((double)lhs.X <= (double)rhs.X ? 1.0 : -1.0);
            double num3 = 8.0 * Math.Sin(num1) * ((double)lhs.X <= (double)rhs.X ? 1.0 : -1.0);
            return new PointF(rhs.X - (float)num2, rhs.Y - (float)num3);
        }

        private void draw_node(Node n, Graphics g, Rectangle rect)
        {
            Rectangle rect1 = this.rect_for_node(n, rect);
            Element element = this.get_element(n.ElementID);
            if (element == null)
                return;
            Image elementIcon = this.get_element_icon(element);
            if (elementIcon == null)
                return;
            g.FillRectangle(SystemBrushes.Window, rect1);
            g.DrawRectangle(this.fHoverNode != n ? SystemPens.WindowText : SystemPens.Highlight, rect1);
            int num1 = (rect1.Height - elementIcon.Height) / 2;
            g.DrawImage(elementIcon, rect1.X + 3, rect1.Y + num1);
            int num2 = 3 + elementIcon.Width + 3;
            rect1.X += num2;
            rect1.Width -= num2 + 3;
            rect1.Y += 3;
            rect1.Height -= 6;
            Brush brush = SystemBrushes.WindowText;
            if (this.fAddingLink && this.fHoverNode == n)
                brush = SystemBrushes.Highlight;
            Font font = this.fSelectedNode == n ? this.fBoldFont : this.Font;
            g.DrawString(element.Name, font, brush, (RectangleF)rect1, this.fStringFormat);
        }

        private void draw_shadow(Node n, Graphics g, Rectangle rect)
        {
            Rectangle rect1 = this.rect_for_node(n, rect);
            rect1.X += 3;
            rect1.Y += 3;
            g.FillRectangle(SystemBrushes.ControlDarkDark, rect1);
        }

        private void draw_new_link(Graphics g, Rectangle rect)
        {
            PointF pt1 = new PointF((float)((int)((double)this.fFirstNode.Position.X * (double)rect.Width) + rect.Left), (float)((int)((double)this.fFirstNode.Position.Y * (double)rect.Height) + rect.Top));
            if (this.fHoverNode != null)
            {
                PointF pt2 = new PointF((float)((int)((double)this.fHoverNode.Position.X * (double)rect.Width) + rect.Left), (float)((int)((double)this.fHoverNode.Position.Y * (double)rect.Height) + rect.Top));
                g.DrawLine(SystemPens.Highlight, pt1, pt2);
            }
            else
            {
                Point client = this.PointToClient(Cursor.Position);
                g.DrawLine(SystemPens.HighlightText, pt1, (PointF)client);
            }
        }

        private Rectangle rect_for_node(Node n, Rectangle rect)
        {
            Element element = this.get_element(n.ElementID);
            if (element == null)
                return new Rectangle(0, 0, 0, 0);
            Image elementIcon = this.get_element_icon(element);
            if (elementIcon == null)
                return new Rectangle(0, 0, 0, 0);
            Font f = this.fSelectedNode == n ? this.fBoldFont : this.Font;
            this.CreateGraphics();
            SizeF textSize = this.get_text_size(element.Name, f);
            textSize.Width += 3f;
            int width = 3 + elementIcon.Width + 3 + (int)textSize.Width + 3;
            int height = 3 + Math.Max(elementIcon.Height, (int)textSize.Height) + 3;
            PointF position = n.Position;
            int num1 = (int)((double)position.X * (double)rect.Width) + rect.Left;
            position = n.Position;
            int num2 = (int)((double)position.Y * (double)rect.Height) + rect.Top;
            return new Rectangle(num1 - width / 2, num2 - height / 2, width, height);
        }

        private PointF get_intersection(PointF pt1, PointF pt2, Rectangle rect)
        {
            float f = (float)(((double)pt2.Y - (double)pt1.Y) / ((double)pt2.X - (double)pt1.X));
            double num1 = (double)pt2.Y - (double)pt2.X * (double)f;
            double num2 = (double)rect.Height / (double)rect.Width;
            double num3;
            double num4;
            if ((double)Math.Abs(f) > Math.Abs(num2))
            {
                num3 = (double)pt1.Y < (double)pt2.Y ? (double)rect.Top : (double)(rect.Top + rect.Height);
                num4 = (num3 - num1) / (double)f;
                if (float.IsInfinity(f))
                    num4 = (double)pt2.X;
            }
            else
            {
                num4 = (double)pt1.X < (double)pt2.X ? (double)rect.Left : (double)(rect.Left + rect.Width);
                num3 = num4 * (double)f + num1;
            }
            return new PointF((float)num4, (float)num3);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point client = this.PointToClient(Cursor.Position);
            this.fSelectedNode = this.node_at_point(client);
            if (this.fSelectedNode != null)
            {
                this.fStructure.Nodes.Remove(this.fSelectedNode);
                this.fStructure.Nodes.Add(this.fSelectedNode);
                Rectangle rectangle = this.rect_for_node(this.fSelectedNode, this.ClientRectangle);
                this.fOffset = new Size(client.X - rectangle.X - rectangle.Width / 2, client.Y - rectangle.Y - rectangle.Height / 2);
                if (this.fAddingLink)
                {
                    if (this.fFirstNode == null)
                    {
                        this.fFirstNode = this.fSelectedNode;
                    }
                    else
                    {
                        if (this.fSelectedNode != this.fFirstNode)
                        {
                            Labyrinth.Plot.Link l = new Labyrinth.Plot.Link();
                            l.LHS = this.fFirstNode.ElementID;
                            l.RHS = this.fSelectedNode.ElementID;
                            l.Description = "";
                            if (new LinkDlg(l).ShowDialog() == DialogResult.OK)
                            {
                                this.fStructure.Links.Add(l);
                                this.OnStructureModified(new EventArgs());
                            }
                        }
                        this.fAddingLink = false;
                        this.fFirstNode = (Node)null;
                    }
                }
            }
            else
            {
                this.fAddingLink = false;
                this.fFirstNode = (Node)null;
            }
            this.Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Node node = this.node_at_point(new Point(e.X, e.Y));
            if (this.fHoverNode != node)
            {
                this.fHoverNode = node;
                this.Refresh();
            }
            if (this.fSelectedNode != null && e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X - this.fOffset.Width, e.Y - this.fOffset.Height);
                float x = (float)point.X / (float)this.Width;
                float y = (float)point.Y / (float)this.Height;
                if ((double)x < 0.0)
                    x = 0.0f;
                if ((double)y < 0.0)
                    y = 0.0f;
                if ((double)x > 1.0)
                    x = 1f;
                if ((double)y > 1.0)
                    y = 1f;
                this.fSelectedNode.Position = new PointF(x, y);
                this.Refresh();
            }
            if (!this.fAddingLink || this.fFirstNode == null)
                return;
            this.Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.fHoverNode = (Node)null;
            this.Refresh();
        }

        private Node node_at_point(Point p)
        {
            Node node1 = (Node)null;
            foreach (Node node2 in this.fStructure.Nodes)
            {
                if (this.rect_for_node(node2, this.ClientRectangle).Contains(p))
                    node1 = node2;
            }
            return node1;
        }

        private Node find_node(Guid element_id)
        {
            foreach (Node node in this.fStructure.Nodes)
            {
                if (node.ElementID == element_id)
                    return node;
            }
            return (Node)null;
        }

        private Element get_element(Guid id)
        {
            int index = LabyrinthData.Project.Elements.IndexOf(id);
            if (index != -1)
                return LabyrinthData.Project.Elements[index];
            return (Element)null;
        }

        private Image get_element_icon(Element e)
        {
            if (this.TopLevelControl is MainForm)
                return LabyrinthData.ElementImages.Images[LabyrinthData.GetImageIndex(e.Type)];
            return (Image)null;
        }

        private SizeF get_text_size(string str, Font f)
        {
            Graphics graphics = this.CreateGraphics();
            SizeF sizeF1 = graphics.MeasureString(str, f);
            int num1 = (int)Math.Ceiling((double)(sizeF1.Width / sizeF1.Height) / 5.0);
            if (num1 == 1)
                return sizeF1;
            float num2 = sizeF1.Width / (float)num1;
            foreach (string text in str.Split((char[])null))
            {
                SizeF sizeF2 = graphics.MeasureString(text, f);
                if ((double)sizeF2.Width > (double)num2)
                    num2 = sizeF2.Width;
            }
            float num3 = sizeF1.Height * (float)num1;
            for (int width = (int)Math.Ceiling((double)num2); (double)width <= Math.Ceiling((double)sizeF1.Width); ++width)
            {
                SizeF sizeF2 = graphics.MeasureString(str, f, width, this.fStringFormat);
                if ((double)sizeF2.Height <= (double)num3)
                    return sizeF2;
            }
            return sizeF1;
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