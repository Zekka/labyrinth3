// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.IApplication
// Assembly: Data, Version=3.6.1928.15689, Culture=neutral, PublicKeyToken=null
// MVID: DD3860A9-34AC-4A51-A3EB-CBA78B243957
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Data.dll

using Labyrinth.Events;
using Labyrinth.Plot;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Labyrinth.Extensibility
{
    /// <summary>
    /// Interface allowing access to the Labyrinth application.
    /// </summary>
    public interface IApplication
    {
        /// <summary>Gets the current project.</summary>
        Project Project { get; }

        /// <summary>Gets or sets the current filename.</summary>
        string FileName { get; set; }

        /// <summary>Gets the application menubar.</summary>
        MainMenu Menubar { get; }

        /// <summary>Gets the application toolbar.</summary>
        ToolBar Toolbar { get; }

        /// <summary>Gets the application statusbar.</summary>
        StatusBar Statusbar { get; }

        /// <summary>Gets the printer page settings.</summary>
        PageSettings PageSettings { get; }

        /// <summary>Gets the printer settings.</summary>
        PrinterSettings PrinterSettings { get; }

        /// <summary>Gets the element currently selected in the explorer.</summary>
        Element SelectedElement { get; }

        /// <summary>
        /// Gets the structure currently selected in the explorer.
        /// </summary>
        Structure SelectedStructure { get; }

        /// <summary>Gets the timeline currently selected in the explorer.</summary>
        Timeline SelectedTimeline { get; }

        /// <summary>Gets the note currently selected in the explorer.</summary>
        Note SelectedNote { get; }

        /// <summary>Gets the active page.</summary>
        IPage ActivePage { get; }

        /// <summary>Gets the collection of open pages.</summary>
        IPage[] OpenPages { get; }

        /// <summary>Gets the list of installed add-ins.</summary>
        IAddIn[] AddIns { get; }

        /// <summary>Gets the ImageList containing element icons.</summary>
        ImageList Glyphs { get; }

        /// <summary>
        /// Opens a page for the given element.
        /// If such a page already exists, it is activated.
        /// </summary>
        /// <param name="e">The element to open.</param>
        void OpenElement(Element e);

        /// <summary>
        /// Opens a page for the given structure.
        /// If such a page already exists, it is activated.
        /// </summary>
        /// <param name="s">The structure to open.</param>
        void OpenStructure(Structure s);

        /// <summary>
        /// Opens a page for the given timeline.
        /// If such a page already exists, it is activated.
        /// </summary>
        /// <param name="tl">The timeline to open.</param>
        void OpenTimeline(Timeline tl);

        /// <summary>
        /// Opens a page for the given note.
        /// If such a page already exists, it is activated.
        /// </summary>
        /// <param name="n">The note to open.</param>
        void OpenNote(Note n);

        /// <summary>Opens the search page.</summary>
        void OpenSearch();

        /// <summary>Opens the annotations page.</summary>
        void OpenAnnotations();

        /// <summary>Opens the tasks page.</summary>
        void OpenTasks();

        /// <summary>Opens the calendar page.</summary>
        void OpenCalendar();

        /// <summary>Opens a blank project.</summary>
        void NewProject();

        /// <summary>Opens the project from the given file.</summary>
        /// <param name="filename">The file to open.</param>
        /// <returns>True if the project was opened successfully, false otherwise.</returns>
        bool OpenProject(string filename);

        /// <summary>Saves the project to the given file.</summary>
        /// <param name="filename">The file to save to.</param>
        /// <returns>True if the project was saved successfully, false otherwise.</returns>
        bool SaveProject(string filename);

        /// <summary>Opens the specified page.</summary>
        /// <param name="page">The page to Open.</param>
        void OpenPage(IPage page);

        /// <summary>Closes the specified page.</summary>
        /// <param name="page">The page to close.</param>
        /// <returns>True if the page was found and closed, false otherwise.</returns>
        bool ClosePage(IPage page);

        /// <summary>Updates the application UI.</summary>
        void UpdateUI();

        /// <summary>
        /// Returns the index of the glyph used for the given object.
        /// </summary>
        /// <param name="obj">The object to find the image for.</param>
        /// <returns>The index in the Glyphs ImageList, or -1 if no icon exists.</returns>
        int GetImageIndex(object obj);

        /// <summary>Occurs when a new blank project is created.</summary>
        event EventHandler ProjectCreated;

        /// <summary>Occurs when a project file is opened.</summary>
        event EventHandler ProjectOpened;

        /// <summary>Occurs when a project is saved.</summary>
        event EventHandler ProjectSaved;

        /// <summary>Occurs when a project is about to be closed.</summary>
        event EventHandler ProjectClosing;

        /// <summary>Occurs when a new element is added.</summary>
        event ElementEventHandler ElementAdded;

        /// <summary>Occurs when an element is changed.</summary>
        event ElementEventHandler ElementModified;

        /// <summary>Occurs when an element is deleted.</summary>
        event ElementEventHandler ElementDeleted;

        /// <summary>Occurs when a new structure is added.</summary>
        event StructureEventHandler StructureAdded;

        /// <summary>Occurs when a structure is changed.</summary>
        event StructureEventHandler StructureModified;

        /// <summary>Occurs when a structure is deleted.</summary>
        event StructureEventHandler StructureDeleted;

        /// <summary>Occurs when a new timeline is added.</summary>
        event TimelineEventHandler TimelineAdded;

        /// <summary>Occurs when a timeline is changed.</summary>
        event TimelineEventHandler TimelineModified;

        /// <summary>Occurs when a timeline is deleted.</summary>
        event TimelineEventHandler TimelineDeleted;

        /// <summary>Occurs when a new note is added.</summary>
        event NoteEventHandler NoteAdded;

        /// <summary>Occurs when a note is changed.</summary>
        event NoteEventHandler NoteModified;

        /// <summary>Occurs when a note is deleted.</summary>
        event NoteEventHandler NoteDeleted;
    }
}