// Decompiled with JetBrains decompiler
// Type: Labyrinth.Events.TimelineEventArgs
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Plot;
using System;

namespace Labyrinth.Events
{
    /// <summary>
    /// Event data for events which take a timeline as an argument.
    /// </summary>
    public class TimelineEventArgs : EventArgs
    {
        private Timeline fTimeline = (Timeline)null;

        /// <summary>Constructor.</summary>
        /// <param name="tl">The timeline.</param>
        public TimelineEventArgs(Timeline tl)
        {
            this.fTimeline = tl;
        }

        /// <summary>The timeline specified by the event.</summary>
        public Timeline Timeline
        {
            get
            {
                return this.fTimeline;
            }
        }
    }
}