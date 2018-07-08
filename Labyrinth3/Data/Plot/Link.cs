// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.Link
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;

namespace Labyrinth.Plot
{
    /// <summary>A link between two plot elements.</summary>
    public class Link
    {
        private Guid fID = Guid.NewGuid();
        private string fDescription = "";
        private Guid fLHS = Guid.Empty;
        private Guid fRHS = Guid.Empty;
        private LinkDirection fDirection = LinkDirection.Single;

        /// <summary>Gets or sets the link's ID.</summary>
        public Guid ID
        {
            get
            {
                return this.fID;
            }
            set
            {
                this.fID = value;
            }
        }

        /// <summary>Gets or sets the text associated with the link.</summary>
        public string Description
        {
            get
            {
                return this.fDescription;
            }
            set
            {
                this.fDescription = value;
            }
        }

        /// <summary>The ID of the element the link is from.</summary>
        public Guid LHS
        {
            get
            {
                return this.fLHS;
            }
            set
            {
                this.fLHS = value;
            }
        }

        /// <summary>The ID of the element the link is to.</summary>
        public Guid RHS
        {
            get
            {
                return this.fRHS;
            }
            set
            {
                this.fRHS = value;
            }
        }

        /// <summary>
        /// The direction of the link.
        /// This governs the placement of arrowheads.
        /// </summary>
        public LinkDirection Direction
        {
            get
            {
                return this.fDirection;
            }
            set
            {
                this.fDirection = value;
            }
        }

        /// <summary>Returns a string representation of the link.</summary>
        /// <returns>Returns a string representation of the link.</returns>
        public override string ToString()
        {
            return this.fDescription;
        }
    }
}