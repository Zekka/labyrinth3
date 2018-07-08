// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.ICommand
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface for add-in commands.</summary>
    public interface ICommand : IAddInComponent
    {
        /// <summary>
        /// Gets a value representing whether the command can be run or not.
        /// </summary>
        bool Available { get; }

        /// <summary>
        /// Gets a value representing whether the command is running or not.
        /// </summary>
        bool Active { get; }

        /// <summary>Occurs when the command is called.</summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Arguments passed to the event.</param>
        void Execute(object sender, EventArgs e);
    }
}