// Decompiled with JetBrains decompiler
// Type: Labyrinth.Pages.AnnotationPage
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Events;
using Labyrinth.Extensibility;
using Labyrinth.Plot;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Pages
{
    public class AnnotationPage : UserControl, IAnnotationPage, IPage
    {
        private bool fShowText = true;
        private bool fShowLink = true;
        private bool fShowSketch = true;
        private ToolBar ToolBar;
        private ImageList ToolbarImages;
        private ToolBarButton TextBtn;
        private ToolBarButton LinkBtn;
        private ToolBarButton SketchBtn;
        private ListView AnnotationList;
        private ContextMenu AnnotationMenu;
        private MenuItem OpenAnnotation;
        private ColumnHeader AnnotationHdr;
        private ColumnHeader SourceHdr;
        private MenuItem OpenSource;
        private ToolBarButton Sep1;
        private ToolBarButton ExportBtn;
        private IContainer components;

        public AnnotationPage()
        {
            this.InitializeComponent();
            this.AnnotationList.SmallImageList = LabyrinthData.ElementImages;
            this.AnnotationList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.update_annotations();
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
            ResourceManager resourceManager = new ResourceManager(typeof(AnnotationPage));
            this.ToolbarImages = new ImageList(this.components);
            this.ToolBar = new ToolBar();
            this.TextBtn = new ToolBarButton();
            this.LinkBtn = new ToolBarButton();
            this.SketchBtn = new ToolBarButton();
            this.AnnotationList = new ListView();
            this.AnnotationHdr = new ColumnHeader();
            this.SourceHdr = new ColumnHeader();
            this.AnnotationMenu = new ContextMenu();
            this.OpenAnnotation = new MenuItem();
            this.OpenSource = new MenuItem();
            this.Sep1 = new ToolBarButton();
            this.ExportBtn = new ToolBarButton();
            this.SuspendLayout();
            this.ToolbarImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ToolbarImages.ImageSize = new Size(16, 16);
            this.ToolbarImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ToolbarImages.ImageStream");
            this.ToolbarImages.TransparentColor = Color.Magenta;
            this.ToolBar.Appearance = ToolBarAppearance.Flat;
            this.ToolBar.Buttons.AddRange(new ToolBarButton[5]
            {
        this.TextBtn,
        this.LinkBtn,
        this.SketchBtn,
        this.Sep1,
        this.ExportBtn
            });
            this.ToolBar.DropDownArrows = true;
            this.ToolBar.ImageList = this.ToolbarImages;
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.ShowToolTips = true;
            this.ToolBar.Size = new Size(552, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.ToolBar_ButtonClick);
            this.TextBtn.ImageIndex = 0;
            this.TextBtn.ToolTipText = "Show Text Annotations";
            this.LinkBtn.ImageIndex = 1;
            this.LinkBtn.ToolTipText = "Show Link Annotations";
            this.SketchBtn.ImageIndex = 2;
            this.SketchBtn.ToolTipText = "Show Sketch Annotations";
            this.AnnotationList.Columns.AddRange(new ColumnHeader[2]
            {
        this.AnnotationHdr,
        this.SourceHdr
            });
            this.AnnotationList.ContextMenu = this.AnnotationMenu;
            this.AnnotationList.Dock = DockStyle.Fill;
            this.AnnotationList.FullRowSelect = true;
            this.AnnotationList.Location = new Point(0, 25);
            this.AnnotationList.Name = "AnnotationList";
            this.AnnotationList.Size = new Size(552, 231);
            this.AnnotationList.Sorting = SortOrder.Ascending;
            this.AnnotationList.TabIndex = 1;
            this.AnnotationList.View = View.Details;
            this.AnnotationList.MouseDown += new MouseEventHandler(this.AnnotationList_MouseDown);
            this.AnnotationList.DoubleClick += new EventHandler(this.AnnotationList_DoubleClick);
            this.AnnotationList.ColumnClick += new ColumnClickEventHandler(this.AnnotationList_ColumnClick);
            this.AnnotationHdr.Text = "Annotation";
            this.AnnotationHdr.Width = 250;
            this.SourceHdr.Text = "Source";
            this.SourceHdr.Width = 120;
            this.AnnotationMenu.MenuItems.AddRange(new MenuItem[2]
            {
        this.OpenAnnotation,
        this.OpenSource
            });
            this.OpenAnnotation.Index = 0;
            this.OpenAnnotation.Text = "Open Annotation";
            this.OpenAnnotation.Click += new EventHandler(this.OpenAnnotation_Click);
            this.OpenSource.Index = 1;
            this.OpenSource.Text = "Open Source";
            this.OpenSource.Click += new EventHandler(this.OpenSource_Click);
            this.Sep1.Style = ToolBarButtonStyle.Separator;
            this.ExportBtn.ImageIndex = 3;
            this.ExportBtn.ToolTipText = "Export Annotations";
            this.Controls.AddRange(new Control[2]
            {
        (Control) this.AnnotationList,
        (Control) this.ToolBar
            });
            this.Name = nameof(AnnotationPage);
            this.Size = new Size(552, 256);
            this.ResumeLayout(false);
        }

        public string Title
        {
            get
            {
                return "Annotation List";
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
            this.OpenAnnotation.Enabled = this.SelectedAnnotation != null;
            this.TextBtn.Enabled = true;
            this.TextBtn.Pushed = this.fShowText;
            this.LinkBtn.Enabled = true;
            this.LinkBtn.Pushed = this.fShowLink;
            this.SketchBtn.Enabled = true;
            this.SketchBtn.Pushed = this.fShowSketch;
        }

        public void UpdateData()
        {
            this.update_annotations();
        }

        public bool ShowTextAnnotations
        {
            get
            {
                return this.fShowText;
            }
            set
            {
                this.fShowText = value;
            }
        }

        public bool ShowLinkAnnotations
        {
            get
            {
                return this.fShowLink;
            }
            set
            {
                this.fShowLink = value;
            }
        }

        public bool ShowSketchAnnotations
        {
            get
            {
                return this.fShowSketch;
            }
            set
            {
                this.fShowSketch = value;
            }
        }

        public Annotation SelectedAnnotation
        {
            get
            {
                if (this.AnnotationList.SelectedItems.Count != 0)
                    return this.AnnotationList.SelectedItems[0].Tag as Annotation;
                return (Annotation)null;
            }
        }

        public event ElementEventHandler ElementModified;

        public event ElementEventHandler ElementActivated;

        public event TimelineEventHandler TimelineModified;

        public event TimelineEventHandler TimelineActivated;

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

        private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.TextBtn)
                {
                    this.fShowText = !this.fShowText;
                    this.update_annotations();
                }
                else if (e.Button == this.LinkBtn)
                {
                    this.fShowLink = !this.fShowLink;
                    this.update_annotations();
                }
                else if (e.Button == this.SketchBtn)
                {
                    this.fShowSketch = !this.fShowSketch;
                    this.update_annotations();
                }
                else
                {
                    if (e.Button != this.ExportBtn)
                        return;
                    string str1 = "HTML Files|*.html|Text Files|*.txt";
                    try
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.FileName = LabyrinthData.Project.Name + " Annotations";
                        saveFileDialog.Filter = str1;
                        if (saveFileDialog.ShowDialog() != DialogResult.OK)
                            return;
                        string str2 = this.export_annotations(saveFileDialog.FilterIndex == 1);
                        StreamWriter text = File.CreateText(saveFileDialog.FileName);
                        text.WriteLine(str2);
                        text.Close();
                    }
                    catch (Exception ex)
                    {
                        LabyrinthData.Log((object)ex);
                    }
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void AnnotationList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedAnnotation == null)
                return;
            this.OpenAnnotation_Click(sender, e);
        }

        private void AnnotationList_MouseDown(object sender, MouseEventArgs e)
        {
            this.AnnotationList.SelectedItems.Clear();
            ListViewItem itemAt = this.AnnotationList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.UpdateUI();
        }

        private void AnnotationList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.AnnotationList, e.Column);
        }

        public void update_annotations()
        {
            this.AnnotationList.BeginUpdate();
            this.AnnotationList.Items.Clear();
            ArrayList arrayList = new ArrayList();
            foreach (Element element in LabyrinthData.Project.Elements)
            {
                foreach (Annotation annotation1 in element.Annotations)
                {
                    ListViewItem annotation2 = this.get_annotation(annotation1, (object)element);
                    if (annotation2 != null)
                        arrayList.Add((object)annotation2);
                }
            }
            foreach (Timeline timeline in LabyrinthData.Project.Timelines)
            {
                foreach (TimelinePoint point in timeline.Points)
                {
                    foreach (TimelineItem timelineItem in point.Items)
                    {
                        ListViewItem annotation = this.get_annotation((Annotation)timelineItem.Annotation, (object)timeline);
                        if (annotation != null)
                            arrayList.Add((object)annotation);
                    }
                }
            }
            this.AnnotationList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            if (this.AnnotationList.Items.Count == 0)
            {
                ListViewItem listViewItem = this.AnnotationList.Items.Add("No annotations");
                listViewItem.ForeColor = SystemColors.GrayText;
                listViewItem.ImageIndex = -1;
            }
            this.AnnotationList.EndUpdate();
        }

        private ListViewItem get_annotation(Annotation a, object source)
        {
            if (a is TextAnnotation && !this.fShowText)
                return (ListViewItem)null;
            if (a is LinkAnnotation && !this.fShowLink)
                return (ListViewItem)null;
            if (a is SketchAnnotation && !this.fShowSketch)
                return (ListViewItem)null;
            return new ListViewItem(a.Title)
            {
                SubItems = {
          source.ToString()
        },
                ImageIndex = LabyrinthData.GetImageIndex(a),
                Tag = (object)a
            };
        }

        private string export_annotations(bool markup)
        {
            string str1 = "";
            string title = LabyrinthData.Project.Name + " Annotations";
            if (markup)
                str1 = str1 + "<html>" + Environment.NewLine + LabyrinthData.HTMLHeader(title) + Environment.NewLine + "<body>" + Environment.NewLine;
            if (markup)
                str1 += "<p class=header>";
            string str2 = str1 + title;
            if (markup)
                str2 += "</p>";
            string str3 = str2 + Environment.NewLine;
            foreach (ListViewItem listViewItem in this.AnnotationList.Items)
            {
                Annotation tag = listViewItem.Tag as Annotation;
                if (tag != null)
                {
                    str3 += Environment.NewLine;
                    if (markup)
                        str3 = str3 + "<p class=annotationtitle>" + Environment.NewLine;
                    str3 = str3 + tag.Title + Environment.NewLine;
                    if (markup)
                        str3 = str3 + "</p>" + Environment.NewLine;
                    object source = this.get_source(tag);
                    if (source != null)
                    {
                        if (markup)
                            str3 = str3 + "<p class=annotationsource>" + Environment.NewLine;
                        str3 = str3 + source.ToString() + Environment.NewLine;
                        if (markup)
                            str3 = str3 + "</p>" + Environment.NewLine;
                    }
                    if (markup)
                        str3 = str3 + "<p class=annotationcontent>" + Environment.NewLine;
                    str3 = str3 + (markup ? tag.Content.Replace("\n", "<br>") : tag.Content) + Environment.NewLine;
                    if (markup)
                        str3 = str3 + "</p>" + Environment.NewLine;
                }
            }
            if (markup)
                str3 = str3 + "</body>" + Environment.NewLine + "</html>" + Environment.NewLine;
            return str3;
        }

        private void OpenAnnotation_Click(object sender, EventArgs e)
        {
            if (this.SelectedAnnotation == null || !Annotations.Open(this.SelectedAnnotation))
                return;
            object source = this.get_source(this.SelectedAnnotation);
            if (source is Element)
                this.OnElementModified(new ElementEventArgs(source as Element));
            if (source is Timeline)
                this.OnTimelineModified(new TimelineEventArgs(source as Timeline));
            this.update_annotations();
        }

        private object get_source(Annotation a)
        {
            foreach (Element element in LabyrinthData.Project.Elements)
            {
                if (element.Annotations.Contains(a))
                    return (object)element;
            }
            foreach (Timeline timeline in LabyrinthData.Project.Timelines)
            {
                foreach (TimelinePoint point in timeline.Points)
                {
                    foreach (TimelineItem timelineItem in point.Items)
                    {
                        if (timelineItem.Annotation == a)
                            return (object)timeline;
                    }
                }
            }
            return (object)null;
        }

        private void OpenSource_Click(object sender, EventArgs e)
        {
            object source = this.get_source(this.SelectedAnnotation);
            if (source is Element)
                this.OnElementActivated(new ElementEventArgs(source as Element));
            if (!(source is Timeline))
                return;
            this.OnTimelineActivated(new TimelineEventArgs(source as Timeline));
        }
    }
}