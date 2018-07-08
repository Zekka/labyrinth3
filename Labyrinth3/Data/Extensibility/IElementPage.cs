// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.IElementPage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Events;
using Labyrinth.Plot;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface implemented by plot element pages.</summary>
    public interface IElementPage : IPage
    {
        /// <summary>Gets the element.</summary>
        Element Element { get; }

        /// <summary>Gets the currently selected annotation.</summary>
        Annotation SelectedAnnotation { get; }

        /// <summary>Gets the currently selected link.</summary>
        Link SelectedLink { get; }

        /// <summary>Gets the currently selected timeline.</summary>
        Timeline SelectedTimeline { get; }

        /// <summary>Gets the currently selected timeline annotation.</summary>
        Annotation SelectedTimelineAnnotation { get; }

        /// <summary>Occurs when an element is opened.</summary>
        event ElementEventHandler ElementActivated;

        /// <summary>Occurs when an element is changed.</summary>
        event ElementEventHandler ElementModified;

        /// <summary>Occurs when a structure is opened.</summary>
        event StructureEventHandler StructureActivated;

        /// <summary>Occurs when a structure is changed.</summary>
        event StructureEventHandler StructureModified;

        /// <summary>Occurs when a timeline is opened.</summary>
        event TimelineEventHandler TimelineActivated;

        /// <summary>Occurs when a timeline is changed.</summary>
        event TimelineEventHandler TimelineModified;
    }
}