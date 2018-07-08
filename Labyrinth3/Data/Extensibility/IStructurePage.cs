// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.IStructurePage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Events;
using Labyrinth.Plot;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface implemented by structure pages.</summary>
    public interface IStructurePage : IPage
    {
        /// <summary>Gets the structure.</summary>
        Structure Structure { get; }

        /// <summary>Gets the currently selected node.</summary>
        Node SelectedNode { get; }

        /// <summary>Gets the currently selected link.</summary>
        Link SelectedLink { get; }

        /// <summary>Occurs when an element is opened.</summary>
        event ElementEventHandler ElementActivated;

        /// <summary>Occurs when an element is changed.</summary>
        event ElementEventHandler ElementModified;

        /// <summary>Occurs when the structure changes.</summary>
        event StructureEventHandler StructureModified;
    }
}