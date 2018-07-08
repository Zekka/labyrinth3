// Decompiled with JetBrains decompiler
// Type: Labyrinth.Plot.SearchResult
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

namespace Labyrinth.Plot
{
    /// <summary>An item returned by a search.</summary>
    public class SearchResult
    {
        private object fData;
        private object fDetails;

        /// <summary>Constructor.</summary>
        /// <param name="data">The item returned by the search.</param>
        /// <param name="details">The secondary information about this result.</param>
        public SearchResult(object data, object details)
        {
            this.fData = data;
            this.fDetails = details;
        }

        /// <summary>Gets the item returned by the search.</summary>
        public object Data
        {
            get
            {
                return this.fData;
            }
        }

        /// <summary>Gets secondary information about this result.</summary>
        public object Details
        {
            get
            {
                return this.fDetails;
            }
        }
    }
}