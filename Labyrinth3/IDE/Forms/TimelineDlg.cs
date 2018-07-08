﻿// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.TimelineDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class TimelineDlg : Form
    {
        private Container components = (Container)null;
        private Timeline fTimeline = (Timeline)null;
        private Label NameLbl;
        private TextBox NameBox;
        private Button OKBtn;
        private Button CancelBtn;
        private CheckBox SortBox;

        public TimelineDlg(Timeline tl)
        {
            this.InitializeComponent();
            this.fTimeline = tl;
            this.NameBox.Text = this.fTimeline.Name;
            this.SortBox.Checked = this.fTimeline.Sorting;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.NameLbl = new Label();
            this.NameBox = new TextBox();
            this.OKBtn = new Button();
            this.CancelBtn = new Button();
            this.SortBox = new CheckBox();
            this.SuspendLayout();
            this.NameLbl.Location = new Point(16, 24);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new Size(48, 23);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Name:";
            this.NameLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.NameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.NameBox.Location = new Point(64, 24);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new Size(216, 21);
            this.NameBox.TabIndex = 1;
            this.NameBox.Text = "";
            this.OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBtn.DialogResult = DialogResult.OK;
            this.OKBtn.Location = new Point(128, 106);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new Size(72, 23);
            this.OKBtn.TabIndex = 3;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(208, 106);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new Size(72, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.SortBox.Location = new Point(16, 64);
            this.SortBox.Name = "SortBox";
            this.SortBox.Size = new Size(128, 24);
            this.SortBox.TabIndex = 2;
            this.SortBox.Text = "Sort timeline points";
            this.AcceptButton = (IButtonControl)this.OKBtn;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(292, 144);
            this.ControlBox = false;
            this.Controls.AddRange(new Control[5]
            {
        (Control) this.SortBox,
        (Control) this.CancelBtn,
        (Control) this.OKBtn,
        (Control) this.NameBox,
        (Control) this.NameLbl
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(TimelineDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Timeline Properties";
            this.ResumeLayout(false);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.fTimeline.Name = this.NameBox.Text;
            this.fTimeline.Sorting = this.SortBox.Checked;
        }
    }
}