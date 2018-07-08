// Decompiled with JetBrains decompiler
// Type: Labyrinth.Pages.SearchPage
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Events;
using Labyrinth.Extensibility;
using Labyrinth.Forms;
using Labyrinth.Plot;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Pages
{
    public class SearchPage : UserControl, ISearchPage, IPage
    {
        private ArrayList fCustomSearches = new ArrayList();
        private ImageList ToolbarImages;
        private ContextMenu ResultContextMenu;
        private MenuItem ResultOpen;
        private Crownwood.Magic.Controls.TabControl TypePages;
        private ToolBarButton NewSearchBtn;
        private ToolBar ToolBar;
        private CheckBox CaseSensitiveBox;
        private TextBox SearchTextBox;
        private Label SearchForLbl;
        private CheckBox NegateBox;
        private MenuItem ResultProperties;
        private Crownwood.Magic.Controls.TabPage StandardPage;
        private ListView ResultsList;
        private ColumnHeader NameHdr;
        private ColumnHeader TypeHdr;
        private ColumnHeader DetailsHdr;
        private Splitter Splitter;
        private Panel SearchPanel;
        private IContainer components;

        public SearchPage()
        {
            this.InitializeComponent();
            this.ResultsList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.TypePages.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiBox;
            this.TypePages.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            this.ResultsList.SmallImageList = LabyrinthData.ElementImages;
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
            ResourceManager resourceManager = new ResourceManager(typeof(SearchPage));
            this.ToolbarImages = new ImageList(this.components);
            this.ResultContextMenu = new ContextMenu();
            this.ResultOpen = new MenuItem();
            this.ResultProperties = new MenuItem();
            this.TypePages = new Crownwood.Magic.Controls.TabControl();
            this.StandardPage = new Crownwood.Magic.Controls.TabPage();
            this.ResultsList = new ListView();
            this.NameHdr = new ColumnHeader();
            this.TypeHdr = new ColumnHeader();
            this.DetailsHdr = new ColumnHeader();
            this.Splitter = new Splitter();
            this.SearchPanel = new Panel();
            this.NegateBox = new CheckBox();
            this.CaseSensitiveBox = new CheckBox();
            this.SearchTextBox = new TextBox();
            this.SearchForLbl = new Label();
            this.NewSearchBtn = new ToolBarButton();
            this.ToolBar = new ToolBar();
            this.StandardPage.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.SuspendLayout();
            this.ToolbarImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ToolbarImages.ImageSize = new Size(16, 16);
            this.ToolbarImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ToolbarImages.ImageStream");
            this.ToolbarImages.TransparentColor = Color.Magenta;
            this.ResultContextMenu.MenuItems.AddRange(new MenuItem[2]
            {
        this.ResultOpen,
        this.ResultProperties
            });
            this.ResultOpen.Index = 0;
            this.ResultOpen.Text = "Open Result Item";
            this.ResultOpen.Click += new EventHandler(this.ResultOpen_Click);
            this.ResultProperties.Index = 1;
            this.ResultProperties.Text = "Result Item Properties";
            this.ResultProperties.Click += new EventHandler(this.ResultProperties_Click);
            this.TypePages.Dock = DockStyle.Fill;
            this.TypePages.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.TypePages.Location = new Point(0, 25);
            this.TypePages.Name = "TypePages";
            this.TypePages.SelectedIndex = 0;
            this.TypePages.SelectedTab = this.StandardPage;
            this.TypePages.Size = new Size(560, 239);
            this.TypePages.TabIndex = 4;
            this.TypePages.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[1]
            {
        this.StandardPage
            });
            this.StandardPage.Controls.AddRange(new Control[3]
            {
        (Control) this.ResultsList,
        (Control) this.Splitter,
        (Control) this.SearchPanel
            });
            this.StandardPage.Name = "StandardPage";
            this.StandardPage.Size = new Size(560, 214);
            this.StandardPage.TabIndex = 0;
            this.StandardPage.Title = "Standard";
            this.ResultsList.Columns.AddRange(new ColumnHeader[3]
            {
        this.NameHdr,
        this.TypeHdr,
        this.DetailsHdr
            });
            this.ResultsList.ContextMenu = this.ResultContextMenu;
            this.ResultsList.Dock = DockStyle.Fill;
            this.ResultsList.FullRowSelect = true;
            this.ResultsList.Location = new Point(195, 0);
            this.ResultsList.Name = "ResultsList";
            this.ResultsList.Size = new Size(365, 214);
            this.ResultsList.Sorting = SortOrder.Ascending;
            this.ResultsList.TabIndex = 2;
            this.ResultsList.View = View.Details;
            this.ResultsList.MouseDown += new MouseEventHandler(this.SimpleResultsList_MouseDown);
            this.ResultsList.DoubleClick += new EventHandler(this.ResultsList_DoubleClick);
            this.ResultsList.ColumnClick += new ColumnClickEventHandler(this.SimpleResultsList_ColumnClick);
            this.NameHdr.Text = "Result";
            this.NameHdr.Width = 150;
            this.TypeHdr.Text = "Type";
            this.TypeHdr.Width = 90;
            this.DetailsHdr.Text = "Source";
            this.DetailsHdr.Width = 90;
            this.Splitter.Location = new Point(192, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new Size(3, 214);
            this.Splitter.TabIndex = 1;
            this.Splitter.TabStop = false;
            this.SearchPanel.BorderStyle = BorderStyle.Fixed3D;
            this.SearchPanel.Controls.AddRange(new Control[4]
            {
        (Control) this.NegateBox,
        (Control) this.CaseSensitiveBox,
        (Control) this.SearchTextBox,
        (Control) this.SearchForLbl
            });
            this.SearchPanel.Dock = DockStyle.Left;
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new Size(192, 214);
            this.SearchPanel.TabIndex = 0;
            this.NegateBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.NegateBox.Location = new Point(16, 120);
            this.NegateBox.Name = "NegateBox";
            this.NegateBox.Size = new Size(152, 32);
            this.NegateBox.TabIndex = 3;
            this.NegateBox.Text = "Search for items which do NOT contain this text";
            this.NegateBox.CheckedChanged += new EventHandler(this.NegateBox_CheckedChanged);
            this.CaseSensitiveBox.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.CaseSensitiveBox.Location = new Point(16, 88);
            this.CaseSensitiveBox.Name = "CaseSensitiveBox";
            this.CaseSensitiveBox.Size = new Size(96, 24);
            this.CaseSensitiveBox.TabIndex = 2;
            this.CaseSensitiveBox.Text = "Case-sensitive";
            this.CaseSensitiveBox.CheckedChanged += new EventHandler(this.CaseSensitiveBox_CheckedChanged);
            this.SearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.SearchTextBox.Location = new Point(16, 56);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new Size(156, 21);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.Text = "";
            this.SearchTextBox.TextChanged += new EventHandler(this.SearchTextBox_TextChanged);
            this.SearchForLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.SearchForLbl.Location = new Point(16, 16);
            this.SearchForLbl.Name = "SearchForLbl";
            this.SearchForLbl.Size = new Size(152, 32);
            this.SearchForLbl.TabIndex = 0;
            this.SearchForLbl.Text = "Search for items containing the following text:";
            this.SearchForLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.NewSearchBtn.ImageIndex = 0;
            this.NewSearchBtn.ToolTipText = "New Search";
            this.ToolBar.Appearance = ToolBarAppearance.Flat;
            this.ToolBar.Buttons.AddRange(new ToolBarButton[1]
            {
        this.NewSearchBtn
            });
            this.ToolBar.ButtonSize = new Size(23, 22);
            this.ToolBar.DropDownArrows = true;
            this.ToolBar.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.ToolBar.ImageList = this.ToolbarImages;
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.ShowToolTips = true;
            this.ToolBar.Size = new Size(560, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.ToolBar_ButtonClick);
            this.Controls.AddRange(new Control[2]
            {
        (Control) this.TypePages,
        (Control) this.ToolBar
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.Name = nameof(SearchPage);
            this.Size = new Size(560, 264);
            this.StandardPage.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public string Title
        {
            get
            {
                return "Search";
            }
        }

        public bool IsObsolete
        {
            get
            {
                return false;
            }
        }

        public void UpdateUI()
        {
            this.ResultOpen.Enabled = this.SelectedResult != null;
            this.ResultProperties.Enabled = this.SelectedResult != null;
            this.NewSearchBtn.Enabled = true;
        }

        public void UpdateData()
        {
            this.update_simple_page();
        }

        public string SimpleText
        {
            get
            {
                return this.SearchTextBox.Text;
            }
            set
            {
                this.SearchTextBox.Text = value;
            }
        }

        public bool SimpleCaseSensitive
        {
            get
            {
                return this.CaseSensitiveBox.Checked;
            }
            set
            {
                this.CaseSensitiveBox.Checked = value;
            }
        }

        public SearchResult SelectedResult
        {
            get
            {
                if (this.TypePages.SelectedTab == this.StandardPage && this.ResultsList.SelectedItems.Count != 0)
                    return this.ResultsList.SelectedItems[0].Tag as SearchResult;
                return (SearchResult)null;
            }
        }

        public void AddCustomSearches(ICustomSearch[] array)
        {
            foreach (ICustomSearch customSearch in array)
            {
                this.fCustomSearches.Add((object)customSearch);
                this.TypePages.TabPages.Add(new Crownwood.Magic.Controls.TabPage(customSearch.Name, customSearch.Control));
                customSearch.Init();
            }
            if (this.TypePages.TabPages.Count <= 1)
                return;
            this.TypePages.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
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

        private void ResultsList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedResult == null)
                return;
            this.ResultOpen_Click(sender, e);
        }

        private void SimpleResultsList_MouseDown(object sender, MouseEventArgs e)
        {
            this.ResultsList.SelectedItems.Clear();
            ListViewItem itemAt = this.ResultsList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.UpdateUI();
        }

        private void update_simple_page()
        {
            string text = this.SearchTextBox.Text;
            bool casesensitive = this.CaseSensitiveBox.Checked;
            bool negated = this.NegateBox.Checked;
            if (text != "")
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.update_results(LabyrinthData.Project.PerformSearch(text.Split((char[])null), casesensitive, negated), this.ResultsList);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
                this.ResultsList.Items.Clear();
        }

        private void update_results(SearchResult[] results, ListView control)
        {
            control.BeginUpdate();
            control.Items.Clear();
            if (results.Length != 0)
            {
                ArrayList arrayList = new ArrayList();
                foreach (SearchResult result in results)
                    arrayList.Add((object)new ListViewItem(result.Data.ToString())
                    {
                        SubItems = {
              result.Data.GetType().Name,
              result.Details != null ? result.Details.ToString() : ""
            },
                        ImageIndex = LabyrinthData.GetImageIndex(result.Data),
                        Tag = (object)result
                    });
                control.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            }
            else
            {
                ListViewItem listViewItem = control.Items.Add("No results were found.");
                listViewItem.ImageIndex = 0;
                listViewItem.ForeColor = SystemColors.GrayText;
            }
            control.EndUpdate();
        }

        private void ResultOpen_Click(object sender, EventArgs e)
        {
            if (this.SelectedResult == null)
                return;
            Element data1 = this.SelectedResult.Data as Element;
            if (data1 != null)
            {
                this.OnElementActivated(new ElementEventArgs(data1));
            }
            else
            {
                Structure data2 = this.SelectedResult.Data as Structure;
                if (data2 != null)
                {
                    this.OnStructureActivated(new StructureEventArgs(data2));
                }
                else
                {
                    Timeline data3 = this.SelectedResult.Data as Timeline;
                    if (data3 != null)
                    {
                        this.OnTimelineActivated(new TimelineEventArgs(data3));
                    }
                    else
                    {
                        Annotation data4 = this.SelectedResult.Data as Annotation;
                        if (data4 != null)
                        {
                            Element details1 = this.SelectedResult.Details as Element;
                            Timeline details2 = this.SelectedResult.Details as Timeline;
                            if (details1 != null)
                                this.OnElementActivated(new ElementEventArgs(details1));
                            else if (details2 != null)
                                this.OnTimelineActivated(new TimelineEventArgs(details2));
                            else
                                this.open_annotation(data4);
                        }
                        else
                        {
                            Labyrinth.Plot.Link data5 = this.SelectedResult.Data as Labyrinth.Plot.Link;
                            if (data5 == null)
                                return;
                            Structure details = this.SelectedResult.Details as Structure;
                            if (details != null)
                                this.OnStructureActivated(new StructureEventArgs(details));
                            else
                                this.open_link(data5);
                        }
                    }
                }
            }
        }

        private void ResultProperties_Click(object sender, EventArgs e)
        {
            if (this.SelectedResult == null)
                return;
            Element data1 = this.SelectedResult.Data as Element;
            if (data1 != null)
            {
                this.open_element(data1);
            }
            else
            {
                Structure data2 = this.SelectedResult.Data as Structure;
                if (data2 != null)
                {
                    this.open_structure(data2);
                }
                else
                {
                    Timeline data3 = this.SelectedResult.Data as Timeline;
                    if (data3 != null)
                    {
                        this.open_timeline(data3);
                    }
                    else
                    {
                        Annotation data4 = this.SelectedResult.Data as Annotation;
                        if (data4 != null)
                        {
                            this.open_annotation(data4);
                        }
                        else
                        {
                            Labyrinth.Plot.Link data5 = this.SelectedResult.Data as Labyrinth.Plot.Link;
                            if (data5 == null)
                                return;
                            this.open_link(data5);
                        }
                    }
                }
            }
        }

        private void open_element(Element e)
        {
            if (new ElementDlg(e).ShowDialog() != DialogResult.OK)
                return;
            this.OnElementModified(new ElementEventArgs(e));
        }

        private void open_structure(Structure s)
        {
            if (new StructureDlg(s).ShowDialog() != DialogResult.OK)
                return;
            this.OnStructureModified(new StructureEventArgs(s));
        }

        private void open_timeline(Timeline tl)
        {
            if (new TimelineDlg(tl).ShowDialog() != DialogResult.OK)
                return;
            this.OnTimelineModified(new TimelineEventArgs(tl));
        }

        private void open_annotation(Annotation note)
        {
            if (!Annotations.Open(note))
                return;
            foreach (Element element in LabyrinthData.Project.Elements)
            {
                if (element.Annotations.Contains(note))
                {
                    this.OnElementModified(new ElementEventArgs(element));
                    return;
                }
            }
            foreach (Timeline timeline in LabyrinthData.Project.Timelines)
            {
                foreach (TimelinePoint point in timeline.Points)
                {
                    foreach (TimelineItem timelineItem in point.Items)
                    {
                        if (timelineItem.Annotation == note)
                        {
                            this.OnTimelineModified(new TimelineEventArgs(timeline));
                            return;
                        }
                    }
                }
            }
        }

        private void open_link(Labyrinth.Plot.Link l)
        {
            if (new LinkDlg(l).ShowDialog() != DialogResult.OK)
                return;
            foreach (Structure structure in LabyrinthData.Project.Structures)
            {
                if (structure.Links.Contains(l))
                {
                    this.OnStructureModified(new StructureEventArgs(structure));
                    break;
                }
            }
        }

        private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button != this.NewSearchBtn)
                    return;
                this.SearchTextBox.Text = "";
                this.CaseSensitiveBox.Checked = false;
                this.update_simple_page();
                foreach (ICustomSearch fCustomSearch in this.fCustomSearches)
                    fCustomSearch.Clear();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.update_simple_page();
        }

        private void CaseSensitiveBox_CheckedChanged(object sender, EventArgs e)
        {
            this.update_simple_page();
        }

        private void NegateBox_CheckedChanged(object sender, EventArgs e)
        {
            this.update_simple_page();
        }

        private void SimpleResultsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.ResultsList, e.Column);
        }
    }
}