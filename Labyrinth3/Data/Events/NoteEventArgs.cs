// Decompiled with JetBrains decompiler
// Type: Labyrinth.Events.NoteEventArgs
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
    public class NoteEventArgs : EventArgs
    {
        private Note fNote = (Note)null;

        /// <summary>Constructor.</summary>
        /// <param name="n">The note.</param>
        public NoteEventArgs(Note n)
        {
            this.fNote = n;
        }

        /// <summary>The note specified by the event.</summary>
        public Note Note
        {
            get
            {
                return this.fNote;
            }
        }
    }
}