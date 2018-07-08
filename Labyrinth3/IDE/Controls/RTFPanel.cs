// Decompiled with JetBrains decompiler
// Type: Labyrinth.Controls.RTFPanel
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Controls
{
    public class RTFPanel : UserControl
    {
        private ImageList ToolbarImages;
        private ToolBar Toolbar;
        private ToolBarButton FontBtn;
        private ToolBarButton Sep1;
        private ToolBarButton BoldBtn;
        private ToolBarButton ItalicBtn;
        private ToolBarButton UnderlineBtn;
        private ToolBarButton StrikeBtn;
        private ToolBarButton Sep2;
        private ToolBarButton BulletBtn;
        private ToolBarButton Sep3;
        private ToolBarButton LeftBtn;
        private ToolBarButton CentreBtn;
        private ToolBarButton RightBtn;
        private RichTextBox ContentBox;
        private ToolBarButton Sep4;
        private ToolBarButton PrintBtn;
        private ToolBarButton PrintPreviewBtn;
        private ToolBarButton Sep5;
        private ToolBarButton IndentBtn;
        private ToolBarButton UnindentBtn;
        private ContextMenu RightClickMenu;
        private MenuItem RightClickCut;
        private MenuItem RightClickCopy;
        private MenuItem RightClickPaste;
        private MenuItem Sep6;
        private MenuItem RightClickSelectAll;
        private ToolBarButton CutBtn;
        private ToolBarButton CopyBtn;
        private ToolBarButton PasteBtn;
        private ToolBarButton Sep7;
        private IContainer components;

        public RTFPanel()
        {
            this.InitializeComponent();
            this.ContentBox.DragOver += new DragEventHandler(this.ContentBox_DragOver);
            this.ContentBox.DragDrop += new DragEventHandler(this.ContentBox_DragDrop);
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
            ResourceManager resourceManager = new ResourceManager(typeof(RTFPanel));
            this.ToolbarImages = new ImageList(this.components);
            this.Toolbar = new ToolBar();
            this.CutBtn = new ToolBarButton();
            this.CopyBtn = new ToolBarButton();
            this.PasteBtn = new ToolBarButton();
            this.Sep1 = new ToolBarButton();
            this.FontBtn = new ToolBarButton();
            this.Sep2 = new ToolBarButton();
            this.BoldBtn = new ToolBarButton();
            this.ItalicBtn = new ToolBarButton();
            this.UnderlineBtn = new ToolBarButton();
            this.StrikeBtn = new ToolBarButton();
            this.Sep3 = new ToolBarButton();
            this.BulletBtn = new ToolBarButton();
            this.Sep4 = new ToolBarButton();
            this.LeftBtn = new ToolBarButton();
            this.CentreBtn = new ToolBarButton();
            this.RightBtn = new ToolBarButton();
            this.Sep5 = new ToolBarButton();
            this.UnindentBtn = new ToolBarButton();
            this.IndentBtn = new ToolBarButton();
            this.Sep7 = new ToolBarButton();
            this.PrintBtn = new ToolBarButton();
            this.PrintPreviewBtn = new ToolBarButton();
            this.ContentBox = new RichTextBox();
            this.RightClickMenu = new ContextMenu();
            this.RightClickCut = new MenuItem();
            this.RightClickCopy = new MenuItem();
            this.RightClickPaste = new MenuItem();
            this.Sep6 = new MenuItem();
            this.RightClickSelectAll = new MenuItem();
            this.SuspendLayout();
            this.ToolbarImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ToolbarImages.ImageSize = new Size(16, 16);
            this.ToolbarImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ToolbarImages.ImageStream");
            this.ToolbarImages.TransparentColor = Color.Magenta;
            this.Toolbar.Appearance = ToolBarAppearance.Flat;
            var buttons = new List<ToolBarButton>() {
                this.CutBtn,
                this.CopyBtn,
                this.PasteBtn,
                this.Sep1,
                this.FontBtn,
                this.Sep2,
                this.BoldBtn,
                this.ItalicBtn,
                this.UnderlineBtn,
                this.StrikeBtn,
                this.Sep3,
                this.BulletBtn,
                this.Sep4,
                this.LeftBtn,
                this.CentreBtn,
                this.RightBtn,
                this.Sep5,
                this.UnindentBtn,
                this.IndentBtn,
                this.Sep7,
                this.PrintBtn,
                this.PrintPreviewBtn
            };

            if (Program.ZEKKA_WORKAROUNDS)
            {
                buttons.RemoveRange(3, 2); // no font button
            }
            this.Toolbar.Buttons.AddRange(buttons.ToArray());
            this.Toolbar.DropDownArrows = true;
            this.Toolbar.ImageList = this.ToolbarImages;
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.ShowToolTips = true;
            this.Toolbar.Size = new Size(472, 25);
            this.Toolbar.TabIndex = 6;
            this.Toolbar.ButtonClick += new ToolBarButtonClickEventHandler(this.Toolbar_ButtonClick);
            this.CutBtn.ImageIndex = 13;
            this.CutBtn.ToolTipText = "Cut";
            this.CopyBtn.ImageIndex = 14;
            this.CopyBtn.ToolTipText = "Copy";
            this.PasteBtn.ImageIndex = 15;
            this.PasteBtn.ToolTipText = "Paste";
            this.Sep1.Style = ToolBarButtonStyle.Separator;
            this.FontBtn.ImageIndex = 8;
            this.FontBtn.ToolTipText = "Font";
            this.Sep2.Style = ToolBarButtonStyle.Separator;
            this.BoldBtn.ImageIndex = 0;
            this.BoldBtn.ToolTipText = "Bold";
            this.ItalicBtn.ImageIndex = 1;
            this.ItalicBtn.ToolTipText = "Italic";
            this.UnderlineBtn.ImageIndex = 2;
            this.UnderlineBtn.ToolTipText = "Underline";
            this.StrikeBtn.ImageIndex = 3;
            this.StrikeBtn.ToolTipText = "Strikeout";
            this.Sep3.Style = ToolBarButtonStyle.Separator;
            this.BulletBtn.ImageIndex = 4;
            this.BulletBtn.ToolTipText = "Bulleted list";
            this.Sep4.Style = ToolBarButtonStyle.Separator;
            this.LeftBtn.ImageIndex = 5;
            this.LeftBtn.ToolTipText = "Left align";
            this.CentreBtn.ImageIndex = 6;
            this.CentreBtn.ToolTipText = "Center align";
            this.RightBtn.ImageIndex = 7;
            this.RightBtn.ToolTipText = "Right align";
            this.Sep5.Style = ToolBarButtonStyle.Separator;
            this.UnindentBtn.ImageIndex = 9;
            this.UnindentBtn.ToolTipText = "Unindent";
            this.IndentBtn.ImageIndex = 10;
            this.IndentBtn.ToolTipText = "Indent";
            this.Sep7.Style = ToolBarButtonStyle.Separator;
            this.PrintBtn.ImageIndex = 11;
            this.PrintBtn.ToolTipText = "Print";
            this.PrintPreviewBtn.ImageIndex = 12;
            this.PrintPreviewBtn.ToolTipText = "Print Preview";
            this.ContentBox.AllowDrop = true;
            this.ContentBox.ContextMenu = this.RightClickMenu;
            this.ContentBox.Dock = DockStyle.Fill;
            this.ContentBox.Location = new Point(0, 25);
            this.ContentBox.Name = "ContentBox";
            this.ContentBox.Size = new Size(472, 159);
            this.ContentBox.TabIndex = 8;
            this.ContentBox.Text = "";
            this.ContentBox.TextChanged += new EventHandler(this.ContentBox_TextChanged);
            this.ContentBox.LinkClicked += new LinkClickedEventHandler(this.ContentBox_LinkClicked);
            this.RightClickMenu.MenuItems.AddRange(new MenuItem[5]
            {
        this.RightClickCut,
        this.RightClickCopy,
        this.RightClickPaste,
        this.Sep6,
        this.RightClickSelectAll
            });
            this.RightClickCut.Index = 0;
            this.RightClickCut.Shortcut = Shortcut.CtrlX;
            this.RightClickCut.Text = "Cut";
            this.RightClickCut.Click += new EventHandler(this.RightClickCut_Click);
            this.RightClickCopy.Index = 1;
            this.RightClickCopy.Shortcut = Shortcut.CtrlC;
            this.RightClickCopy.Text = "Copy";
            this.RightClickCopy.Click += new EventHandler(this.RightClickCopy_Click);
            this.RightClickPaste.Index = 2;
            this.RightClickPaste.Shortcut = Shortcut.CtrlV;
            this.RightClickPaste.Text = "Paste";
            this.RightClickPaste.Click += new EventHandler(this.RightClickPaste_Click);
            this.Sep6.Index = 3;
            this.Sep6.Text = "-";
            this.RightClickSelectAll.Index = 4;
            this.RightClickSelectAll.Shortcut = Shortcut.CtrlA;
            this.RightClickSelectAll.Text = "Select All";
            this.RightClickSelectAll.Click += new EventHandler(this.RightClickSelectAll_Click);
            this.Controls.AddRange(new Control[2]
            {
        (Control) this.ContentBox,
        (Control) this.Toolbar
            });
            this.Name = nameof(RTFPanel);
            this.Size = new Size(472, 184);

            this.DoubleBuffered = true;

            this.ResumeLayout(false);
        }

        public string RTF
        {
            get
            {
                return this.ContentBox.Rtf;
            }
            set
            {
                this.ContentBox.Rtf = value;
            }
        }

        public override string Text
        {
            get
            {
                return this.ContentBox.Text.Replace("\n", Environment.NewLine);
            }
            set
            {
                this.ContentBox.Text = value;
            }
        }

        public void UpdateUI()
        {
            this.RightClickCut.Enabled = this.ContentBox.SelectedText != "";
            this.RightClickCopy.Enabled = this.ContentBox.SelectedText != "";
            this.RightClickPaste.Enabled = true;
            this.RightClickSelectAll.Enabled = true;
            this.CutBtn.Enabled = this.RightClickCut.Enabled;
            this.CopyBtn.Enabled = this.RightClickCopy.Enabled;
            this.PasteBtn.Enabled = this.RightClickPaste.Enabled;
            if (this.ContentBox.SelectionFont != null)
            {
                this.BoldBtn.Pushed = this.ContentBox.SelectionFont.Bold;
                this.ItalicBtn.Pushed = this.ContentBox.SelectionFont.Italic;
                this.UnderlineBtn.Pushed = this.ContentBox.SelectionFont.Underline;
                this.StrikeBtn.Pushed = this.ContentBox.SelectionFont.Strikeout;
            }
            this.BulletBtn.Pushed = this.ContentBox.SelectionBullet;
            this.LeftBtn.Pushed = this.ContentBox.SelectionAlignment == HorizontalAlignment.Left;
            this.CentreBtn.Pushed = this.ContentBox.SelectionAlignment == HorizontalAlignment.Center;
            this.RightBtn.Pushed = this.ContentBox.SelectionAlignment == HorizontalAlignment.Right;
            this.UnindentBtn.Enabled = this.ContentBox.SelectionIndent > 0;
            this.IndentBtn.Enabled = true;
        }

        public event EventHandler ContentModified;

        protected void OnContentModified(EventArgs e)
        {
            try
            {
                if (this.ContentModified == null)
                    return;
                this.ContentModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void Toolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.CutBtn)
                    this.RightClickCut_Click(sender, (EventArgs)e);
                else if (e.Button == this.CopyBtn)
                    this.RightClickCopy_Click(sender, (EventArgs)e);
                else if (e.Button == this.PasteBtn)
                    this.RightClickPaste_Click(sender, (EventArgs)e);
                else if (e.Button == this.FontBtn)
                {
                    FontDialog fontDialog = new FontDialog();
                    fontDialog.ShowColor = true;
                    fontDialog.Color = this.ContentBox.SelectionColor;
                    fontDialog.Font = this.ContentBox.SelectionFont;
                    if (fontDialog.ShowDialog() != DialogResult.OK)
                        return;
                    this.ContentBox.SelectionColor = fontDialog.Color;
                    this.ContentBox.SelectionFont = fontDialog.Font;
                }
                else if (e.Button == this.BoldBtn)
                {
                    Font selectionFont = this.ContentBox.SelectionFont;
                    FontStyle newStyle = selectionFont.Bold ? FontStyle.Regular : FontStyle.Bold;
                    this.ContentBox.SelectionFont = new Font(selectionFont, newStyle);
                }
                else if (e.Button == this.ItalicBtn)
                {
                    Font selectionFont = this.ContentBox.SelectionFont;
                    FontStyle newStyle = selectionFont.Italic ? FontStyle.Regular : FontStyle.Italic;
                    this.ContentBox.SelectionFont = new Font(selectionFont, newStyle);
                }
                else if (e.Button == this.UnderlineBtn)
                {
                    Font selectionFont = this.ContentBox.SelectionFont;
                    FontStyle newStyle = selectionFont.Underline ? FontStyle.Regular : FontStyle.Underline;
                    this.ContentBox.SelectionFont = new Font(selectionFont, newStyle);
                }
                else if (e.Button == this.StrikeBtn)
                {
                    Font selectionFont = this.ContentBox.SelectionFont;
                    FontStyle newStyle = selectionFont.Strikeout ? FontStyle.Regular : FontStyle.Strikeout;
                    this.ContentBox.SelectionFont = new Font(selectionFont, newStyle);
                }
                else if (e.Button == this.BulletBtn)
                    this.ContentBox.SelectionBullet = !this.ContentBox.SelectionBullet;
                else if (e.Button == this.LeftBtn)
                    this.ContentBox.SelectionAlignment = HorizontalAlignment.Left;
                else if (e.Button == this.CentreBtn)
                    this.ContentBox.SelectionAlignment = HorizontalAlignment.Center;
                else if (e.Button == this.RightBtn)
                    this.ContentBox.SelectionAlignment = HorizontalAlignment.Right;
                else if (e.Button == this.UnindentBtn)
                {
                    this.ContentBox.SelectionIndent -= 10;
                    if (this.ContentBox.SelectionIndent >= 0)
                        return;
                    this.ContentBox.SelectionIndent = 0;
                }
                else if (e.Button == this.IndentBtn)
                    this.ContentBox.SelectionIndent += 10;
                else if (e.Button == this.PrintBtn)
                {
                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = this.create_print_doc();
                    if (printDialog.ShowDialog() != DialogResult.OK)
                        return;
                    for (int index = 0; index != (int)printDialog.PrinterSettings.Copies; ++index)
                        printDialog.Document.Print();
                }
                else
                {
                    if (e.Button != this.PrintPreviewBtn)
                        return;
                    int num = (int)new PrintPreviewDialog()
                    {
                        Document = this.create_print_doc()
                    }.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private PrintDocument create_print_doc()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = LabyrinthData.Project.Name;
            printDocument.PrintController = (PrintController)new StandardPrintController();
            printDocument.DefaultPageSettings = LabyrinthData.PageSettings;
            printDocument.PrinterSettings = LabyrinthData.PrinterSettings;
            printDocument.PrintPage += new PrintPageEventHandler(this.PrintPage);
            return printDocument;
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            format.Trimming = StringTrimming.EllipsisCharacter;
            Font font = new Font(this.Font, this.Font.Style);
            float height = e.Graphics.MeasureString(this.ContentBox.Text, font, e.MarginBounds.Width).Height;
            if ((double)height > (double)e.MarginBounds.Height)
            {
                float emSize = font.SizeInPoints * (float)e.MarginBounds.Height / height;
                font = new Font(font.FontFamily, emSize);
            }
            e.Graphics.DrawString(this.ContentBox.Text, font, SystemBrushes.WindowText, (RectangleF)e.MarginBounds, format);
        }

        bool zekka_hack_ongoing;
        RichTextBox zekka_hack;
        private void ContentBox_TextChanged(object sender, EventArgs e)
        {
            this.OnContentModified(e);

            // ZEKKA HACKING: Without this, copypasting randomly changes the font size
            // Sorry, this breaks the fonts menu so I disable that
            if (Program.ZEKKA_WORKAROUNDS && !zekka_hack_ongoing)
            {
                try
                {
                    this.SuspendLayout();
                    this.ContentBox.SuspendLayout();
                    zekka_hack_ongoing = true;

                    var selectionStart = this.ContentBox.SelectionStart;
                    var selectionLen = this.ContentBox.SelectionLength;
                    if (zekka_hack == null)
                    {
                        zekka_hack = new RichTextBox();
                        zekka_hack.Font = ContentBox.Font;
                    }
                    zekka_hack.Rtf = ContentBox.Rtf;
                    zekka_hack.SelectAll();
                    zekka_hack.SelectionFont = ContentBox.Font;
                    ContentBox.Rtf = zekka_hack.Rtf;
                    this.ContentBox.Select(selectionStart, selectionLen);
                }
                finally
                {
                    this.ResumeLayout();
                    this.ContentBox.ResumeLayout();
                    zekka_hack_ongoing = false;
                }
            }
        }

        private void ContentBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ContentBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void ContentBox_DragDrop(object sender, DragEventArgs e)
        {
            this.import_data(e.Data);
        }

        private void RightClickCut_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject((object)new DataObject(DataFormats.Rtf, (object)this.ContentBox.SelectedRtf), true);
                this.ContentBox.SelectedText = "";
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void RightClickCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject((object)new DataObject(DataFormats.Rtf, (object)this.ContentBox.SelectedRtf), true);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void RightClickPaste_Click(object sender, EventArgs e)
        {
            try
            {
                this.import_data(Clipboard.GetDataObject());
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void RightClickSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.ContentBox.SelectAll();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void import_data(IDataObject data)
        {
            if (data.GetDataPresent(DataFormats.Rtf))
                this.ContentBox.SelectedRtf = data.GetData(DataFormats.Rtf) as string;
            else if (data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] data1 = data.GetData(DataFormats.FileDrop) as string[];
                string str = "";
                foreach (string path in data1)
                {
                    StreamReader streamReader = new StreamReader(path);
                    str += streamReader.ReadToEnd();
                }
                this.ContentBox.SelectedText = str;
            }
            else
            {
                if (!data.GetDataPresent(typeof(string)))
                    return;
                this.ContentBox.SelectedText = data.GetData(typeof(string)) as string;
            }
        }
    }
}