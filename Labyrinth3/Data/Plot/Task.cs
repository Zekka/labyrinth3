// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.Task
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;

namespace Labyrinth.Plot
{
    /// <summary>Represents a task or to-do item.</summary>
    public class Task
    {
        private Guid fID = Guid.NewGuid();
        private string fTitle = "";
        private string fDetails = "";
        private bool fCompleted = false;
        private Importance fImportance = Importance.Normal;
        private bool fHasDeadline = false;
        private DateTime fDeadline = DateTime.MinValue;

        /// <summary>Gets or sets the task's ID.</summary>
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

        /// <summary>Gets or sets the title of the task.</summary>
        public string Title
        {
            get
            {
                return this.fTitle;
            }
            set
            {
                this.fTitle = value;
            }
        }

        /// <summary>Gets or sets the task's details.</summary>
        public string Details
        {
            get
            {
                return this.fDetails;
            }
            set
            {
                this.fDetails = value;
            }
        }

        /// <summary>Gets or sets whether the task has been completed.</summary>
        public bool Completed
        {
            get
            {
                return this.fCompleted;
            }
            set
            {
                this.fCompleted = value;
            }
        }

        /// <summary>Gets or sets the task's importance.</summary>
        public Importance Importance
        {
            get
            {
                return this.fImportance;
            }
            set
            {
                this.fImportance = value;
            }
        }

        /// <summary>Gets or sets whether the task has a set deadline.</summary>
        public bool HasDeadline
        {
            get
            {
                return this.fHasDeadline;
            }
            set
            {
                this.fHasDeadline = value;
            }
        }

        /// <summary>Gets or sets the task's deadline.</summary>
        public DateTime Deadline
        {
            get
            {
                return this.fDeadline;
            }
            set
            {
                this.fDeadline = value;
            }
        }

        /// <summary>Returns a string representation of the object.</summary>
        /// <returns>Returns a string representation of the object.</returns>
        public override string ToString()
        {
            return this.fTitle;
        }
    }
}