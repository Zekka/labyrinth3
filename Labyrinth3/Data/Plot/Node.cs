// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.Node
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;
using System.Drawing;

namespace Labyrinth.Plot
{
    /// <summary>A node in a structure.</summary>
    public class Node
    {
        private Guid fElementID = Guid.Empty;
        private PointF fPosition = PointF.Empty;

        /// <summary>The ID of the element.</summary>
        public Guid ElementID
        {
            get
            {
                return this.fElementID;
            }
            set
            {
                this.fElementID = value;
            }
        }

        /// <summary>The location of the node.</summary>
        public PointF Position
        {
            get
            {
                return this.fPosition;
            }
            set
            {
                this.fPosition = value;
            }
        }
    }
}