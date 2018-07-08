using System.Collections.Generic;

namespace Labyrinth.Plot
{
    /// <summary>A plot project.</summary>
    public class Project
    {
        private string fSaveFormat = "3.5";
        private string fName = "";
        private List<Element> fElements = new List<Element>();
        private List<Structure> fStructures = new List<Structure>();
        private List<Timeline> fTimelines = new List<Timeline>();
        private List<Task> fTasks = new List<Task>();
        private List<Note> fNotes = new List<Note>();

        /// <summary>Gets or sets the save format version.</summary>
        public string SaveFormat
        {
            get
            {
                return this.fSaveFormat;
            }
            set
            {
                this.fSaveFormat = value;
            }
        }

        /// <summary>Gets or sets the project's name.</summary>
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

        /// <summary>Gets the collection of elements in this project.</summary>
        public List<Element> Elements
        {
            get
            {
                return this.fElements;
            }
        }

        /// <summary>Gets the collection of structures in this project.</summary>
        public List<Structure> Structures
        {
            get
            {
                return this.fStructures;
            }
        }

        /// <summary>Gets the collection of timelines in this project.</summary>
        public List<Timeline> Timelines
        {
            get
            {
                return this.fTimelines;
            }
        }

        /// <summary>Gets the collection of task items.</summary>
        public List<Task> Tasks
        {
            get
            {
                return this.fTasks;
            }
        }

        /// <summary>Gets the collection of note items.</summary>
        public List<Note> Notes
        {
            get
            {
                return this.fNotes;
            }
        }

        /// <summary>
        /// Deletes an element from a project.
        /// This also removes all references to the element in all structures and timelines.
        /// </summary>
        /// <param name="e">The element to be removed</param>
        public void RemoveElement(Element e)
        {
            this.fElements.Remove(e);
            foreach (Structure fStructure in this.fStructures)
                fStructure.RemoveElement(e.ID);
            foreach (Timeline fTimeline in this.fTimelines)
                fTimeline.RemoveElement(e.ID);
        }

        /// <summary>
        /// Merges the content of several elements into a new element.
        /// </summary>
        /// <param name="oldelements">The old elements</param>
        /// <param name="newelement">The new element</param>
        public void MergeElements(Element[] oldelements, Element newelement)
        {
            foreach (Element oldelement in oldelements)
                newelement.Annotations.AddRange(oldelement.Annotations);
            foreach (Structure fStructure in this.fStructures)
                fStructure.MergeElements(oldelements, newelement);
            foreach (Timeline fTimeline in this.fTimelines)
                fTimeline.MergeElements(oldelements, newelement);
            foreach (var oldelement in oldelements)
                this.fElements.Remove(oldelement);
        }

        /// <summary>Performs a simple search on the project.</summary>
        /// <param name="terms">The terms to search for.</param>
        /// <param name="casesensitive">Whether case is taken into account.</param>
        /// <param name="negated">Whether a logical NOT is applied to the search.</param>
        /// <returns>A list of search results.</returns>
        public SearchResult[] PerformSearch(string[] terms, bool casesensitive, bool negated)
        {
            var arrayList = new List<SearchResult>();
            foreach (Element fElement in this.fElements)
            {
                if (this.match(fElement.Name, terms, casesensitive, negated))
                    arrayList.Add(new SearchResult(fElement, null));
                foreach (Annotation annotation in fElement.Annotations)
                {
                    if (this.match(annotation.Title, terms, casesensitive, negated) || this.match(annotation.Content, terms, casesensitive, negated))
                        arrayList.Add(new SearchResult(annotation, fElement));
                }
            }
            foreach (Structure fStructure in this.fStructures)
            {
                if (this.match(fStructure.Name, terms, casesensitive, negated))
                    arrayList.Add(new SearchResult(fStructure, null));
                foreach (Link link in fStructure.Links)
                {
                    if (this.match(link.Description, terms, casesensitive, negated))
                        arrayList.Add(new SearchResult(link, fStructure));
                }
            }
            foreach (Timeline fTimeline in this.fTimelines)
            {
                if (this.match(fTimeline.Name, terms, casesensitive, negated))
                    arrayList.Add(new SearchResult(fTimeline, null));
                foreach (TimelinePoint point in fTimeline.Points)
                {
                    foreach (TimelineItem timelineItem in point.Items)
                    {
                        if (this.match(timelineItem.Annotation.Title, terms, casesensitive, negated) || this.match(timelineItem.Annotation.Content, terms, casesensitive, negated))
                            arrayList.Add(new SearchResult(timelineItem.Annotation, fTimeline));
                    }
                }
            }
            foreach (Task fTask in this.fTasks)
            {
                if (this.match(fTask.Title, terms, casesensitive, negated) || this.match(fTask.Details, terms, casesensitive, negated))
                    arrayList.Add(new SearchResult(fTask, null));
            }
            foreach (Note fNote in this.fNotes)
            {
                if (this.match(fNote.Title, terms, casesensitive, negated) || this.match(fNote.Text, terms, casesensitive, negated))
                    arrayList.Add(new SearchResult(fNote, null));
            }
            return arrayList.ToArray();
        }

        private bool match(string source, string[] terms, bool casesensitive, bool negated)
        {
            string str1 = casesensitive ? source : source.ToLower();
            foreach (string term in terms)
            {
                string str2 = casesensitive ? term : term.ToLower();
                if (str1.IndexOf(str2) != -1 == negated)
                    return false;
            }
            return true;
        }
    }
}