// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.TimelinePoint
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;
using System.Collections.Generic;

namespace Labyrinth.Plot
{
    /// <summary>Class representing a point in a timeline.</summary>
    public class TimelinePoint : IComparable
    {
        private Guid fID = Guid.NewGuid();
        private string fName = "";
        private ScheduleType fUseSchedule = ScheduleType.None;
        private DateTime fSchedule = DateTime.MinValue;
        private List<TimelineItem> fItems = new List<TimelineItem>();

        /// <summary>Gets or sets the timeline point's ID.</summary>
        public Guid ID
        {
            get
            {
                return this.fID;
            }
            set
            {
                this.fID = value;
            }
        }

        /// <summary>Gets or sets the timeline point's name.</summary>
        public string Name
        {
            get
            {
                return this.fName;
            }
            set
            {
                this.fName = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the point is scheduled for a specific date and time.
        /// </summary>
        public ScheduleType UseSchedule
        {
            get
            {
                return this.fUseSchedule;
            }
            set
            {
                this.fUseSchedule = value;
            }
        }

        /// <summary>Gets or sets the date and time the point occurs on.</summary>
        public DateTime Schedule
        {
            get
            {
                return this.fSchedule;
            }
            set
            {
                this.fSchedule = value;
            }
        }

        /// <summary>Gets the list of items in this point.</summary>
        public List<TimelineItem> Items
        {
            get
            {
                return this.fItems;
            }
        }

        /// <summary>Compares this instance with a specified object.</summary>
        /// <param name="obj">An Object that evaluates to a TimelinePoint.</param>
        /// <returns>A value indicating the relative order of the two objects.</returns>
        public int CompareTo(object obj)
        {
            TimelinePoint timelinePoint = obj as TimelinePoint;
            if (timelinePoint == null)
                throw new ArgumentException();
            if (this.fUseSchedule == ScheduleType.None && timelinePoint.UseSchedule == ScheduleType.None)
                return this.fName.CompareTo(timelinePoint.Name);
            if (this.fUseSchedule == ScheduleType.None)
                return -1;
            if (timelinePoint.UseSchedule == ScheduleType.None)
                return 1;
            return this.fSchedule.CompareTo((object)timelinePoint.Schedule);
        }
    }
}