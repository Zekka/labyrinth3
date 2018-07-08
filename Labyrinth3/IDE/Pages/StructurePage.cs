// Decompiled with JetBrains decompiler
// Type: Labyrinth.Pages.StructurePage
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Collections;
using Labyrinth.Controls;
using Labyrinth.Events;
using Labyrinth.Extensibility;
using Labyrinth.Forms;
using Labyrinth.Plot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Pages
{
    public class StructurePage : UserControl, IStructurePage, IPage
    {
        private Structure fStructure = (Structure)null;
        private int fZoom = 0;
        private IContainer components;
        private ToolBar ToolBar;
        private ListView LinkList;
        private ColumnHeader LinkTextHdr;
        private Splitter ListSplitter;
        private StructureView StructureView;
        private ToolBarButton AddLinkBtn;
        private ImageList Images;
        private ContextMenu StructureContextMenu;
        private ContextMenu LinkContextMenu;
        private MenuItem StructureOpenElement;
        private MenuItem StructureDeleteNode;
        private MenuItem StructureElementProperties;
        private MenuItem LinkDeleteLink;
        private MenuItem LinkLinkProperties;
        private ToolBarButton ExportBtn;
        private ToolBarButton Sep1;
        private ToolBarButton Sep2;
        private ToolBarButton PrintBtn;
        private ToolBarButton PrintPreviewBtn;
        private ToolBarButton ShowLinksPanelBtn;
        private ToolBarButton ShowArrowsBtn;
        private ToolBarButton ShowTextBtn;
        private ColumnHeader FromHdr;
        private ColumnHeader ToHdr;
        private MenuItem LinkReverseLink;
        private Panel StructurePanel;
        private ToolBarButton Sep3;
        private ToolBarButton ZoomInBtn;
        private ToolBarButton ZoomOutBtn;
        private ToolBarButton PropertiesBtn;

        public StructurePage(Structure s)
        {
            this.InitializeComponent();
            this.LinkList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.fStructure = s;
            this.StructureView.Location = new Point(0, 0);
            this.StructureView.Structure = this.fStructure;
            this.LinkList.Visible = false;
            this.ListSplitter.Visible = false;
            this.UpdateData();
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
            ResourceManager resourceManager = new ResourceManager(typeof(StructurePage));
            this.Images = new ImageList(this.components);
            this.ToolBar = new ToolBar();
            this.PropertiesBtn = new ToolBarButton();
            this.Sep1 = new ToolBarButton();
            this.AddLinkBtn = new ToolBarButton();
            this.ShowLinksPanelBtn = new ToolBarButton();
            this.ShowArrowsBtn = new ToolBarButton();
            this.ShowTextBtn = new ToolBarButton();
            this.Sep2 = new ToolBarButton();
            this.PrintBtn = new ToolBarButton();
            this.PrintPreviewBtn = new ToolBarButton();
            this.ExportBtn = new ToolBarButton();
            this.LinkList = new ListView();
            this.FromHdr = new ColumnHeader();
            this.ToHdr = new ColumnHeader();
            this.LinkTextHdr = new ColumnHeader();
            this.LinkContextMenu = new ContextMenu();
            this.LinkReverseLink = new MenuItem();
            this.LinkDeleteLink = new MenuItem();
            this.LinkLinkProperties = new MenuItem();
            this.ListSplitter = new Splitter();
            this.StructureView = new StructureView();
            this.StructureContextMenu = new ContextMenu();
            this.StructureOpenElement = new MenuItem();
            this.StructureDeleteNode = new MenuItem();
            this.StructureElementProperties = new MenuItem();
            this.StructurePanel = new Panel();
            this.Sep3 = new ToolBarButton();
            this.ZoomInBtn = new ToolBarButton();
            this.ZoomOutBtn = new ToolBarButton();
            this.StructurePanel.SuspendLayout();
            this.SuspendLayout();
            this.Images.ColorDepth = ColorDepth.Depth8Bit;
            this.Images.ImageSize = new Size(16, 16);
            this.Images.ImageStream = (ImageListStreamer)resourceManager.GetObject("Images.ImageStream");
            this.Images.TransparentColor = Color.Magenta;
            this.ToolBar.Appearance = ToolBarAppearance.Flat;
            this.ToolBar.Buttons.AddRange(new ToolBarButton[13]
            {
        this.PropertiesBtn,
        this.Sep1,
        this.AddLinkBtn,
        this.ShowLinksPanelBtn,
        this.ShowArrowsBtn,
        this.ShowTextBtn,
        this.Sep2,
        this.PrintBtn,
        this.PrintPreviewBtn,
        this.ExportBtn,
        this.Sep3,
        this.ZoomInBtn,
        this.ZoomOutBtn
            });
            this.ToolBar.DropDownArrows = true;
            this.ToolBar.ImageList = this.Images;
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.ShowToolTips = true;
            this.ToolBar.Size = new Size(448, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.ToolBar_ButtonClick);
            this.PropertiesBtn.ImageIndex = 0;
            this.Sep1.Style = ToolBarButtonStyle.Separator;
            this.AddLinkBtn.ImageIndex = 3;
            this.AddLinkBtn.ToolTipText = "Add Link";
            this.ShowLinksPanelBtn.ImageIndex = 4;
            this.ShowLinksPanelBtn.ToolTipText = "Show Links Panel";
            this.ShowArrowsBtn.ImageIndex = 5;
            this.ShowArrowsBtn.ToolTipText = "Show Arrows";
            this.ShowTextBtn.ImageIndex = 6;
            this.ShowTextBtn.ToolTipText = "Show Link Text";
            this.Sep2.Style = ToolBarButtonStyle.Separator;
            this.PrintBtn.ImageIndex = 1;
            this.PrintBtn.ToolTipText = "Print";
            this.PrintPreviewBtn.ImageIndex = 2;
            this.PrintPreviewBtn.ToolTipText = "Print Preview";
            this.ExportBtn.ImageIndex = 7;
            this.ExportBtn.ToolTipText = "Export Structure";
            this.LinkList.Columns.AddRange(new ColumnHeader[3]
            {
        this.FromHdr,
        this.ToHdr,
        this.LinkTextHdr
            });
            this.LinkList.ContextMenu = this.LinkContextMenu;
            this.LinkList.Dock = DockStyle.Bottom;
            this.LinkList.FullRowSelect = true;
            this.LinkList.Location = new Point(0, 176);
            this.LinkList.Name = "LinkList";
            this.LinkList.Size = new Size(448, 88);
            this.LinkList.SmallImageList = this.Images;
            this.LinkList.Sorting = SortOrder.Ascending;
            this.LinkList.TabIndex = 3;
            this.LinkList.View = View.Details;
            this.LinkList.MouseDown += new MouseEventHandler(this.LinkList_MouseDown);
            this.LinkList.DoubleClick += new EventHandler(this.LinkList_DoubleClick);
            this.LinkList.ColumnClick += new ColumnClickEventHandler(this.LinkList_ColumnClick);
            this.FromHdr.Text = "From";
            this.FromHdr.Width = 120;
            this.ToHdr.Text = "To";
            this.ToHdr.Width = 120;
            this.LinkTextHdr.Text = "Link Text";
            this.LinkTextHdr.Width = 180;
            this.LinkContextMenu.MenuItems.AddRange(new MenuItem[3]
            {
        this.LinkReverseLink,
        this.LinkDeleteLink,
        this.LinkLinkProperties
            });
            this.LinkReverseLink.Index = 0;
            this.LinkReverseLink.Text = "Reverse Link";
            this.LinkReverseLink.Click += new EventHandler(this.LinkReverseLink_Click);
            this.LinkDeleteLink.Index = 1;
            this.LinkDeleteLink.Text = "Delete Link";
            this.LinkDeleteLink.Click += new EventHandler(this.LinkDeleteLink_Click);
            this.LinkLinkProperties.Index = 2;
            this.LinkLinkProperties.Text = "Link Properties";
            this.LinkLinkProperties.Click += new EventHandler(this.LinkLinkProperties_Click);
            this.ListSplitter.Dock = DockStyle.Bottom;
            this.ListSplitter.Location = new Point(0, 173);
            this.ListSplitter.Name = "ListSplitter";
            this.ListSplitter.Size = new Size(448, 3);
            this.ListSplitter.TabIndex = 2;
            this.ListSplitter.TabStop = false;
            this.StructureView.AddingLink = false;
            this.StructureView.AllowDrop = true;
            this.StructureView.BackColor = SystemColors.ControlDark;
            this.StructureView.ContextMenu = this.StructureContextMenu;
            this.StructureView.Location = new Point(8, 8);
            this.StructureView.Name = "StructureView";
            this.StructureView.ShowArrows = true;
            this.StructureView.ShowText = true;
            this.StructureView.Size = new Size(328, 103);
            this.StructureView.Structure = (Structure)null;
            this.StructureView.TabIndex = 1;
            this.StructureView.StructureModified += new EventHandler(this.StructureView_StructureModified);
            this.StructureView.DragDrop += new DragEventHandler(this.StructureView_DragDrop);
            this.StructureView.DoubleClick += new EventHandler(this.StructureView_DoubleClick);
            this.StructureView.DragOver += new DragEventHandler(this.StructureView_DragOver);
            this.StructureContextMenu.MenuItems.AddRange(new MenuItem[3]
            {
        this.StructureOpenElement,
        this.StructureDeleteNode,
        this.StructureElementProperties
            });
            this.StructureOpenElement.Index = 0;
            this.StructureOpenElement.Text = "Open Element";
            this.StructureOpenElement.Click += new EventHandler(this.StructureOpenElement_Click);
            this.StructureDeleteNode.Index = 1;
            this.StructureDeleteNode.Text = "Remove Element";
            this.StructureDeleteNode.Click += new EventHandler(this.StructureDeleteNode_Click);
            this.StructureElementProperties.Index = 2;
            this.StructureElementProperties.Text = "Element Properties";
            this.StructureElementProperties.Click += new EventHandler(this.StructureElementProperties_Click);
            this.StructurePanel.AutoScroll = true;
            this.StructurePanel.Controls.AddRange(new Control[1]
            {
        (Control) this.StructureView
            });
            this.StructurePanel.Dock = DockStyle.Fill;
            this.StructurePanel.Location = new Point(0, 25);
            this.StructurePanel.Name = "StructurePanel";
            this.StructurePanel.Size = new Size(448, 148);
            this.StructurePanel.TabIndex = 4;
            this.StructurePanel.Layout += new LayoutEventHandler(this.StructurePanel_Layout);
            this.Sep3.Style = ToolBarButtonStyle.Separator;
            this.ZoomInBtn.ImageIndex = 8;
            this.ZoomInBtn.ToolTipText = "Zoom In";
            this.ZoomOutBtn.ImageIndex = 9;
            this.ZoomOutBtn.ToolTipText = "Zoom Out";
            this.Controls.AddRange(new Control[4]
            {
        (Control) this.StructurePanel,
        (Control) this.ListSplitter,
        (Control) this.LinkList,
        (Control) this.ToolBar
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.Name = nameof(StructurePage);
            this.Size = new Size(448, 264);
            this.StructurePanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public string Title
        {
            get
            {
                return this.fStructure.Name;
            }
        }

        public bool IsObsolete
        {
            get
            {
                return LabyrinthData.Project.Structures.IndexOf(this.fStructure) == -1;
            }
        }

        public void UpdateUI()
        {
            this.PropertiesBtn.Enabled = true;
            this.PrintBtn.Enabled = true;
            this.PrintPreviewBtn.Enabled = true;
            this.AddLinkBtn.Enabled = this.fStructure.Nodes.Count >= 2;
            this.AddLinkBtn.Pushed = this.StructureView.AddingLink;
            this.ShowLinksPanelBtn.Enabled = true;
            this.ShowLinksPanelBtn.Pushed = this.LinkList.Visible;
            this.ShowArrowsBtn.Enabled = true;
            this.ShowArrowsBtn.Pushed = this.StructureView.ShowArrows;
            this.ShowTextBtn.Enabled = true;
            this.ShowTextBtn.Pushed = this.StructureView.ShowText;
            this.ExportBtn.Enabled = true;
            this.ZoomInBtn.Enabled = true;
            this.ZoomOutBtn.Enabled = this.fZoom != 0;
            this.StructureOpenElement.Enabled = this.StructureView.SelectedNode != null;
            this.StructureDeleteNode.Enabled = this.StructureView.SelectedNode != null;
            this.StructureElementProperties.Enabled = this.StructureView.SelectedNode != null;
            this.LinkDeleteLink.Enabled = this.SelectedLink != null;
            this.LinkLinkProperties.Enabled = this.SelectedLink != null;
        }

        public void UpdateData()
        {
            this.StructureView.Refresh();
            this.update_links();
        }

        public Structure Structure
        {
            get
            {
                return this.fStructure;
            }
        }

        public Node SelectedNode
        {
            get
            {
                return this.StructureView.SelectedNode;
            }
        }

        public Labyrinth.Plot.Link SelectedLink
        {
            get
            {
                if (this.LinkList.SelectedItems.Count != 0)
                    return this.LinkList.SelectedItems[0].Tag as Labyrinth.Plot.Link;
                return (Labyrinth.Plot.Link)null;
            }
        }

        public int Zoom
        {
            get
            {
                return this.fZoom;
            }
            set
            {
                if (this.fZoom == value)
                    return;
                this.fZoom = value;
                this.resize_structure();
            }
        }

        public event StructureEventHandler StructureModified;

        public event ElementEventHandler ElementActivated;

        public event ElementEventHandler ElementModified;

        protected void OnStructureModified(StructureEventArgs e)
        {
            try
            {
                if (this.StructureModified == null)
                    return;
                this.StructureModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnElementActivated(ElementEventArgs e)
        {
            try
            {
                if (this.ElementActivated == null)
                    return;
                this.ElementActivated((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnElementModified(ElementEventArgs e)
        {
            try
            {
                if (this.ElementModified == null)
                    return;
                this.ElementModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.PropertiesBtn)
                {
                    if (new StructureDlg(this.fStructure).ShowDialog() != DialogResult.OK)
                        return;
                    this.UpdateData();
                    this.OnStructureModified(new StructureEventArgs(this.fStructure));
                }
                else if (e.Button == this.AddLinkBtn)
                    this.StructureView.AddingLink = !this.StructureView.AddingLink;
                else if (e.Button == this.ShowLinksPanelBtn)
                {
                    bool visible = this.LinkList.Visible;
                    this.ListSplitter.Visible = !visible;
                    this.LinkList.Visible = !visible;
                }
                else if (e.Button == this.ShowArrowsBtn)
                {
                    this.StructureView.ShowArrows = !this.StructureView.ShowArrows;
                    this.Refresh();
                }
                else if (e.Button == this.ShowTextBtn)
                {
                    this.StructureView.ShowText = !this.StructureView.ShowText;
                    this.Refresh();
                }
                else if (e.Button == this.ExportBtn)
                {
                    string str = "JPG Images|*.jpg|GIF Images|*.gif|Bitmaps|*.bmp";
                    try
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.FileName = this.fStructure.Name;
                        saveFileDialog.Filter = str;
                        if (saveFileDialog.ShowDialog() != DialogResult.OK)
                            return;
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1:
                                this.StructureView.CreateImage().Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                                break;

                            case 2:
                                this.StructureView.CreateImage().Save(saveFileDialog.FileName, ImageFormat.Gif);
                                break;

                            case 3:
                                this.StructureView.CreateImage().Save(saveFileDialog.FileName, ImageFormat.Bmp);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        LabyrinthData.Log((object)ex);
                    }
                }
                else if (e.Button == this.PrintBtn)
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
                else if (e.Button == this.ZoomInBtn)
                {
                    ++this.fZoom;
                    this.resize_structure();
                }
                else
                {
                    if (e.Button != this.ZoomOutBtn)
                        return;
                    --this.fZoom;
                    if (this.fZoom < 0)
                        this.fZoom = 0;
                    this.resize_structure();
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
            printDocument.DocumentName = LabyrinthData.Project.Name + ": " + this.fStructure.Name;
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
            string str = LabyrinthData.Project.Name + ": " + this.fStructure.Name;
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
            this.StructureView.Render(e.Graphics, marginBounds2);
        }

        private void StructureView_StructureModified(object sender, EventArgs e)
        {
            this.update_links();
            this.OnStructureModified(new StructureEventArgs(this.fStructure));
        }

        private void update_links()
        {
            this.LinkList.BeginUpdate();
            this.LinkList.Items.Clear();
            if (this.fStructure.Links.Count != 0)
            {
                ArrayList arrayList = new ArrayList();
                foreach (Labyrinth.Plot.Link link in this.fStructure.Links)
                {
                    Element element1 = this.get_element(link.LHS);
                    Element element2 = this.get_element(link.RHS);
                    if (element1 != null && element2 != null)
                        arrayList.Add((object)new ListViewItem(element1.Name)
                        {
                            SubItems = {
                element2.Name,
                link.Description
              },
                            ImageIndex = 3,
                            Tag = (object)link
                        });
                }
                this.LinkList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            }
            else
            {
                ListViewItem listViewItem = this.LinkList.Items.Add("No links");
                listViewItem.ForeColor = SystemColors.GrayText;
                listViewItem.ImageIndex = -1;
            }
            this.LinkList.EndUpdate();
        }

        private Element get_element(Guid id)
        {
            int index = LabyrinthData.Project.Elements.IndexOf(id);
            if (index != -1)
                return LabyrinthData.Project.Elements[index];
            return (Element)null;
        }

        private void StructureOpenElement_Click(object sender, EventArgs e)
        {
            if (this.StructureView.SelectedNode == null)
                return;
            Element element = this.get_element(this.StructureView.SelectedNode.ElementID);
            if (element == null)
                return;
            this.OnElementActivated(new ElementEventArgs(element));
        }

        private void StructureDeleteNode_Click(object sender, EventArgs e)
        {
            if (this.StructureView.SelectedNode == null || MessageBox.Show("Delete reference: are you sure?" + "\n" + "The element will not be deleted.", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.fStructure.RemoveElement(this.StructureView.SelectedNode.ElementID);
            this.StructureView.Refresh();
            this.update_links();
            this.OnStructureModified(new StructureEventArgs(this.fStructure));
        }

        private void StructureElementProperties_Click(object sender, EventArgs e)
        {
            if (this.StructureView.SelectedNode == null)
                return;
            Element element = this.get_element(this.StructureView.SelectedNode.ElementID);
            if (element == null || new ElementDlg(element).ShowDialog() != DialogResult.OK)
                return;
            this.StructureView.Refresh();
            this.update_links();
            this.OnElementModified(new ElementEventArgs(element));
        }

        private void LinkReverseLink_Click(object sender, EventArgs e)
        {
            if (this.SelectedLink == null)
                return;
            Guid lhs = this.SelectedLink.LHS;
            this.SelectedLink.LHS = this.SelectedLink.RHS;
            this.SelectedLink.RHS = lhs;
            this.StructureView.Refresh();
            this.update_links();
            this.OnStructureModified(new StructureEventArgs(this.fStructure));
        }

        private void LinkDeleteLink_Click(object sender, EventArgs e)
        {
            if (this.SelectedLink == null || MessageBox.Show("Delete link: are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.fStructure.Links.Remove(this.SelectedLink);
            this.StructureView.Refresh();
            this.update_links();
            this.OnStructureModified(new StructureEventArgs(this.fStructure));
        }

        private void LinkLinkProperties_Click(object sender, EventArgs e)
        {
            if (this.SelectedLink == null || new LinkDlg(this.SelectedLink).ShowDialog() != DialogResult.OK)
                return;
            this.StructureView.Refresh();
            this.update_links();
            this.OnStructureModified(new StructureEventArgs(this.fStructure));
        }

        private void StructureView_DoubleClick(object sender, EventArgs e)
        {
            if (this.StructureView.SelectedNode == null)
                return;
            this.StructureOpenElement_Click(sender, e);
        }

        private void LinkList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedLink == null)
                return;
            this.LinkLinkProperties_Click(sender, e);
        }

        private void LinkList_MouseDown(object sender, MouseEventArgs e)
        {
            this.LinkList.SelectedItems.Clear();
            ListViewItem itemAt = this.LinkList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.UpdateUI();
        }

        private void StructureView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            Element data1 = e.Data.GetData(typeof(Element)) as Element;
            Structure data2 = e.Data.GetData(typeof(Structure)) as Structure;
            Timeline data3 = e.Data.GetData(typeof(Timeline)) as Timeline;
            if (data1 == null && (data2 == null || data2 == this.fStructure) && data3 == null)
                return;
            e.Effect = DragDropEffects.Copy;
        }

        private void StructureView_DragDrop(object sender, DragEventArgs e)
        {
            Point client = this.StructureView.PointToClient(Cursor.Position);
            bool flag = false;
            Element data1 = e.Data.GetData(typeof(Element)) as Element;
            if (data1 != null)
            {
                if (this.find_node(data1.ID) != null)
                {
                    int num = (int)MessageBox.Show("This element is already part of this structure.", "Labyrinth", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                List<Guid> ids = new List<Guid>();
                ids.Add(data1.ID);
                flag = this.add_elements(ids, client);
            }
            Structure data2 = e.Data.GetData(typeof(Structure)) as Structure;
            if (data2 != null)
            {
                if (MessageBox.Show("Do you want to add all the elements from this structure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                List<Guid> ids = new List<Guid>();
                foreach (Node node in data2.Nodes)
                {
                    if (this.find_node(node.ElementID) == null)
                        ids.Add(node.ElementID);
                }
                flag = this.add_elements(ids, client);
            }
            Timeline data3 = e.Data.GetData(typeof(Timeline)) as Timeline;
            if (data3 != null)
            {
                if (MessageBox.Show("Do you want to add all the elements from this timeline?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                flag = this.add_elements(data3.ElementIDs, client);
            }
            if (!flag)
                return;
            this.Refresh();
            this.OnStructureModified(new StructureEventArgs(this.fStructure));
        }

        private bool add_elements(List<Guid> ids, Point p)
        {
            bool flag = false;
            Random random = new Random();
            foreach (Guid id in ids)
            {
                float x = (float)p.X / (float)this.StructureView.Width;
                float y = (float)p.Y / (float)this.StructureView.Height;
                if (id != ids[ids.Count - 1])
                {
                    float num = 0.02f;
                    x += (float)(random.NextDouble() * random.NextDouble() * (double)num * 2.0) - num;
                    y += (float)(random.NextDouble() * random.NextDouble() * (double)num * 2.0) - num;
                }
                this.fStructure.Nodes.Add(new Node()
                {
                    ElementID = id,
                    Position = new PointF(x, y)
                });
                flag = true;
            }
            return flag;
        }

        private Node find_node(Guid element_id)
        {
            foreach (Node node in this.fStructure.Nodes)
            {
                if (node.ElementID == element_id)
                    return node;
            }
            return (Node)null;
        }

        private void LinkList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.LinkList, e.Column);
        }

        private void StructurePanel_Layout(object sender, LayoutEventArgs e)
        {
            this.resize_structure();
        }

        private void resize_structure()
        {
            this.StructureView.Size = new Size((int)((double)this.StructureView.Parent.Width * Math.Pow(1.1, (double)this.fZoom)), (int)((double)this.StructureView.Parent.Height * Math.Pow(1.1, (double)this.fZoom)));
        }
    }
}