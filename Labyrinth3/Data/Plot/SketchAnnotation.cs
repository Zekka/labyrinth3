// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.SketchAnnotation
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace Labyrinth.Plot
{
    /// <summary>An annotation containing a drawn image.</summary>
    public class SketchAnnotation : Annotation
    {
        private string fTitle = "";
        private string fContent = "";
        private Image fSketch = (Image)null;

        /// <summary>Constructor.</summary>
        public SketchAnnotation()
        {
            this.fSketch = (Image)new Bitmap(1000, 1000);
            Graphics.FromImage(this.fSketch).Clear(Color.White);
        }

        /// <summary>Gets or sets the title of the image.</summary>
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

        /// <summary>Gets or sets a description of the image.</summary>
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

        /// <summary>Gets or sets the image.</summary>
        [XmlIgnore]
        public Image Sketch
        {
            get
            {
                return this.fSketch;
            }
            set
            {
                this.fSketch = value;
            }
        }

        /// <summary>Gets or sets the image as a byte array.</summary>
        public byte[] ImageData
        {
            get
            {
                MemoryStream memoryStream = new MemoryStream();
                this.fSketch.Save((Stream)memoryStream, ImageFormat.Gif);
                int int32 = Convert.ToInt32(memoryStream.Length);
                byte[] buffer = new byte[(int)checked((uint)int32)];
                memoryStream.Position = 0L;
                memoryStream.Read(buffer, 0, int32);
                memoryStream.Close();
                return buffer;
            }
            set
            {
                this.fSketch = (Image)new Bitmap((Image)new Bitmap((Stream)new MemoryStream(value)));
            }
        }
    }
}