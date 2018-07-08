using Labyrinth.Plot;
using System;
using System.Collections.Generic;

namespace Labyrinth.Collections
{
    public static class ElementExtensions
    {
        /// <summary>
        /// Returns the 0-based index of the Element with the specified ID.
        /// </summary>
        /// <param name="id">The Guid to search for.</param>
        /// <returns>The 0-based index of the item, or -1 if the item is not present.</returns>
        public static int IndexOf(this List<Element> l, Guid id)
        {
            for (int index = 0; index != l.Count; ++index)
            {
                if (l[index].ID == id)
                    return index;
            }
            return -1;
        }

        /// <summary>
        /// Returns the 0-based index of the Element with the specified name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>The 0-based index of the item, or -1 if the item is not present.</returns>
        public static int IndexOf(this List<Element> l, string name)
        {
            for (int index = 0; index != l.Count; ++index)
            {
                if (l[index].Name == name)
                    return index;
            }
            return -1;
        }
    }
}