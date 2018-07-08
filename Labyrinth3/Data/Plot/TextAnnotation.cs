// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.TextAnnotation
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

namespace Labyrinth.Plot
{
    /// <summary>An annotation containing RTF text.</summary>
    public class TextAnnotation : Annotation
    {
        private string fTitle = "";
        private string fContent = "";
        private string fRTF = "";

        /// <summary>Gets or sets the title of the annotation.</summary>
        public override string Title
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

        /// <summary>Gets or sets the plaintext content of the annotation.</summary>
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

        /// <summary>Gets or sets the RTF content of the annotation.</summary>
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
    }
}