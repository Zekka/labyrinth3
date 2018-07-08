// Decompiled with JetBrains decompiler
// Type: Labyrinth.Pages.ElementPage
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
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Pages
{
    public class ElementPage : UserControl, IElementPage, IPage
    {
        private Element fElement = (Element)null;
        private ArrayList fItemsToPrint = new ArrayList();
        private IContainer components;
        private ToolBar ToolBar;
        private ImageList ToolbarImages;
        private Crownwood.Magic.Controls.TabControl Pages;
        private Crownwood.Magic.Controls.TabPage AnnotationsPage;
        private Crownwood.Magic.Controls.TabPage LinksPage;
        private ListView LinkList;
        private ColumnHeader ElementHdr;
        private ColumnHeader LinkTextHdr;
        private ColumnHeader StructureHdr;
        private ToolBarButton Sep1;
        private ToolBarButton Sep2;
        private ContextMenu AnnotationContextMenu;
        private MenuItem AnnotationNew;
        private MenuItem AnnotationDelete;
        private MenuItem AnnotationProperties;
        private MenuItem Sep3;
        private MenuItem AnnotationMoveUp;
        private MenuItem AnnotationMoveDown;
        private ToolBarButton AnnotationNewBtn;
        private Crownwood.Magic.Controls.TabPage TimelinePage;
        private ColumnHeader TimelineHdr;
        private ListView TimelineList;
        private Splitter TimelineSplitter;
        private ContextMenu TimelineContextMenu;
        private MenuItem TimelineDelete;
        private MenuItem TimelineProperties;
        private ContextMenu LinkContextMenu;
        private MenuItem LinkOpenElement;
        private ImageList ListImages;
        private MenuItem LinkOpenStructure;
        private MenuItem LinkLinkProperties;
        private MenuItem TimelineOpenTimeline;
        private ToolBarButton Sep4;
        private ToolBarButton ExportBtn;
        private ToolBarButton PrintBtn;
        private ToolBarButton PrintPreviewBtn;
        private ToolBarButton ItemDeleteBtn;
        private ToolBarButton ItemPropertiesBtn;
        private ToolBarButton MoveUpBtn;
        private ToolBarButton MoveDownBtn;
        private MenuItem LinkDeleteLink;
        private MenuItem Sep5;
        private AnnotationPanel AnnotationPanel;
        private ToolBarButton FilterBtn;
        private AnnotationPanel TimelineAnnotationPanel;
        private ToolBarButton PropertiesBtn;

        public ElementPage(Element e)
        {
            this.InitializeComponent();
            this.LinkList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.TimelineList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.Pages.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiBox;
            if (this.TopLevelControl is MainForm)
                this.LinkList.SmallImageList = LabyrinthData.ElementImages;
            this.fElement = e;
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
            ResourceManager resourceManager = new ResourceManager(typeof(ElementPage));
            this.ToolBar = new ToolBar();
            this.PropertiesBtn = new ToolBarButton();
            this.Sep1 = new ToolBarButton();
            this.AnnotationNewBtn = new ToolBarButton();
            this.ItemDeleteBtn = new ToolBarButton();
            this.ItemPropertiesBtn = new ToolBarButton();
            this.Sep2 = new ToolBarButton();
            this.MoveUpBtn = new ToolBarButton();
            this.MoveDownBtn = new ToolBarButton();
            this.FilterBtn = new ToolBarButton();
            this.Sep4 = new ToolBarButton();
            this.PrintBtn = new ToolBarButton();
            this.PrintPreviewBtn = new ToolBarButton();
            this.ExportBtn = new ToolBarButton();
            this.ToolbarImages = new ImageList(this.components);
            this.Pages = new Crownwood.Magic.Controls.TabControl();
            this.ListImages = new ImageList(this.components);
            this.AnnotationsPage = new Crownwood.Magic.Controls.TabPage();
            this.AnnotationPanel = new AnnotationPanel();
            this.AnnotationContextMenu = new ContextMenu();
            this.AnnotationNew = new MenuItem();
            this.AnnotationProperties = new MenuItem();
            this.AnnotationDelete = new MenuItem();
            this.Sep3 = new MenuItem();
            this.AnnotationMoveUp = new MenuItem();
            this.AnnotationMoveDown = new MenuItem();
            this.LinksPage = new Crownwood.Magic.Controls.TabPage();
            this.LinkList = new ListView();
            this.ElementHdr = new ColumnHeader();
            this.LinkTextHdr = new ColumnHeader();
            this.StructureHdr = new ColumnHeader();
            this.LinkContextMenu = new ContextMenu();
            this.LinkOpenElement = new MenuItem();
            this.LinkOpenStructure = new MenuItem();
            this.Sep5 = new MenuItem();
            this.LinkDeleteLink = new MenuItem();
            this.LinkLinkProperties = new MenuItem();
            this.TimelinePage = new Crownwood.Magic.Controls.TabPage();
            this.TimelineAnnotationPanel = new AnnotationPanel();
            this.TimelineSplitter = new Splitter();
            this.TimelineList = new ListView();
            this.TimelineHdr = new ColumnHeader();
            this.TimelineContextMenu = new ContextMenu();
            this.TimelineProperties = new MenuItem();
            this.TimelineDelete = new MenuItem();
            this.TimelineOpenTimeline = new MenuItem();
            this.AnnotationsPage.SuspendLayout();
            this.LinksPage.SuspendLayout();
            this.TimelinePage.SuspendLayout();
            this.SuspendLayout();
            this.ToolBar.Appearance = ToolBarAppearance.Flat;
            this.ToolBar.Buttons.AddRange(new ToolBarButton[13]
            {
        this.PropertiesBtn,
        this.Sep1,
        this.AnnotationNewBtn,
        this.ItemDeleteBtn,
        this.ItemPropertiesBtn,
        this.Sep2,
        this.MoveUpBtn,
        this.MoveDownBtn,
        this.FilterBtn,
        this.Sep4,
        this.PrintBtn,
        this.PrintPreviewBtn,
        this.ExportBtn
            });
            this.ToolBar.DropDownArrows = true;
            this.ToolBar.ImageList = this.ToolbarImages;
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.ShowToolTips = true;
            this.ToolBar.Size = new Size(336, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.ButtonDropDown += new ToolBarButtonClickEventHandler(this.ToolBar_ButtonDropDown);
            this.ToolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.ToolBar_ButtonClick);
            this.PropertiesBtn.ImageIndex = 0;
            this.PropertiesBtn.ToolTipText = "Element Properties";
            this.Sep1.Style = ToolBarButtonStyle.Separator;
            this.AnnotationNewBtn.ImageIndex = 3;
            this.AnnotationNewBtn.Style = ToolBarButtonStyle.DropDownButton;
            this.AnnotationNewBtn.ToolTipText = "New Annotation";
            this.ItemDeleteBtn.ImageIndex = 4;
            this.ItemDeleteBtn.ToolTipText = "Delete Annotation";
            this.ItemPropertiesBtn.ImageIndex = 0;
            this.ItemPropertiesBtn.ToolTipText = "Annotation Properties";
            this.Sep2.Style = ToolBarButtonStyle.Separator;
            this.MoveUpBtn.ImageIndex = 5;
            this.MoveUpBtn.ToolTipText = "Move Up";
            this.MoveDownBtn.ImageIndex = 6;
            this.MoveDownBtn.ToolTipText = "Move Down";
            this.FilterBtn.ImageIndex = 8;
            this.FilterBtn.ToolTipText = "Filter";
            this.Sep4.Style = ToolBarButtonStyle.Separator;
            this.PrintBtn.ImageIndex = 1;
            this.PrintBtn.ToolTipText = "Print";
            this.PrintPreviewBtn.ImageIndex = 2;
            this.PrintPreviewBtn.ToolTipText = "Print Preview";
            this.ExportBtn.ImageIndex = 7;
            this.ExportBtn.ToolTipText = "Export";
            this.ToolbarImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ToolbarImages.ImageSize = new Size(16, 16);
            this.ToolbarImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ToolbarImages.ImageStream");
            this.ToolbarImages.TransparentColor = Color.Magenta;
            this.Pages.Dock = DockStyle.Fill;
            this.Pages.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.Pages.ImageList = this.ListImages;
            this.Pages.Location = new Point(0, 25);
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.SelectedTab = this.AnnotationsPage;
            this.Pages.Size = new Size(336, 207);
            this.Pages.TabIndex = 1;
            this.Pages.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[3]
            {
        this.AnnotationsPage,
        this.LinksPage,
        this.TimelinePage
            });
            this.ListImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ListImages.ImageSize = new Size(16, 16);
            this.ListImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ListImages.ImageStream");
            this.ListImages.TransparentColor = Color.Magenta;
            this.AnnotationsPage.Controls.AddRange(new Control[1]
            {
        (Control) this.AnnotationPanel
            });
            this.AnnotationsPage.ImageIndex = 0;
            this.AnnotationsPage.Name = "AnnotationsPage";
            this.AnnotationsPage.Size = new Size(336, 182);
            this.AnnotationsPage.TabIndex = 0;
            this.AnnotationsPage.Title = "Annotations";
            this.AnnotationPanel.AllowDrop = true;
            this.AnnotationPanel.ContextMenu = this.AnnotationContextMenu;
            this.AnnotationPanel.Dock = DockStyle.Fill;
            this.AnnotationPanel.Name = "AnnotationPanel";
            this.AnnotationPanel.SelectedAnnotation = (Annotation)null;
            this.AnnotationPanel.SelectedIndex = -1;
            this.AnnotationPanel.ShowFilter = false;
            this.AnnotationPanel.Size = new Size(336, 182);
            this.AnnotationPanel.TabIndex = 4;
            this.AnnotationPanel.DragDrop += new DragEventHandler(this.AnnotationList_DragDrop);
            this.AnnotationPanel.DoubleClick += new EventHandler(this.AnnotationPanel_DoubleClick);
            this.AnnotationPanel.DragOver += new DragEventHandler(this.AnnotationList_DragOver);
            this.AnnotationContextMenu.MenuItems.AddRange(new MenuItem[6]
            {
        this.AnnotationNew,
        this.AnnotationProperties,
        this.AnnotationDelete,
        this.Sep3,
        this.AnnotationMoveUp,
        this.AnnotationMoveDown
            });
            this.AnnotationContextMenu.Popup += new EventHandler(this.AnnotationContextMenu_Popup);
            this.AnnotationNew.Index = 0;
            this.AnnotationNew.Text = "New Annotation";
            this.AnnotationProperties.Index = 1;
            this.AnnotationProperties.Text = "Open Annotation";
            this.AnnotationProperties.Click += new EventHandler(this.AnnotationProperties_Click);
            this.AnnotationDelete.Index = 2;
            this.AnnotationDelete.Shortcut = Shortcut.Del;
            this.AnnotationDelete.Text = "Delete Annotation";
            this.AnnotationDelete.Click += new EventHandler(this.AnnotationDelete_Click);
            this.Sep3.Index = 3;
            this.Sep3.Text = "-";
            this.AnnotationMoveUp.Index = 4;
            this.AnnotationMoveUp.Text = "Move Up";
            this.AnnotationMoveUp.Click += new EventHandler(this.AnnotationMoveUp_Click);
            this.AnnotationMoveDown.Index = 5;
            this.AnnotationMoveDown.Text = "Move Down";
            this.AnnotationMoveDown.Click += new EventHandler(this.AnnotationMoveDown_Click);
            this.LinksPage.Controls.AddRange(new Control[1]
            {
        (Control) this.LinkList
            });
            this.LinksPage.ImageIndex = 2;
            this.LinksPage.Name = "LinksPage";
            this.LinksPage.Selected = false;
            this.LinksPage.Size = new Size(336, 182);
            this.LinksPage.TabIndex = 1;
            this.LinksPage.Title = "Links";
            this.LinkList.Columns.AddRange(new ColumnHeader[3]
            {
        this.ElementHdr,
        this.LinkTextHdr,
        this.StructureHdr
            });
            this.LinkList.ContextMenu = this.LinkContextMenu;
            this.LinkList.Dock = DockStyle.Fill;
            this.LinkList.FullRowSelect = true;
            this.LinkList.Name = "LinkList";
            this.LinkList.Size = new Size(336, 182);
            this.LinkList.SmallImageList = this.ListImages;
            this.LinkList.Sorting = SortOrder.Ascending;
            this.LinkList.TabIndex = 0;
            this.LinkList.View = View.Details;
            this.LinkList.MouseDown += new MouseEventHandler(this.LinkList_MouseDown);
            this.LinkList.DoubleClick += new EventHandler(this.LinkList_DoubleClick);
            this.LinkList.ColumnClick += new ColumnClickEventHandler(this.LinkList_ColumnClick);
            this.ElementHdr.Text = "Element";
            this.ElementHdr.Width = 120;
            this.LinkTextHdr.Text = "Link Text";
            this.LinkTextHdr.Width = 120;
            this.StructureHdr.Text = "Structure";
            this.StructureHdr.Width = 90;
            this.LinkContextMenu.MenuItems.AddRange(new MenuItem[5]
            {
        this.LinkOpenElement,
        this.LinkOpenStructure,
        this.Sep5,
        this.LinkDeleteLink,
        this.LinkLinkProperties
            });
            this.LinkOpenElement.Index = 0;
            this.LinkOpenElement.Text = "Open Element";
            this.LinkOpenElement.Click += new EventHandler(this.LinkOpenElement_Click);
            this.LinkOpenStructure.Index = 1;
            this.LinkOpenStructure.Text = "Open Structure";
            this.LinkOpenStructure.Click += new EventHandler(this.LinkOpenStructure_Click);
            this.Sep5.Index = 2;
            this.Sep5.Text = "-";
            this.LinkDeleteLink.Index = 3;
            this.LinkDeleteLink.Text = "Delete Link";
            this.LinkDeleteLink.Click += new EventHandler(this.LinkDeleteLink_Click);
            this.LinkLinkProperties.Index = 4;
            this.LinkLinkProperties.Text = "Link Properties";
            this.LinkLinkProperties.Click += new EventHandler(this.LinkLinkProperties_Click);
            this.TimelinePage.Controls.AddRange(new Control[3]
            {
        (Control) this.TimelineAnnotationPanel,
        (Control) this.TimelineSplitter,
        (Control) this.TimelineList
            });
            this.TimelinePage.ImageIndex = 1;
            this.TimelinePage.Name = "TimelinePage";
            this.TimelinePage.Selected = false;
            this.TimelinePage.Size = new Size(336, 182);
            this.TimelinePage.TabIndex = 2;
            this.TimelinePage.Title = "Timelines";
            this.TimelineAnnotationPanel.Dock = DockStyle.Fill;
            this.TimelineAnnotationPanel.Location = new Point(115, 0);
            this.TimelineAnnotationPanel.Name = "TimelineAnnotationPanel";
            this.TimelineAnnotationPanel.SelectedAnnotation = (Annotation)null;
            this.TimelineAnnotationPanel.SelectedIndex = -1;
            this.TimelineAnnotationPanel.ShowFilter = false;
            this.TimelineAnnotationPanel.Size = new Size(221, 182);
            this.TimelineAnnotationPanel.TabIndex = 4;
            this.TimelineAnnotationPanel.DoubleClick += new EventHandler(this.TimelineAnnotationList_DoubleClick);
            this.TimelineSplitter.Location = new Point(112, 0);
            this.TimelineSplitter.Name = "TimelineSplitter";
            this.TimelineSplitter.Size = new Size(3, 182);
            this.TimelineSplitter.TabIndex = 1;
            this.TimelineSplitter.TabStop = false;
            this.TimelineList.Columns.AddRange(new ColumnHeader[1]
            {
        this.TimelineHdr
            });
            this.TimelineList.Dock = DockStyle.Left;
            this.TimelineList.FullRowSelect = true;
            this.TimelineList.Name = "TimelineList";
            this.TimelineList.Size = new Size(112, 182);
            this.TimelineList.SmallImageList = this.ListImages;
            this.TimelineList.Sorting = SortOrder.Ascending;
            this.TimelineList.TabIndex = 0;
            this.TimelineList.View = View.Details;
            this.TimelineList.MouseDown += new MouseEventHandler(this.TimelineList_MouseDown);
            this.TimelineList.DoubleClick += new EventHandler(this.TimelineList_DoubleClick);
            this.TimelineList.ColumnClick += new ColumnClickEventHandler(this.TimelineList_ColumnClick);
            this.TimelineList.SelectedIndexChanged += new EventHandler(this.TimelineList_SelectedIndexChanged);
            this.TimelineHdr.Text = "Timeline";
            this.TimelineHdr.Width = 90;
            this.TimelineContextMenu.MenuItems.AddRange(new MenuItem[3]
            {
        this.TimelineProperties,
        this.TimelineDelete,
        this.TimelineOpenTimeline
            });
            this.TimelineProperties.Index = 0;
            this.TimelineProperties.Text = "Open Annotation";
            this.TimelineProperties.Click += new EventHandler(this.TimelineProperties_Click);
            this.TimelineDelete.Index = 1;
            this.TimelineDelete.Text = "Delete Annotation";
            this.TimelineDelete.Click += new EventHandler(this.TimelineDelete_Click);
            this.TimelineOpenTimeline.Index = 2;
            this.TimelineOpenTimeline.Text = "Open Timeline";
            this.TimelineOpenTimeline.Click += new EventHandler(this.TimelineOpenTimeline_Click);
            this.Controls.AddRange(new Control[2]
            {
        (Control) this.Pages,
        (Control) this.ToolBar
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.Name = nameof(ElementPage);
            this.Size = new Size(336, 232);
            this.AnnotationsPage.ResumeLayout(false);
            this.LinksPage.ResumeLayout(false);
            this.TimelinePage.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public string Title
        {
            get
            {
                return this.fElement.Name;
            }
        }

        public bool IsObsolete
        {
            get
            {
                return LabyrinthData.Project.Elements.IndexOf(this.fElement) == -1;
            }
        }

        public void UpdateUI()
        {
            if (this.Pages.SelectedTab == this.AnnotationsPage)
            {
                bool flag1 = this.AnnotationPanel.SelectedAnnotation != null;
                bool flag2 = this.AnnotationPanel.SelectedIndex == 0;
                bool flag3 = this.AnnotationPanel.SelectedIndex == this.AnnotationPanel.Annotations.Count - 1;
                this.AnnotationNew.Enabled = true;
                this.AnnotationDelete.Enabled = flag1;
                this.AnnotationProperties.Enabled = flag1;
                this.AnnotationMoveUp.Enabled = flag1 && !flag2 && !this.AnnotationPanel.FilterApplied;
                this.AnnotationMoveDown.Enabled = flag1 && !flag3 && !this.AnnotationPanel.FilterApplied;
                this.PropertiesBtn.Enabled = true;
                this.AnnotationNewBtn.Enabled = this.AnnotationNew.Enabled;
                this.ItemDeleteBtn.Enabled = this.AnnotationDelete.Enabled;
                this.ItemPropertiesBtn.Enabled = this.AnnotationProperties.Enabled;
                this.MoveUpBtn.Enabled = this.AnnotationMoveUp.Enabled;
                this.MoveDownBtn.Enabled = this.AnnotationMoveDown.Enabled;
                this.FilterBtn.Enabled = true;
                this.FilterBtn.Pushed = this.AnnotationPanel.ShowFilter;
                this.ExportBtn.Enabled = true;
            }
            else if (this.Pages.SelectedTab == this.LinksPage)
            {
                this.LinkOpenElement.Enabled = this.SelectedLink != null;
                this.LinkOpenStructure.Enabled = this.SelectedLink != null;
                this.LinkDeleteLink.Enabled = this.SelectedLink != null;
                this.LinkLinkProperties.Enabled = this.SelectedLink != null;
                this.PropertiesBtn.Enabled = true;
                this.AnnotationNewBtn.Enabled = false;
                this.ItemDeleteBtn.Enabled = this.LinkDeleteLink.Enabled;
                this.ItemPropertiesBtn.Enabled = this.LinkLinkProperties.Enabled;
                this.MoveUpBtn.Enabled = false;
                this.MoveDownBtn.Enabled = false;
                this.FilterBtn.Enabled = false;
                this.FilterBtn.Pushed = false;
                this.ExportBtn.Enabled = true;
            }
            else
            {
                if (this.Pages.SelectedTab != this.TimelinePage)
                    return;
                bool flag = this.TimelineAnnotationPanel.SelectedAnnotation != null;
                this.TimelineDelete.Enabled = flag;
                this.TimelineProperties.Enabled = flag;
                this.TimelineOpenTimeline.Enabled = this.SelectedTimeline != null;
                this.PropertiesBtn.Enabled = true;
                this.AnnotationNewBtn.Enabled = false;
                this.ItemDeleteBtn.Enabled = this.TimelineDelete.Enabled;
                this.ItemPropertiesBtn.Enabled = this.TimelineProperties.Enabled;
                this.MoveUpBtn.Enabled = false;
                this.MoveDownBtn.Enabled = false;
                this.FilterBtn.Enabled = true;
                this.FilterBtn.Pushed = this.TimelineAnnotationPanel.ShowFilter;
                this.ExportBtn.Enabled = this.SelectedTimeline != null;
            }
        }

        public void UpdateData()
        {
            this.update_annotations();
            this.update_timelines();
            this.update_links();
        }

        public Element Element
        {
            get
            {
                return this.fElement;
            }
        }

        public Annotation SelectedAnnotation
        {
            get
            {
                return this.AnnotationPanel.SelectedAnnotation;
            }
        }

        public Annotation SelectedTimelineAnnotation
        {
            get
            {
                return this.TimelineAnnotationPanel.SelectedAnnotation;
            }
        }

        public Timeline SelectedTimeline
        {
            get
            {
                if (this.TimelineList.SelectedItems.Count != 0)
                    return this.TimelineList.SelectedItems[0].Tag as Timeline;
                return (Timeline)null;
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

        public event ElementEventHandler ElementModified;

        public event ElementEventHandler ElementActivated;

        public event TimelineEventHandler TimelineModified;

        public event TimelineEventHandler TimelineActivated;

        public event StructureEventHandler StructureActivated;

        public event StructureEventHandler StructureModified;

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

        protected void OnTimelineModified(TimelineEventArgs e)
        {
            try
            {
                if (this.TimelineModified == null)
                    return;
                this.TimelineModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnTimelineActivated(TimelineEventArgs e)
        {
            try
            {
                if (this.TimelineActivated == null)
                    return;
                this.TimelineActivated((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnStructureActivated(StructureEventArgs e)
        {
            try
            {
                if (this.StructureActivated == null)
                    return;
                this.StructureActivated((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

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

        private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.PropertiesBtn)
                {
                    if (new ElementDlg(this.fElement).ShowDialog() != DialogResult.OK)
                        return;
                    this.UpdateData();
                    this.OnElementModified(new ElementEventArgs(this.fElement));
                }
                else if (e.Button == this.AnnotationNewBtn)
                    this.AnnotationNewText_Click(sender, (EventArgs)e);
                else if (e.Button == this.ItemDeleteBtn)
                {
                    if (this.Pages.SelectedTab == this.AnnotationsPage)
                        this.AnnotationDelete_Click(sender, (EventArgs)e);
                    else if (this.Pages.SelectedTab == this.LinksPage)
                    {
                        this.LinkDeleteLink_Click(sender, (EventArgs)e);
                    }
                    else
                    {
                        if (this.Pages.SelectedTab != this.TimelinePage)
                            return;
                        this.TimelineDelete_Click(sender, (EventArgs)e);
                    }
                }
                else if (e.Button == this.ItemPropertiesBtn)
                {
                    if (this.Pages.SelectedTab == this.AnnotationsPage)
                        this.AnnotationProperties_Click(sender, (EventArgs)e);
                    else if (this.Pages.SelectedTab == this.LinksPage)
                    {
                        this.LinkLinkProperties_Click(sender, (EventArgs)e);
                    }
                    else
                    {
                        if (this.Pages.SelectedTab != this.TimelinePage)
                            return;
                        this.TimelineProperties_Click(sender, (EventArgs)e);
                    }
                }
                else if (e.Button == this.MoveUpBtn)
                    this.AnnotationMoveUp_Click(sender, (EventArgs)e);
                else if (e.Button == this.MoveDownBtn)
                    this.AnnotationMoveDown_Click(sender, (EventArgs)e);
                else if (e.Button == this.FilterBtn)
                {
                    if (this.Pages.SelectedTab == this.AnnotationsPage)
                    {
                        this.AnnotationPanel.ShowFilter = !this.AnnotationPanel.ShowFilter;
                    }
                    else
                    {
                        if (this.Pages.SelectedTab == this.LinksPage || this.Pages.SelectedTab != this.TimelinePage)
                            return;
                        this.TimelineAnnotationPanel.ShowFilter = !this.TimelineAnnotationPanel.ShowFilter;
                    }
                }
                else if (e.Button == this.ExportBtn)
                {
                    string str1 = "HTML Files|*.html|Text Files|*.txt";
                    try
                    {
                        string str2 = this.fElement.Name;
                        if (this.Pages.SelectedTab == this.TimelinePage && this.SelectedTimeline != null)
                            str2 = str2 + " " + this.SelectedTimeline.Name;
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.FileName = str2;
                        saveFileDialog.Filter = str1;
                        if (saveFileDialog.ShowDialog() != DialogResult.OK)
                            return;
                        bool markup = saveFileDialog.FilterIndex == 1;
                        string str3 = "";
                        if (this.Pages.SelectedTab == this.AnnotationsPage)
                            str3 = this.export_annotations(markup);
                        else if (this.Pages.SelectedTab == this.LinksPage)
                            str3 = this.export_links(markup);
                        else if (this.Pages.SelectedTab == this.TimelinePage)
                            str3 = this.export_timeline_annotations(markup);
                        StreamWriter text = File.CreateText(saveFileDialog.FileName);
                        text.WriteLine(str3);
                        text.Close();
                    }
                    catch (Exception ex)
                    {
                        LabyrinthData.Log((object)ex);
                    }
                }
                else if (e.Button == this.PrintBtn)
                {
                    this.print(false);
                }
                else
                {
                    if (e.Button != this.PrintPreviewBtn)
                        return;
                    this.print(true);
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ToolBar_ButtonDropDown(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button != this.AnnotationNewBtn)
                    return;
                ContextMenu contextMenu = new ContextMenu();
                contextMenu.MenuItems.AddRange(this.get_annotation_submenu());
                Rectangle rectangle = this.AnnotationNewBtn.Rectangle;
                int x = rectangle.X;
                rectangle = this.AnnotationNewBtn.Rectangle;
                int y1 = rectangle.Y;
                rectangle = this.AnnotationNewBtn.Rectangle;
                int height = rectangle.Height;
                int y2 = y1 + height;
                contextMenu.Show((Control)this.ToolBar, new Point(x, y2));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void TimelineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.update_timeline_annotations();
        }

        private void TimelineList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedTimeline == null)
                return;
            this.TimelineOpenTimeline_Click(sender, e);
        }

        private void AnnotationDelete_Click(object sender, EventArgs e)
        {
            if (this.AnnotationPanel.SelectedAnnotation == null || MessageBox.Show("Delete annotation '" + this.AnnotationPanel.SelectedAnnotation.Title + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.fElement.Annotations.Remove(this.AnnotationPanel.SelectedAnnotation);
            this.update_annotations();
            this.OnElementModified(new ElementEventArgs(this.fElement));
        }

        private void AnnotationProperties_Click(object sender, EventArgs e)
        {
            if (this.AnnotationPanel.SelectedAnnotation == null)
                return;
            Annotation selectedAnnotation = this.AnnotationPanel.SelectedAnnotation;
            if (!Annotations.Open(selectedAnnotation))
                return;
            this.update_annotations();
            this.OnElementModified(new ElementEventArgs(this.fElement));
            this.AnnotationPanel.SelectedAnnotation = selectedAnnotation;
        }

        private void AnnotationMoveUp_Click(object sender, EventArgs e)
        {
            if (this.AnnotationPanel.SelectedAnnotation == null)
                return;
            Annotation selectedAnnotation = this.AnnotationPanel.SelectedAnnotation;
            int index = this.fElement.Annotations.IndexOf(selectedAnnotation);
            switch (index)
            {
                case -1:
                    break;

                case 0:
                    break;

                default:
                    Annotation annotation = this.fElement.Annotations[index - 1];
                    this.fElement.Annotations[index - 1] = this.fElement.Annotations[index];
                    this.fElement.Annotations[index] = annotation;
                    this.update_annotations();
                    this.OnElementModified(new ElementEventArgs(this.fElement));
                    this.AnnotationPanel.SelectedAnnotation = selectedAnnotation;
                    break;
            }
        }

        private void AnnotationMoveDown_Click(object sender, EventArgs e)
        {
            if (this.AnnotationPanel.SelectedAnnotation == null)
                return;
            Annotation selectedAnnotation = this.AnnotationPanel.SelectedAnnotation;
            int index = this.fElement.Annotations.IndexOf(selectedAnnotation);
            if (index == -1 || index == this.AnnotationPanel.Annotations.Count - 1)
                return;
            Annotation annotation = this.fElement.Annotations[index + 1];
            this.fElement.Annotations[index + 1] = this.fElement.Annotations[index];
            this.fElement.Annotations[index] = annotation;
            this.update_annotations();
            this.OnElementModified(new ElementEventArgs(this.fElement));
            this.AnnotationPanel.SelectedAnnotation = selectedAnnotation;
        }

        private void TimelineDelete_Click(object sender, EventArgs e)
        {
            if (this.TimelineAnnotationPanel.SelectedAnnotation == null || MessageBox.Show("Delete annotation '" + this.TimelineAnnotationPanel.SelectedAnnotation.Title + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            Timeline tl = (Timeline)null;
            TimelinePoint timelinePoint = (TimelinePoint)null;
            TimelineItem timelineItem1 = (TimelineItem)null;
            foreach (Timeline timeline in LabyrinthData.Project.Timelines)
            {
                foreach (TimelinePoint point in timeline.Points)
                {
                    foreach (TimelineItem timelineItem2 in point.Items)
                    {
                        if (timelineItem2.Annotation.ID == this.TimelineAnnotationPanel.SelectedAnnotation.ID)
                        {
                            tl = timeline;
                            timelinePoint = point;
                            timelineItem1 = timelineItem2;
                            break;
                        }
                    }
                }
            }
            if (timelineItem1 == null)
                return;
            timelinePoint.Items.Remove(timelineItem1);
            this.update_timelines();
            this.OnTimelineModified(new TimelineEventArgs(tl));
        }

        private void TimelineProperties_Click(object sender, EventArgs e)
        {
            if (this.TimelineAnnotationPanel.SelectedAnnotation == null)
                return;
            Annotation selectedAnnotation = this.TimelineAnnotationPanel.SelectedAnnotation;
            if (!Annotations.Open(selectedAnnotation))
                return;
            this.update_timelines();
            this.OnTimelineModified(new TimelineEventArgs(this.SelectedTimeline));
            this.TimelineAnnotationPanel.SelectedAnnotation = selectedAnnotation;
        }

        private void TimelineOpenTimeline_Click(object sender, EventArgs e)
        {
            if (this.SelectedTimeline == null)
                return;
            this.OnTimelineActivated(new TimelineEventArgs(this.SelectedTimeline));
        }

        private void LinkOpenElement_Click(object sender, EventArgs e)
        {
            if (this.SelectedLink == null)
                return;
            int index = LabyrinthData.Project.Elements.IndexOf(this.SelectedLink.LHS != this.fElement.ID ? this.SelectedLink.LHS : this.SelectedLink.RHS);
            if (index == -1)
                return;
            this.OnElementActivated(new ElementEventArgs(LabyrinthData.Project.Elements[index]));
        }

        private void LinkOpenStructure_Click(object sender, EventArgs e)
        {
            if (this.SelectedLink == null)
                return;
            Structure structureContaining = this.get_structure_containing(this.SelectedLink);
            if (structureContaining == null)
                return;
            this.OnStructureActivated(new StructureEventArgs(structureContaining));
        }

        private void LinkDeleteLink_Click(object sender, EventArgs e)
        {
            if (this.SelectedLink == null || MessageBox.Show("Delete link '" + this.SelectedLink.Description + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            Structure structureContaining = this.get_structure_containing(this.SelectedLink);
            structureContaining.Links.Remove(this.SelectedLink);
            this.update_links();
            this.OnStructureModified(new StructureEventArgs(structureContaining));
        }

        private void LinkLinkProperties_Click(object sender, EventArgs e)
        {
            if (this.SelectedLink == null)
                return;
            Structure structureContaining = this.get_structure_containing(this.SelectedLink);
            if (new LinkDlg(this.SelectedLink).ShowDialog() != DialogResult.OK)
                return;
            this.update_links();
            this.OnStructureModified(new StructureEventArgs(structureContaining));
        }

        private void update_annotations()
        {
            this.AnnotationPanel.Annotations = this.fElement.Annotations;
        }

        private void update_timelines()
        {
            this.TimelineList.BeginUpdate();
            this.TimelineList.Items.Clear();
            if (this.fElement != null)
            {
                ArrayList arrayList = new ArrayList();
                foreach (Timeline timeline in LabyrinthData.Project.Timelines)
                {
                    if (timeline.ElementIDs.Contains(this.fElement.ID))
                        arrayList.Add((object)new ListViewItem(timeline.Name)
                        {
                            ImageIndex = 1,
                            Tag = (object)timeline
                        });
                }
                this.TimelineList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            }
            if (this.TimelineList.Items.Count == 0)
            {
                ListViewItem listViewItem = this.TimelineList.Items.Add("No timelines");
                listViewItem.ImageIndex = -1;
                listViewItem.ForeColor = SystemColors.GrayText;
            }
            this.TimelineList.EndUpdate();
        }

        private void update_timeline_annotations()
        {
            var annotationCollection = new List<Annotation>();
            if (this.SelectedTimeline != null)
            {
                foreach (TimelinePoint point in this.SelectedTimeline.Points)
                {
                    foreach (TimelineItem timelineItem in point.Items)
                    {
                        if (timelineItem.ElementID == this.fElement.ID)
                            annotationCollection.Add((Annotation)timelineItem.Annotation);
                    }
                }
            }
            this.TimelineAnnotationPanel.Annotations = annotationCollection;
        }

        private void update_links()
        {
            this.LinkList.BeginUpdate();
            this.LinkList.Items.Clear();
            ArrayList arrayList = new ArrayList();
            foreach (Structure structure in LabyrinthData.Project.Structures)
            {
                foreach (Labyrinth.Plot.Link link in structure.Links)
                {
                    if (link.LHS == this.fElement.ID || link.RHS == this.fElement.ID)
                    {
                        int index = LabyrinthData.Project.Elements.IndexOf(link.LHS != this.fElement.ID ? link.LHS : link.RHS);
                        if (index != -1)
                            arrayList.Add((object)new ListViewItem(LabyrinthData.Project.Elements[index].Name)
                            {
                                SubItems = {
                  link.Description,
                  structure.Name
                },
                                ImageIndex = 2,
                                Tag = (object)link
                            });
                    }
                }
            }
            this.LinkList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            if (this.LinkList.Items.Count == 0)
            {
                ListViewItem listViewItem = this.LinkList.Items.Add("No links");
                listViewItem.ImageIndex = -1;
                listViewItem.ForeColor = SystemColors.GrayText;
            }
            this.LinkList.EndUpdate();
        }

        private Structure get_structure_containing(Labyrinth.Plot.Link l)
        {
            foreach (Structure structure in LabyrinthData.Project.Structures)
            {
                if (structure.Links.Contains(l))
                    return structure;
            }
            return (Structure)null;
        }

        private void TimelineList_MouseDown(object sender, MouseEventArgs e)
        {
            this.TimelineList.SelectedItems.Clear();
            ListViewItem itemAt = this.TimelineList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.UpdateUI();
        }

        private void LinkList_MouseDown(object sender, MouseEventArgs e)
        {
            this.LinkList.SelectedItems.Clear();
            ListViewItem itemAt = this.LinkList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.UpdateUI();
        }

        private void LinkList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedLink == null)
                return;
            this.LinkOpenElement_Click(sender, e);
        }

        private void TimelineAnnotationList_DoubleClick(object sender, EventArgs e)
        {
            if (this.TimelineAnnotationPanel.SelectedAnnotation == null)
                return;
            this.TimelineProperties_Click(sender, e);
        }

        private string export_annotations(bool markup)
        {
            string str1 = "";
            string title = "Annotations for " + this.fElement.Name;
            if (markup)
                str1 = str1 + "<html>" + Environment.NewLine + LabyrinthData.HTMLHeader(title) + Environment.NewLine + "<body>" + Environment.NewLine;
            if (markup)
                str1 += "<p class=header>";
            string str2 = str1 + title;
            if (markup)
                str2 += "</p>";
            string str3 = str2 + Environment.NewLine;
            foreach (Annotation annotation in this.AnnotationPanel.Annotations)
            {
                str3 += Environment.NewLine;
                str3 = str3 + this.annotation_to_string(annotation.Title, annotation.Content, markup) + Environment.NewLine;
            }
            if (markup)
                str3 = str3 + "</body>" + Environment.NewLine + "</html>" + Environment.NewLine;
            return str3;
        }

        private string export_timeline_annotations(bool markup)
        {
            string str1 = "";
            string title1 = "Annotations for " + this.fElement.Name + " in " + this.SelectedTimeline.Name;
            if (markup)
                str1 = str1 + "<html>" + Environment.NewLine + LabyrinthData.HTMLHeader(title1) + Environment.NewLine + "<body>" + Environment.NewLine;
            if (markup)
                str1 += "<p class=header>";
            string str2 = str1 + title1;
            if (markup)
                str2 += "</p>";
            string str3 = str2 + Environment.NewLine;
            foreach (Annotation annotation in this.TimelineAnnotationPanel.Annotations)
            {
                TimelinePoint timelinePoint = (TimelinePoint)null;
                foreach (TimelinePoint point in this.SelectedTimeline.Points)
                {
                    foreach (TimelineItem timelineItem in point.Items)
                    {
                        if (timelineItem.Annotation == annotation)
                        {
                            timelinePoint = point;
                            break;
                        }
                    }
                }
                str3 += Environment.NewLine;
                string title2 = timelinePoint.Name + ": " + annotation.Title;
                str3 = str3 + this.annotation_to_string(title2, annotation.Content, markup) + Environment.NewLine;
            }
            if (markup)
                str3 = str3 + "</body>" + Environment.NewLine + "</html>" + Environment.NewLine;
            return str3;
        }

        private string annotation_to_string(string title, string content, bool markup)
        {
            string str1 = "";
            if (markup)
                str1 = str1 + "<p class=annotationtitle>" + Environment.NewLine;
            string str2 = str1 + title + Environment.NewLine;
            if (markup)
                str2 = str2 + "</p>" + Environment.NewLine;
            if (markup)
                str2 = str2 + "<p class=annotationcontent>" + Environment.NewLine;
            string str3 = str2 + (markup ? content.Replace("\n", "<br>") : content) + Environment.NewLine;
            if (markup)
                str3 += "</p>";
            return str3;
        }

        private string export_links(bool markup)
        {
            string str1 = "";
            string title = "Links for " + this.fElement.Name;
            if (markup)
                str1 = str1 + "<html>" + Environment.NewLine + LabyrinthData.HTMLHeader(title) + Environment.NewLine + "<body>" + Environment.NewLine;
            if (markup)
                str1 += "<h1>";
            string str2 = str1 + title;
            if (markup)
                str2 += "</h1>";
            string str3 = str2 + Environment.NewLine;
            if (markup)
                str3 = str3 + "<table border=1>" + Environment.NewLine + "<tr>" + Environment.NewLine + "<td>" + Environment.NewLine + "<p class=colhdr>" + Environment.NewLine + "Element" + Environment.NewLine + "</p>" + Environment.NewLine + "</td>" + Environment.NewLine + "<td>" + Environment.NewLine + "<p class=colhdr>" + Environment.NewLine + "Link Text" + Environment.NewLine + "</p>" + Environment.NewLine + "</td>" + Environment.NewLine + "<td>" + Environment.NewLine + "<p class=colhdr>" + Environment.NewLine + "Structure" + Environment.NewLine + "</p>" + Environment.NewLine + "</td>" + Environment.NewLine + "</tr>" + Environment.NewLine;
            foreach (ListViewItem listViewItem in this.LinkList.Items)
            {
                Labyrinth.Plot.Link tag = listViewItem.Tag as Labyrinth.Plot.Link;
                if (tag != null)
                {
                    Element element = LabyrinthData.Project.Elements[LabyrinthData.Project.Elements.IndexOf(tag.LHS == this.fElement.ID ? tag.RHS : tag.LHS)];
                    Structure structure1 = (Structure)null;
                    foreach (Structure structure2 in LabyrinthData.Project.Structures)
                    {
                        if (structure2.Links.Contains(tag))
                        {
                            structure1 = structure2;
                            break;
                        }
                    }
                    if (markup)
                    {
                        str3 = str3 + "<tr>" + Environment.NewLine;
                        str3 = str3 + "<td>" + Environment.NewLine;
                        str3 = str3 + "<p class=linkelement>" + Environment.NewLine;
                        str3 = str3 + element.Name + Environment.NewLine;
                        str3 = str3 + "</p>" + Environment.NewLine;
                        str3 = str3 + "</td>" + Environment.NewLine;
                        str3 = str3 + "<td>" + Environment.NewLine;
                        str3 = str3 + "<p class=linktext>" + Environment.NewLine;
                        str3 = str3 + tag.Description + Environment.NewLine;
                        str3 = str3 + "</p>" + Environment.NewLine;
                        str3 = str3 + "</td>" + Environment.NewLine;
                        str3 = str3 + "<td>" + Environment.NewLine;
                        str3 = str3 + "<p class=linkstructure>" + Environment.NewLine;
                        str3 = str3 + structure1.Name + Environment.NewLine;
                        str3 = str3 + "</p>" + Environment.NewLine;
                        str3 = str3 + "</td>" + Environment.NewLine;
                        str3 = str3 + "</tr>" + Environment.NewLine;
                    }
                    else
                    {
                        str3 += Environment.NewLine;
                        str3 = str3 + element.Name + "\t" + tag.Description + "\t" + structure1.Name;
                    }
                }
            }
            if (markup)
                str3 = str3 + "</body>" + Environment.NewLine + "</html>" + Environment.NewLine;
            return str3;
        }

        private void print(bool preview)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = LabyrinthData.Project.Name + ": " + this.fElement.Name;
            printDocument.PrintController = (PrintController)new StandardPrintController();
            printDocument.DefaultPageSettings = LabyrinthData.PageSettings;
            printDocument.PrinterSettings = LabyrinthData.PrinterSettings;
            printDocument.PrintPage += new PrintPageEventHandler(this.PrintPage);
            this.fItemsToPrint.Clear();
            if (this.Pages.SelectedTab == this.AnnotationsPage)
            {
                this.fItemsToPrint.AddRange((ICollection)this.fElement.Annotations);
                printDocument.DocumentName += " (annotations)";
            }
            else if (this.Pages.SelectedTab == this.LinksPage)
            {
                foreach (ListViewItem listViewItem in this.LinkList.Items)
                    this.fItemsToPrint.Add(listViewItem.Tag);
                printDocument.DocumentName += " (links)";
            }
            else if (this.Pages.SelectedTab == this.TimelinePage)
            {
                this.fItemsToPrint.AddRange((ICollection)this.TimelineAnnotationPanel.Annotations);
                printDocument.DocumentName += " (timeline annotations)";
            }
            if (preview)
            {
                int num = (int)new PrintPreviewDialog()
                {
                    Document = printDocument
                }.ShowDialog();
            }
            else
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() != DialogResult.OK)
                    return;
                for (int index = 0; index != (int)printDialog.PrinterSettings.Copies; ++index)
                    printDialog.Document.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            int num1 = 0;
            Font font = new Font(this.Font, this.Font.Style);
            while (this.fItemsToPrint.Count != 0)
            {
                TextAnnotation textAnnotation = this.fItemsToPrint[0] as TextAnnotation;
                Labyrinth.Plot.Link l = this.fItemsToPrint[0] as Labyrinth.Plot.Link;
                int num2 = 0;
                if (textAnnotation != null)
                    num2 = this.measure_annotation((Annotation)textAnnotation, e.Graphics, e.MarginBounds.Width, font);
                else if (l != null)
                    num2 = this.measure_link(l, e.Graphics, e.MarginBounds.Width, font);
                if (num2 > e.MarginBounds.Height - num1)
                {
                    if (num1 == 0)
                    {
                        float emSize = font.SizeInPoints * (float)e.MarginBounds.Height / (float)num2;
                        font = new Font(font.FontFamily, emSize);
                    }
                    else
                        break;
                }
                Rectangle rect;
                int x = e.MarginBounds.X;
                int num3 = num1;
                Rectangle marginBounds = e.MarginBounds;
                int y1 = marginBounds.Y;
                int y2 = num3 + y1;
                marginBounds = e.MarginBounds;
                int width = marginBounds.Width;
                int height = num2;
                rect = new Rectangle(x, y2, width, height);
                num1 = num1 + num2 + this.Font.Height;
                if (textAnnotation != null)
                    this.render_annotation((Annotation)textAnnotation, e.Graphics, font, rect);
                else if (l != null)
                    this.render_link(l, e.Graphics, font, rect);
                this.fItemsToPrint.RemoveAt(0);
            }
            e.HasMorePages = this.fItemsToPrint.Count != 0;
        }

        private int measure_annotation(Annotation a, Graphics g, int width, Font font)
        {
            Font font1 = new Font(font, font.Style | FontStyle.Bold);
            return (int)((double)g.MeasureString(a.Title, font1, width).Height + (double)g.MeasureString(a.Content, font, width).Height);
        }

        private void render_annotation(Annotation a, Graphics g, Font f, Rectangle rect)
        {
            Brush windowText = SystemBrushes.WindowText;
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.EllipsisWord;
            Font font = new Font(f, f.Style | FontStyle.Bold);
            float height = g.MeasureString(a.Title, font, rect.Width, format).Height;
            g.DrawString(a.Title, font, windowText, (RectangleF)rect, format);
            rect.Y += (int)height;
            rect.Height -= (int)height;
            g.DrawString(a.Content, f, windowText, (RectangleF)rect, format);
        }

        private int measure_link(Labyrinth.Plot.Link l, Graphics g, int width, Font font)
        {
            string text = LabyrinthData.Project.Elements[LabyrinthData.Project.Elements.IndexOf(l.LHS)].Name + ", " + LabyrinthData.Project.Elements[LabyrinthData.Project.Elements.IndexOf(l.RHS)].Name;
            Structure structure1 = null;
            foreach (Structure structure2 in LabyrinthData.Project.Structures)
            {
                if (structure2.Links.Contains(l))
                {
                    structure1 = structure2;
                    break;
                }
            }
            return (int)Math.Max(Math.Max(g.MeasureString(text, font, width / 2).Height, g.MeasureString(l.Description, font, width / 4).Height), g.MeasureString(structure1.Name, font, width / 4).Height);
        }

        private void render_link(Labyrinth.Plot.Link l, Graphics g, Font f, Rectangle rect)
        {
            string s = LabyrinthData.Project.Elements[LabyrinthData.Project.Elements.IndexOf(l.LHS)].Name + ", " + LabyrinthData.Project.Elements[LabyrinthData.Project.Elements.IndexOf(l.RHS)].Name;
            Structure structure1 = (Structure)null;
            foreach (Structure structure2 in LabyrinthData.Project.Structures)
            {
                if (structure2.Links.Contains(l))
                {
                    structure1 = structure2;
                    break;
                }
            }
            Rectangle rectangle1 = new Rectangle(rect.X, rect.Y, rect.Width / 2, rect.Height);
            Rectangle rectangle2 = new Rectangle(rectangle1.X + rectangle1.Width, rect.Y, rect.Width / 4, rect.Height);
            Rectangle rectangle3 = new Rectangle(rectangle2.X + rectangle2.Width, rect.Y, rect.Width / 4, rect.Height);
            g.DrawString(s, this.Font, SystemBrushes.WindowText, (RectangleF)rectangle1);
            g.DrawString(l.Description, this.Font, SystemBrushes.WindowText, (RectangleF)rectangle2);
            g.DrawString(structure1.Name, this.Font, SystemBrushes.WindowText, (RectangleF)rectangle3);
        }

        private void AnnotationPanel_DoubleClick(object sender, EventArgs e)
        {
            if (this.AnnotationPanel.SelectedAnnotation != null)
                this.AnnotationProperties_Click(sender, e);
            else
                this.AnnotationNewText_Click(sender, e);
        }

        private void AnnotationList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;
            e.Effect = DragDropEffects.Link;
        }

        private void AnnotationList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Rtf))
            {
                string data1 = e.Data.GetData(DataFormats.Rtf) as string;
                string data2 = e.Data.GetData(typeof(string)) as string;
                TextAnnotation textAnnotation = new TextAnnotation();
                textAnnotation.Title = "New Annotation";
                textAnnotation.Content = data2;
                textAnnotation.RTF = data1;
                this.fElement.Annotations.Add((Annotation)textAnnotation);
                this.update_annotations();
                this.OnElementModified(new ElementEventArgs(this.fElement));
            }
            else if (e.Data.GetDataPresent(typeof(string)))
            {
                string data = e.Data.GetData(typeof(string)) as string;
                TextAnnotation textAnnotation = new TextAnnotation();
                textAnnotation.Title = "New Annotation";
                textAnnotation.Content = data;
                this.fElement.Annotations.Add((Annotation)textAnnotation);
                this.update_annotations();
                this.OnElementModified(new ElementEventArgs(this.fElement));
            }
            else
            {
                if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                    return;
                foreach (string str in e.Data.GetData(DataFormats.FileDrop) as string[])
                {
                    LinkAnnotation linkAnnotation = new LinkAnnotation();
                    linkAnnotation.Content = str;
                    this.fElement.Annotations.Add((Annotation)linkAnnotation);
                }
                this.update_annotations();
                this.OnElementModified(new ElementEventArgs(this.fElement));
            }
        }

        private MenuItem[] get_annotation_submenu()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add((object)new MenuItem("Text Annotation", new EventHandler(this.AnnotationNewText_Click)));
            arrayList.Add((object)new MenuItem("File Link Annotation", new EventHandler(this.AnnotationNewLink_Click)));
            arrayList.Add((object)new MenuItem("Sketch Annotation", new EventHandler(this.AnnotationNewSketch_Click)));
            var noteCollection = new List<Note>();
            foreach (Note note in LabyrinthData.Project.Notes)
            {
                if (note.IsTemplate)
                    noteCollection.Add(note);
            }
            if (noteCollection.Count != 0)
            {
                arrayList.Add((object)new MenuItem("-"));
                foreach (Note note in noteCollection)
                    arrayList.Add((object)new MenuItem(note.Title, new EventHandler(this.AnnotationNewTemplate_Click)));
            }
            return (MenuItem[])arrayList.ToArray(typeof(MenuItem));
        }

        private void AnnotationNewText_Click(object sender, EventArgs e)
        {
            try
            {
                this.new_text_annotation((Note)null);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void AnnotationNewLink_Click(object sender, EventArgs e)
        {
            try
            {
                LinkAnnotation linkAnnotation = new LinkAnnotation();
                if (!Annotations.Open((Annotation)linkAnnotation))
                    return;
                this.fElement.Annotations.Add((Annotation)linkAnnotation);
                this.update_annotations();
                this.OnElementModified(new ElementEventArgs(this.fElement));
                this.AnnotationPanel.SelectedAnnotation = (Annotation)linkAnnotation;
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void AnnotationNewSketch_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "New Sketch";
                string title = str;
                int num = 1;
                for (; this.fElement.Annotations.IndexOf(title) != -1; title = str + " " + (object)num)
                    ++num;
                SketchAnnotation sketchAnnotation = new SketchAnnotation();
                sketchAnnotation.Title = title;
                if (!Annotations.Open((Annotation)sketchAnnotation))
                    return;
                this.fElement.Annotations.Add((Annotation)sketchAnnotation);
                this.update_annotations();
                this.OnElementModified(new ElementEventArgs(this.fElement));
                this.AnnotationPanel.SelectedAnnotation = (Annotation)sketchAnnotation;
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void AnnotationNewTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                var noteCollection = new List<Note>();
                foreach (Note note in LabyrinthData.Project.Notes)
                {
                    if (note.IsTemplate)
                        noteCollection.Add(note);
                }
                MenuItem menuItem = sender as MenuItem;
                if (menuItem == null)
                    return;
                int index = noteCollection.IndexOf(menuItem.Text);
                if (index == -1)
                    return;
                this.new_text_annotation(noteCollection[index]);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void new_text_annotation(Note template)
        {
            string str = template != null ? template.Title : "New Text Annotation";
            string title = str;
            int num = 1;
            for (; this.fElement.Annotations.IndexOf(title) != -1; title = str + " " + (object)num)
                ++num;
            TextAnnotation textAnnotation = new TextAnnotation();
            textAnnotation.Title = title;
            if (template != null)
                textAnnotation.RTF = template.RTF;
            if (!Annotations.Open((Annotation)textAnnotation))
                return;
            this.fElement.Annotations.Add((Annotation)textAnnotation);
            this.update_annotations();
            this.OnElementModified(new ElementEventArgs(this.fElement));
            this.AnnotationPanel.SelectedAnnotation = (Annotation)textAnnotation;
        }

        private void LinkList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.LinkList, e.Column);
        }

        private void TimelineList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.TimelineList, e.Column);
        }

        private void AnnotationList_Layout(object sender, LayoutEventArgs e)
        {
            this.update_annotations();
        }

        private void TimelineAnnotationList_Layout(object sender, LayoutEventArgs e)
        {
            this.update_timeline_annotations();
        }

        private void AnnotationContextMenu_Popup(object sender, EventArgs e)
        {
            this.AnnotationNew.MenuItems.Clear();
            this.AnnotationNew.MenuItems.AddRange(this.get_annotation_submenu());
        }
    }
}