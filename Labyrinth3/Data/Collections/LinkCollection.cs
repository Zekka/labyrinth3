using Labyrinth.Plot;
using System;
using System.Collections.Generic;

namespace Labyrinth.Collections
{
    public static class LinkExtensions
    {
        /// <summary>
        /// Returns the 0-based index of the Link with the specified ID.
        /// </summary>
        /// <param name="id">The Guid to search for.</param>
        /// <returns>The 0-based index of the item, or -1 if the item is not present.</returns>
        public static int IndexOf(this List<Link> l, Guid id)
        {
            for (int index = 0; index != l.Count; ++index)
            {
                if (l[index].ID == id)
                    return index;
            }
            return -1;
        }

        /// <summary>
        /// Returns the 0-based index of the Link with the specified text.
        /// </summary>
        /// <param name="desc">The text to search for.</param>
        /// <returns>The 0-based index of the item, or -1 if the item is not present.</returns>
        public static int IndexOf(this List<Link> l, string desc)
        {
            for (int index = 0; index != l.Count; ++index)
            {
                if (l[index].Description == desc)
                    return index;
            }
            return -1;
        }
    }
}