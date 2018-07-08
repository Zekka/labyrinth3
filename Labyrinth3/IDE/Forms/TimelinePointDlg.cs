// Decompiled with JetBrains decompiler
// Type: Labyrinth.Forms.TimelinePointDlg
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Forms
{
    public class TimelinePointDlg : Form
    {
        private Container components = (Container)null;
        private TimelinePoint fTimelinePoint = (TimelinePoint)null;
        private Label NameLbl;
        private TextBox NameBox;
        private Button OKBtn;
        private Button CancelBtn;
        private Label DateLbl;
        private DateTimePicker DateBox;
        private DateTimePicker TimeBox;
        private Label TimeLbl;
        private Label ScheduleLbl;
        private ComboBox ScheduleBox;

        public TimelinePointDlg(TimelinePoint tlp)
        {
            this.InitializeComponent();
            this.fTimelinePoint = tlp;
            foreach (ScheduleType scheduleType in Enum.GetValues(typeof(ScheduleType)))
                this.ScheduleBox.Items.Add((object)scheduleType);
            this.NameBox.Text = this.fTimelinePoint.Name;
            this.ScheduleBox.SelectedItem = (object)this.fTimelinePoint.UseSchedule;
            if (this.fTimelinePoint.UseSchedule != ScheduleType.None)
                this.DateBox.Value = this.fTimelinePoint.Schedule;
            if (this.fTimelinePoint.UseSchedule == ScheduleType.DateTime)
                this.TimeBox.Value = this.fTimelinePoint.Schedule;
            this.ScheduleBox_SelectedIndexChanged((object)null, (EventArgs)null);
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
            this.NameBox = new TextBox();
            this.OKBtn = new Button();
            this.CancelBtn = new Button();
            this.DateLbl = new Label();
            this.DateBox = new DateTimePicker();
            this.TimeBox = new DateTimePicker();
            this.TimeLbl = new Label();
            this.ScheduleLbl = new Label();
            this.ScheduleBox = new ComboBox();
            this.SuspendLayout();
            this.NameLbl.Location = new Point(16, 24);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new Size(48, 23);
            this.NameLbl.TabIndex = 0;
            this.NameLbl.Text = "Name:";
            this.NameLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.NameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.NameBox.Location = new Point(80, 24);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new Size(200, 21);
            this.NameBox.TabIndex = 1;
            this.NameBox.Text = "";
            this.OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.OKBtn.DialogResult = DialogResult.OK;
            this.OKBtn.Location = new Point(128, 178);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new Size(72, 23);
            this.OKBtn.TabIndex = 8;
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new EventHandler(this.OKBtn_Click);
            this.CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.CancelBtn.DialogResult = DialogResult.Cancel;
            this.CancelBtn.Location = new Point(208, 178);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new Size(72, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.DateLbl.Location = new Point(16, 104);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new Size(48, 23);
            this.DateLbl.TabIndex = 4;
            this.DateLbl.Text = "Date:";
            this.DateLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.DateBox.Format = DateTimePickerFormat.Short;
            this.DateBox.Location = new Point(80, 104);
            this.DateBox.Name = "DateBox";
            this.DateBox.TabIndex = 5;
            this.TimeBox.CustomFormat = "HH:mm";
            this.TimeBox.Format = DateTimePickerFormat.Custom;
            this.TimeBox.Location = new Point(80, 136);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.ShowUpDown = true;
            this.TimeBox.TabIndex = 7;
            this.TimeLbl.Location = new Point(16, 136);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new Size(48, 23);
            this.TimeLbl.TabIndex = 6;
            this.TimeLbl.Text = "Time:";
            this.TimeLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.ScheduleLbl.Location = new Point(16, 72);
            this.ScheduleLbl.Name = "ScheduleLbl";
            this.ScheduleLbl.Size = new Size(56, 23);
            this.ScheduleLbl.TabIndex = 2;
            this.ScheduleLbl.Text = "Schedule:";
            this.ScheduleLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.ScheduleBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ScheduleBox.Location = new Point(80, 72);
            this.ScheduleBox.Name = "ScheduleBox";
            this.ScheduleBox.Size = new Size(200, 21);
            this.ScheduleBox.TabIndex = 3;
            this.ScheduleBox.SelectedIndexChanged += new EventHandler(this.ScheduleBox_SelectedIndexChanged);
            this.AcceptButton = (IButtonControl)this.OKBtn;
            this.AutoScaleBaseSize = new Size(5, 14);
            this.CancelButton = (IButtonControl)this.CancelBtn;
            this.ClientSize = new Size(292, 216);
            this.ControlBox = false;
            this.Controls.AddRange(new Control[10]
            {
        (Control) this.ScheduleBox,
        (Control) this.ScheduleLbl,
        (Control) this.TimeLbl,
        (Control) this.TimeBox,
        (Control) this.DateBox,
        (Control) this.DateLbl,
        (Control) this.CancelBtn,
        (Control) this.OKBtn,
        (Control) this.NameBox,
        (Control) this.NameLbl
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(TimelinePointDlg);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Timeline Point Properties";
            this.ResumeLayout(false);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.fTimelinePoint.Name = this.NameBox.Text;
            this.fTimelinePoint.UseSchedule = (ScheduleType)this.ScheduleBox.SelectedItem;
            DateTime dateTime;
            if (this.fTimelinePoint.UseSchedule == ScheduleType.Date)
            {
                int year = this.DateBox.Value.Year;
                int month = this.DateBox.Value.Month;
                dateTime = this.DateBox.Value;
                int day = dateTime.Day;
                this.fTimelinePoint.Schedule = new DateTime(year, month, day, 0, 0, 0);
            }
            if (this.fTimelinePoint.UseSchedule != ScheduleType.DateTime)
                return;
            dateTime = this.DateBox.Value;
            int year1 = dateTime.Year;
            dateTime = this.DateBox.Value;
            int month1 = dateTime.Month;
            dateTime = this.DateBox.Value;
            int day1 = dateTime.Day;
            dateTime = this.TimeBox.Value;
            int hour = dateTime.Hour;
            dateTime = this.TimeBox.Value;
            int minute = dateTime.Minute;
            this.fTimelinePoint.Schedule = new DateTime(year1, month1, day1, hour, minute, 0);
        }

        private void ScheduleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduleType selectedItem = (ScheduleType)this.ScheduleBox.SelectedItem;
            this.DateLbl.Enabled = selectedItem != ScheduleType.None;
            this.DateBox.Enabled = selectedItem != ScheduleType.None;
            this.TimeLbl.Enabled = selectedItem == ScheduleType.DateTime;
            this.TimeBox.Enabled = selectedItem == ScheduleType.DateTime;
        }
    }
}