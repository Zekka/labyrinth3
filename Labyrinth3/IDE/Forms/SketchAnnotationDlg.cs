// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.SketchAnnotationDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Controls;
using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class SketchAnnotationDlg : Form
    {
        private SketchAnnotation fNote = (SketchAnnotation)null;
        private int fToolSize = 5;
        private Color fForeColor = Color.Black;
        private Color fBackColor = Color.White;
        private Point fLastPoint = Point.Empty;
        private ImageList ToolbarImages;
        private Label TitleLbl;
        private TextBox TitleBox;
        private Button OKBtn;
        private Button CancelBtn;
        private TextBox DescBox;
        private Label DescLbl;
        private Panel ImagePanel;
        private ToolBar Toolbar;
        private PictureBox SketchBox;
        private ToolBarButton ClearBtn;
        private ColorPanel ColorPanel;
        private Label SizeLbl;
        private NumericUpDown SizeBox;
        private ToolBarButton PrintBtn;
        private ToolBarButton PrintPreviewBtn;
        private ToolBarButton Sep1;
        private ToolBarButton BrowseBtn;
        private ToolBarButton FlipVertBtn;
        private ToolBarButton FlipHorBtn;
        private ToolBarButton RotClockBtn;
        private ToolBarButton RotAntiBtn;
        private ToolBarButton Sep2;
        private ToolBarButton Sep3;
        private IContainer components;

        public SketchAnnotationDlg(SketchAnnotation note)
        {
            this.InitializeComponent();
            this.fNote = note;
            this.ColorPanel.Color1 = this.fForeColor;
            this.ColorPanel.Color2 = this.fBackColor;
            this.SizeBox.Value = (Decimal)this.fToolSize;
            this.TitleBox.Text = this.fNote.Title;
            this.DescBox.Text = this.fNote.Content;
            this.SketchBox.Image = this.fNote.Sketch.Clone() as Image;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            ResourceManager resourceManager = new ResourceManager(typeof(SketchAnnotationDlg));
            this.ToolbarImages = new ImageList(this.components);
            this.OKBtn = new Button();
            this.CancelBtn = new Button();
            this.TitleLbl = new Label();
            this.TitleBox = new TextBox();
            this.DescBox = new TextBox();
            this.DescLbl = new Label();
            this.ImagePanel = new Panel();
            this.SketchBox = new PictureBox();
            this.Toolbar = new ToolBar();
            this.PrintBtn = new ToolBarButton();
            this.PrintPreviewBtn = new ToolBarButton();
            this.Sep1 = new ToolBarButton();
            this.ClearBtn = new ToolBarButton();
            this.BrowseBtn = new ToolBarButton();
            this.ColorPanel = new ColorPanel();
            this.SizeLbl = new Label();
            this.SizeBox = new NumericUpDown();
            this.FlipVertBtn = new ToolBarButton();
            this.FlipHorBtn = new ToolBarButton();
            this.RotClockBtn = new ToolBarButton();
            this.RotAntiBtn = new ToolBarButton();
            this.Sep2 = new ToolBarButton();
            this.Sep3 = new ToolBarButton();
            this.ImagePanel.SuspendLayout();
            this.SizeBox.BeginInit();
            this.SuspendLayout();
            this.ToolbarImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ToolbarImages.ImageSize = new Size(16, 16);
            this.ToolbarImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ToolbarImages.ImageStream");
            this.ToolbarImages.TransparentColor = Color.Magenta;
            this.OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBtn.DialogResult = DialogResult.OK;
            this.OKBtn.Location = new Point(348, 360);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.TabIndex = 8;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(428, 360);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.TitleLbl.Location = new Point(16, 16);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new Size(64, 23);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Title:";
            this.TitleLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.TitleBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.TitleBox.Location = new Point(88, 16);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new Size(416, 21);
            this.TitleBox.TabIndex = 1;
            this.TitleBox.Text = "";
            this.DescBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.DescBox.Location = new Point(88, 48);
            this.DescBox.Name = "DescBox";
            this.DescBox.Size = new Size(416, 21);
            this.DescBox.TabIndex = 3;
            this.DescBox.Text = "";
            this.DescLbl.Location = new Point(16, 48);
            this.DescLbl.Name = "DescLbl";
            this.DescLbl.Size = new Size(64, 23);
            this.DescLbl.TabIndex = 2;
            this.DescLbl.Text = "Description:";
            this.DescLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.ImagePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.ImagePanel.Controls.AddRange(new Control[2]
            {
        (Control) this.SketchBox,
        (Control) this.Toolbar
            });
            this.ImagePanel.Location = new Point(16, 88);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new Size(488, 256);
            this.ImagePanel.TabIndex = 4;
            this.SketchBox.BorderStyle = BorderStyle.Fixed3D;
            this.SketchBox.Cursor = Cursors.Cross;
            this.SketchBox.Dock = DockStyle.Fill;
            this.SketchBox.Location = new Point(0, 25);
            this.SketchBox.Name = "SketchBox";
            this.SketchBox.Size = new Size(488, 231);
            this.SketchBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.SketchBox.TabIndex = 1;
            this.SketchBox.TabStop = false;
            this.SketchBox.MouseUp += new MouseEventHandler(this.SketchBox_MouseUp);
            this.SketchBox.MouseMove += new MouseEventHandler(this.SketchBox_MouseMove);
            this.SketchBox.MouseDown += new MouseEventHandler(this.SketchBox_MouseDown);
            this.Toolbar.Appearance = ToolBarAppearance.Flat;
            this.Toolbar.Buttons.AddRange(new ToolBarButton[11]
            {
        this.BrowseBtn,
        this.Sep1,
        this.PrintBtn,
        this.PrintPreviewBtn,
        this.Sep2,
        this.ClearBtn,
        this.Sep3,
        this.FlipVertBtn,
        this.FlipHorBtn,
        this.RotClockBtn,
        this.RotAntiBtn
            });
            this.Toolbar.DropDownArrows = true;
            this.Toolbar.ImageList = this.ToolbarImages;
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.ShowToolTips = true;
            this.Toolbar.Size = new Size(488, 25);
            this.Toolbar.TabIndex = 0;
            this.Toolbar.ButtonClick += new ToolBarButtonClickEventHandler(this.Toolbar_ButtonClick);
            this.PrintBtn.ImageIndex = 0;
            this.PrintBtn.ToolTipText = "Print";
            this.PrintPreviewBtn.ImageIndex = 1;
            this.PrintPreviewBtn.ToolTipText = "Print Preview";
            this.Sep1.Style = ToolBarButtonStyle.Separator;
            this.ClearBtn.ImageIndex = 2;
            this.ClearBtn.ToolTipText = "Clear";
            this.BrowseBtn.ImageIndex = 3;
            this.BrowseBtn.ToolTipText = "Browse";
            this.ColorPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.ColorPanel.BorderStyle = BorderStyle.Fixed3D;
            this.ColorPanel.Color1 = Color.Black;
            this.ColorPanel.Color2 = Color.White;
            this.ColorPanel.Location = new Point(16, 352);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new Size(32, 32);
            this.ColorPanel.TabIndex = 5;
            this.ColorPanel.ForeColorClick += new EventHandler(this.ColorPanel_ForeColorClick);
            this.ColorPanel.BackColorClick += new EventHandler(this.ColorPanel_BackColorClick);
            this.SizeLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.SizeLbl.Location = new Point(64, 360);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new Size(64, 23);
            this.SizeLbl.TabIndex = 6;
            this.SizeLbl.Text = "Tool size:";
            this.SizeLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.SizeBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.SizeBox.Location = new Point(136, 360);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new Size(56, 21);
            this.SizeBox.TabIndex = 7;
            this.SizeBox.ValueChanged += new EventHandler(this.SizeBox_ValueChanged);
            this.FlipVertBtn.ImageIndex = 5;
            this.FlipVertBtn.ToolTipText = "Flip Vertically";
            this.FlipHorBtn.ImageIndex = 4;
            this.FlipHorBtn.ToolTipText = "Flip Horizontally";
            this.RotClockBtn.ImageIndex = 6;
            this.RotClockBtn.ToolTipText = "Rotate Clockwise";
            this.RotAntiBtn.ImageIndex = 7;
            this.RotAntiBtn.ToolTipText = "Rotate Anticlockwise";
            this.Sep2.Style = ToolBarButtonStyle.Separator;
            this.Sep3.Style = ToolBarButtonStyle.Separator;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(520, 398);
            this.Controls.AddRange(new Control[10]
            {
        (Control) this.SizeBox,
        (Control) this.SizeLbl,
        (Control) this.ColorPanel,
        (Control) this.ImagePanel,
        (Control) this.DescBox,
        (Control) this.DescLbl,
        (Control) this.TitleBox,
        (Control) this.TitleLbl,
        (Control) this.CancelBtn,
        (Control) this.OKBtn
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.Icon = (Icon)resourceManager.GetObject("$this.Icon");
            this.MinimizeBox = false;
            this.Name = nameof(SketchAnnotationDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Sketch Annotation Properties";
            this.ImagePanel.ResumeLayout(false);
            this.SizeBox.EndInit();
            this.ResumeLayout(false);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.fNote.Title = this.TitleBox.Text;
            this.fNote.Content = this.DescBox.Text;
            this.fNote.Sketch = this.SketchBox.Image;
        }

        private void SketchBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.draw(this.fForeColor);
            if (e.Button != MouseButtons.Right)
                return;
            this.draw(this.fBackColor);
        }

        private void SketchBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.draw(this.fForeColor);
            if (e.Button != MouseButtons.Right)
                return;
            this.draw(this.fBackColor);
        }

        private void SketchBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.fLastPoint = Point.Empty;
        }

        private Point get_pixel()
        {
            Point client = this.SketchBox.PointToClient(Cursor.Position);
            return new Point(client.X * this.SketchBox.Image.Width / this.SketchBox.Width, client.Y * this.SketchBox.Image.Height / this.SketchBox.Height);
        }

        private void draw(Color c)
        {
            Point pixel = this.get_pixel();
            if (!this.fLastPoint.IsEmpty)
            {
                Graphics.FromImage(this.SketchBox.Image).DrawLine(new Pen(c, (float)this.fToolSize), this.fLastPoint, pixel);
                this.SketchBox.Refresh();
            }
            this.fLastPoint = pixel;
        }

        private void Toolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == this.PrintBtn)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = this.create_print_doc();
                if (printDialog.ShowDialog() != DialogResult.OK)
                    return;
                for (int index = 0; index != (int)printDialog.PrinterSettings.Copies; ++index)
                    printDialog.Document.Print();
            }
            else if (e.Button == this.PrintPreviewBtn)
            {
                int num = (int)new PrintPreviewDialog()
                {
                    Document = this.create_print_doc()
                }.ShowDialog();
            }
            else if (e.Button == this.ClearBtn)
            {
                Graphics.FromImage(this.SketchBox.Image).Clear(this.fBackColor);
                this.SketchBox.Refresh();
            }
            else if (e.Button == this.BrowseBtn)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.gif;*.bmp| All Files|*.*";
                if (openFileDialog.ShowDialog() != DialogResult.OK || MessageBox.Show("Do you want to replace your sketch with the contents of this file?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                this.SketchBox.Image = (Image)new Bitmap(Image.FromFile(openFileDialog.FileName), this.SketchBox.Image.Size);
            }
            else if (e.Button == this.FlipVertBtn)
            {
                this.SketchBox.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                this.SketchBox.Refresh();
            }
            else if (e.Button == this.FlipHorBtn)
            {
                this.SketchBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                this.SketchBox.Refresh();
            }
            else if (e.Button == this.RotClockBtn)
            {
                this.SketchBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.SketchBox.Refresh();
            }
            else
            {
                if (e.Button != this.RotAntiBtn)
                    return;
                this.SketchBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                this.SketchBox.Refresh();
            }
        }

        private PrintDocument create_print_doc()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = LabyrinthData.Project.Name + ": " + this.fNote.Title;
            printDocument.PrintController = (PrintController)new StandardPrintController();
            printDocument.DefaultPageSettings = LabyrinthData.PageSettings;
            printDocument.PrinterSettings = LabyrinthData.PrinterSettings;
            printDocument.PrintPage += new PrintPageEventHandler(this.PrintPage);
            return printDocument;
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;
            string str = LabyrinthData.Project.Name + ": " + this.fNote.Title;
            int height = (int)e.Graphics.MeasureString(str, this.Font, e.MarginBounds.Width).Height;
            RectangleF layoutRectangle;
            Rectangle marginBounds1 = e.MarginBounds;
            double x = (double)marginBounds1.X;
            marginBounds1 = e.MarginBounds;
            double y = (double)marginBounds1.Y;
            marginBounds1 = e.MarginBounds;
            double width = (double)marginBounds1.Width;
            double num = (double)height;
            layoutRectangle = new RectangleF((float)x, (float)y, (float)width, (float)num);
            e.Graphics.DrawString(str, this.Font, SystemBrushes.WindowText, layoutRectangle, format);
            Rectangle marginBounds2 = e.MarginBounds;
            marginBounds2.Y += height;
            marginBounds2.Height -= height;
            e.Graphics.DrawImage(this.SketchBox.Image, marginBounds2);
        }

        private void ColorPanel_ForeColorClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = this.fForeColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            this.fForeColor = colorDialog.Color;
            this.ColorPanel.Color1 = colorDialog.Color;
        }

        private void ColorPanel_BackColorClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = this.fBackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            this.fBackColor = colorDialog.Color;
            this.ColorPanel.Color2 = colorDialog.Color;
        }

        private void SizeBox_ValueChanged(object sender, EventArgs e)
        {
            this.fToolSize = (int)this.SizeBox.Value;
        }
    }
}