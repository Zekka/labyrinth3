// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.ITimelinePage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Events;
using Labyrinth.Plot;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface implemented by timeline pages.</summary>
    public interface ITimelinePage : IPage
    {
        /// <summary>Gets the timeline.</summary>
        Timeline Timeline { get; }

        /// <summary>Gets the currently selected element.</summary>
        Element SelectedElement { get; }

        /// <summary>Gets the currently selected timeline point.</summary>
        TimelinePoint SelectedPoint { get; }

        /// <summary>Occurs when an element is opened.</summary>
        event ElementEventHandler ElementActivated;

        /// <summary>Occurs when an element is changed.</summary>
        event ElementEventHandler ElementModified;

        /// <summary>Occurs when the timeline changes.</summary>
        event TimelineEventHandler TimelineModified;
    }
}