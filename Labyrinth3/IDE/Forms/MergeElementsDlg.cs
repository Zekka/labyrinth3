// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.MergeElementsDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Controls;
using Labyrinth.Plot;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class MergeElementsDlg : Form
    {
        private Container components = (Container)null;
        private bool text = false;
        private int selected = 0;
        private Label NameLbl;
        private Button OKBtn;
        private Button CancelBtn;
        private Label Step1Lbl;
        private ListView ElementList;
        private Label Step2Lbl;
        private ColumnHeader ElementHdr;
        private Label TypeLbl;
        private ElementTypeBox TypeBox;
        private ComboBox NameBox;

        public MergeElementsDlg()
        {
            this.InitializeComponent();
            this.ElementList.SmallImageList = LabyrinthData.ElementImages;
            this.ElementList.ListViewItemSorter = (IComparer)new ListViewSorter();
            foreach (Element element in LabyrinthData.Project.Elements)
            {
                ListViewItem listViewItem = this.ElementList.Items.Add(element.Name);
                listViewItem.ImageIndex = LabyrinthData.GetImageIndex(element.Type);
                listViewItem.Tag = (object)element;
            }
            this.light_ok();
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
            this.OKBtn = new Button();
            this.CancelBtn = new Button();
            this.Step1Lbl = new Label();
            this.ElementList = new ListView();
            this.ElementHdr = new ColumnHeader();
            this.Step2Lbl = new Label();
            this.TypeLbl = new Label();
            this.TypeBox = new ElementTypeBox();
            this.NameBox = new ComboBox();
            this.SuspendLayout();
            this.NameLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.NameLbl.Location = new Point(16, 270);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new Size(48, 23);
            this.NameLbl.TabIndex = 3;
            this.NameLbl.Text = "Name:";
            this.NameLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBtn.DialogResult = DialogResult.OK;
            this.OKBtn.Location = new Point(192, 344);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new Size(74, 23);
            this.OKBtn.TabIndex = 7;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(272, 344);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new Size(74, 23);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "Cancel";
            this.Step1Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Step1Lbl.Location = new Point(16, 16);
            this.Step1Lbl.Name = "Step1Lbl";
            this.Step1Lbl.Size = new Size(328, 23);
            this.Step1Lbl.TabIndex = 0;
            this.Step1Lbl.Text = "Step 1: Choose the elements to be merged together.";
            this.Step1Lbl.TextAlign = ContentAlignment.MiddleLeft;
            this.ElementList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.ElementList.CheckBoxes = true;
            this.ElementList.Columns.AddRange(new ColumnHeader[1]
            {
        this.ElementHdr
            });
            this.ElementList.Location = new Point(16, 48);
            this.ElementList.Name = "ElementList";
            this.ElementList.Size = new Size(328, 174);
            this.ElementList.TabIndex = 1;
            this.ElementList.View = View.Details;
            this.ElementList.ColumnClick += new ColumnClickEventHandler(this.ElementList_ColumnClick);
            this.ElementList.ItemCheck += new ItemCheckEventHandler(this.ElementList_ItemCheck);
            this.ElementHdr.Text = "Element";
            this.ElementHdr.Width = 300;
            this.Step2Lbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Step2Lbl.Location = new Point(16, 238);
            this.Step2Lbl.Name = "Step2Lbl";
            this.Step2Lbl.Size = new Size(328, 23);
            this.Step2Lbl.TabIndex = 2;
            this.Step2Lbl.Text = "Step 2: Provide a name and type for the new merged element.";
            this.Step2Lbl.TextAlign = ContentAlignment.MiddleLeft;
            this.TypeLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.TypeLbl.Location = new Point(16, 304);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new Size(48, 23);
            this.TypeLbl.TabIndex = 5;
            this.TypeLbl.Text = "Type:";
            this.TypeLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.TypeBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.TypeBox.DrawMode = DrawMode.OwnerDrawVariable;
            this.TypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.TypeBox.Items.AddRange(new object[13]
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
            });
            this.TypeBox.Location = new Point(64, 304);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.SelectedElementType = ElementType.Generic;
            this.TypeBox.Size = new Size(280, 22);
            this.TypeBox.TabIndex = 6;
            this.NameBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.NameBox.Location = new Point(64, 272);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new Size(280, 21);
            this.NameBox.Sorted = true;
            this.NameBox.TabIndex = 9;
            this.AcceptButton = (IButtonControl)this.OKBtn;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(360, 382);
            this.ControlBox = false;
            this.Controls.AddRange(new Control[9]
            {
        (Control) this.NameBox,
        (Control) this.TypeBox,
        (Control) this.TypeLbl,
        (Control) this.Step2Lbl,
        (Control) this.ElementList,
        (Control) this.Step1Lbl,
        (Control) this.CancelBtn,
        (Control) this.OKBtn,
        (Control) this.NameLbl
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(MergeElementsDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Merge Elements";
            this.ResumeLayout(false);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            foreach (ListViewItem checkedItem in this.ElementList.CheckedItems)
            {
                Element tag = checkedItem.Tag as Element;
                if (tag != null)
                    arrayList.Add((object)tag);
            }
            Element[] array = (Element[])arrayList.ToArray(typeof(Element));
            Element newelement = new Element();
            newelement.Name = this.NameBox.Text;
            newelement.Type = this.TypeBox.SelectedElementType;
            LabyrinthData.Project.Elements.Add(newelement);
            LabyrinthData.Project.MergeElements(array, newelement);
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            this.text = this.NameBox.Text != "";
            this.light_ok();
        }

        private void ElementList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.selected = this.ElementList.CheckedItems.Count;
            ListViewItem listViewItem = this.ElementList.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                ++this.selected;
                this.NameBox.Items.Add((object)listViewItem.Text);
            }
            if (e.NewValue == CheckState.Unchecked)
            {
                --this.selected;
                this.NameBox.Items.Remove((object)listViewItem.Text);
            }
            this.light_ok();
        }

        private void ElementList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.ElementList, e.Column);
        }

        private void light_ok()
        {
            this.OKBtn.Enabled = this.text && this.selected > 1;
        }
    }
}
