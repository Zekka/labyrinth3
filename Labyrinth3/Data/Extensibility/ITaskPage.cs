// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.ITaskPage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Plot;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface implemented by task pages.</summary>
    public interface ITaskPage : IPage
    {
        /// <summary>Gets the selected task.</summary>
        Task SelectedTask { get; }
    }
}