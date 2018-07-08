// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.TimelineItem
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;

namespace Labyrinth.Plot
{
    /// <summary>
    /// Class representing information about a plot element at a point in a timeline.
    /// </summary>
    public class TimelineItem
    {
        private Guid fID = Guid.NewGuid();
        private Guid fElementID = Guid.Empty;
        private TextAnnotation fAnnotation = new TextAnnotation();

        /// <summary>Gets or sets the timeline item's ID.</summary>
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

        /// <summary>Gets or sets the ID of the plot element.</summary>
        public Guid ElementID
        {
            get
            {
                return this.fElementID;
            }
            set
            {
                this.fElementID = value;
            }
        }

        /// <summary>Gets or sets the annotation for this item.</summary>
        public TextAnnotation Annotation
        {
            get
            {
                return this.fAnnotation;
            }
            set
            {
                this.fAnnotation = value;
            }
        }
    }
}