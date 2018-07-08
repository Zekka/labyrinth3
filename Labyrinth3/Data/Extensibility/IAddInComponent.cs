// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.IAddInComponent
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

namespace Labyrinth.Extensibility
{
    /// <summary>Interface for add-in functions.</summary>
    public interface IAddInComponent
    {
        /// <summary>Gets the name of the component.</summary>
        string Name { get; }

        /// <summary>Gets the description of the component.</summary>
        string Description { get; }

        /// <summary>Called by the system when the project data changes.</summary>
        void UpdateData();
    }
}