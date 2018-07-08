// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.INotePage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Events;
using Labyrinth.Plot;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface implemented by note pages.</summary>
    public interface INotePage : IPage
    {
        /// <summary>Gets the note.</summary>
        Note Note { get; }

        /// <summary>Occurs when the note is modified.</summary>
        event NoteEventHandler NoteModified;
    }
}