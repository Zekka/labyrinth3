// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.ElementDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Controls;
using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class ElementDlg : Form
    {
        private Container components = (Container)null;
        private Element fElement = (Element)null;
        private Label NameLbl;
        private TextBox NameBox;
        private Button OKBtn;
        private Button CancelBtn;
        private Label TypeLbl;
        private ElementTypeBox TypeBox;

        public ElementDlg(Element e)
        {
            this.InitializeComponent();
            this.fElement = e;
            this.NameBox.Text = this.fElement.Name;
            this.TypeBox.SelectedElementType = this.fElement.Type;
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
            this.TypeLbl = new Label();
            this.TypeBox = new ElementTypeBox();
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
            this.OKBtn.Location = new Point(128, 98);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new Size(72, 23);
            this.OKBtn.TabIndex = 4;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(208, 98);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new Size(72, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.TypeLbl.Location = new Point(16, 56);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new Size(48, 23);
            this.TypeLbl.TabIndex = 2;
            this.TypeLbl.Text = "Type:";
            this.TypeLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.TypeBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.TypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.TypeBox.Items.AddRange(new object[26]
            {
        (object) ElementType.Generic,
        (object) ElementType.Character,
        (object) ElementType.Organisation,
        (object) ElementType.Website,
        (object) ElementType.EmailAccount,
        (object) ElementType.PhoneNumber,
        (object) ElementType.File,
        (object) ElementType.Puzzle,
        (object) ElementType.Location,
        (object) ElementType.Vehicle,
        (object) ElementType.Concept,
        (object) ElementType.Object,
        (object) ElementType.Event,
        (object) ElementType.Generic,
        (object) ElementType.Character,
        (object) ElementType.Organisation,
        (object) ElementType.Website,
        (object) ElementType.EmailAccount,
        (object) ElementType.PhoneNumber,
        (object) ElementType.File,
        (object) ElementType.Puzzle,
        (object) ElementType.Location,
        (object) ElementType.Vehicle,
        (object) ElementType.Concept,
        (object) ElementType.Object,
        (object) ElementType.Event
            });
            this.TypeBox.Location = new Point(64, 56);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.SelectedElementType = ElementType.Generic;
            this.TypeBox.Size = new Size(216, 22);
            this.TypeBox.TabIndex = 3;
            this.AcceptButton = (IButtonControl)this.OKBtn;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(292, 136);
            this.ControlBox = false;
            this.Controls.AddRange(new Control[6]
            {
        (Control) this.TypeBox,
        (Control) this.TypeLbl,
        (Control) this.CancelBtn,
        (Control) this.OKBtn,
        (Control) this.NameBox,
        (Control) this.NameLbl
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(ElementDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Element Properties";
            this.ResumeLayout(false);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.fElement.Name = this.NameBox.Text;
            this.fElement.Type = this.TypeBox.SelectedElementType;
        }
    }
}