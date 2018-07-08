// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.Element
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Labyrinth.Plot
{
    /// <summary>A plot element.</summary>
    public class Element
    {
        private Guid fID = Guid.NewGuid();
        private string fName = "";
        private ElementType fType = ElementType.Generic;
        private List<Annotation> fAnnotations = new List<Annotation>();

        /// <summary>Gets or sets the element's ID.</summary>
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

        /// <summary>Gets or sets the element's name.</summary>
        public string Name
        {
            get
            {
                return this.fName;
            }
            set
            {
                this.fName = value;
            }
        }

        /// <summary>Gets or sets the element's type.</summary>
        public ElementType Type
        {
            get
            {
                return this.fType;
            }
            set
            {
                this.fType = value;
            }
        }

        /// <summary>Gets the collection of annotations for the element.</summary>
        [XmlArrayItem(typeof(TextAnnotation))]
        [XmlArrayItem(typeof(SketchAnnotation))]
        [XmlArrayItem(typeof(LinkAnnotation))]
        public List<Annotation> Annotations
        {
            get
            {
                return this.fAnnotations;
            }
        }

        /// <summary>Returns a string representation of the element.</summary>
        /// <returns>Returns a string representation of the element.</returns>
        public override string ToString()
        {
            return this.fName;
        }
    }
}