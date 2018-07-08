// Decompiled with JetBrains decompiler
// Type: Labyrinth.Events.StructureEventArgs
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Plot;
using System;

namespace Labyrinth.Events
{
    /// <summary>
    /// Event data for events which take a structure as an argument.
    /// </summary>
    public class StructureEventArgs : EventArgs
    {
        private Structure fStructure = (Structure)null;

        /// <summary>Constructor.</summary>
        /// <param name="s">The structure.</param>
        public StructureEventArgs(Structure s)
        {
            this.fStructure = s;
        }

        /// <summary>The structure specified by the event.</summary>
        public Structure Structure
        {
            get
            {
                return this.fStructure;
            }
        }
    }
}