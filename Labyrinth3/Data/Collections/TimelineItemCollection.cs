using Labyrinth.Plot;
using System;
using System.Collections.Generic;

namespace Labyrinth.Extensions
{
    public static class TimelineItemExtensions
    {
        /// <summary>
        /// Returns the 0-based index of the TimelineItem with the specified ID.
        /// </summary>
        /// <param name="id">The Guid to search for.</param>
        /// <returns>The 0-based index of the item, or -1 if the item is not present.</returns>
        public static int IndexOf(this List<TimelineItem> l, Guid id)
        {
            for (int index = 0; index != l.Count; ++index)
            {
                if (l[index].ID == id)
                    return index;
            }
            return -1;
        }
    }
}