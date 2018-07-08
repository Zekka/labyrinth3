// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.IAddIn
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

namespace Labyrinth.Extensibility
{
    /// <summary>Interface required for add-ins.</summary>
    public interface IAddIn
    {
        /// <summary>Gets the name of the add-in.</summary>
        string Name { get; }

        /// <summary>Gets the description of the add-in.</summary>
        string Description { get; }

        /// <summary>
        /// Gets the collection of components provided by the add-in.
        /// </summary>
        IAddInComponent[] Components { get; }

        /// <summary>Called by the system to initialise the add-in.</summary>
        /// <param name="app">The application.</param>
        /// <returns>True if the add-in was initialised successfully, false otherwise</returns>
        bool Load(IApplication app);

        /// <summary>Called by the system to unload the add-in.</summary>
        void Unload();
    }
}