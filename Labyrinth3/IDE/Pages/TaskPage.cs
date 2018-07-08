// Decompiled with JetBrains decompiler
// Type: Labyrinth.Pages.TaskPage
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Collections;
using Labyrinth.Extensibility;
using Labyrinth.Forms;
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
    public class TaskPage : UserControl, ITaskPage, IPage
    {
        private ToolBar ToolBar;
        private ListView TaskList;
        private ColumnHeader TaskHdr;
        private ToolBarButton NewBtn;
        private ToolBarButton DeleteBtn;
        private ToolBarButton PropertiesBtn;
        private ContextMenu TaskMenu;
        private MenuItem TaskNew;
        private MenuItem TaskProperties;
        private MenuItem TaskDelete;
        private ColumnHeader DeadlineHdr;
        private ColumnHeader ImportanceHdr;
        private ColumnHeader CompletedHdr;
        private ImageList ToolbarImages;
        private ToolBarButton Sep1;
        private ToolBarButton ExportBtn;
        private IContainer components;

        public TaskPage()
        {
            this.InitializeComponent();
            this.TaskList.SmallImageList = LabyrinthData.ElementImages;
            this.TaskList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.update_tasks();
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
            ResourceManager resourceManager = new ResourceManager(typeof(TaskPage));
            this.ToolbarImages = new ImageList(this.components);
            this.ToolBar = new ToolBar();
            this.NewBtn = new ToolBarButton();
            this.DeleteBtn = new ToolBarButton();
            this.PropertiesBtn = new ToolBarButton();
            this.TaskList = new ListView();
            this.TaskHdr = new ColumnHeader();
            this.DeadlineHdr = new ColumnHeader();
            this.ImportanceHdr = new ColumnHeader();
            this.CompletedHdr = new ColumnHeader();
            this.TaskMenu = new ContextMenu();
            this.TaskNew = new MenuItem();
            this.TaskDelete = new MenuItem();
            this.TaskProperties = new MenuItem();
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
        this.NewBtn,
        this.DeleteBtn,
        this.PropertiesBtn,
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
            this.NewBtn.ImageIndex = 0;
            this.NewBtn.ToolTipText = "New Task";
            this.DeleteBtn.ImageIndex = 1;
            this.DeleteBtn.ToolTipText = "Delete Task";
            this.PropertiesBtn.ImageIndex = 2;
            this.PropertiesBtn.ToolTipText = "Task Properties";
            this.TaskList.Columns.AddRange(new ColumnHeader[4]
            {
        this.TaskHdr,
        this.DeadlineHdr,
        this.ImportanceHdr,
        this.CompletedHdr
            });
            this.TaskList.ContextMenu = this.TaskMenu;
            this.TaskList.Dock = DockStyle.Fill;
            this.TaskList.FullRowSelect = true;
            this.TaskList.Location = new Point(0, 25);
            this.TaskList.Name = "TaskList";
            this.TaskList.Size = new Size(552, 231);
            this.TaskList.Sorting = SortOrder.Ascending;
            this.TaskList.TabIndex = 1;
            this.TaskList.View = View.Details;
            this.TaskList.MouseDown += new MouseEventHandler(this.TaskList_MouseDown);
            this.TaskList.DoubleClick += new EventHandler(this.TaskList_DoubleClick);
            this.TaskList.ColumnClick += new ColumnClickEventHandler(this.TaskList_ColumnClick);
            this.TaskHdr.Text = "Task";
            this.TaskHdr.Width = 200;
            this.DeadlineHdr.Text = "Deadline";
            this.DeadlineHdr.Width = 90;
            this.ImportanceHdr.Text = "Importance";
            this.ImportanceHdr.Width = 90;
            this.CompletedHdr.Text = "Completed";
            this.CompletedHdr.Width = 90;
            this.TaskMenu.MenuItems.AddRange(new MenuItem[3]
            {
        this.TaskNew,
        this.TaskDelete,
        this.TaskProperties
            });
            this.TaskNew.Index = 0;
            this.TaskNew.Text = "New Task";
            this.TaskNew.Click += new EventHandler(this.TaskNew_Click);
            this.TaskDelete.Index = 1;
            this.TaskDelete.Text = "Delete Task";
            this.TaskDelete.Click += new EventHandler(this.TaskDelete_Click);
            this.TaskProperties.Index = 2;
            this.TaskProperties.Text = "Task Properties";
            this.TaskProperties.Click += new EventHandler(this.TaskProperties_Click);
            this.Sep1.Style = ToolBarButtonStyle.Separator;
            this.ExportBtn.ImageIndex = 3;
            this.ExportBtn.ToolTipText = "Export Tasks";
            this.Controls.AddRange(new Control[2]
            {
        (Control) this.TaskList,
        (Control) this.ToolBar
            });
            this.Name = nameof(TaskPage);
            this.Size = new Size(552, 256);
            this.ResumeLayout(false);
        }

        public string Title
        {
            get
            {
                return "Task List";
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
            this.TaskNew.Enabled = true;
            this.TaskDelete.Enabled = this.SelectedTask != null;
            this.TaskProperties.Enabled = this.SelectedTask != null;
            this.NewBtn.Enabled = this.TaskNew.Enabled;
            this.DeleteBtn.Enabled = this.TaskDelete.Enabled;
            this.PropertiesBtn.Enabled = this.TaskProperties.Enabled;
        }

        public void UpdateData()
        {
            this.update_tasks();
        }

        public Task SelectedTask
        {
            get
            {
                if (this.TaskList.SelectedItems.Count != 0)
                    return this.TaskList.SelectedItems[0].Tag as Task;
                return (Task)null;
            }
        }

        private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.NewBtn)
                    this.TaskNew_Click(sender, (EventArgs)e);
                else if (e.Button == this.DeleteBtn)
                    this.TaskDelete_Click(sender, (EventArgs)e);
                else if (e.Button == this.PropertiesBtn)
                {
                    this.TaskProperties_Click(sender, (EventArgs)e);
                }
                else
                {
                    if (e.Button != this.ExportBtn)
                        return;
                    string str1 = "HTML Files|*.html|Text Files|*.txt";
                    try
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.FileName = LabyrinthData.Project.Name + " Tasks";
                        saveFileDialog.Filter = str1;
                        if (saveFileDialog.ShowDialog() != DialogResult.OK)
                            return;
                        string str2 = this.export_tasks(saveFileDialog.FilterIndex == 1);
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

        private void TaskNew_Click(object sender, EventArgs e)
        {
            string str = "New Task";
            string title = str;
            int num = 1;
            for (; LabyrinthData.Project.Tasks.IndexOf(title) != -1; title = str + " " + (object)num)
                ++num;
            Task t = new Task();
            t.Title = title;
            if (new TaskDlg(t).ShowDialog() != DialogResult.OK)
                return;
            LabyrinthData.Project.Tasks.Add(t);
            this.update_tasks();
        }

        private void TaskDelete_Click(object sender, EventArgs e)
        {
            if (this.SelectedTask == null || MessageBox.Show("Delete task '" + this.SelectedTask.Title + "': Are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            LabyrinthData.Project.Tasks.Remove(this.SelectedTask);
            this.update_tasks();
        }

        private void TaskProperties_Click(object sender, EventArgs e)
        {
            if (this.SelectedTask == null || new TaskDlg(this.SelectedTask).ShowDialog() != DialogResult.OK)
                return;
            this.update_tasks();
        }

        private void TaskList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
                this.TaskProperties_Click(sender, e);
            else
                this.TaskNew_Click(sender, e);
        }

        private void TaskList_MouseDown(object sender, MouseEventArgs e)
        {
            this.TaskList.SelectedItems.Clear();
            ListViewItem itemAt = this.TaskList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.UpdateUI();
        }

        private void TaskList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.TaskList, e.Column);
        }

        public void update_tasks()
        {
            this.TaskList.BeginUpdate();
            this.TaskList.Items.Clear();
            Font font = new Font(this.Font, FontStyle.Bold);
            if (LabyrinthData.Project.Tasks.Count != 0)
            {
                ArrayList arrayList = new ArrayList();
                foreach (Task task in LabyrinthData.Project.Tasks)
                {
                    Font prototype = this.Font;
                    Color color1 = SystemColors.WindowText;
                    Color color2 = SystemColors.WindowText;
                    Color window = SystemColors.Window;
                    switch (task.Importance)
                    {
                        case Importance.Low:
                            color1 = SystemColors.GrayText;
                            break;

                        case Importance.High:
                            prototype = new Font(prototype, prototype.Style | FontStyle.Bold);
                            break;
                    }
                    if (task.HasDeadline)
                    {
                        TimeSpan timeSpan = task.Deadline - DateTime.Now;
                        if (!(timeSpan > new TimeSpan(1, 0, 0, 0)))
                        {
                            if (timeSpan > TimeSpan.Zero)
                            {
                                color2 = Color.Red;
                            }
                            else
                            {
                                color1 = Color.Red;
                                color2 = Color.Red;
                            }
                        }
                    }
                    if (task.Completed)
                    {
                        prototype = new Font(prototype, prototype.Style | FontStyle.Strikeout);
                        color1 = SystemColors.GrayText;
                    }
                    arrayList.Add((object)new ListViewItem(task.Title)
                    {
                        UseItemStyleForSubItems = false,
                        Font = prototype,
                        ForeColor = color1,
                        ImageIndex = LabyrinthData.GetImageIndex(task),
                        Tag = (object)task,
                        SubItems = {
              {
                task.HasDeadline ? task.Deadline.ToShortDateString() : "",
                color2,
                window,
                prototype
              },
              {
                task.Importance.ToString(),
                color1,
                window,
                prototype
              },
              {
                task.Completed.ToString(),
                color1,
                window,
                prototype
              }
            }
                    });
                }
                this.TaskList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            }
            else
            {
                ListViewItem listViewItem = this.TaskList.Items.Add("No tasks");
                listViewItem.ForeColor = SystemColors.GrayText;
                listViewItem.ImageIndex = -1;
            }
            this.TaskList.EndUpdate();
        }

        private string export_tasks(bool markup)
        {
            string str1 = "";
            string title = LabyrinthData.Project.Name + " Tasks";
            if (markup)
                str1 = str1 + "<html>" + Environment.NewLine + LabyrinthData.HTMLHeader(title) + Environment.NewLine + "<body>" + Environment.NewLine;
            if (markup)
                str1 += "<p class=header>";
            string str2 = str1 + title;
            if (markup)
                str2 += "</p>";
            string str3 = str2 + Environment.NewLine;
            foreach (Task task in LabyrinthData.Project.Tasks)
            {
                string str4 = "";
                if (task.Completed)
                {
                    if (str4 != "")
                        str4 += "; ";
                    str4 += "Completed";
                }
                if (task.Importance != Importance.Normal)
                {
                    if (str4 != "")
                        str4 += "; ";
                    str4 += "Importance: ";
                    if (task.Importance == Importance.High)
                        str4 += "high";
                    if (task.Importance == Importance.Low)
                        str4 += "low";
                }
                if (task.HasDeadline)
                {
                    if (str4 != "")
                        str4 += "; ";
                    str4 = str4 + "Deadline: " + task.Deadline.ToShortDateString();
                }
                str3 += Environment.NewLine;
                if (markup)
                    str3 = str3 + "<p class=tasktitle>" + Environment.NewLine;
                str3 = str3 + task.Title + Environment.NewLine;
                if (markup)
                    str3 = str3 + "</p>" + Environment.NewLine;
                if (str4 != "")
                {
                    if (markup)
                        str3 = str3 + "<p class=taskflags>" + Environment.NewLine;
                    str3 = str3 + str4 + Environment.NewLine;
                    if (markup)
                        str3 = str3 + "</p>" + Environment.NewLine;
                }
                if (markup)
                    str3 = str3 + "<p class=taskdetails>" + Environment.NewLine;
                str3 = str3 + (markup ? task.Details.Replace("\n", "<br>") : task.Details) + Environment.NewLine;
                if (markup)
                    str3 = str3 + "</p>" + Environment.NewLine;
            }
            if (markup)
                str3 = str3 + "</body>" + Environment.NewLine + "</html>" + Environment.NewLine;
            return str3;
        }
    }
}