// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.Note
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;

namespace Labyrinth.Plot
{
    /// <summary>Represents a text note.</summary>
    public class Note
    {
        private Guid fID = Guid.NewGuid();
        private string fTitle = "";
        private string fRTF = "";
        private string fText = "";
        private bool fTemplate = false;

        /// <summary>Gets or sets the note's ID.</summary>
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

        /// <summary>Gets or sets the title of the note.</summary>
        public string Title
        {
            get
            {
                return this.fTitle;
            }
            set
            {
                this.fTitle = value;
            }
        }

        /// <summary>Gets or sets the note's RTF text.</summary>
        public string RTF
        {
            get
            {
                return this.fRTF;
            }
            set
            {
                this.fRTF = value;
            }
        }

        /// <summary>Gets or sets the note's text.</summary>
        public string Text
        {
            get
            {
                return this.fText;
            }
            set
            {
                this.fText = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the note is an annotation template.
        /// </summary>
        public bool IsTemplate
        {
            get
            {
                return this.fTemplate;
            }
            set
            {
                this.fTemplate = value;
            }
        }

        /// <summary>Returns a string representation of the object.</summary>
        /// <returns>Returns a string representation of the object.</returns>
        public override string ToString()
        {
            return this.fTitle;
        }
    }
}