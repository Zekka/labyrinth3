using System;
using System.Collections.Generic;
using System.Drawing;

namespace Labyrinth.Plot
{
    /// <summary>
    /// Class holding information on relationships between plot elements.
    /// </summary>
    public class Structure
    {
        private Guid fID = Guid.NewGuid();
        private string fName = "";
        private List<Node> fNodes = new List<Node>();
        private List<Link> fLinks = new List<Link>();

        /// <summary>Gets or sets the structure's ID.</summary>
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

        /// <summary>Gets or sets the structure's name.</summary>
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

        /// <summary>Gets the collection of nodes in this structure.</summary>
        public List<Node> Nodes
        {
            get
            {
                return this.fNodes;
            }
        }

        /// <summary>Gets the collection of links in this structure.</summary>
        public List<Link> Links
        {
            get
            {
                return this.fLinks;
            }
        }

        /// <summary>Returns a string representation of the structure.</summary>
        /// <returns>Returns a string representation of the structure.</returns>
        public override string ToString()
        {
            return this.fName;
        }

        /// <summary>Removes all references to an element.</summary>
        /// <param name="element_id">The element to remove.</param>
        public void RemoveElement(Guid element_id)
        {
            var arrayList1 = new List<Node>();
            foreach (Node fNode in this.fNodes)
            {
                if (fNode.ElementID == element_id)
                    arrayList1.Add(fNode);
            }
            foreach (Node node in arrayList1)
                this.fNodes.Remove(node);

            var arrayList2 = new List<Link>();
            foreach (Link fLink in this.fLinks)
            {
                if (fLink.LHS == element_id || fLink.RHS == element_id)
                    arrayList2.Add(fLink);
            }
            foreach (Link link in arrayList2)
                this.fLinks.Remove(link);
        }

        /// <summary>
        /// Merges the content of several elements into a new element.
        /// </summary>
        /// <param name="oldelements">The old elements</param>
        /// <param name="newelement">The new element</param>
        public void MergeElements(Element[] oldelements, Element newelement)
        {
            var arrayList1 = new List<Guid>();
            foreach (Element oldelement in oldelements)
                arrayList1.Add(oldelement.ID);
            var arrayList2 = new List<Node>();
            float num1 = 0.0f;
            float num2 = 0.0f;
            foreach (Node fNode in this.fNodes)
            {
                if (arrayList1.Contains(fNode.ElementID))
                {
                    arrayList2.Add(fNode);
                    num1 += fNode.Position.X;
                    num2 += fNode.Position.Y;
                }
            }
            foreach (Node node in arrayList2)
                this.fNodes.Remove(node);
            if (arrayList2.Count != 0)
            {
                Node node = new Node();
                node.ElementID = newelement.ID;
                float x = num1 / (float)arrayList2.Count;
                float y = num2 / (float)arrayList2.Count;
                node.Position = new PointF(x, y);
                this.fNodes.Add(node);
            }
            foreach (Element oldelement in oldelements)
            {
                foreach (Link fLink in this.fLinks)
                {
                    if (fLink.LHS == oldelement.ID)
                        fLink.LHS = newelement.ID;
                    if (fLink.RHS == oldelement.ID)
                        fLink.RHS = newelement.ID;
                }
            }
            var arrayList3 = new List<Link>();
            foreach (Link fLink in this.fLinks)
            {
                if (fLink.LHS == fLink.RHS)
                    arrayList3.Add(fLink);
            }
            foreach (Link link in arrayList3)
                this.fLinks.Remove(link);
        }
    }
}