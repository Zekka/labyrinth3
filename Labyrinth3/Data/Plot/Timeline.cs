using System;
using System.Collections.Generic;

namespace Labyrinth.Plot
{
    /// <summary>
    /// A timeline of events holding information about plot elements.
    /// </summary>
    public class Timeline
    {
        private Guid fID = Guid.NewGuid();
        private string fName = "";
        private List<Guid> fElementIDs = new List<Guid>();
        private List<TimelinePoint> fPoints = new List<TimelinePoint>();
        private bool fSorting = true;

        /// <summary>Gets or sets the timeline's ID.</summary>
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

        /// <summary>Gets or sets the timeline's name.</summary>
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

        /// <summary>Gets the list of elements in this timeline.</summary>
        public List<Guid> ElementIDs
        {
            get
            {
                return this.fElementIDs;
            }
        }

        /// <summary>Gets the list of points in this timeline.</summary>
        public List<TimelinePoint> Points
        {
            get
            {
                return this.fPoints;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the timeline sorts its points by date.
        /// </summary>
        public bool Sorting
        {
            get
            {
                return this.fSorting;
            }
            set
            {
                this.fSorting = value;
            }
        }

        /// <summary>Returns a string representation of the timeline.</summary>
        /// <returns>Returns a string representation of the timeline.</returns>
        public override string ToString()
        {
            return this.fName;
        }

        /// <summary>Removes all references to an element.</summary>
        /// <param name="element_id">The element to remove.</param>
        public void RemoveElement(Guid element_id)
        {
            var arrayList1 = new List<Guid>();
            foreach (Guid fElementId in this.fElementIDs)
            {
                if (fElementId == element_id)
                    arrayList1.Add(fElementId);
            }
            foreach (Guid guid in arrayList1)
                this.fElementIDs.Remove(guid);
            foreach (TimelinePoint fPoint in this.fPoints)
            {
                var arrayList2 = new List<TimelineItem>();
                foreach (TimelineItem timelineItem in fPoint.Items)
                {
                    if (timelineItem.ElementID == element_id)
                        arrayList2.Add(timelineItem);
                }
                foreach (TimelineItem timelineItem in arrayList2)
                    fPoint.Items.Remove(timelineItem);
            }
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

            var arrayList2 = new List<Guid>();
            foreach (Guid fElementId in this.fElementIDs)
            {
                if (arrayList1.Contains(fElementId))
                    arrayList2.Add(fElementId);
            }
            foreach (Guid guid in arrayList2)
                this.fElementIDs.Remove(guid);
            if (arrayList2.Count != 0)
                this.fElementIDs.Add(newelement.ID);
            foreach (TimelinePoint fPoint in this.fPoints)
            {
                foreach (TimelineItem timelineItem in fPoint.Items)
                {
                    if (arrayList1.Contains(timelineItem.ElementID))
                        timelineItem.ElementID = newelement.ID;
                }
            }
        }
    }
}