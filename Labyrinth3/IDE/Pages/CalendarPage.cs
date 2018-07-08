// Decompiled with JetBrains decompiler
// Type: Labyrinth.Pages.CalendarPage
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Collections;
using Labyrinth.Events;
using Labyrinth.Extensibility;
using Labyrinth.Forms;
using Labyrinth.Plot;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Pages
{
    public class CalendarPage : UserControl, ICalendarPage, IPage
    {
        private Container components = (Container)null;
        private ContextMenu ItemContext;
        private MenuItem ItemOpenAnnotation;
        private MenuItem ItemPointProperties;
        private MenuItem ItemTimelineProperties;
        private MenuItem ItemOpenElement;
        private MenuItem ItemElementProperties;
        private MenuItem ItemOpenTimeline;
        private ListView PointList;
        private Splitter PointSplitter;
        private Panel CalendarPanel;
        private MonthCalendar Calendar;
        private ListView ItemList;
        private ColumnHeader NameHdr;
        private ColumnHeader ElementHdr;
        private ColumnHeader PointHdr;
        private ColumnHeader TimelineHdr;
        private ColumnHeader DateHdr;

        public CalendarPage()
        {
            this.InitializeComponent();
            this.PointList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.ItemList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.ItemList.SmallImageList = LabyrinthData.ElementImages;
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
            this.ItemContext = new ContextMenu();
            this.ItemOpenAnnotation = new MenuItem();
            this.ItemOpenElement = new MenuItem();
            this.ItemOpenTimeline = new MenuItem();
            this.ItemElementProperties = new MenuItem();
            this.ItemPointProperties = new MenuItem();
            this.ItemTimelineProperties = new MenuItem();
            this.PointList = new ListView();
            this.PointSplitter = new Splitter();
            this.CalendarPanel = new Panel();
            this.Calendar = new MonthCalendar();
            this.ItemList = new ListView();
            this.NameHdr = new ColumnHeader();
            this.ElementHdr = new ColumnHeader();
            this.PointHdr = new ColumnHeader();
            this.TimelineHdr = new ColumnHeader();
            this.DateHdr = new ColumnHeader();
            this.CalendarPanel.SuspendLayout();
            this.SuspendLayout();
            this.ItemContext.MenuItems.AddRange(new MenuItem[6]
            {
        this.ItemOpenAnnotation,
        this.ItemOpenElement,
        this.ItemOpenTimeline,
        this.ItemElementProperties,
        this.ItemPointProperties,
        this.ItemTimelineProperties
            });
            this.ItemOpenAnnotation.Index = 0;
            this.ItemOpenAnnotation.Text = "Open Annotation";
            this.ItemOpenAnnotation.Click += new EventHandler(this.ItemOpenAnnotation_Click);
            this.ItemOpenElement.Index = 1;
            this.ItemOpenElement.Text = "Open Element";
            this.ItemOpenElement.Click += new EventHandler(this.ItemOpenElement_Click);
            this.ItemOpenTimeline.Index = 2;
            this.ItemOpenTimeline.Text = "Open Timeline";
            this.ItemOpenTimeline.Click += new EventHandler(this.ItemOpenTimeline_Click);
            this.ItemElementProperties.Index = 3;
            this.ItemElementProperties.Text = "Element Properties";
            this.ItemElementProperties.Click += new EventHandler(this.ItemElementProperties_Click);
            this.ItemPointProperties.Index = 4;
            this.ItemPointProperties.Text = "Timeline Point Properties";
            this.ItemPointProperties.Click += new EventHandler(this.ItemPointProperties_Click);
            this.ItemTimelineProperties.Index = 5;
            this.ItemTimelineProperties.Text = "Timeline Properties";
            this.ItemTimelineProperties.Click += new EventHandler(this.ItemTimelineProperties_Click);
            this.PointList.Activation = ItemActivation.OneClick;
            this.PointList.Columns.AddRange(new ColumnHeader[1]
            {
        this.DateHdr
            });
            this.PointList.Dock = DockStyle.Left;
            this.PointList.FullRowSelect = true;
            this.PointList.Name = "PointList";
            this.PointList.Size = new Size(160, 352);
            this.PointList.TabIndex = 6;
            this.PointList.View = View.Details;
            this.PointList.MouseDown += new MouseEventHandler(this.PointList_MouseDown);
            this.PointList.ItemActivate += new EventHandler(this.PointList_ItemActivate);
            this.PointList.ColumnClick += new ColumnClickEventHandler(this.PointList_ColumnClick);
            this.PointSplitter.Location = new Point(160, 0);
            this.PointSplitter.Name = "PointSplitter";
            this.PointSplitter.Size = new Size(3, 352);
            this.PointSplitter.TabIndex = 7;
            this.PointSplitter.TabStop = false;
            this.CalendarPanel.AutoScroll = true;
            this.CalendarPanel.BackColor = SystemColors.ControlDark;
            this.CalendarPanel.Controls.AddRange(new Control[1]
            {
        (Control) this.Calendar
            });
            this.CalendarPanel.Dock = DockStyle.Top;
            this.CalendarPanel.Location = new Point(163, 0);
            this.CalendarPanel.Name = "CalendarPanel";
            this.CalendarPanel.Size = new Size(453, 168);
            this.CalendarPanel.TabIndex = 8;
            this.CalendarPanel.Resize += new EventHandler(this.CalendarPanel_Resize);
            this.CalendarPanel.Layout += new LayoutEventHandler(this.CalendarPanel_Layout);
            this.Calendar.Location = new Point(8, 8);
            this.Calendar.MaxSelectionCount = 1;
            this.Calendar.Name = "Calendar";
            this.Calendar.ScrollChange = 1;
            this.Calendar.ShowTodayCircle = false;
            this.Calendar.TabIndex = 4;
            this.Calendar.DateSelected += new DateRangeEventHandler(this.Calendar_DateSelected);
            this.Calendar.DateChanged += new DateRangeEventHandler(this.Calendar_DateSelected);
            this.ItemList.Columns.AddRange(new ColumnHeader[4]
            {
        this.NameHdr,
        this.ElementHdr,
        this.PointHdr,
        this.TimelineHdr
            });
            this.ItemList.ContextMenu = this.ItemContext;
            this.ItemList.Dock = DockStyle.Fill;
            this.ItemList.FullRowSelect = true;
            this.ItemList.Location = new Point(163, 168);
            this.ItemList.Name = "ItemList";
            this.ItemList.Size = new Size(453, 184);
            this.ItemList.TabIndex = 9;
            this.ItemList.View = View.Details;
            this.ItemList.MouseDown += new MouseEventHandler(this.ItemList_MouseDown);
            this.ItemList.DoubleClick += new EventHandler(this.ItemList_DoubleClick);
            this.ItemList.ColumnClick += new ColumnClickEventHandler(this.ItemList_ColumnClick);
            this.NameHdr.Text = "Name";
            this.NameHdr.Width = 90;
            this.ElementHdr.Text = "Element";
            this.ElementHdr.Width = 90;
            this.PointHdr.Text = "Point";
            this.PointHdr.Width = 90;
            this.TimelineHdr.Text = "Timeline";
            this.TimelineHdr.Width = 90;
            this.DateHdr.Text = "Date";
            this.DateHdr.Width = 150;
            this.Controls.AddRange(new Control[4]
            {
        (Control) this.ItemList,
        (Control) this.CalendarPanel,
        (Control) this.PointSplitter,
        (Control) this.PointList
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.Name = "ChronologyPage";
            this.Size = new Size(616, 352);
            this.CalendarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public string Title
        {
            get
            {
                return "Calendar";
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
            bool flag = this.SelectedItem != null;
            this.ItemOpenAnnotation.Enabled = flag;
            this.ItemOpenElement.Enabled = flag;
            this.ItemOpenTimeline.Enabled = flag;
            this.ItemElementProperties.Enabled = flag;
            this.ItemPointProperties.Enabled = flag;
            this.ItemTimelineProperties.Enabled = flag;
        }

        public void UpdateData()
        {
            this.update_calendar();
            this.update_items();
        }

        public DateTime SelectedDate
        {
            get
            {
                if (this.PointList.SelectedItems.Count == 0)
                    return DateTime.MinValue;
                try
                {
                    return (DateTime)this.PointList.SelectedItems[0].Tag;
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        public TimelineItem SelectedItem
        {
            get
            {
                if (this.ItemList.SelectedItems.Count != 0)
                    return this.ItemList.SelectedItems[0].Tag as TimelineItem;
                return (TimelineItem)null;
            }
        }

        public event ElementEventHandler ElementActivated;

        public event ElementEventHandler ElementModified;

        public event TimelineEventHandler TimelineActivated;

        public event TimelineEventHandler TimelineModified;

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

        private void ItemOpenAnnotation_Click(object sender, EventArgs e)
        {
            TimelineItem selectedItem = this.SelectedItem;
            if (selectedItem == null || !Annotations.Open((Annotation)selectedItem.Annotation))
                return;
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.get_parent(selectedItem)));
        }

        private void ItemOpenElement_Click(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
                return;
            int index = LabyrinthData.Project.Elements.IndexOf(this.SelectedItem.ElementID);
            if (index == -1)
                return;
            this.OnElementActivated(new ElementEventArgs(LabyrinthData.Project.Elements[index]));
        }

        private void ItemOpenTimeline_Click(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
                return;
            Timeline parent = this.get_parent(this.SelectedItem);
            if (parent == null)
                return;
            this.OnTimelineActivated(new TimelineEventArgs(parent));
        }

        private void ItemElementProperties_Click(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
                return;
            int index = LabyrinthData.Project.Elements.IndexOf(this.SelectedItem.ElementID);
            if (index == -1)
                return;
            Element element = LabyrinthData.Project.Elements[index];
            if (new ElementDlg(element).ShowDialog() != DialogResult.OK)
                return;
            this.UpdateData();
            this.OnElementModified(new ElementEventArgs(element));
        }

        private void ItemPointProperties_Click(object sender, EventArgs e)
        {
            TimelineItem selectedItem = this.SelectedItem;
            if (selectedItem == null)
                return;
            TimelinePoint parentPoint = this.get_parent_point(selectedItem);
            if (parentPoint == null || new TimelinePointDlg(parentPoint).ShowDialog() != DialogResult.OK)
                return;
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(this.get_parent(selectedItem)));
        }

        private void ItemTimelineProperties_Click(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
                return;
            Timeline parent = this.get_parent(this.SelectedItem);
            if (parent == null || new TimelineDlg(parent).ShowDialog() != DialogResult.OK)
                return;
            this.UpdateData();
            this.OnTimelineModified(new TimelineEventArgs(parent));
        }

        private void ItemList_MouseDown(object sender, MouseEventArgs e)
        {
            this.ItemList.SelectedItems.Clear();
            ListViewItem itemAt = this.ItemList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.UpdateUI();
        }

        private void PointList_MouseDown(object sender, MouseEventArgs e)
        {
            this.PointList.SelectedItems.Clear();
            ListViewItem itemAt = this.PointList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.UpdateUI();
        }

        private void CalendarPanel_Resize(object sender, EventArgs e)
        {
            this.position_calendar();
        }

        private void CalendarPanel_Layout(object sender, LayoutEventArgs e)
        {
            this.position_calendar();
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.update_items();
        }

        private void ItemList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.ItemList, e.Column);
        }

        private void ItemList_DoubleClick(object sender, EventArgs e)
        {
            this.ItemOpenAnnotation_Click(sender, e);
        }

        private void PointList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.PointList, e.Column);
        }

        private void PointList_ItemActivate(object sender, EventArgs e)
        {
            if (!(this.SelectedDate != DateTime.MinValue))
                return;
            this.Calendar.SelectionStart = this.SelectedDate;
        }

        private void update_calendar()
        {
            DateTime dateTime1 = DateTime.MaxValue;
            DateTime dateTime2 = DateTime.MinValue;
            ArrayList arrayList1 = new ArrayList();
            foreach (Timeline timeline in LabyrinthData.Project.Timelines)
            {
                foreach (TimelinePoint point in timeline.Points)
                {
                    if (point.UseSchedule != ScheduleType.None)
                    {
                        if (point.Schedule < dateTime1)
                            dateTime1 = point.Schedule;
                        if (point.Schedule > dateTime2)
                            dateTime2 = point.Schedule;
                        arrayList1.Add((object)point.Schedule);
                    }
                }
            }
            this.Calendar.BoldedDates = (DateTime[])arrayList1.ToArray(typeof(DateTime));
            this.Calendar.UpdateBoldedDates();
            this.PointList.BeginUpdate();
            this.PointList.Items.Clear();
            if (this.Calendar.BoldedDates.Length != 0)
            {
                ArrayList arrayList2 = new ArrayList();
                foreach (DateTime boldedDate in this.Calendar.BoldedDates)
                    arrayList2.Add((object)new ListViewItem(boldedDate.ToLongDateString())
                    {
                        ImageIndex = -1,
                        Tag = (object)boldedDate
                    });
                this.PointList.Items.AddRange((ListViewItem[])arrayList2.ToArray(typeof(ListViewItem)));
            }
            else
            {
                ListViewItem listViewItem = this.PointList.Items.Add("No scheduled points");
                listViewItem.ForeColor = SystemColors.GrayText;
                listViewItem.ImageIndex = -1;
            }
            this.PointList.EndUpdate();
            if (dateTime1 == DateTime.MaxValue)
            {
                this.Calendar.SelectionStart = DateTime.Today;
                this.Calendar.CalendarDimensions = new Size(1, 1);
            }
            else
            {
                this.Calendar.SelectionStart = dateTime1;
                int num = dateTime2.Month - dateTime1.Month + 1 + (dateTime2.Year - dateTime1.Year) * 12;
                this.Calendar.SetCalendarDimensions(num > 0 ? num : 1, 1);
            }
            this.position_calendar();
        }

        private void update_items()
        {
            SelectionRange selectionRange = this.Calendar.SelectionRange;
            this.ItemList.BeginUpdate();
            this.ItemList.Items.Clear();
            ArrayList arrayList = new ArrayList();
            foreach (Timeline timeline in LabyrinthData.Project.Timelines)
            {
                foreach (TimelinePoint point in timeline.Points)
                {
                    if (point.UseSchedule != ScheduleType.None && point.Schedule >= selectionRange.Start && point.Schedule <= selectionRange.End)
                    {
                        foreach (TimelineItem timelineItem in point.Items)
                        {
                            Element element = (Element)null;
                            int index = LabyrinthData.Project.Elements.IndexOf(timelineItem.ElementID);
                            if (index != -1)
                                element = LabyrinthData.Project.Elements[index];
                            arrayList.Add((object)new ListViewItem(timelineItem.Annotation.Title)
                            {
                                SubItems = {
                  element != null ? element.Name : "",
                  point.Name,
                  timeline.Name
                },
                                ImageIndex = LabyrinthData.GetImageIndex((Annotation)timelineItem.Annotation),
                                Tag = (object)timelineItem
                            });
                        }
                    }
                }
            }
            this.ItemList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            if (this.ItemList.Items.Count == 0)
            {
                ListViewItem listViewItem = this.ItemList.Items.Add("No timeline items");
                listViewItem.ForeColor = SystemColors.GrayText;
                listViewItem.ImageIndex = -1;
            }
            this.ItemList.EndUpdate();
        }

        private void position_calendar()
        {
            if (this.CalendarPanel.Width >= this.Calendar.Width)
                this.Calendar.Left = (this.CalendarPanel.Width - this.Calendar.Width) / 2;
            else
                this.Calendar.Left = 0;
            this.Calendar.Top = 0;
            this.CalendarPanel.Height = this.Calendar.Height + (this.CalendarPanel.Height - this.CalendarPanel.ClientRectangle.Height);
            this.CalendarPanel.Invalidate();
        }

        private Timeline get_parent(TimelineItem tli)
        {
            foreach (Timeline timeline in LabyrinthData.Project.Timelines)
            {
                foreach (TimelinePoint point in timeline.Points)
                {
                    if (point.Items.Contains(tli))
                        return timeline;
                }
            }
            return (Timeline)null;
        }

        private TimelinePoint get_parent_point(TimelineItem tli)
        {
            foreach (Timeline timeline in LabyrinthData.Project.Timelines)
            {
                foreach (TimelinePoint point in timeline.Points)
                {
                    if (point.Items.Contains(tli))
                        return point;
                }
            }
            return null;
        }
    }
}