// Decompiled with JetBrains decompiler
// Type: Labyrinth.Events.TimelineEventHandler
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

namespace Labyrinth.Events
{
    /// <summary>
    /// Delegate for events which take a timeline as an argument.
    /// </summary>
    public delegate void TimelineEventHandler(object sender, TimelineEventArgs e);
}