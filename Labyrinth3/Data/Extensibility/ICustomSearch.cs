// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.ICustomSearch
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System.Windows.Forms;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface for add-in searches.</summary>
    public interface ICustomSearch : IAddInComponent
    {
        /// <summary>Gets the control presented on the search pane.</summary>
        Control Control { get; }

        /// <summary>Called by the system to initialise the control.</summary>
        void Init();

        /// <summary>Called by the system to reset the search.</summary>
        void Clear();
    }
}