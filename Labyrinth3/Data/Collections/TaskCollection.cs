﻿using Labyrinth.Plot;
using System;
using System.Collections.Generic;

namespace Labyrinth.Collections
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Returns the 0-based index of the Task with the specified ID.
        /// </summary>
        /// <param name="id">The Guid to search for.</param>
        /// <returns>The 0-based index of the item, or -1 if the item is not present.</returns>
        public static int IndexOf(this List<Task> l, Guid id)
        {
            for (int index = 0; index != l.Count; ++index)
            {
                if (l[index].ID == id)
                    return index;
            }
            return -1;
        }

        /// <summary>
        /// Returns the 0-based index of the Task with the specified title.
        /// </summary>
        /// <param name="title">The name to search for.</param>
        /// <returns>The 0-based index of the item, or -1 if the item is not present.</returns>
        public static int IndexOf(this List<Task> l, string title)
        {
            for (int index = 0; index != l.Count; ++index)
            {
                if (l[index].Title == title)
                    return index;
            }
            return -1;
        }
    }
}