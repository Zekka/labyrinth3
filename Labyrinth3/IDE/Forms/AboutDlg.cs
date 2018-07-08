// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.AboutDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class AboutDlg : Form
    {
        private Container components = (Container)null;
        private Button OKBn;
        private Label VersionLbl;
        private Label CopyrightLbl;
        private LinkLabel EmailLbl;
        private PictureBox pictureBox1;
        private Label VerLbl;
        private Label CopyLbl;
        private Label SuppLbl;

        public AboutDlg()
        {
            this.InitializeComponent();
            this.VersionLbl.Text = Application.ProductVersion;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ResourceManager resourceManager = new ResourceManager(typeof(AboutDlg));
            this.VersionLbl = new Label();
            this.CopyrightLbl = new Label();
            this.OKBn = new Button();
            this.EmailLbl = new LinkLabel();
            this.pictureBox1 = new PictureBox();
            this.VerLbl = new Label();
            this.CopyLbl = new Label();
            this.SuppLbl = new Label();
            this.SuspendLayout();
            this.VersionLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.VersionLbl.Location = new Point(88, 96);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new Size(176, 23);
            this.VersionLbl.TabIndex = 0;
            this.VersionLbl.Text = "{version}";
            this.VersionLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.CopyrightLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.CopyrightLbl.Location = new Point(88, 128);
            this.CopyrightLbl.Name = "CopyrightLbl";
            this.CopyrightLbl.Size = new Size(176, 23);
            this.CopyrightLbl.TabIndex = 1;
            this.CopyrightLbl.Text = "Karetao 2004";
            this.CopyrightLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.OKBn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBn.DialogResult = DialogResult.OK;
            this.OKBn.Location = new Point(184, 208);
            this.OKBn.Name = "OKBn";
            this.OKBn.TabIndex = 3;
            this.OKBn.Text = "OK";
            this.EmailLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.EmailLbl.Location = new Point(88, 160);
            this.EmailLbl.Name = "EmailLbl";
            this.EmailLbl.Size = new Size(176, 24);
            this.EmailLbl.TabIndex = 2;
            this.EmailLbl.TabStop = true;
            this.EmailLbl.Text = "labyrinth@habitualindolence.net";
            this.EmailLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.EmailLbl.LinkClicked += new LinkLabelLinkClickedEventHandler(this.EmailLbl_LinkClicked);
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox1.Image = (Image)resourceManager.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new Point(29, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(216, 59);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.VerLbl.Location = new Point(16, 96);
            this.VerLbl.Name = "VerLbl";
            this.VerLbl.Size = new Size(64, 23);
            this.VerLbl.TabIndex = 7;
            this.VerLbl.Text = "Version:";
            this.VerLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.CopyLbl.Location = new Point(16, 128);
            this.CopyLbl.Name = "CopyLbl";
            this.CopyLbl.Size = new Size(64, 23);
            this.CopyLbl.TabIndex = 8;
            this.CopyLbl.Text = "Copyright:";
            this.CopyLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.SuppLbl.Location = new Point(16, 160);
            this.SuppLbl.Name = "SuppLbl";
            this.SuppLbl.Size = new Size(64, 23);
            this.SuppLbl.TabIndex = 9;
            this.SuppLbl.Text = "Support:";
            this.SuppLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.AcceptButton = (IButtonControl)this.OKBn;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.ClientSize = new Size(274, 248);
            this.Controls.AddRange(new Control[8]
            {
        (Control) this.SuppLbl,
        (Control) this.CopyLbl,
        (Control) this.VerLbl,
        (Control) this.pictureBox1,
        (Control) this.EmailLbl,
        (Control) this.OKBn,
        (Control) this.CopyrightLbl,
        (Control) this.VersionLbl
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = (Icon)resourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(AboutDlg);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
        }

        private void EmailLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("mailto:" + this.EmailLbl.Text);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }
    }
}