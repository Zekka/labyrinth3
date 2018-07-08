// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.TaskDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class TaskDlg : Form
    {
        private Task fTask = (Task)null;
        private ImageList ToolbarImages;
        private Label TitleLbl;
        private TextBox TitleBox;
        private Button OKBtn;
        private Button CancelBtn;
        private RichTextBox DetailsBox;
        private CheckBox DueByBox;
        private DateTimePicker DueDateBox;
        private CheckBox CompletedBox;
        private Label ImportanceLbl;
        private ComboBox ImportanceBox;
        private IContainer components;

        public TaskDlg(Task t)
        {
            this.InitializeComponent();
            this.fTask = t;
            foreach (Importance importance in Enum.GetValues(typeof(Importance)))
                this.ImportanceBox.Items.Add((object)importance);
            this.TitleBox.Text = this.fTask.Title;
            this.DetailsBox.Text = this.fTask.Details;
            this.ImportanceBox.SelectedItem = (object)this.fTask.Importance;
            this.DueByBox.Checked = this.fTask.HasDeadline;
            if (this.fTask.HasDeadline)
                this.DueDateBox.Value = this.fTask.Deadline;
            this.CompletedBox.Checked = this.fTask.Completed;
            this.DueByBox_CheckedChanged((object)null, (EventArgs)null);
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
            ResourceManager resourceManager = new ResourceManager(typeof(TaskDlg));
            this.ToolbarImages = new ImageList(this.components);
            this.OKBtn = new Button();
            this.CancelBtn = new Button();
            this.TitleLbl = new Label();
            this.TitleBox = new TextBox();
            this.DetailsBox = new RichTextBox();
            this.DueByBox = new CheckBox();
            this.DueDateBox = new DateTimePicker();
            this.CompletedBox = new CheckBox();
            this.ImportanceLbl = new Label();
            this.ImportanceBox = new ComboBox();
            this.SuspendLayout();
            this.ToolbarImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ToolbarImages.ImageSize = new Size(16, 16);
            this.ToolbarImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ToolbarImages.ImageStream");
            this.ToolbarImages.TransparentColor = Color.Magenta;
            this.OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBtn.DialogResult = DialogResult.OK;
            this.OKBtn.Location = new Point(152, 326);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new Size(72, 23);
            this.OKBtn.TabIndex = 8;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(232, 326);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new Size(72, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.TitleLbl.Location = new Point(16, 16);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new Size(48, 23);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Title:";
            this.TitleLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.TitleBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.TitleBox.Location = new Point(72, 16);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new Size(232, 21);
            this.TitleBox.TabIndex = 1;
            this.TitleBox.Text = "";
            this.DetailsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.DetailsBox.Location = new Point(16, 56);
            this.DetailsBox.Name = "DetailsBox";
            this.DetailsBox.Size = new Size(288, 166);
            this.DetailsBox.TabIndex = 2;
            this.DetailsBox.Text = "";
            this.DetailsBox.LinkClicked += new LinkClickedEventHandler(this.DetailsBox_LinkClicked);
            this.DueByBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.DueByBox.Location = new Point(16, 270);
            this.DueByBox.Name = "DueByBox";
            this.DueByBox.Size = new Size(80, 24);
            this.DueByBox.TabIndex = 5;
            this.DueByBox.Text = "Due by:";
            this.DueByBox.CheckedChanged += new EventHandler(this.DueByBox_CheckedChanged);
            this.DueDateBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.DueDateBox.Location = new Point(104, 270);
            this.DueDateBox.Name = "DueDateBox";
            this.DueDateBox.TabIndex = 6;
            this.CompletedBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.CompletedBox.Location = new Point(16, 294);
            this.CompletedBox.Name = "CompletedBox";
            this.CompletedBox.Size = new Size(80, 24);
            this.CompletedBox.TabIndex = 7;
            this.CompletedBox.Text = "Completed";
            this.ImportanceLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.ImportanceLbl.Location = new Point(16, 238);
            this.ImportanceLbl.Name = "ImportanceLbl";
            this.ImportanceLbl.Size = new Size(80, 23);
            this.ImportanceLbl.TabIndex = 3;
            this.ImportanceLbl.Text = "Importance:";
            this.ImportanceLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.ImportanceBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.ImportanceBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ImportanceBox.Location = new Point(104, 238);
            this.ImportanceBox.Name = "ImportanceBox";
            this.ImportanceBox.Size = new Size(200, 21);
            this.ImportanceBox.TabIndex = 4;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(320, 364);
            this.Controls.AddRange(new Control[10]
            {
        (Control) this.ImportanceBox,
        (Control) this.ImportanceLbl,
        (Control) this.CompletedBox,
        (Control) this.DueDateBox,
        (Control) this.DueByBox,
        (Control) this.TitleBox,
        (Control) this.TitleLbl,
        (Control) this.CancelBtn,
        (Control) this.OKBtn,
        (Control) this.DetailsBox
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.Icon = (Icon)resourceManager.GetObject("$this.Icon");
            this.MinimizeBox = false;
            this.Name = nameof(TaskDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Task Properties";
            this.ResumeLayout(false);
        }

        private void DetailsBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.fTask.Title = this.TitleBox.Text;
            this.fTask.Details = this.DetailsBox.Text;
            this.fTask.Completed = this.CompletedBox.Checked;
            this.fTask.Importance = (Importance)this.ImportanceBox.SelectedItem;
            this.fTask.HasDeadline = this.DueByBox.Checked;
            if (this.fTask.HasDeadline)
                this.fTask.Deadline = this.DueDateBox.Value;
            this.fTask.Details = this.fTask.Details.Replace("\n", Environment.NewLine);
        }

        private void DueByBox_CheckedChanged(object sender, EventArgs e)
        {
            this.DueDateBox.Enabled = this.DueByBox.Checked;
        }
    }
}