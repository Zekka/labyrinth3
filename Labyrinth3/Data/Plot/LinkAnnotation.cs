// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.LinkAnnotation
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System.IO;

namespace Labyrinth.Plot
{
    /// <summary>An annotation containing a link to a file.</summary>
    public class LinkAnnotation : Annotation
    {
        private string fContent = "";

        /// <summary>Gets the name of the file.</summary>
        public override string Title
        {
            get
            {
                FileInfo fileInfo = new FileInfo(this.fContent);
                return fileInfo.Exists ? fileInfo.Name : "";
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the filename.</summary>
        public override string Content
        {
            get
            {
                return this.fContent;
            }
            set
            {
                this.fContent = value;
            }
        }
    }
}