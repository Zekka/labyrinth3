// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.ISearchPage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Events;
using Labyrinth.Plot;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface implemented by the search page.</summary>
    public interface ISearchPage : IPage
    {
        /// <summary>Gets or sets the text for the simple search.</summary>
        string SimpleText { get; set; }

        /// <summary>
        /// Gets or sets whether the simple search is case-sensitive.
        /// </summary>
        bool SimpleCaseSensitive { get; set; }

        /// <summary>Gets the currently selected search result.</summary>
        SearchResult SelectedResult { get; }

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