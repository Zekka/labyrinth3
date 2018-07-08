// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.AddInDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Extensibility;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class AddInDlg : Form
    {
        private Button OKBn;
        private TabControl Tabs;
        private TabPage DescPage;
        private TabPage CompPage;
        private RichTextBox DescBox;
        private ListView CompList;
        private ColumnHeader ComponentHdr;
        private ColumnHeader TypeHdr;
        private ColumnHeader DescHdr;
        private ImageList Images;
        private ColumnHeader NameHdr;
        private ColumnHeader VersionHdr;
        private ColumnHeader FileHdr;
        private ListView AddInList;
        private IContainer components;

        public AddInDlg(AddInManager addins)
        {
            this.InitializeComponent();
            this.AddInList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.CompList.ListViewItemSorter = (IComparer)new ListViewSorter();
            foreach (IAddIn addIn in addins.AddIns)
            {
                Assembly assembly = Assembly.GetAssembly(addIn.GetType());
                ListViewItem listViewItem = this.AddInList.Items.Add(addIn.Name);
                listViewItem.SubItems.Add(assembly.GetName().Version.ToString());
                listViewItem.SubItems.Add(assembly.Location);
                listViewItem.ImageIndex = 0;
                listViewItem.Tag = (object)addIn;
            }
            this.AddInList.Items[0].Selected = true;
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
            ResourceManager resourceManager = new ResourceManager(typeof(AddInDlg));
            this.OKBn = new Button();
            this.Tabs = new TabControl();
            this.DescPage = new TabPage();
            this.DescBox = new RichTextBox();
            this.CompPage = new TabPage();
            this.CompList = new ListView();
            this.ComponentHdr = new ColumnHeader();
            this.TypeHdr = new ColumnHeader();
            this.DescHdr = new ColumnHeader();
            this.Images = new ImageList(this.components);
            this.AddInList = new ListView();
            this.NameHdr = new ColumnHeader();
            this.VersionHdr = new ColumnHeader();
            this.FileHdr = new ColumnHeader();
            this.Tabs.SuspendLayout();
            this.DescPage.SuspendLayout();
            this.CompPage.SuspendLayout();
            this.SuspendLayout();
            this.OKBn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBn.DialogResult = DialogResult.OK;
            this.OKBn.Location = new Point(382, 326);
            this.OKBn.Name = "OKBn";
            this.OKBn.TabIndex = 7;
            this.OKBn.Text = "OK";
            this.Tabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Tabs.Controls.AddRange(new Control[2]
            {
        (Control) this.DescPage,
        (Control) this.CompPage
            });
            this.Tabs.Location = new Point(16, 152);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new Size(438, 152);
            this.Tabs.TabIndex = 9;
            this.DescPage.Controls.AddRange(new Control[1]
            {
        (Control) this.DescBox
            });
            ((Control)this.DescPage).Location = new Point(4, 22);
            this.DescPage.Name = "DescPage";
            this.DescPage.Size = new Size(430, 126);
            this.DescPage.TabIndex = 0;
            this.DescPage.Text = "Description";
            this.DescBox.AcceptsTab = true;
            this.DescBox.Dock = DockStyle.Fill;
            this.DescBox.Name = "DescBox";
            this.DescBox.ReadOnly = true;
            this.DescBox.Size = new Size(430, 126);
            this.DescBox.TabIndex = 9;
            this.DescBox.Text = "";
            this.CompPage.Controls.AddRange(new Control[1]
            {
        (Control) this.CompList
            });
            ((Control)this.CompPage).Location = new Point(4, 22);
            this.CompPage.Name = "CompPage";
            this.CompPage.Size = new Size(430, 126);
            this.CompPage.TabIndex = 1;
            this.CompPage.Text = "Components";
            this.CompList.Columns.AddRange(new ColumnHeader[3]
            {
        this.ComponentHdr,
        this.TypeHdr,
        this.DescHdr
            });
            this.CompList.Dock = DockStyle.Fill;
            this.CompList.FullRowSelect = true;
            this.CompList.Name = "CompList";
            this.CompList.Size = new Size(430, 126);
            this.CompList.SmallImageList = this.Images;
            this.CompList.TabIndex = 0;
            this.CompList.View = View.Details;
            this.CompList.ColumnClick += new ColumnClickEventHandler(this.CompList_ColumnClick);
            this.ComponentHdr.Text = "Component";
            this.ComponentHdr.Width = 120;
            this.TypeHdr.Text = "Type";
            this.TypeHdr.Width = 90;
            this.DescHdr.Text = "Description";
            this.DescHdr.Width = 150;
            this.Images.ColorDepth = ColorDepth.Depth8Bit;
            this.Images.ImageSize = new Size(16, 16);
            this.Images.ImageStream = (ImageListStreamer)resourceManager.GetObject("Images.ImageStream");
            this.Images.TransparentColor = Color.Magenta;
            this.AddInList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.AddInList.Columns.AddRange(new ColumnHeader[3]
            {
        this.NameHdr,
        this.VersionHdr,
        this.FileHdr
            });
            this.AddInList.FullRowSelect = true;
            this.AddInList.HideSelection = false;
            this.AddInList.Location = new Point(16, 16);
            this.AddInList.Name = "AddInList";
            this.AddInList.Size = new Size(440, 120);
            this.AddInList.SmallImageList = this.Images;
            this.AddInList.TabIndex = 10;
            this.AddInList.View = View.Details;
            this.AddInList.ColumnClick += new ColumnClickEventHandler(this.AddInList_ColumnClick);
            this.AddInList.SelectedIndexChanged += new EventHandler(this.AddInList_SelectedIndexChanged);
            this.NameHdr.Text = "Add-In";
            this.NameHdr.Width = 120;
            this.VersionHdr.Text = "Version";
            this.VersionHdr.Width = 120;
            this.FileHdr.Text = "Filename";
            this.FileHdr.Width = 150;
            this.AcceptButton = (IButtonControl)this.OKBn;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.ClientSize = new Size(472, 366);
            this.Controls.AddRange(new Control[3]
            {
        (Control) this.AddInList,
        (Control) this.Tabs,
        (Control) this.OKBn
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.Icon = (Icon)resourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(AddInDlg);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add-In Manager";
            this.Tabs.ResumeLayout(false);
            this.DescPage.ResumeLayout(false);
            this.CompPage.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public IAddIn SelectedAddIn
        {
            get
            {
                if (this.AddInList.SelectedItems.Count != 0)
                    return this.AddInList.SelectedItems[0].Tag as IAddIn;
                return (IAddIn)null;
            }
        }

        private void AddInList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.AddInList, e.Column);
        }

        private void CompList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.CompList, e.Column);
        }

        private void AddInList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DescBox.Clear();
            this.CompList.Items.Clear();
            if (this.SelectedAddIn == null)
                return;
            this.DescBox.Text = this.SelectedAddIn.Description;
            foreach (IAddInComponent component in this.SelectedAddIn.Components)
            {
                string text = "";
                if (component is ICommand)
                    text = "Command";
                else if (component is IExplorerPage)
                    text = "Explorer page";
                else if (component is ICustomSearch)
                    text = "Custom search";
                ListViewItem listViewItem = this.CompList.Items.Add(component.Name);
                listViewItem.SubItems.Add(text);
                listViewItem.SubItems.Add(component.Description);
                listViewItem.ImageIndex = 0;
                listViewItem.Tag = (object)component;
            }
        }
    }
}