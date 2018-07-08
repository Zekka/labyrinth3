// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.Annotation
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;

namespace Labyrinth.Plot
{
    /// <summary>A piece of explanatory or expositionary content.</summary>
    public abstract class Annotation
    {
        private Guid fID = Guid.NewGuid();

        /// <summary>Gets or sets the ID.</summary>
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

        /// <summary>Gets or sets the title of the annotation.</summary>
        public abstract string Title { get; set; }

        /// <summary>Gets or sets the content of the annotation.</summary>
        public abstract string Content { get; set; }

        /// <summary>Returns a string representation of the object.</summary>
        /// <returns>Returns a string representation of the object.</returns>
        public override string ToString()
        {
            return this.Title;
        }
    }
}