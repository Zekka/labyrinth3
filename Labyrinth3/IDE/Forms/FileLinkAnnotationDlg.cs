// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.FileLinkAnnotationDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class FileLinkAnnotationDlg : Form
    {
        private LinkAnnotation fNote = (LinkAnnotation)null;
        private ImageList ToolbarImages;
        private Button OKBtn;
        private Button CancelBtn;
        private Label LinkLbl;
        private Button BrowseBtn;
        private Label SizeLbl;
        private Label CreatedLbl;
        private Label LastAccessedLbl;
        private Label LastModifiedLbl;
        private Label AttributesLbl;
        private Label AttributesValLbl;
        private Label LastModifiedValLbl;
        private Label LastAccessedValLbl;
        private Label CreatedValLbl;
        private Label SizeValLbl;
        private LinkLabel FilenameLbl;
        private IContainer components;

        public FileLinkAnnotationDlg(LinkAnnotation note)
        {
            this.InitializeComponent();
            this.fNote = note;
            if (this.fNote.Content == "")
            {
                this.FilenameLbl.Text = "(no file specified)";
                this.FilenameLbl.Links.Clear();
            }
            else
                this.FilenameLbl.Text = this.fNote.Content;
            this.update_details();
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
            ResourceManager resourceManager = new ResourceManager(typeof(FileLinkAnnotationDlg));
            this.ToolbarImages = new ImageList(this.components);
            this.OKBtn = new Button();
            this.CancelBtn = new Button();
            this.LinkLbl = new Label();
            this.BrowseBtn = new Button();
            this.SizeLbl = new Label();
            this.CreatedLbl = new Label();
            this.LastAccessedLbl = new Label();
            this.LastModifiedLbl = new Label();
            this.AttributesLbl = new Label();
            this.AttributesValLbl = new Label();
            this.LastModifiedValLbl = new Label();
            this.LastAccessedValLbl = new Label();
            this.CreatedValLbl = new Label();
            this.SizeValLbl = new Label();
            this.FilenameLbl = new LinkLabel();
            this.SuspendLayout();
            this.ToolbarImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ToolbarImages.ImageSize = new Size(16, 16);
            this.ToolbarImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ToolbarImages.ImageStream");
            this.ToolbarImages.TransparentColor = Color.Magenta;
            this.OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBtn.DialogResult = DialogResult.OK;
            this.OKBtn.Location = new Point(140, 200);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.TabIndex = 13;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(220, 200);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.TabIndex = 14;
            this.CancelBtn.Text = "Cancel";
            this.LinkLbl.Location = new Point(16, 16);
            this.LinkLbl.Name = "LinkLbl";
            this.LinkLbl.Size = new Size(32, 23);
            this.LinkLbl.TabIndex = 0;
            this.LinkLbl.Text = "File:";
            this.LinkLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.BrowseBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.BrowseBtn.Location = new Point(264, 16);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new Size(32, 23);
            this.BrowseBtn.TabIndex = 2;
            this.BrowseBtn.Text = "...";
            this.BrowseBtn.Click += new EventHandler(this.BrowseBtn_Click);
            this.SizeLbl.Location = new Point(16, 56);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new Size(88, 23);
            this.SizeLbl.TabIndex = 3;
            this.SizeLbl.Text = "Size:";
            this.CreatedLbl.Location = new Point(16, 80);
            this.CreatedLbl.Name = "CreatedLbl";
            this.CreatedLbl.Size = new Size(88, 23);
            this.CreatedLbl.TabIndex = 5;
            this.CreatedLbl.Text = "Created:";
            this.LastAccessedLbl.Location = new Point(16, 128);
            this.LastAccessedLbl.Name = "LastAccessedLbl";
            this.LastAccessedLbl.Size = new Size(88, 23);
            this.LastAccessedLbl.TabIndex = 9;
            this.LastAccessedLbl.Text = "Last Accessed:";
            this.LastModifiedLbl.Location = new Point(16, 104);
            this.LastModifiedLbl.Name = "LastModifiedLbl";
            this.LastModifiedLbl.Size = new Size(88, 23);
            this.LastModifiedLbl.TabIndex = 7;
            this.LastModifiedLbl.Text = "Last Modified:";
            this.AttributesLbl.Location = new Point(16, 152);
            this.AttributesLbl.Name = "AttributesLbl";
            this.AttributesLbl.Size = new Size(88, 23);
            this.AttributesLbl.TabIndex = 11;
            this.AttributesLbl.Text = "Attributes:";
            this.AttributesValLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.AttributesValLbl.Location = new Point(112, 152);
            this.AttributesValLbl.Name = "AttributesValLbl";
            this.AttributesValLbl.Size = new Size(184, 40);
            this.AttributesValLbl.TabIndex = 12;
            this.AttributesValLbl.Text = "xxx";
            this.LastModifiedValLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.LastModifiedValLbl.Location = new Point(112, 104);
            this.LastModifiedValLbl.Name = "LastModifiedValLbl";
            this.LastModifiedValLbl.Size = new Size(184, 23);
            this.LastModifiedValLbl.TabIndex = 8;
            this.LastModifiedValLbl.Text = "xxx";
            this.LastAccessedValLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.LastAccessedValLbl.Location = new Point(112, 128);
            this.LastAccessedValLbl.Name = "LastAccessedValLbl";
            this.LastAccessedValLbl.Size = new Size(184, 23);
            this.LastAccessedValLbl.TabIndex = 10;
            this.LastAccessedValLbl.Text = "xxx";
            this.CreatedValLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.CreatedValLbl.Location = new Point(112, 80);
            this.CreatedValLbl.Name = "CreatedValLbl";
            this.CreatedValLbl.Size = new Size(184, 23);
            this.CreatedValLbl.TabIndex = 6;
            this.CreatedValLbl.Text = "xxx";
            this.SizeValLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.SizeValLbl.Location = new Point(112, 56);
            this.SizeValLbl.Name = "SizeValLbl";
            this.SizeValLbl.Size = new Size(184, 23);
            this.SizeValLbl.TabIndex = 4;
            this.SizeValLbl.Text = "xxx";
            this.FilenameLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.FilenameLbl.Location = new Point(56, 16);
            this.FilenameLbl.Name = "FilenameLbl";
            this.FilenameLbl.Size = new Size(208, 23);
            this.FilenameLbl.TabIndex = 1;
            this.FilenameLbl.TabStop = true;
            this.FilenameLbl.Text = "filename";
            this.FilenameLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.FilenameLbl.LinkClicked += new LinkLabelLinkClickedEventHandler(this.FilenameLbl_LinkClicked);
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(312, 238);
            this.Controls.AddRange(new Control[15]
            {
        (Control) this.FilenameLbl,
        (Control) this.AttributesValLbl,
        (Control) this.LastModifiedValLbl,
        (Control) this.LastAccessedValLbl,
        (Control) this.CreatedValLbl,
        (Control) this.SizeValLbl,
        (Control) this.AttributesLbl,
        (Control) this.LastModifiedLbl,
        (Control) this.LastAccessedLbl,
        (Control) this.CreatedLbl,
        (Control) this.SizeLbl,
        (Control) this.BrowseBtn,
        (Control) this.LinkLbl,
        (Control) this.CancelBtn,
        (Control) this.OKBtn
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.Icon = (Icon)resourceManager.GetObject("$this.Icon");
            this.MinimizeBox = false;
            this.Name = nameof(FileLinkAnnotationDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "File Link Annotation Properties";
            this.ResumeLayout(false);
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

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.fNote.Content = this.FilenameLbl.Text;
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.FileName = this.FilenameLbl.Text;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.FilenameLbl.Text = openFileDialog.FileName;
            this.FilenameLbl.Links.Clear();
            this.FilenameLbl.Links.Add(0, this.FilenameLbl.Text.Length);
            this.update_details();
        }

        private void FilenameLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(this.FilenameLbl.Text);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
                int num = (int)MessageBox.Show(ex.Message, "Labyrinth", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void update_details()
        {
            this.SizeValLbl.Text = "-";
            this.CreatedValLbl.Text = "-";
            this.LastModifiedValLbl.Text = "-";
            this.LastAccessedValLbl.Text = "-";
            this.AttributesValLbl.Text = "-";
            try
            {
                FileInfo fileInfo = new FileInfo(this.FilenameLbl.Text);
                if (!fileInfo.Exists)
                    return;
                string str1 = fileInfo.Length >= 1024L ? (fileInfo.Length >= 1048576L ? (fileInfo.Length >= 1073741824L ? ((double)fileInfo.Length / 1073741824.0).ToString("F1") + " Gb" : ((double)fileInfo.Length / 1048576.0).ToString("F1") + " Mb") : ((double)fileInfo.Length / 1024.0).ToString("F1") + " kb") : fileInfo.Length.ToString() + " bytes";
                DateTime dateTime = fileInfo.CreationTime;
                string shortDateString1 = dateTime.ToShortDateString();
                string str2 = ", ";
                dateTime = fileInfo.CreationTime;
                string shortTimeString1 = dateTime.ToShortTimeString();
                string str3 = shortDateString1 + str2 + shortTimeString1;
                dateTime = fileInfo.LastWriteTime;
                string shortDateString2 = dateTime.ToShortDateString();
                string str4 = ", ";
                dateTime = fileInfo.LastWriteTime;
                string shortTimeString2 = dateTime.ToShortTimeString();
                string str5 = shortDateString2 + str4 + shortTimeString2;
                dateTime = fileInfo.LastAccessTime;
                string shortDateString3 = dateTime.ToShortDateString();
                string str6 = ", ";
                dateTime = fileInfo.LastAccessTime;
                string shortTimeString3 = dateTime.ToShortTimeString();
                string str7 = shortDateString3 + str6 + shortTimeString3;
                string str8 = fileInfo.Attributes.ToString();
                this.SizeValLbl.Text = str1;
                this.CreatedValLbl.Text = str3;
                this.LastModifiedValLbl.Text = str5;
                this.LastAccessedValLbl.Text = str7;
                this.AttributesValLbl.Text = str8;
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }
    }
}