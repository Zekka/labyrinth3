// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.IAnnotationPage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Events;
using Labyrinth.Plot;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface implemented by annnotation pages.</summary>
    public interface IAnnotationPage : IPage
    {
        /// <summary>Gets or sets whether text annotations are displayed.</summary>
        bool ShowTextAnnotations { get; set; }

        /// <summary>
        /// Gets or sets whether file link annotations are displayed.
        /// </summary>
        bool ShowLinkAnnotations { get; set; }

        /// <summary>
        /// Gets or sets whether sketch annotations are displayed.
        /// </summary>
        bool ShowSketchAnnotations { get; set; }

        /// <summary>Gets the selected annotation.</summary>
        Annotation SelectedAnnotation { get; }

        /// <summary>Occurs when an element is modified.</summary>
        event ElementEventHandler ElementModified;

        /// <summary>Occurs when an element is activated.</summary>
        event ElementEventHandler ElementActivated;

        /// <summary>Occurs when a timeline is modified.</summary>
        event TimelineEventHandler TimelineModified;

        /// <summary>Occurs when a timeline is activated.</summary>
        event TimelineEventHandler TimelineActivated;
    }
}