// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.TextAnnotationDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Controls;
using Labyrinth.Plot;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class TextAnnotationDlg : Form
    {
        private TextAnnotation fNote = (TextAnnotation)null;
        private Label TitleLbl;
        private TextBox TitleBox;
        private Button OKBtn;
        private Button CancelBtn;
        private Panel ContentPanel;
        private RTFPanel RTFPanel;

        public TextAnnotationDlg(TextAnnotation note)
        {
            this.InitializeComponent();
            Application.Idle += new EventHandler(this.update_rtfpanel);
            this.fNote = note;
            this.TitleBox.Text = this.fNote.Title;
            if (this.fNote.RTF != "")
                this.RTFPanel.RTF = this.fNote.RTF;
            else
                this.RTFPanel.Text = this.fNote.Content;
        }

        private void InitializeComponent()
        {
            ResourceManager resourceManager = new ResourceManager(typeof(TextAnnotationDlg));
            this.OKBtn = new Button();
            this.CancelBtn = new Button();
            this.TitleLbl = new Label();
            this.TitleBox = new TextBox();
            this.ContentPanel = new Panel();
            this.RTFPanel = new RTFPanel();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            this.OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBtn.DialogResult = DialogResult.OK;
            this.OKBtn.Location = new Point(340, 280);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.TabIndex = 3;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(420, 280);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.TitleLbl.Location = new Point(16, 16);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new Size(48, 23);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Title:";
            this.TitleLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.TitleBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.TitleBox.Location = new Point(72, 16);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new Size(424, 21);
            this.TitleBox.TabIndex = 1;
            this.TitleBox.Text = "";
            this.ContentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.ContentPanel.Controls.AddRange(new Control[1]
            {
        (Control) this.RTFPanel
            });
            this.ContentPanel.Location = new Point(16, 56);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new Size(480, 208);
            this.ContentPanel.TabIndex = 2;
            this.RTFPanel.Dock = DockStyle.Fill;
            this.RTFPanel.Name = "RTFPanel";
            this.RTFPanel.Size = new Size(480, 208);
            this.RTFPanel.TabIndex = 0;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(512, 318);
            this.Controls.AddRange(new Control[5]
            {
        (Control) this.ContentPanel,
        (Control) this.TitleBox,
        (Control) this.TitleLbl,
        (Control) this.CancelBtn,
        (Control) this.OKBtn
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.Icon = (Icon)resourceManager.GetObject("$this.Icon");
            this.MinimizeBox = false;
            this.Name = nameof(TextAnnotationDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Text Annotation Properties";
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.fNote.Title = this.TitleBox.Text;
            this.fNote.Content = this.RTFPanel.Text;
            this.fNote.RTF = this.RTFPanel.RTF;
        }

        private void update_rtfpanel(object sender, EventArgs e)
        {
            this.RTFPanel.UpdateUI();
        }
    }
}