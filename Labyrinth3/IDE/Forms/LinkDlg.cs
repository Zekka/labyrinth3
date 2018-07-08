// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.LinkDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Collections;
using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class LinkDlg : Form
    {
        private Container components = (Container)null;
        private Labyrinth.Plot.Link fLink = (Labyrinth.Plot.Link)null;
        private Button OKBtn;
        private Button CancelBtn;
        private Label DescLbl;
        private TextBox DescBox;
        private Label DirLbl;
        private ComboBox DirBox;
        private Label FromLbl;
        private Label FromNameLbl;
        private Label ToLbl;
        private Label ToNameLbl;

        public LinkDlg(Labyrinth.Plot.Link l)
        {
            this.InitializeComponent();
            foreach (LinkDirection linkDirection in Enum.GetValues(typeof(LinkDirection)))
                this.DirBox.Items.Add((object)linkDirection);
            this.fLink = l;
            int index1 = LabyrinthData.Project.Elements.IndexOf(l.LHS);
            if (index1 != -1)
                this.FromNameLbl.Text = LabyrinthData.Project.Elements[index1].Name;
            int index2 = LabyrinthData.Project.Elements.IndexOf(l.RHS);
            if (index2 != -1)
                this.ToNameLbl.Text = LabyrinthData.Project.Elements[index2].Name;
            this.DescBox.Text = this.fLink.Description;
            this.DirBox.SelectedItem = (object)this.fLink.Direction;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.DescLbl = new Label();
            this.DescBox = new TextBox();
            this.OKBtn = new Button();
            this.CancelBtn = new Button();
            this.DirLbl = new Label();
            this.DirBox = new ComboBox();
            this.FromLbl = new Label();
            this.FromNameLbl = new Label();
            this.ToLbl = new Label();
            this.ToNameLbl = new Label();
            this.SuspendLayout();
            this.DescLbl.Location = new Point(16, 80);
            this.DescLbl.Name = "DescLbl";
            this.DescLbl.Size = new Size(72, 23);
            this.DescLbl.TabIndex = 4;
            this.DescLbl.Text = "Description:";
            this.DescLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.DescBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.DescBox.Location = new Point(96, 80);
            this.DescBox.Name = "DescBox";
            this.DescBox.Size = new Size(184, 21);
            this.DescBox.TabIndex = 5;
            this.DescBox.Text = "";
            this.OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBtn.DialogResult = DialogResult.OK;
            this.OKBtn.Location = new Point(128, 146);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new Size(72, 23);
            this.OKBtn.TabIndex = 8;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(208, 146);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new Size(72, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.DirLbl.Location = new Point(16, 104);
            this.DirLbl.Name = "DirLbl";
            this.DirLbl.Size = new Size(72, 23);
            this.DirLbl.TabIndex = 6;
            this.DirLbl.Text = "Direction:";
            this.DirLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.DirBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DirBox.Location = new Point(96, 104);
            this.DirBox.Name = "DirBox";
            this.DirBox.Size = new Size(184, 21);
            this.DirBox.TabIndex = 7;
            this.FromLbl.Location = new Point(16, 16);
            this.FromLbl.Name = "FromLbl";
            this.FromLbl.Size = new Size(72, 23);
            this.FromLbl.TabIndex = 0;
            this.FromLbl.Text = "From:";
            this.FromLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.FromNameLbl.Location = new Point(96, 16);
            this.FromNameLbl.Name = "FromNameLbl";
            this.FromNameLbl.Size = new Size(184, 23);
            this.FromNameLbl.TabIndex = 1;
            this.FromNameLbl.Text = "<element name>";
            this.FromNameLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.ToLbl.Location = new Point(16, 40);
            this.ToLbl.Name = "ToLbl";
            this.ToLbl.Size = new Size(72, 23);
            this.ToLbl.TabIndex = 2;
            this.ToLbl.Text = "To:";
            this.ToLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.ToNameLbl.Location = new Point(96, 40);
            this.ToNameLbl.Name = "ToNameLbl";
            this.ToNameLbl.Size = new Size(184, 23);
            this.ToNameLbl.TabIndex = 3;
            this.ToNameLbl.Text = "<element name>";
            this.ToNameLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.AcceptButton = (IButtonControl)this.OKBtn;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(292, 184);
            this.ControlBox = false;
            this.Controls.AddRange(new Control[10]
            {
        (Control) this.ToNameLbl,
        (Control) this.ToLbl,
        (Control) this.FromNameLbl,
        (Control) this.FromLbl,
        (Control) this.DirBox,
        (Control) this.DirLbl,
        (Control) this.CancelBtn,
        (Control) this.OKBtn,
        (Control) this.DescBox,
        (Control) this.DescLbl
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(LinkDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Link Properties";
            this.ResumeLayout(false);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.fLink.Description = this.DescBox.Text;
            this.fLink.Direction = (LinkDirection)this.DirBox.SelectedItem;
        }
    }
}