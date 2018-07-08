// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.IExplorerPage
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Extensibility
{
    /// <summary>Interface for custom explorer pages.</summary>
    public interface IExplorerPage : IAddInComponent
    {
        /// <summary>Gets the icon to be displayed on the page tab.</summary>
        Icon Icon { get; }

        /// <summary>Gets the control to be displayed on the page.</summary>
        Control Control { get; }
    }
}