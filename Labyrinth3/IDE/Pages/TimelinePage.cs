// Decompiled with JetBrains decompiler
// Type: Labyrinth.Pages.TimelinePage
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Pages
{
    public class TimelinePage : UserControl, ITimelinePage, IPage
    {
        private Timeline fTimeline = (Timeline)null;
        private int fZoom = 0;
        private IContainer components;
        private ImageList ToolbarImages;
        private ToolBar ToolBar;
        private ContextMenu TimelineContextMenu;
        private MenuItem TimelineDeleteAnnotation;
        private MenuItem TimelineAnnotationProperties;
        private MenuItem TimelineNewAnnotation;
        private MenuItem menuItem10;
        private MenuItem menuItem9;
        private MenuItem TimelinePointProperties;
        private MenuItem TimelineDeletePoint;
        private MenuItem TimelineNewPoint;
        private MenuItem TimelineElementProperties;
        private MenuItem TimelineDeleteElement;
        private MenuItem TimelineOpenElement;
        private ToolBarButton Sep1;
        private ToolBarButton MoveLeftBtn;
        private ToolBarButton MoveRightBtn;
        private ToolBarButton Sep2;
        private ToolBarButton MoveUpBtn;
        private ToolBarButton MoveDownBtn;
        private ToolBarButton Sep3;
        private ToolBarButton ExportBtn;
        private ToolBarButton PrintBtn;
        private ToolBarButton PrintPreviewBtn;
        private TimelineGrid TimelineGrid;
        private Panel TimelinePanel;
        private ToolBarButton Sep4;
        private ToolBarButton ZoomInBtn;
        private ToolBarButton ZoomOutBtn;
        private ToolBarButton PropertiesBtn;

        public TimelinePage(Timeline tl)
        {
            this.InitializeComponent();
            this.fTimeline = tl;
            this.TimelineGrid.Location = new Point(0, 0);
            this.TimelineGrid.Timeline = this.fTimeline;
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
            ResourceManager resourceManager = new ResourceManager(typeof(TimelinePage));
            this.ToolbarImages = new ImageList(this.components);
            this.ToolBar = new ToolBar();
            this.PropertiesBtn = new ToolBarButton();
            this.PrintBtn = new ToolBarButton();
            this.PrintPreviewBtn = new ToolBarButton();
            this.Sep1 = new ToolBarButton();
            this.MoveLeftBtn = new ToolBarButton();
            this.MoveRightBtn = new ToolBarButton();
            this.Sep2 = new ToolBarButton();
            this.MoveUpBtn = new ToolBarButton();
            this.MoveDownBtn = new ToolBarButton();
            this.Sep3 = new ToolBarButton();
            this.ExportBtn = new ToolBarButton();
            this.Sep4 = new ToolBarButton();
            this.ZoomInBtn = new ToolBarButton();
            this.ZoomOutBtn = new ToolBarButton();
            this.TimelineContextMenu = new ContextMenu();
            this.TimelineNewAnnotation = new MenuItem();
            this.TimelineAnnotationProperties = new MenuItem();
            this.TimelineDeleteAnnotation = new MenuItem();
            this.menuItem9 = new MenuItem();
            this.TimelineOpenElement = new MenuItem();
            this.TimelineDeleteElement = new MenuItem();
            this.TimelineElementProperties = new MenuItem();
            this.menuItem10 = new MenuItem();
            this.TimelineNewPoint = new MenuItem();
            this.TimelineDeletePoint = new MenuItem();
            this.TimelinePointProperties = new MenuItem();
            this.TimelineGrid = new TimelineGrid();
            this.TimelinePanel = new Panel();
            this.TimelinePanel.SuspendLayout();
            this.SuspendLayout();
            this.ToolbarImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ToolbarImages.ImageSize = new Size(16, 16);
            this.ToolbarImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ToolbarImages.ImageStream");
            this.ToolbarImages.TransparentColor = Color.Magenta;
            this.ToolBar.Appearance = ToolBarAppearance.Flat;
            this.ToolBar.Buttons.AddRange(new ToolBarButton[14]
            {
        this.PropertiesBtn,
        this.PrintBtn,
        this.PrintPreviewBtn,
        this.Sep1,
        this.MoveLeftBtn,
        this.MoveRightBtn,
        this.Sep2,
        this.MoveUpBtn,
        this.MoveDownBtn,
        this.Sep3,
        this.ExportBtn,
        this.Sep4,
        this.ZoomInBtn,
        this.ZoomOutBtn
            });
            this.ToolBar.DropDownArrows = true;
            this.ToolBar.ImageList = this.ToolbarImages;
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.ShowToolTips = true;
            this.ToolBar.Size = new Size(360, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.ToolBar_ButtonClick);
            this.PropertiesBtn.ImageIndex = 0;
            this.PrintBtn.ImageIndex = 6;
            this.PrintBtn.ToolTipText = "Print";
            this.PrintPreviewBtn.ImageIndex = 7;
            this.PrintPreviewBtn.ToolTipText = "Print Preview";
            this.Sep1.Style = ToolBarButtonStyle.Separator;
            this.MoveLeftBtn.ImageIndex = 1;
            this.MoveLeftBtn.ToolTipText = "Move left";
            this.MoveRightBtn.ImageIndex = 2;
            this.MoveRightBtn.ToolTipText = "Move right";
            this.Sep2.Style = ToolBarButtonStyle.Separator;
            this.MoveUpBtn.ImageIndex = 3;
            this.MoveUpBtn.ToolTipText = "Move up";
            this.MoveDownBtn.ImageIndex = 4;
            this.MoveDownBtn.ToolTipText = "Move down";
            this.Sep3.Style = ToolBarButtonStyle.Separator;
            this.ExportBtn.ImageIndex = 5;
            this.ExportBtn.ToolTipText = "Export Timeline";
            this.Sep4.Style = ToolBarButtonStyle.Separator;
            this.ZoomInBtn.ImageIndex = 8;
            this.ZoomInBtn.ToolTipText = "Zoom In";
            this.ZoomOutBtn.ImageIndex = 9;
            this.ZoomOutBtn.ToolTipText = "Zoom Out";
            this.TimelineContextMenu.MenuItems.AddRange(new MenuItem[11]
            {
        this.TimelineNewAnnotation,
        this.TimelineAnnotationProperties,
        this.TimelineDeleteAnnotation,
        this.menuItem9,
        this.TimelineOpenElement,
        this.TimelineDeleteElement,
        this.TimelineElementProperties,
        this.menuItem10,
        this.TimelineNewPoint,
        this.TimelineDeletePoint,
        this.TimelinePointProperties
            });
            this.TimelineNewAnnotation.Index = 0;
            this.TimelineNewAnnotation.Text = "New Annotation...";
            this.TimelineNewAnnotation.Click += new EventHandler(this.TimelineAddAnnotation_Click);
            this.TimelineAnnotationProperties.Index = 1;
            this.TimelineAnnotationProperties.Text = "Open Annotation";
            this.TimelineAnnotationProperties.Click += new EventHandler(this.TimelineAnnotationProperties_Click);
            this.TimelineDeleteAnnotation.Index = 2;
            this.TimelineDeleteAnnotation.Text = "Delete Annotation";
            this.TimelineDeleteAnnotation.Click += new EventHandler(this.TimelineDeleteAnnotation_Click);
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "-";
            this.TimelineOpenElement.Index = 4;
            this.TimelineOpenElement.Text = "Open Element";
            this.TimelineOpenElement.Click += new EventHandler(this.TimelineOpenElement_Click);
            this.TimelineDeleteElement.Index = 5;
            this.TimelineDeleteElement.Text = "Remove Element";
            this.TimelineDeleteElement.Click += new EventHandler(this.TimelineDeleteElement_Click);
            this.TimelineElementProperties.Index = 6;
            this.TimelineElementProperties.Text = "Element Properties";
            this.TimelineElementProperties.Click += new EventHandler(this.TimelineElementProperties_Click);
            this.menuItem10.Index = 7;
            this.menuItem10.Text = "-";
            this.TimelineNewPoint.Index = 8;
            this.TimelineNewPoint.Text = "New Point...";
            this.TimelineNewPoint.Click += new EventHandler(this.TimelineAddPoint_Click);
            this.TimelineDeletePoint.Index = 9;
            this.TimelineDeletePoint.Text = "Delete Point";
            this.TimelineDeletePoint.Click += new EventHandler(this.TimelineDeletePoint_Click);
            this.TimelinePointProperties.Index = 10;
            this.TimelinePointProperties.Text = "Point Properties";
            this.TimelinePointProperties.Click += new EventHandler(this.TimelinePointProperties_Click);
            this.TimelineGrid.AllowDrop = true;
            this.TimelineGrid.ContextMenu = this.TimelineContextMenu;
            this.TimelineGrid.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.TimelineGrid.Location = new Point(8, 8);
            this.TimelineGrid.Name = "TimelineGrid";
            this.TimelineGrid.Size = new Size(224, 85);
            this.TimelineGrid.TabIndex = 1;
            this.TimelineGrid.Timeline = (Timeline)null;
            this.TimelineGrid.DragDrop += new DragEventHandler(this.RowHdrPanel_DragDrop);
            this.TimelineGrid.DoubleClick += new EventHandler(this.TimelineGrid_DoubleClick);
            this.TimelineGrid.DragOver += new DragEventHandler(this.RowHdrPanel_DragOver);
            this.TimelinePanel.AutoScroll = true;
            this.TimelinePanel.Controls.AddRange(new Control[1]
            {
        (Control) this.TimelineGrid
            });
            this.TimelinePanel.Dock = DockStyle.Fill;
            this.TimelinePanel.Location = new Point(0, 25);
            this.TimelinePanel.Name = "TimelinePanel";
            this.TimelinePanel.Size = new Size(360, 215);
            this.TimelinePanel.TabIndex = 2;
            this.TimelinePanel.Layout += new LayoutEventHandler(this.TimelinePanel_Layout);
            this.Controls.AddRange(new Control[2]
            {
        (Control) this.TimelinePanel,
        (Control) this.ToolBar
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.Name = nameof(TimelinePage);
            this.Size = new Size(360, 240);
            this.TimelinePanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public string Title
        {
            get
            {
                return this.fTimeline.Name;
            }
        }

        public bool IsObsolete
        {
            get
            {
                return LabyrinthData.Project.Timelines.IndexOf(this.fTimeline) == -1;
            }
        }

        public void UpdateUI()
        {
            Element selectedElement = this.TimelineGrid.SelectedElement;
            TimelinePoint selectedPoint = this.TimelineGrid.SelectedPoint;
            Annotation annotation = this.get_annotation(selectedElement, selectedPoint);
            this.TimelineNewAnnotation.Enabled = selectedElement != null && selectedPoint != null && annotation == null;
            this.TimelineDeleteAnnotation.Enabled = selectedElement != null && selectedPoint != null && annotation != null;
            this.TimelineAnnotationProperties.Enabled = annotation != null;
            this.TimelineOpenElement.Enabled = selectedElement != null;
            this.TimelineDeleteElement.Enabled = selectedElement != null;
            this.TimelineElementProperties.Enabled = selectedElement != null;
            this.TimelineNewPoint.Enabled = true;
            this.TimelineDeletePoint.Enabled = selectedPoint != null;
            this.TimelinePointProperties.Enabled = selectedPoint != null;
            this.PropertiesBtn.Enabled = true;
            this.PrintBtn.Enabled = true;
            this.PrintPreviewBtn.Enabled = true;
            this.MoveLeftBtn.Enabled = !this.fTimeline.Sorting && selectedPoint != null && this.fTimeline.Points.Count != 0 && selectedPoint != this.fTimeline.Points[0];
            this.MoveRightBtn.Enabled = !this.fTimeline.Sorting && selectedPoint != null && this.fTimeline.Points.Count != 0 && selectedPoint != this.fTimeline.Points[this.fTimeline.Points.Count - 1];
            this.MoveUpBtn.Enabled = selectedElement != null && this.fTimeline.ElementIDs.Count != 0 && selectedElement.ID != this.fTimeline.ElementIDs[0];
            this.MoveDownBtn.Enabled = selectedElement != null && this.fTimeline.ElementIDs.Count != 0 && selectedElement.ID != this.fTimeline.ElementIDs[this.fTimeline.ElementIDs.Count - 1];
            this.ExportBtn.Enabled = true;
            this.ZoomInBtn.Enabled = true;
            this.ZoomOutBtn.Enabled = this.fZoom != 0;
        }

        public void UpdateData()
        {
            if (this.fTimeline.Sorting)
                this.fTimeline.Points.Sort();
            this.TimelineGrid.Refresh();
        }

        public Timeline Timeline
        {
            get
            {
                return this.fTimeline;
            }
        }

        public Element SelectedElement
        {
            get
            {
                return this.TimelineGrid.SelectedElement;
            }
        }

        public TimelinePoint SelectedPoint
        {
            get
            {
                return this.TimelineGrid.SelectedPoint;
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
                this.resize_grid();
            }
        }

        public event TimelineEventHandler TimelineModified;

        public event ElementEventHandler ElementModified;

        public event ElementEventHandler ElementActivated;

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

        private void RowHdrPanel_DragOver(object sender, DragEventArgs e)
        {
            this.OnDragOver(e);
            this.TimelineGrid.RecalculateHover();
            e.Effect = DragDropEffects.None;
            string str = "";
            foreach (string format in e.Data.GetFormats())
            {
                if (str != "")
                    str += "; ";
                str += format;
            }
            Element data1 = e.Data.GetData(typeof(Element)) as Element;
            Structure data2 = e.Data.GetData(typeof(Structure)) as Structure;
            Timeline data3 = e.Data.GetData(typeof(Timeline)) as Timeline;
            if (data1 != null || data2 != null || data3 != null && data3 != this.fTimeline)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                string[] data4 = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (data4.Length == 0 || !File.Exists(data4[0]) || this.TimelineGrid.HoverElement == null || (this.TimelineGrid.HoverPoint == null || this.get_annotation(this.TimelineGrid.HoverElement, this.TimelineGrid.HoverPoint) != null))
                    return;
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void RowHdrPanel_DragDrop(object sender, DragEventArgs e)
        {
            this.OnDragDrop(e);
            bool flag = false;
            Element data1 = e.Data.GetData(typeof(Element)) as Element;
            if (data1 != null)
            {
                if (this.fTimeline.ElementIDs.Contains(data1.ID))
                {
                    int num = (int)MessageBox.Show("This element is already part of this timeline.", "Labyrinth", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                this.fTimeline.ElementIDs.Add(data1.ID);
                flag = true;
            }
            Structure data2 = e.Data.GetData(typeof(Structure)) as Structure;
            if (data2 != null)
            {
                if (MessageBox.Show("Do you want to add all the elements from this structure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                foreach (Node node in data2.Nodes)
                {
                    if (!this.fTimeline.ElementIDs.Contains(node.ElementID))
                    {
                        this.fTimeline.ElementIDs.Add(node.ElementID);
                        flag = true;
                    }
                }
            }
            Timeline data3 = e.Data.GetData(typeof(Timeline)) as Timeline;
            if (data3 != null)
            {
                if (MessageBox.Show("Do you want to add all the elements from this timeline?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                foreach (Guid elementId in data3.ElementIDs)
                {
                    if (!this.fTimeline.ElementIDs.Contains(elementId))
                    {
                        this.fTimeline.ElementIDs.Add(elementId);
                        flag = true;
                    }
                }
            }
            string[] data4 = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (data4.Length != 0 && this.get_annotation(this.TimelineGrid.HoverElement, this.TimelineGrid.HoverPoint) == null)
            {
                string str = data4[0];
                FileInfo fileInfo = new FileInfo(str);
                if (fileInfo.Exists)
                {
                    string end = new StreamReader(str).ReadToEnd();
                    TimelineItem timelineItem = new TimelineItem();
                    timelineItem.ElementID = this.TimelineGrid.HoverElement.ID;
                    timelineItem.Annotation.Title = fileInfo.Name;
                    timelineItem.Annotation.Content = end;
                    this.TimelineGrid.HoverPoint.Items.Add(timelineItem);
                    flag = true;
                }
            }
            if (!flag)
                return;
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
        }

        private void TimelineAddAnnotation_Click(object sender, EventArgs e)
        {
            if (this.get_annotation(this.TimelineGrid.SelectedElement, this.TimelineGrid.SelectedPoint) != null)
                return;
            TextAnnotation textAnnotation = new TextAnnotation();
            textAnnotation.Title = "New Annotation";
            if (!Annotations.Open((Annotation)textAnnotation))
                return;
            this.TimelineGrid.SelectedPoint.Items.Add(new TimelineItem()
            {
                ElementID = this.TimelineGrid.SelectedElement.ID,
                Annotation = textAnnotation
            });
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
        }

        private void TimelineDeleteAnnotation_Click(object sender, EventArgs e)
        {
            Annotation annotation = this.get_annotation(this.TimelineGrid.SelectedElement, this.TimelineGrid.SelectedPoint);
            if (annotation == null || MessageBox.Show("Delete annotation '" + annotation.Title + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            TimelineItem timelineItem1 = (TimelineItem)null;
            foreach (TimelineItem timelineItem2 in this.TimelineGrid.SelectedPoint.Items)
            {
                if (timelineItem2.Annotation == annotation)
                {
                    timelineItem1 = timelineItem2;
                    break;
                }
            }
            if (timelineItem1 == null)
                return;
            this.TimelineGrid.SelectedPoint.Items.Remove(timelineItem1);
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
        }

        private void TimelineAnnotationProperties_Click(object sender, EventArgs e)
        {
            Annotation annotation = this.get_annotation(this.TimelineGrid.SelectedElement, this.TimelineGrid.SelectedPoint);
            if (annotation == null || !Annotations.Open(annotation))
                return;
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
        }

        private void TimelineOpenElement_Click(object sender, EventArgs e)
        {
            if (this.TimelineGrid.SelectedElement == null)
                return;
            this.OnElementActivated(new ElementEventArgs(this.TimelineGrid.SelectedElement));
        }

        private void TimelineDeleteElement_Click(object sender, EventArgs e)
        {
            if (this.TimelineGrid.SelectedElement == null || MessageBox.Show("Delete element reference: are you sure?" + "\n" + "The element itself will not be deleted.", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.fTimeline.RemoveElement(this.TimelineGrid.SelectedElement.ID);
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
        }

        private void TimelineElementProperties_Click(object sender, EventArgs e)
        {
            if (this.TimelineGrid.SelectedElement == null)
                return;
            Element selectedElement = this.TimelineGrid.SelectedElement;
            if (new ElementDlg(selectedElement).ShowDialog() != DialogResult.OK)
                return;
            this.UpdateData();
            this.OnElementModified(new ElementEventArgs(selectedElement));
        }

        private void TimelineAddPoint_Click(object sender, EventArgs e)
        {
            string str = "New Timeline Point";
            string name = str;
            int num = 1;
            for (; this.fTimeline.Points.IndexOf(name) != -1; name = str + " " + (object)num)
                ++num;
            TimelinePoint tlp = new TimelinePoint();
            tlp.Name = name;
            if (new TimelinePointDlg(tlp).ShowDialog() != DialogResult.OK)
                return;
            this.fTimeline.Points.Add(tlp);
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
        }

        private void TimelineDeletePoint_Click(object sender, EventArgs e)
        {
            if (this.TimelineGrid.SelectedPoint == null || MessageBox.Show("Delete point '" + this.TimelineGrid.SelectedPoint.Name + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.fTimeline.Points.Remove(this.TimelineGrid.SelectedPoint);
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
        }

        private void TimelinePointProperties_Click(object sender, EventArgs e)
        {
            if (this.TimelineGrid.SelectedPoint == null || new TimelinePointDlg(this.TimelineGrid.SelectedPoint).ShowDialog() != DialogResult.OK)
                return;
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
        }

        private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.PropertiesBtn)
                {
                    if (new TimelineDlg(this.fTimeline).ShowDialog() != DialogResult.OK)
                        return;
                    this.UpdateData();
                    this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
                }
                else if (e.Button == this.MoveLeftBtn)
                {
                    TimelinePoint selectedPoint = this.TimelineGrid.SelectedPoint;
                    if (selectedPoint == null)
                        return;
                    int index = this.Timeline.Points.IndexOf(selectedPoint);
                    if (index == 0)
                        return;
                    TimelinePoint point = this.Timeline.Points[index - 1];
                    this.Timeline.Points[index - 1] = selectedPoint;
                    this.Timeline.Points[index] = point;
                    this.UpdateData();
                    this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
                }
                else if (e.Button == this.MoveRightBtn)
                {
                    TimelinePoint selectedPoint = this.TimelineGrid.SelectedPoint;
                    if (selectedPoint == null)
                        return;
                    int index = this.Timeline.Points.IndexOf(selectedPoint);
                    if (index == this.Timeline.Points.Count - 1)
                        return;
                    TimelinePoint point = this.Timeline.Points[index + 1];
                    this.Timeline.Points[index + 1] = selectedPoint;
                    this.Timeline.Points[index] = point;
                    this.UpdateData();
                    this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
                }
                else if (e.Button == this.MoveUpBtn)
                {
                    Element selectedElement = this.TimelineGrid.SelectedElement;
                    if (selectedElement == null)
                        return;
                    int index = this.Timeline.ElementIDs.IndexOf(selectedElement.ID);
                    if (index == 0)
                        return;
                    Guid elementId = this.Timeline.ElementIDs[index - 1];
                    this.Timeline.ElementIDs[index - 1] = selectedElement.ID;
                    this.Timeline.ElementIDs[index] = elementId;
                    this.UpdateData();
                    this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
                }
                else if (e.Button == this.MoveDownBtn)
                {
                    Element selectedElement = this.TimelineGrid.SelectedElement;
                    if (selectedElement == null)
                        return;
                    int index = this.Timeline.ElementIDs.IndexOf(selectedElement.ID);
                    if (index == this.Timeline.ElementIDs.Count - 1)
                        return;
                    Guid elementId = this.Timeline.ElementIDs[index + 1];
                    this.Timeline.ElementIDs[index + 1] = selectedElement.ID;
                    this.Timeline.ElementIDs[index] = elementId;
                    this.UpdateData();
                    this.OnTimelineModified(new TimelineEventArgs(this.fTimeline));
                }
                else if (e.Button == this.ExportBtn)
                {
                    string str = "HTML Table Pages|*.html|HTML Diary Pages|*.html|JPG Images|*.jpg|GIF Images|*.gif|Bitmaps|*.bmp";
                    try
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.FileName = this.fTimeline.Name;
                        saveFileDialog.Filter = str;
                        if (saveFileDialog.ShowDialog() != DialogResult.OK)
                            return;
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1:
                                string htmlTable = this.export_to_html_table();
                                StreamWriter text1 = File.CreateText(saveFileDialog.FileName);
                                text1.WriteLine(htmlTable);
                                text1.Close();
                                break;

                            case 2:
                                string htmlDiary = this.export_to_html_diary();
                                StreamWriter text2 = File.CreateText(saveFileDialog.FileName);
                                text2.WriteLine(htmlDiary);
                                text2.Close();
                                break;

                            case 3:
                                this.TimelineGrid.CreateImage().Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                                break;

                            case 4:
                                this.TimelineGrid.CreateImage().Save(saveFileDialog.FileName, ImageFormat.Gif);
                                break;

                            case 5:
                                this.TimelineGrid.CreateImage().Save(saveFileDialog.FileName, ImageFormat.Bmp);
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
                    this.resize_grid();
                }
                else
                {
                    if (e.Button != this.ZoomOutBtn)
                        return;
                    --this.fZoom;
                    if (this.fZoom < 0)
                        this.fZoom = 0;
                    this.resize_grid();
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
            printDocument.DocumentName = LabyrinthData.Project.Name + ": " + this.fTimeline.Name;
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
            string str = LabyrinthData.Project.Name + ": " + this.fTimeline.Name;
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
            this.TimelineGrid.Render(e.Graphics, marginBounds2);
        }

        private void TimelineGrid_DoubleClick(object sender, EventArgs e)
        {
            Element selectedElement = this.TimelineGrid.SelectedElement;
            TimelinePoint selectedPoint = this.TimelineGrid.SelectedPoint;
            if (selectedElement != null && selectedPoint != null)
            {
                if (this.get_annotation(selectedElement, selectedPoint) != null)
                    this.TimelineAnnotationProperties_Click(sender, e);
                else
                    this.TimelineAddAnnotation_Click(sender, e);
            }
            else if (selectedElement != null && selectedPoint == null)
                this.TimelineOpenElement_Click(sender, e);
            else if (selectedElement == null && selectedPoint != null)
                this.TimelinePointProperties_Click(sender, e);
            else
                this.TimelineAddPoint_Click(sender, e);
        }

        private Annotation get_annotation(Element e, TimelinePoint tlp)
        {
            if (e != null && tlp != null)
            {
                foreach (TimelineItem timelineItem in tlp.Items)
                {
                    if (timelineItem.ElementID == e.ID)
                        return (Annotation)timelineItem.Annotation;
                }
            }
            return (Annotation)null;
        }

        private Element get_element(Guid id)
        {
            int index = LabyrinthData.Project.Elements.IndexOf(id);
            if (index != -1)
                return LabyrinthData.Project.Elements[index];
            return (Element)null;
        }

        private string export_to_html_table()
        {
            string str1 = "<html>" + Environment.NewLine + LabyrinthData.HTMLHeader(this.fTimeline.Name) + Environment.NewLine + "<body>" + Environment.NewLine + "<p class=header>" + this.fTimeline.Name + "</p>" + Environment.NewLine + "<table border = 1>" + Environment.NewLine + "<tr>" + Environment.NewLine + "<td></td>" + Environment.NewLine;
            foreach (TimelinePoint point in this.fTimeline.Points)
            {
                str1 = str1 + "<td>" + Environment.NewLine;
                str1 = str1 + "<p class=colhdr>" + Environment.NewLine;
                str1 = str1 + point.Name + Environment.NewLine;
                str1 = str1 + "</p>" + Environment.NewLine;
                DateTime schedule;
                switch (point.UseSchedule)
                {
                    case ScheduleType.Date:
                        string[] strArray1 = new string[5]
                        {
              str1,
              "<p class=schedule>",
              null,
              null,
              null
                        };
                        string[] strArray2 = strArray1;
                        int index1 = 2;
                        schedule = point.Schedule;
                        string shortDateString1 = schedule.ToShortDateString();
                        strArray2[index1] = shortDateString1;
                        strArray1[3] = "</p>";
                        strArray1[4] = Environment.NewLine;
                        str1 = string.Concat(strArray1);
                        break;

                    case ScheduleType.DateTime:
                        string str2 = str1;
                        string[] strArray3 = new string[7];
                        strArray3[0] = str2;
                        strArray3[1] = "<p class=schedule>";
                        string[] strArray4 = strArray3;
                        int index2 = 2;
                        schedule = point.Schedule;
                        string shortDateString2 = schedule.ToShortDateString();
                        strArray4[index2] = shortDateString2;
                        strArray3[3] = " ";
                        string[] strArray5 = strArray3;
                        int index3 = 4;
                        schedule = point.Schedule;
                        string str3 = schedule.ToString("HH:mm");
                        strArray5[index3] = str3;
                        strArray3[5] = "</p>";
                        strArray3[6] = Environment.NewLine;
                        str1 = string.Concat(strArray3);
                        break;
                }
                str1 = str1 + "</td>" + Environment.NewLine;
            }
            string str4 = str1 + "</tr>" + Environment.NewLine;
            foreach (Guid elementId in this.fTimeline.ElementIDs)
            {
                str4 = str4 + "<tr>" + Environment.NewLine;
                Element element = this.get_element(elementId);
                str4 = str4 + "<td>" + Environment.NewLine;
                str4 = str4 + "<p class=rowhdr>" + Environment.NewLine;
                str4 = str4 + element.Name + Environment.NewLine;
                str4 = str4 + "</p>" + Environment.NewLine;
                str4 = str4 + "</td>" + Environment.NewLine;
                foreach (TimelinePoint point in this.fTimeline.Points)
                {
                    str4 = str4 + "<td>" + Environment.NewLine;
                    ArrayList arrayList = new ArrayList();
                    foreach (TimelineItem timelineItem in point.Items)
                    {
                        if (timelineItem.ElementID == elementId)
                            arrayList.Add((object)timelineItem.Annotation);
                    }
                    foreach (Annotation annotation in arrayList)
                    {
                        str4 = str4 + "<p class=annotationtitle>" + Environment.NewLine;
                        str4 = str4 + annotation.Title + Environment.NewLine;
                        str4 = str4 + "</p>" + Environment.NewLine;
                        str4 = str4 + "<p class=annotationcontent>" + Environment.NewLine;
                        str4 = str4 + annotation.Content.Replace("\n", "<br>") + Environment.NewLine;
                        str4 = str4 + "</p>" + Environment.NewLine;
                    }
                    str4 = str4 + "</td>" + Environment.NewLine;
                }
                str4 = str4 + "</tr>" + Environment.NewLine;
            }
            return str4 + "</table>" + Environment.NewLine + "</body>" + Environment.NewLine + "</html>";
        }

        private string export_to_html_diary()
        {
            string str1 = "<html>" + Environment.NewLine + LabyrinthData.HTMLHeader(this.fTimeline.Name) + Environment.NewLine + "<body>" + Environment.NewLine + "<p class=header>" + this.fTimeline.Name + "</p>" + Environment.NewLine;
            foreach (TimelinePoint point in this.fTimeline.Points)
            {
                str1 = str1 + "<p class=pointheader>" + point.Name + "</p>" + Environment.NewLine;
                switch (point.UseSchedule)
                {
                    case ScheduleType.Date:
                        str1 = str1 + "<p class=schedule>" + point.Schedule.ToShortDateString() + "</p>" + Environment.NewLine;
                        break;

                    case ScheduleType.DateTime:
                        string str2 = str1;
                        string[] strArray1 = new string[7];
                        strArray1[0] = str2;
                        strArray1[1] = "<p class=schedule>";
                        string[] strArray2 = strArray1;
                        int index1 = 2;
                        DateTime schedule = point.Schedule;
                        string shortDateString = schedule.ToShortDateString();
                        strArray2[index1] = shortDateString;
                        strArray1[3] = " ";
                        string[] strArray3 = strArray1;
                        int index2 = 4;
                        schedule = point.Schedule;
                        string str3 = schedule.ToString("HH:mm");
                        strArray3[index2] = str3;
                        strArray1[5] = "</p>";
                        strArray1[6] = Environment.NewLine;
                        str1 = string.Concat(strArray1);
                        break;
                }
                foreach (TimelineItem timelineItem in point.Items)
                {
                    Element element = this.get_element(timelineItem.ElementID);
                    str1 = str1 + "<p class=annotationtitle>" + Environment.NewLine;
                    if (element != null)
                        str1 = str1 + element.Name + ": ";
                    str1 = str1 + timelineItem.Annotation.Title + Environment.NewLine;
                    str1 = str1 + "</p>" + Environment.NewLine;
                    str1 = str1 + "<p class=annotationcontent>" + Environment.NewLine;
                    str1 = str1 + timelineItem.Annotation.Content.Replace("\n", "<br>") + Environment.NewLine;
                    str1 = str1 + "</p>" + Environment.NewLine;
                }
            }
            return str1 + "</body>" + Environment.NewLine + "</html>";
        }

        private void TimelinePanel_Layout(object sender, LayoutEventArgs e)
        {
            this.resize_grid();
        }

        private void resize_grid()
        {
            this.TimelineGrid.Size = new Size((int)((double)this.TimelineGrid.Parent.Width * Math.Pow(1.1, (double)this.fZoom)), (int)((double)this.TimelineGrid.Parent.Height * Math.Pow(1.1, (double)this.fZoom)));
        }
    }
}