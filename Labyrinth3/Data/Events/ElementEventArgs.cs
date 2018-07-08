using Labyrinth.Plot;
using System;

namespace Labyrinth.Events
{
    /// <summary>
    /// Event data for events which take an element as an argument.
    /// </summary>
    public class ElementEventArgs : EventArgs
    {
        private Element fElement = (Element)null;

        /// <summary>Constructor.</summary>
        /// <param name="e">The element.</param>
        public ElementEventArgs(Element e)
        {
            this.fElement = e;
        }

        /// <summary>The element specified by the event.</summary>
        public Element Element
        {
            get
            {
                return this.fElement;
            }
        }
    }
}