// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.ICalendarPage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Events;
using Labyrinth.Plot;
using System;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface implemented by calendar pages.</summary>
    public interface ICalendarPage : IPage
    {
        /// <summary>Gets the selected date.</summary>
        DateTime SelectedDate { get; }

        /// <summary>Gets the selected timeline item.</summary>
        TimelineItem SelectedItem { get; }

        /// <summary>Occurs when an element is activated.</summary>
        event ElementEventHandler ElementActivated;

        /// <summary>Occurs when an element is modified.</summary>
        event ElementEventHandler ElementModified;

        /// <summary>Occurs when a timeline is activated.</summary>
        event TimelineEventHandler TimelineActivated;

        /// <summary>Occurs when a timeline is modified.</summary>
        event TimelineEventHandler TimelineModified;
    }
}