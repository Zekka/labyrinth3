// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.IPage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

namespace Labyrinth.Extensibility
{
    /// <summary>
    /// Interface implemented by Labyrinth pages.
    /// This interface must be implemented by a class derived from
    /// System.Windows.Forms.Control.
    /// </summary>
    public interface IPage
    {
        /// <summary>Gets the title of the page.</summary>
        string Title { get; }

        /// <summary>
        /// Gets a value indicating whether this page should be closed.
        /// </summary>
        bool IsObsolete { get; }

        /// <summary>Called by the system to update UI cues.</summary>
        void UpdateUI();

        /// <summary>Called by the system when the project changes.</summary>
        void UpdateData();
    }
}