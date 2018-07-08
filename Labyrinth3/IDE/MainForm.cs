// Decompiled with JetBrains decompiler
// Type: Labyrinth.MainForm
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Collections;
using Labyrinth.Events;
using Labyrinth.Extensibility;
using Labyrinth.Forms;
using Labyrinth.Pages;
using Labyrinth.Plot;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Labyrinth
{
    public class MainForm : Form, IApplication
    {
        private AddInManager fAddInMgr = new AddInManager();
        private ArrayList fCustomSearches = new ArrayList();
        private const string FileFilter = "Plot Files|*.plt|All Files|*.*";
        private StatusBarPanel NoteStatusPanel;
        private MenuItem ViewPageTabs;
        private MenuItem ToolsMergeElements;
        private MenuItem WindowMenu;
        private MenuItem WindowCloseAll;
        private MenuItem WindowCloseAllExcept;
        private MenuItem WindowClose;
        private MenuItem Sep7;
        private MenuItem WindowPages;
        private MenuItem Sep8;
        private MainMenu MainMenu;
        private StatusBarPanel NameStatusPanel;
        private StatusBarPanel ElementStatusPanel;
        private StatusBarPanel StructureStatusPanel;
        private StatusBarPanel TimelineStatusPanel;
        private StatusBar StatusBar;
        private ToolBar MainToolBar;
        private MenuItem FileMenu;
        private MenuItem HelpMenu;
        private MenuItem FileNew;
        private MenuItem FileOpen;
        private MenuItem FileSave;
        private MenuItem FileSaveAs;
        private MenuItem Sep1;
        private MenuItem FileExit;
        private MenuItem HelpAbout;
        private ToolBarButton MainNewBtn;
        private ToolBarButton MainOpenBtn;
        private Crownwood.Magic.Controls.TabControl Explorer;
        private Splitter ExplorerSplitter;
        private Crownwood.Magic.Controls.TabControl Pages;
        private Crownwood.Magic.Controls.TabPage ElementPage;
        private Crownwood.Magic.Controls.TabPage StructurePage;
        private Crownwood.Magic.Controls.TabPage TimelinePage;
        private MenuItem ViewMenu;
        private MenuItem ViewExplorer;
        private ImageList ElementImages;
        private ImageList Images;
        private ColumnHeader StructureNameHdr;
        private ColumnHeader TimelineNameHdr;
        private ToolBar ElementToolbar;
        private ToolBarButton ElementNewBtn;
        private ToolBarButton ElementDeleteBtn;
        private ToolBarButton ElementPropertiesBtn;
        private ToolBar StructureToolbar;
        private ToolBarButton StructureNewBtn;
        private ToolBarButton StructureDeleteBtn;
        private ToolBarButton StructurePropertiesBtn;
        private ToolBar TimelineToolbar;
        private ToolBarButton TimelineNewBtn;
        private ToolBarButton TimelineDeleteBtn;
        private ToolBarButton TimelinePropertiesBtn;
        private ListView StructureList;
        private ListView TimelineList;
        private ToolBarButton ElementViewBtn;
        private ToolBarButton StructureViewBtn;
        private ToolBarButton TimelineViewBtn;
        private MenuItem EditMenu;
        private MenuItem EditElements;
        private MenuItem EditStructures;
        private MenuItem EditTimelines;
        private MenuItem EditElementsNew;
        private MenuItem EditElementsDelete;
        private MenuItem EditElementsProperties;
        private MenuItem EditElementsView;
        private MenuItem EditStructuresNew;
        private MenuItem EditStructuresDelete;
        private MenuItem EditStructuresProperties;
        private MenuItem EditStructuresView;
        private MenuItem EditTimelinesNew;
        private MenuItem EditTimelinesDelete;
        private MenuItem EditTimelinesProperties;
        private MenuItem EditTimelinesView;
        private ToolBarButton MainSaveBtn;
        private ContextMenu ElementContextMenu;
        private ContextMenu StructureContextMenu;
        private ContextMenu TimelineContextMenu;
        private MenuItem ElementNew;
        private MenuItem ElementDelete;
        private MenuItem ElementProperties;
        private MenuItem ElementView;
        private MenuItem StructureNew;
        private MenuItem StructureDelete;
        private MenuItem StructureProperties;
        private MenuItem StructureView;
        private MenuItem TimelineNew;
        private MenuItem TimelineDelete;
        private MenuItem TimelineProperties;
        private MenuItem TimelineView;
        private ListView ElementList;
        private ColumnHeader ElementNameHdr;
        private MenuItem EditProjectProperties;
        private ToolBarButton Sep2;
        private ToolBarButton MainPropertiesBtn;
        private MenuItem ViewToolbar;
        private MenuItem ViewStatusbar;
        private ToolBarButton MainSearchBtn;
        private MenuItem HelpContents;
        private MenuItem FilePageSetup;
        private MenuItem Sep4;
        private MenuItem ToolsSearch;
        private MenuItem ToolsMenu;
        private MenuItem ToolsAddIns;
        private MenuItem ToolsAddinsNone;
        private IContainer components;
        private MenuItem FileImport;
        private MenuItem Sep5;
        private ToolBarButton MainTasksBtn;
        private MenuItem Sep3;
        private MenuItem ToolsTaskList;
        private MenuItem ToolsAnnotations;
        private ToolBarButton MainAnnotationsBtn;
        private MenuItem ToolsCalendar;
        private ToolBarButton MainCalendarBtn;
        private Crownwood.Magic.Controls.TabPage NotePage;
        private ListView NoteList;
        private ToolBar NoteToolbar;
        private ContextMenu NoteContextMenu;
        private MenuItem EditNotes;
        private MenuItem EditNotesNew;
        private MenuItem EditNotesDelete;
        private MenuItem EditNotesProperties;
        private MenuItem EditNotesView;
        private MenuItem Sep6;
        private ColumnHeader NoteNameHdr;
        private ToolBarButton NoteNewBtn;
        private ToolBarButton NoteDeleteBtn;
        private ToolBarButton NotePropertiesBtn;
        private ToolBarButton NoteViewBtn;
        private MenuItem NoteNew;
        private MenuItem NoteDelete;
        private MenuItem NoteProperties;
        private MenuItem NoteView;

        public Project Project
        {
            get
            {
                return LabyrinthData.Project;
            }
        }

        public string FileName
        {
            get
            {
                return LabyrinthData.FileName;
            }
            set
            {
                LabyrinthData.FileName = value;
            }
        }

        public MainMenu Menubar
        {
            get
            {
                return this.MainMenu;
            }
        }

        public ToolBar Toolbar
        {
            get
            {
                return this.MainToolBar;
            }
        }

        public StatusBar Statusbar
        {
            get
            {
                return this.StatusBar;
            }
        }

        public PageSettings PageSettings
        {
            get
            {
                return LabyrinthData.PageSettings;
            }
        }

        public PrinterSettings PrinterSettings
        {
            get
            {
                return LabyrinthData.PrinterSettings;
            }
        }

        public IPage ActivePage
        {
            get
            {
                if (this.Pages.SelectedTab == null)
                    return (IPage)null;
                return this.Pages.SelectedTab.Control as IPage;
            }
        }

        public IPage[] OpenPages
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
                {
                    if (tabPage.Control is IPage)
                        arrayList.Add((object)tabPage.Control);
                }
                return (IPage[])arrayList.ToArray();
            }
        }

        public IAddIn[] AddIns
        {
            get
            {
                return (IAddIn[])this.fAddInMgr.AddIns.ToArray(typeof(IAddIn));
            }
        }

        public ImageList Glyphs
        {
            get
            {
                return LabyrinthData.ElementImages;
            }
        }

        public void OpenElement(Element e)
        {
            this.view_element(e);
        }

        public void OpenStructure(Structure s)
        {
            this.view_structure(s);
        }

        public void OpenTimeline(Timeline tl)
        {
            this.view_timeline(tl);
        }

        public void OpenNote(Note n)
        {
            this.view_note(n);
        }

        public void OpenSearch()
        {
            this.view_search();
        }

        public void OpenAnnotations()
        {
            this.view_annotations();
        }

        public void OpenTasks()
        {
            this.view_tasks();
        }

        public void OpenCalendar()
        {
            this.view_calendar();
        }

        public void NewProject()
        {
            this.new_project();
            this.ElementPage.Selected = true;
            this.Pages.TabPages.Clear();
            this.update_ui();
        }

        public bool OpenProject(string filename)
        {
            bool flag = this.open_project(filename);
            this.ElementPage.Selected = true;
            this.Pages.TabPages.Clear();
            this.update_ui();
            return flag;
        }

        public bool SaveProject(string filename)
        {
            bool flag = this.save_project(filename);
            this.update_ui();
            return flag;
        }

        public void OpenPage(IPage page)
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                if (tabPage.Control as IPage == page)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            int imageIndex = LabyrinthData.GetImageIndex((object)page);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(page.Title, page as Control, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        public bool ClosePage(IPage page)
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                if (tabPage.Control as IPage == page)
                {
                    this.Pages.TabPages.Remove(tabPage);
                    return true;
                }
            }
            return false;
        }

        public void UpdateUI()
        {
            this.update_ui();
        }

        public int GetImageIndex(object obj)
        {
            return LabyrinthData.GetImageIndex(obj);
        }

        public event EventHandler ProjectCreated;

        public event EventHandler ProjectOpened;

        public event EventHandler ProjectSaved;

        public event EventHandler ProjectClosing;

        public event ElementEventHandler ElementAdded;

        public event ElementEventHandler ElementModified;

        public event ElementEventHandler ElementDeleted;

        public event StructureEventHandler StructureAdded;

        public event StructureEventHandler StructureModified;

        public event StructureEventHandler StructureDeleted;

        public event TimelineEventHandler TimelineAdded;

        public event TimelineEventHandler TimelineModified;

        public event TimelineEventHandler TimelineDeleted;

        public event NoteEventHandler NoteAdded;

        public event NoteEventHandler NoteModified;

        public event NoteEventHandler NoteDeleted;

        protected void OnProjectCreated(EventArgs e)
        {
            try
            {
                if (this.ProjectCreated == null)
                    return;
                this.ProjectCreated((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnProjectOpened(EventArgs e)
        {
            try
            {
                if (this.ProjectOpened == null)
                    return;
                this.ProjectOpened((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnProjectSaved(EventArgs e)
        {
            try
            {
                if (this.ProjectSaved == null)
                    return;
                this.ProjectSaved((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnProjectClosing(EventArgs e)
        {
            try
            {
                if (this.ProjectClosing == null)
                    return;
                this.ProjectClosing((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnElementAdded(ElementEventArgs e)
        {
            try
            {
                if (this.ElementAdded == null)
                    return;
                this.ElementAdded((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnElementModified(ElementEventArgs e)
        {
            try
            {
                if (this.ElementModified == null)
                    return;
                this.ElementModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnElementDeleted(ElementEventArgs e)
        {
            try
            {
                if (this.ElementDeleted == null)
                    return;
                this.ElementDeleted((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnStructureAdded(StructureEventArgs e)
        {
            try
            {
                if (this.StructureAdded == null)
                    return;
                this.StructureAdded((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnStructureModified(StructureEventArgs e)
        {
            try
            {
                if (this.StructureModified == null)
                    return;
                this.StructureModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnStructureDeleted(StructureEventArgs e)
        {
            try
            {
                if (this.StructureDeleted == null)
                    return;
                this.StructureDeleted((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnTimelineAdded(TimelineEventArgs e)
        {
            try
            {
                if (this.TimelineAdded == null)
                    return;
                this.TimelineAdded((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnTimelineModified(TimelineEventArgs e)
        {
            try
            {
                if (this.TimelineModified == null)
                    return;
                this.TimelineModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnTimelineDeleted(TimelineEventArgs e)
        {
            try
            {
                if (this.TimelineDeleted == null)
                    return;
                this.TimelineDeleted((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnNoteAdded(NoteEventArgs e)
        {
            try
            {
                if (this.NoteAdded == null)
                    return;
                this.NoteAdded((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnNoteModified(NoteEventArgs e)
        {
            try
            {
                if (this.NoteModified == null)
                    return;
                this.NoteModified((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected void OnNoteDeleted(NoteEventArgs e)
        {
            try
            {
                if (this.NoteDeleted == null)
                    return;
                this.NoteDeleted((object)this, e);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        public MainForm(StartupData sd)
        {
            this.InitializeComponent();
            this.ElementList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.StructureList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.TimelineList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.NoteList.ListViewItemSorter = (IComparer)new ListViewSorter();
            this.ElementList.SmallImageList = (ImageList)null;
            this.ElementList.SmallImageList = this.ElementImages;
            this.Pages.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
            this.ElementPage.Selected = true;
            Application.Idle += new EventHandler(this.OnIdle);
            try
            {
                this.fAddInMgr.Load(Application.StartupPath + "\\AddIns", (IApplication)this);
                if (sd.AddInPath != "")
                    this.fAddInMgr.Load(sd.AddInPath, (IApplication)this);
                this.load_addins();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
            try
            {
                if (sd.FileName != "")
                    this.open_project(sd.FileName);
                else
                    this.new_project();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
            this.update_ui();
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            if (this.ask_for_save())
            {
                this.OnProjectClosing(new EventArgs());
                foreach (IAddIn addIn in this.fAddInMgr.AddIns)
                {
                    try
                    {
                        addIn.Unload();
                    }
                    catch (Exception ex)
                    {
                        LabyrinthData.Log((object)ex);
                    }
                }
            }
            else
                e.Cancel = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void load_addins()
        {
            foreach (IAddIn addIn in this.fAddInMgr.AddIns)
            {
                foreach (IAddInComponent component in addIn.Components)
                {
                    IExplorerPage explorerPage = component as IExplorerPage;
                    if (explorerPage != null)
                        this.Explorer.TabPages.Add(new Crownwood.Magic.Controls.TabPage(explorerPage.Name, explorerPage.Control, explorerPage.Icon));
                    ICustomSearch customSearch = component as ICustomSearch;
                    if (customSearch != null)
                        this.fCustomSearches.Add((object)customSearch);
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            ResourceManager resourceManager = new ResourceManager(typeof(MainForm));
            this.MainMenu = new MainMenu();
            this.FileMenu = new MenuItem();
            this.FileNew = new MenuItem();
            this.FileOpen = new MenuItem();
            this.FileSave = new MenuItem();
            this.FileSaveAs = new MenuItem();
            this.Sep1 = new MenuItem();
            this.FileImport = new MenuItem();
            this.Sep4 = new MenuItem();
            this.FilePageSetup = new MenuItem();
            this.Sep5 = new MenuItem();
            this.FileExit = new MenuItem();
            this.EditMenu = new MenuItem();
            this.EditElements = new MenuItem();
            this.EditElementsNew = new MenuItem();
            this.EditElementsDelete = new MenuItem();
            this.EditElementsProperties = new MenuItem();
            this.EditElementsView = new MenuItem();
            this.EditStructures = new MenuItem();
            this.EditStructuresNew = new MenuItem();
            this.EditStructuresDelete = new MenuItem();
            this.EditStructuresProperties = new MenuItem();
            this.EditStructuresView = new MenuItem();
            this.EditTimelines = new MenuItem();
            this.EditTimelinesNew = new MenuItem();
            this.EditTimelinesDelete = new MenuItem();
            this.EditTimelinesProperties = new MenuItem();
            this.EditTimelinesView = new MenuItem();
            this.EditNotes = new MenuItem();
            this.EditNotesNew = new MenuItem();
            this.EditNotesDelete = new MenuItem();
            this.EditNotesProperties = new MenuItem();
            this.EditNotesView = new MenuItem();
            this.Sep6 = new MenuItem();
            this.EditProjectProperties = new MenuItem();
            this.ViewMenu = new MenuItem();
            this.ViewExplorer = new MenuItem();
            this.ViewToolbar = new MenuItem();
            this.ViewStatusbar = new MenuItem();
            this.ViewPageTabs = new MenuItem();
            this.ToolsMenu = new MenuItem();
            this.ToolsSearch = new MenuItem();
            this.ToolsTaskList = new MenuItem();
            this.ToolsAnnotations = new MenuItem();
            this.ToolsCalendar = new MenuItem();
            this.Sep3 = new MenuItem();
            this.ToolsAddIns = new MenuItem();
            this.ToolsAddinsNone = new MenuItem();
            this.ToolsMergeElements = new MenuItem();
            this.WindowMenu = new MenuItem();
            this.WindowClose = new MenuItem();
            this.WindowCloseAll = new MenuItem();
            this.WindowCloseAllExcept = new MenuItem();
            this.Sep7 = new MenuItem();
            this.WindowPages = new MenuItem();
            this.HelpMenu = new MenuItem();
            this.HelpContents = new MenuItem();
            this.HelpAbout = new MenuItem();
            this.StatusBar = new StatusBar();
            this.NameStatusPanel = new StatusBarPanel();
            this.ElementStatusPanel = new StatusBarPanel();
            this.StructureStatusPanel = new StatusBarPanel();
            this.TimelineStatusPanel = new StatusBarPanel();
            this.NoteStatusPanel = new StatusBarPanel();
            this.MainToolBar = new ToolBar();
            this.MainNewBtn = new ToolBarButton();
            this.MainOpenBtn = new ToolBarButton();
            this.MainSaveBtn = new ToolBarButton();
            this.Sep2 = new ToolBarButton();
            this.MainPropertiesBtn = new ToolBarButton();
            this.MainTasksBtn = new ToolBarButton();
            this.MainAnnotationsBtn = new ToolBarButton();
            this.MainCalendarBtn = new ToolBarButton();
            this.MainSearchBtn = new ToolBarButton();
            this.Images = new ImageList(this.components);
            this.Explorer = new Crownwood.Magic.Controls.TabControl();
            this.ElementImages = new ImageList(this.components);
            this.ElementPage = new Crownwood.Magic.Controls.TabPage();
            this.ElementList = new ListView();
            this.ElementNameHdr = new ColumnHeader();
            this.ElementContextMenu = new ContextMenu();
            this.ElementNew = new MenuItem();
            this.ElementDelete = new MenuItem();
            this.ElementProperties = new MenuItem();
            this.ElementView = new MenuItem();
            this.ElementToolbar = new ToolBar();
            this.ElementNewBtn = new ToolBarButton();
            this.ElementDeleteBtn = new ToolBarButton();
            this.ElementPropertiesBtn = new ToolBarButton();
            this.ElementViewBtn = new ToolBarButton();
            this.StructurePage = new Crownwood.Magic.Controls.TabPage();
            this.StructureList = new ListView();
            this.StructureNameHdr = new ColumnHeader();
            this.StructureContextMenu = new ContextMenu();
            this.StructureNew = new MenuItem();
            this.StructureDelete = new MenuItem();
            this.StructureProperties = new MenuItem();
            this.StructureView = new MenuItem();
            this.StructureToolbar = new ToolBar();
            this.StructureNewBtn = new ToolBarButton();
            this.StructureDeleteBtn = new ToolBarButton();
            this.StructurePropertiesBtn = new ToolBarButton();
            this.StructureViewBtn = new ToolBarButton();
            this.TimelinePage = new Crownwood.Magic.Controls.TabPage();
            this.TimelineList = new ListView();
            this.TimelineNameHdr = new ColumnHeader();
            this.TimelineContextMenu = new ContextMenu();
            this.TimelineNew = new MenuItem();
            this.TimelineDelete = new MenuItem();
            this.TimelineProperties = new MenuItem();
            this.TimelineView = new MenuItem();
            this.TimelineToolbar = new ToolBar();
            this.TimelineNewBtn = new ToolBarButton();
            this.TimelineDeleteBtn = new ToolBarButton();
            this.TimelinePropertiesBtn = new ToolBarButton();
            this.TimelineViewBtn = new ToolBarButton();
            this.NotePage = new Crownwood.Magic.Controls.TabPage();
            this.NoteList = new ListView();
            this.NoteNameHdr = new ColumnHeader();
            this.NoteContextMenu = new ContextMenu();
            this.NoteNew = new MenuItem();
            this.NoteDelete = new MenuItem();
            this.NoteProperties = new MenuItem();
            this.NoteView = new MenuItem();
            this.NoteToolbar = new ToolBar();
            this.NoteNewBtn = new ToolBarButton();
            this.NoteDeleteBtn = new ToolBarButton();
            this.NotePropertiesBtn = new ToolBarButton();
            this.NoteViewBtn = new ToolBarButton();
            this.ExplorerSplitter = new Splitter();
            this.Pages = new Crownwood.Magic.Controls.TabControl();
            this.Sep8 = new MenuItem();
            this.NameStatusPanel.BeginInit();
            this.ElementStatusPanel.BeginInit();
            this.StructureStatusPanel.BeginInit();
            this.TimelineStatusPanel.BeginInit();
            this.NoteStatusPanel.BeginInit();
            this.ElementPage.SuspendLayout();
            this.StructurePage.SuspendLayout();
            this.TimelinePage.SuspendLayout();
            this.NotePage.SuspendLayout();
            this.SuspendLayout();
            this.MainMenu.MenuItems.AddRange(new MenuItem[6]
            {
        this.FileMenu,
        this.EditMenu,
        this.ViewMenu,
        this.ToolsMenu,
        this.WindowMenu,
        this.HelpMenu
            });
            this.FileMenu.Index = 0;
            this.FileMenu.MenuItems.AddRange(new MenuItem[10]
            {
        this.FileNew,
        this.FileOpen,
        this.FileSave,
        this.FileSaveAs,
        this.Sep1,
        this.FileImport,
        this.Sep4,
        this.FilePageSetup,
        this.Sep5,
        this.FileExit
            });
            this.FileMenu.Text = "File";
            this.FileNew.Index = 0;
            this.FileNew.Shortcut = Shortcut.CtrlN;
            this.FileNew.Text = "New";
            this.FileNew.Click += new EventHandler(this.FileNew_Click);
            this.FileOpen.Index = 1;
            this.FileOpen.Shortcut = Shortcut.CtrlO;
            this.FileOpen.Text = "Open...";
            this.FileOpen.Click += new EventHandler(this.FileOpen_Click);
            this.FileSave.Index = 2;
            this.FileSave.Shortcut = Shortcut.CtrlS;
            this.FileSave.Text = "Save";
            this.FileSave.Click += new EventHandler(this.FileSave_Click);
            this.FileSaveAs.Index = 3;
            this.FileSaveAs.Text = "Save As...";
            this.FileSaveAs.Click += new EventHandler(this.FileSaveAs_Click);
            this.Sep1.Index = 4;
            this.Sep1.Text = "-";
            this.FileImport.Index = 5;
            this.FileImport.Text = "Import...";
            this.FileImport.Click += new EventHandler(this.FileImport_Click);
            this.Sep4.Index = 6;
            this.Sep4.Text = "-";
            this.FilePageSetup.Index = 7;
            this.FilePageSetup.Text = "Page Setup";
            this.FilePageSetup.Click += new EventHandler(this.FilePageSetup_Click);
            this.Sep5.Index = 8;
            this.Sep5.Text = "-";
            this.FileExit.Index = 9;
            this.FileExit.Text = "Exit";
            this.FileExit.Click += new EventHandler(this.FileExit_Click);
            this.EditMenu.Index = 1;
            this.EditMenu.MenuItems.AddRange(new MenuItem[6]
            {
        this.EditElements,
        this.EditStructures,
        this.EditTimelines,
        this.EditNotes,
        this.Sep6,
        this.EditProjectProperties
            });
            this.EditMenu.Text = "Edit";
            this.EditElements.Index = 0;
            this.EditElements.MenuItems.AddRange(new MenuItem[4]
            {
        this.EditElementsNew,
        this.EditElementsDelete,
        this.EditElementsProperties,
        this.EditElementsView
            });
            this.EditElements.Text = "Elements";
            this.EditElementsNew.Index = 0;
            this.EditElementsNew.Text = "New...";
            this.EditElementsNew.Click += new EventHandler(this.EditElementsNew_Click);
            this.EditElementsDelete.Index = 1;
            this.EditElementsDelete.Text = "Delete";
            this.EditElementsDelete.Click += new EventHandler(this.EditElementsDelete_Click);
            this.EditElementsProperties.Index = 2;
            this.EditElementsProperties.Text = "Properties";
            this.EditElementsProperties.Click += new EventHandler(this.EditElementsProperties_Click);
            this.EditElementsView.Index = 3;
            this.EditElementsView.Text = "Open";
            this.EditElementsView.Click += new EventHandler(this.EditElementsView_Click);
            this.EditStructures.Index = 1;
            this.EditStructures.MenuItems.AddRange(new MenuItem[4]
            {
        this.EditStructuresNew,
        this.EditStructuresDelete,
        this.EditStructuresProperties,
        this.EditStructuresView
            });
            this.EditStructures.Text = "Structures";
            this.EditStructuresNew.Index = 0;
            this.EditStructuresNew.Text = "New...";
            this.EditStructuresNew.Click += new EventHandler(this.EditStructuresNew_Click);
            this.EditStructuresDelete.Index = 1;
            this.EditStructuresDelete.Text = "Delete";
            this.EditStructuresDelete.Click += new EventHandler(this.EditStructuresDelete_Click);
            this.EditStructuresProperties.Index = 2;
            this.EditStructuresProperties.Text = "Properties";
            this.EditStructuresProperties.Click += new EventHandler(this.EditStructuresProperties_Click);
            this.EditStructuresView.Index = 3;
            this.EditStructuresView.Text = "Open";
            this.EditStructuresView.Click += new EventHandler(this.EditStructuresView_Click);
            this.EditTimelines.Index = 2;
            this.EditTimelines.MenuItems.AddRange(new MenuItem[4]
            {
        this.EditTimelinesNew,
        this.EditTimelinesDelete,
        this.EditTimelinesProperties,
        this.EditTimelinesView
            });
            this.EditTimelines.Text = "Timelines";
            this.EditTimelinesNew.Index = 0;
            this.EditTimelinesNew.Text = "New...";
            this.EditTimelinesNew.Click += new EventHandler(this.EditTimelinesNew_Click);
            this.EditTimelinesDelete.Index = 1;
            this.EditTimelinesDelete.Text = "Delete";
            this.EditTimelinesDelete.Click += new EventHandler(this.EditTimelinesDelete_Click);
            this.EditTimelinesProperties.Index = 2;
            this.EditTimelinesProperties.Text = "Properties";
            this.EditTimelinesProperties.Click += new EventHandler(this.EditTimelinesProperties_Click);
            this.EditTimelinesView.Index = 3;
            this.EditTimelinesView.Text = "Open";
            this.EditTimelinesView.Click += new EventHandler(this.EditTimelinesView_Click);
            this.EditNotes.Index = 3;
            this.EditNotes.MenuItems.AddRange(new MenuItem[4]
            {
        this.EditNotesNew,
        this.EditNotesDelete,
        this.EditNotesProperties,
        this.EditNotesView
            });
            this.EditNotes.Text = "Notes";
            this.EditNotesNew.Index = 0;
            this.EditNotesNew.Text = "New...";
            this.EditNotesNew.Click += new EventHandler(this.EditNotesNew_Click);
            this.EditNotesDelete.Index = 1;
            this.EditNotesDelete.Text = "Delete";
            this.EditNotesDelete.Click += new EventHandler(this.EditNotesDelete_Click);
            this.EditNotesProperties.Index = 2;
            this.EditNotesProperties.Text = "Properties";
            this.EditNotesProperties.Click += new EventHandler(this.EditNotesProperties_Click);
            this.EditNotesView.Index = 3;
            this.EditNotesView.Text = "Open";
            this.EditNotesView.Click += new EventHandler(this.EditNotesView_Click);
            this.Sep6.Index = 4;
            this.Sep6.Text = "-";
            this.EditProjectProperties.Index = 5;
            this.EditProjectProperties.Text = "Project Properties";
            this.EditProjectProperties.Click += new EventHandler(this.EditProjectProperties_Click);
            this.ViewMenu.Index = 2;
            this.ViewMenu.MenuItems.AddRange(new MenuItem[4]
            {
        this.ViewExplorer,
        this.ViewToolbar,
        this.ViewStatusbar,
        this.ViewPageTabs
            });
            this.ViewMenu.Text = "View";
            this.ViewExplorer.Index = 0;
            this.ViewExplorer.Text = "Explorer";
            this.ViewExplorer.Click += new EventHandler(this.ViewExplorer_Click);
            this.ViewToolbar.Index = 1;
            this.ViewToolbar.Text = "Toolbar";
            this.ViewToolbar.Click += new EventHandler(this.ViewToolbar_Click);
            this.ViewStatusbar.Index = 2;
            this.ViewStatusbar.Text = "Statusbar";
            this.ViewStatusbar.Click += new EventHandler(this.ViewStatusbar_Click);
            this.ViewPageTabs.Index = 3;
            this.ViewPageTabs.Text = "Page Tabs";
            this.ViewPageTabs.Click += new EventHandler(this.ViewPageTabs_Click);
            this.ToolsMenu.Index = 3;
            this.ToolsMenu.MenuItems.AddRange(new MenuItem[8]
            {
        this.ToolsSearch,
        this.ToolsTaskList,
        this.ToolsAnnotations,
        this.ToolsCalendar,
        this.Sep3,
        this.ToolsMergeElements,
        this.Sep8,
        this.ToolsAddIns
            });
            this.ToolsMenu.Text = "Tools";
            this.ToolsSearch.Index = 0;
            this.ToolsSearch.Shortcut = Shortcut.F3;
            this.ToolsSearch.Text = "Search";
            this.ToolsSearch.Click += new EventHandler(this.ToolsSearch_Click);
            this.ToolsTaskList.Index = 1;
            this.ToolsTaskList.Text = "Task List";
            this.ToolsTaskList.Click += new EventHandler(this.ToolsTaskList_Click);
            this.ToolsAnnotations.Index = 2;
            this.ToolsAnnotations.Text = "Annotations";
            this.ToolsAnnotations.Click += new EventHandler(this.ToolsAnnotations_Click);
            this.ToolsCalendar.Index = 3;
            this.ToolsCalendar.Text = "Calendar";
            this.ToolsCalendar.Click += new EventHandler(this.ToolsCalendar_Click);
            this.Sep3.Index = 4;
            this.Sep3.Text = "-";
            this.ToolsAddIns.Index = 7;
            this.ToolsAddIns.MenuItems.AddRange(new MenuItem[1]
            {
        this.ToolsAddinsNone
            });
            this.ToolsAddIns.Text = "Add-Ins";
            this.ToolsAddIns.Popup += new EventHandler(this.ToolsAddIns_Popup);
            this.ToolsAddinsNone.Enabled = false;
            this.ToolsAddinsNone.Index = 0;
            this.ToolsAddinsNone.Text = "None";
            this.ToolsMergeElements.Index = 5;
            this.ToolsMergeElements.Text = "Merge Elements...";
            this.ToolsMergeElements.Click += new EventHandler(this.ToolsMergeElements_Click);
            this.WindowMenu.Index = 4;
            this.WindowMenu.MenuItems.AddRange(new MenuItem[5]
            {
        this.WindowClose,
        this.WindowCloseAll,
        this.WindowCloseAllExcept,
        this.Sep7,
        this.WindowPages
            });
            this.WindowMenu.Text = "Window";
            this.WindowMenu.Popup += new EventHandler(this.WindowMenu_Popup);
            this.WindowClose.Index = 0;
            this.WindowClose.Text = "&Close";
            this.WindowClose.Click += new EventHandler(this.WindowClose_Click);
            this.WindowCloseAll.Index = 1;
            this.WindowCloseAll.Text = "Close &All";
            this.WindowCloseAll.Click += new EventHandler(this.WindowCloseAll_Click);
            this.WindowCloseAllExcept.Index = 2;
            this.WindowCloseAllExcept.Text = "Close All E&xcept";
            this.WindowCloseAllExcept.Click += new EventHandler(this.WindowCloseAllExcept_Click);
            this.Sep7.Index = 3;
            this.Sep7.Text = "-";
            this.WindowPages.Index = 4;
            this.WindowPages.Text = "Pages";
            this.HelpMenu.Index = 5;
            this.HelpMenu.MenuItems.AddRange(new MenuItem[2]
            {
        this.HelpContents,
        this.HelpAbout
            });
            this.HelpMenu.Text = "Help";
            this.HelpContents.Index = 0;
            this.HelpContents.Shortcut = Shortcut.F1;
            this.HelpContents.Text = "Contents";
            this.HelpContents.Click += new EventHandler(this.HelpContents_Click);
            this.HelpAbout.Index = 1;
            this.HelpAbout.Text = "About";
            this.HelpAbout.Click += new EventHandler(this.HelpAbout_Click);
            this.StatusBar.Location = new Point(0, 379);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Panels.AddRange(new StatusBarPanel[5]
            {
        this.NameStatusPanel,
        this.ElementStatusPanel,
        this.StructureStatusPanel,
        this.TimelineStatusPanel,
        this.NoteStatusPanel
            });
            this.StatusBar.ShowPanels = true;
            this.StatusBar.Size = new Size(712, 22);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.PanelClick += new StatusBarPanelClickEventHandler(this.StatusBar_PanelClick);
            this.NameStatusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            this.NameStatusPanel.Text = "Project: X";
            this.NameStatusPanel.Width = 407;
            this.ElementStatusPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            this.ElementStatusPanel.Text = "Elements: X";
            this.ElementStatusPanel.Width = 75;
            this.StructureStatusPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            this.StructureStatusPanel.Text = "Structures: X";
            this.StructureStatusPanel.Width = 80;
            this.TimelineStatusPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            this.TimelineStatusPanel.Text = "Timelines: X";
            this.TimelineStatusPanel.Width = 77;
            this.NoteStatusPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            this.NoteStatusPanel.Text = "Notes: X";
            this.NoteStatusPanel.Width = 57;
            this.MainToolBar.Appearance = ToolBarAppearance.Flat;
            this.MainToolBar.Buttons.AddRange(new ToolBarButton[9]
            {
        this.MainNewBtn,
        this.MainOpenBtn,
        this.MainSaveBtn,
        this.Sep2,
        this.MainPropertiesBtn,
        this.MainTasksBtn,
        this.MainAnnotationsBtn,
        this.MainCalendarBtn,
        this.MainSearchBtn
            });
            this.MainToolBar.DropDownArrows = true;
            this.MainToolBar.ImageList = this.Images;
            this.MainToolBar.Name = "MainToolBar";
            this.MainToolBar.ShowToolTips = true;
            this.MainToolBar.Size = new Size(712, 25);
            this.MainToolBar.TabIndex = 0;
            this.MainToolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.MainToolBar_ButtonClick);
            this.MainNewBtn.ImageIndex = 0;
            this.MainNewBtn.ToolTipText = "New";
            this.MainOpenBtn.ImageIndex = 1;
            this.MainOpenBtn.ToolTipText = "Open";
            this.MainSaveBtn.ImageIndex = 2;
            this.MainSaveBtn.ToolTipText = "Save";
            this.Sep2.Style = ToolBarButtonStyle.Separator;
            this.MainPropertiesBtn.ImageIndex = 5;
            this.MainPropertiesBtn.ToolTipText = "Project Properties";
            this.MainTasksBtn.ImageIndex = 15;
            this.MainTasksBtn.ToolTipText = "Task List";
            this.MainAnnotationsBtn.ImageIndex = 16;
            this.MainAnnotationsBtn.ToolTipText = "Annotations List";
            this.MainCalendarBtn.ImageIndex = 17;
            this.MainCalendarBtn.ToolTipText = "Calendar";
            this.MainSearchBtn.ImageIndex = 6;
            this.MainSearchBtn.ToolTipText = "Search";
            this.Images.ColorDepth = ColorDepth.Depth8Bit;
            this.Images.ImageSize = new Size(16, 16);
            this.Images.ImageStream = (ImageListStreamer)resourceManager.GetObject("Images.ImageStream");
            this.Images.TransparentColor = Color.Magenta;
            this.Explorer.Dock = DockStyle.Left;
            this.Explorer.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.Explorer.ImageList = this.ElementImages;
            this.Explorer.Location = new Point(0, 25);
            this.Explorer.Name = "Explorer";
            this.Explorer.SelectedIndex = 0;
            this.Explorer.SelectedTab = this.ElementPage;
            this.Explorer.SelectedTextOnly = true;
            this.Explorer.ShowArrows = true;
            this.Explorer.ShrinkPagesToFit = false;
            this.Explorer.Size = new Size(208, 354);
            this.Explorer.TabIndex = 2;
            this.Explorer.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[4]
            {
        this.ElementPage,
        this.StructurePage,
        this.TimelinePage,
        this.NotePage
            });
            this.ElementImages.ColorDepth = ColorDepth.Depth8Bit;
            this.ElementImages.ImageSize = new Size(16, 16);
            this.ElementImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ElementImages.ImageStream");
            this.ElementImages.TransparentColor = Color.Magenta;
            this.ElementPage.Controls.AddRange(new Control[2]
            {
        (Control) this.ElementList,
        (Control) this.ElementToolbar
            });
            this.ElementPage.ImageIndex = 1;
            this.ElementPage.Name = "ElementPage";
            this.ElementPage.Size = new Size(208, 329);
            this.ElementPage.TabIndex = 0;
            this.ElementPage.Title = "Elements";
            this.ElementList.Columns.AddRange(new ColumnHeader[1]
            {
        this.ElementNameHdr
            });
            this.ElementList.ContextMenu = this.ElementContextMenu;
            this.ElementList.Dock = DockStyle.Fill;
            this.ElementList.FullRowSelect = true;
            this.ElementList.LargeImageList = this.ElementImages;
            this.ElementList.Location = new Point(0, 25);
            this.ElementList.Name = "ElementList";
            this.ElementList.Size = new Size(208, 304);
            this.ElementList.SmallImageList = this.ElementImages;
            this.ElementList.Sorting = SortOrder.Ascending;
            this.ElementList.TabIndex = 1;
            this.ElementList.View = View.Details;
            this.ElementList.MouseDown += new MouseEventHandler(this.ElementList_MouseDown);
            this.ElementList.DoubleClick += new EventHandler(this.ElementList_DoubleClick);
            this.ElementList.ColumnClick += new ColumnClickEventHandler(this.ElementList_ColumnClick);
            this.ElementList.ItemDrag += new ItemDragEventHandler(this.ElementList_ItemDrag);
            this.ElementNameHdr.Text = "Name";
            this.ElementNameHdr.Width = 120;
            this.ElementContextMenu.MenuItems.AddRange(new MenuItem[4]
            {
        this.ElementNew,
        this.ElementDelete,
        this.ElementProperties,
        this.ElementView
            });
            this.ElementNew.Index = 0;
            this.ElementNew.Shortcut = Shortcut.F2;
            this.ElementNew.Text = "New Element...";
            this.ElementNew.Click += new EventHandler(this.EditElementsNew_Click);
            this.ElementDelete.Index = 1;
            this.ElementDelete.Text = "Delete Element";
            this.ElementDelete.Click += new EventHandler(this.EditElementsDelete_Click);
            this.ElementProperties.Index = 2;
            this.ElementProperties.Shortcut = Shortcut.F4;
            this.ElementProperties.Text = "Element Properties";
            this.ElementProperties.Click += new EventHandler(this.EditElementsProperties_Click);
            this.ElementView.Index = 3;
            this.ElementView.Shortcut = Shortcut.F10;
            this.ElementView.Text = "Open Element";
            this.ElementView.Click += new EventHandler(this.EditElementsView_Click);
            this.ElementToolbar.Appearance = ToolBarAppearance.Flat;
            this.ElementToolbar.Buttons.AddRange(new ToolBarButton[4]
            {
        this.ElementNewBtn,
        this.ElementDeleteBtn,
        this.ElementPropertiesBtn,
        this.ElementViewBtn
            });
            this.ElementToolbar.DropDownArrows = true;
            this.ElementToolbar.ImageList = this.Images;
            this.ElementToolbar.Name = "ElementToolbar";
            this.ElementToolbar.ShowToolTips = true;
            this.ElementToolbar.Size = new Size(208, 25);
            this.ElementToolbar.TabIndex = 0;
            this.ElementToolbar.ButtonClick += new ToolBarButtonClickEventHandler(this.ElementToolbar_ButtonClick);
            this.ElementNewBtn.ImageIndex = 7;
            this.ElementNewBtn.ToolTipText = "New";
            this.ElementDeleteBtn.ImageIndex = 4;
            this.ElementDeleteBtn.ToolTipText = "Delete";
            this.ElementPropertiesBtn.ImageIndex = 5;
            this.ElementPropertiesBtn.ToolTipText = "Properties";
            this.ElementViewBtn.ImageIndex = 11;
            this.ElementViewBtn.ToolTipText = "View";
            this.StructurePage.Controls.AddRange(new Control[2]
            {
        (Control) this.StructureList,
        (Control) this.StructureToolbar
            });
            this.StructurePage.ImageIndex = 18;
            this.StructurePage.Name = "StructurePage";
            this.StructurePage.Selected = false;
            this.StructurePage.Size = new Size(208, 329);
            this.StructurePage.TabIndex = 1;
            this.StructurePage.Title = "Structures";
            this.StructureList.Columns.AddRange(new ColumnHeader[1]
            {
        this.StructureNameHdr
            });
            this.StructureList.ContextMenu = this.StructureContextMenu;
            this.StructureList.Dock = DockStyle.Fill;
            this.StructureList.FullRowSelect = true;
            this.StructureList.Location = new Point(0, 39);
            this.StructureList.Name = "StructureList";
            this.StructureList.Size = new Size(208, 290);
            this.StructureList.SmallImageList = this.ElementImages;
            this.StructureList.Sorting = SortOrder.Ascending;
            this.StructureList.TabIndex = 2;
            this.StructureList.View = View.Details;
            this.StructureList.MouseDown += new MouseEventHandler(this.StructureList_MouseDown);
            this.StructureList.DoubleClick += new EventHandler(this.StructureList_DoubleClick);
            this.StructureList.ColumnClick += new ColumnClickEventHandler(this.StructureList_ColumnClick);
            this.StructureList.ItemDrag += new ItemDragEventHandler(this.StructureList_ItemDrag);
            this.StructureNameHdr.Text = "Name";
            this.StructureNameHdr.Width = 120;
            this.StructureContextMenu.MenuItems.AddRange(new MenuItem[4]
            {
        this.StructureNew,
        this.StructureDelete,
        this.StructureProperties,
        this.StructureView
            });
            this.StructureNew.Index = 0;
            this.StructureNew.Shortcut = Shortcut.F2;
            this.StructureNew.Text = "New Structure...";
            this.StructureNew.Click += new EventHandler(this.EditStructuresNew_Click);
            this.StructureDelete.Index = 1;
            this.StructureDelete.Text = "Delete Structure";
            this.StructureDelete.Click += new EventHandler(this.EditStructuresDelete_Click);
            this.StructureProperties.Index = 2;
            this.StructureProperties.Shortcut = Shortcut.F4;
            this.StructureProperties.Text = "Structure Properties";
            this.StructureProperties.Click += new EventHandler(this.EditStructuresProperties_Click);
            this.StructureView.Index = 3;
            this.StructureView.Shortcut = Shortcut.F10;
            this.StructureView.Text = "Open Structure";
            this.StructureView.Click += new EventHandler(this.EditStructuresView_Click);
            this.StructureToolbar.Appearance = ToolBarAppearance.Flat;
            this.StructureToolbar.Buttons.AddRange(new ToolBarButton[4]
            {
        this.StructureNewBtn,
        this.StructureDeleteBtn,
        this.StructurePropertiesBtn,
        this.StructureViewBtn
            });
            this.StructureToolbar.DropDownArrows = true;
            this.StructureToolbar.ImageList = this.Images;
            this.StructureToolbar.Name = "StructureToolbar";
            this.StructureToolbar.ShowToolTips = true;
            this.StructureToolbar.Size = new Size(208, 39);
            this.StructureToolbar.TabIndex = 1;
            this.StructureToolbar.ButtonClick += new ToolBarButtonClickEventHandler(this.StructureToolbar_ButtonClick);
            this.StructureNewBtn.ImageIndex = 8;
            this.StructureNewBtn.ToolTipText = "New";
            this.StructureDeleteBtn.ImageIndex = 4;
            this.StructureDeleteBtn.ToolTipText = "Delete";
            this.StructurePropertiesBtn.ImageIndex = 5;
            this.StructurePropertiesBtn.ToolTipText = "Properties";
            this.StructureViewBtn.ImageIndex = 12;
            this.StructureViewBtn.ToolTipText = "View";
            this.TimelinePage.Controls.AddRange(new Control[2]
            {
        (Control) this.TimelineList,
        (Control) this.TimelineToolbar
            });
            this.TimelinePage.ImageIndex = 19;
            this.TimelinePage.Name = "TimelinePage";
            this.TimelinePage.Selected = false;
            this.TimelinePage.Size = new Size(208, 329);
            this.TimelinePage.TabIndex = 2;
            this.TimelinePage.Title = "Timelines";
            this.TimelineList.Columns.AddRange(new ColumnHeader[1]
            {
        this.TimelineNameHdr
            });
            this.TimelineList.ContextMenu = this.TimelineContextMenu;
            this.TimelineList.Dock = DockStyle.Fill;
            this.TimelineList.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.TimelineList.FullRowSelect = true;
            this.TimelineList.Location = new Point(0, 39);
            this.TimelineList.Name = "TimelineList";
            this.TimelineList.Size = new Size(208, 290);
            this.TimelineList.SmallImageList = this.ElementImages;
            this.TimelineList.Sorting = SortOrder.Ascending;
            this.TimelineList.TabIndex = 2;
            this.TimelineList.View = View.Details;
            this.TimelineList.MouseDown += new MouseEventHandler(this.TimelineList_MouseDown);
            this.TimelineList.DoubleClick += new EventHandler(this.TimelineList_DoubleClick);
            this.TimelineList.ColumnClick += new ColumnClickEventHandler(this.TimelineList_ColumnClick);
            this.TimelineList.ItemDrag += new ItemDragEventHandler(this.TimelineList_ItemDrag);
            this.TimelineNameHdr.Text = "Name";
            this.TimelineNameHdr.Width = 120;
            this.TimelineContextMenu.MenuItems.AddRange(new MenuItem[4]
            {
        this.TimelineNew,
        this.TimelineDelete,
        this.TimelineProperties,
        this.TimelineView
            });
            this.TimelineNew.Index = 0;
            this.TimelineNew.Shortcut = Shortcut.F2;
            this.TimelineNew.Text = "New Timeline...";
            this.TimelineNew.Click += new EventHandler(this.EditTimelinesNew_Click);
            this.TimelineDelete.Index = 1;
            this.TimelineDelete.Text = "Delete Timeline";
            this.TimelineDelete.Click += new EventHandler(this.EditTimelinesDelete_Click);
            this.TimelineProperties.Index = 2;
            this.TimelineProperties.Shortcut = Shortcut.F4;
            this.TimelineProperties.Text = "Timeline Properties";
            this.TimelineProperties.Click += new EventHandler(this.EditTimelinesProperties_Click);
            this.TimelineView.Index = 3;
            this.TimelineView.Shortcut = Shortcut.F10;
            this.TimelineView.Text = "Open Timeline";
            this.TimelineView.Click += new EventHandler(this.EditTimelinesView_Click);
            this.TimelineToolbar.Appearance = ToolBarAppearance.Flat;
            this.TimelineToolbar.Buttons.AddRange(new ToolBarButton[4]
            {
        this.TimelineNewBtn,
        this.TimelineDeleteBtn,
        this.TimelinePropertiesBtn,
        this.TimelineViewBtn
            });
            this.TimelineToolbar.DropDownArrows = true;
            this.TimelineToolbar.ImageList = this.Images;
            this.TimelineToolbar.Name = "TimelineToolbar";
            this.TimelineToolbar.ShowToolTips = true;
            this.TimelineToolbar.Size = new Size(208, 39);
            this.TimelineToolbar.TabIndex = 1;
            this.TimelineToolbar.ButtonClick += new ToolBarButtonClickEventHandler(this.TimelineToolbar_ButtonClick);
            this.TimelineNewBtn.ImageIndex = 9;
            this.TimelineNewBtn.ToolTipText = "New";
            this.TimelineDeleteBtn.ImageIndex = 4;
            this.TimelineDeleteBtn.ToolTipText = "Delete";
            this.TimelinePropertiesBtn.ImageIndex = 5;
            this.TimelinePropertiesBtn.ToolTipText = "Properties";
            this.TimelineViewBtn.ImageIndex = 13;
            this.TimelineViewBtn.ToolTipText = "View";
            this.NotePage.Controls.AddRange(new Control[2]
            {
        (Control) this.NoteList,
        (Control) this.NoteToolbar
            });
            this.NotePage.ImageIndex = 25;
            this.NotePage.Name = "NotePage";
            this.NotePage.Selected = false;
            this.NotePage.Size = new Size(208, 329);
            this.NotePage.TabIndex = 3;
            this.NotePage.Title = "Notes";
            this.NoteList.Columns.AddRange(new ColumnHeader[1]
            {
        this.NoteNameHdr
            });
            this.NoteList.ContextMenu = this.NoteContextMenu;
            this.NoteList.Dock = DockStyle.Fill;
            this.NoteList.FullRowSelect = true;
            this.NoteList.LargeImageList = this.ElementImages;
            this.NoteList.Location = new Point(0, 39);
            this.NoteList.Name = "NoteList";
            this.NoteList.Size = new Size(208, 290);
            this.NoteList.SmallImageList = this.ElementImages;
            this.NoteList.Sorting = SortOrder.Ascending;
            this.NoteList.TabIndex = 3;
            this.NoteList.View = View.Details;
            this.NoteList.MouseDown += new MouseEventHandler(this.NoteList_MouseDown);
            this.NoteList.DoubleClick += new EventHandler(this.NoteList_DoubleClick);
            this.NoteList.ColumnClick += new ColumnClickEventHandler(this.NoteList_ColumnClick);
            this.NoteList.ItemDrag += new ItemDragEventHandler(this.NoteList_ItemDrag);
            this.NoteNameHdr.Text = "Name";
            this.NoteNameHdr.Width = 120;
            this.NoteContextMenu.MenuItems.AddRange(new MenuItem[4]
            {
        this.NoteNew,
        this.NoteDelete,
        this.NoteProperties,
        this.NoteView
            });
            this.NoteNew.Index = 0;
            this.NoteNew.Shortcut = Shortcut.F2;
            this.NoteNew.Text = "New Note...";
            this.NoteNew.Click += new EventHandler(this.EditNotesNew_Click);
            this.NoteDelete.Index = 1;
            this.NoteDelete.Text = "Delete Note";
            this.NoteDelete.Click += new EventHandler(this.EditNotesDelete_Click);
            this.NoteProperties.Index = 2;
            this.NoteProperties.Shortcut = Shortcut.F4;
            this.NoteProperties.Text = "Note Properties";
            this.NoteProperties.Click += new EventHandler(this.EditNotesProperties_Click);
            this.NoteView.Index = 3;
            this.NoteView.Shortcut = Shortcut.F10;
            this.NoteView.Text = "Open Note";
            this.NoteView.Click += new EventHandler(this.EditNotesView_Click);
            this.NoteToolbar.Appearance = ToolBarAppearance.Flat;
            this.NoteToolbar.Buttons.AddRange(new ToolBarButton[4]
            {
        this.NoteNewBtn,
        this.NoteDeleteBtn,
        this.NotePropertiesBtn,
        this.NoteViewBtn
            });
            this.NoteToolbar.DropDownArrows = true;
            this.NoteToolbar.ImageList = this.Images;
            this.NoteToolbar.Name = "NoteToolbar";
            this.NoteToolbar.ShowToolTips = true;
            this.NoteToolbar.Size = new Size(208, 39);
            this.NoteToolbar.TabIndex = 2;
            this.NoteToolbar.ButtonClick += new ToolBarButtonClickEventHandler(this.NoteToolbar_ButtonClick);
            this.NoteNewBtn.ImageIndex = 10;
            this.NoteNewBtn.ToolTipText = "New";
            this.NoteDeleteBtn.ImageIndex = 4;
            this.NoteDeleteBtn.ToolTipText = "Delete";
            this.NotePropertiesBtn.ImageIndex = 5;
            this.NotePropertiesBtn.ToolTipText = "Properties";
            this.NoteViewBtn.ImageIndex = 14;
            this.NoteViewBtn.ToolTipText = "View";
            this.ExplorerSplitter.Location = new Point(208, 25);
            this.ExplorerSplitter.Name = "ExplorerSplitter";
            this.ExplorerSplitter.Size = new Size(3, 354);
            this.ExplorerSplitter.TabIndex = 3;
            this.ExplorerSplitter.TabStop = false;
            this.Pages.Dock = DockStyle.Fill;
            this.Pages.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.Pages.ImageList = this.ElementImages;
            this.Pages.Location = new Point(211, 25);
            this.Pages.Name = "Pages";
            this.Pages.Size = new Size(501, 354);
            this.Pages.TabIndex = 2;
            this.Pages.ClosePressed += new EventHandler(this.Pages_ClosePressed);
            this.Sep8.Index = 6;
            this.Sep8.Text = "-";
            this.AutoScaleBaseSize = new Size(5, 14);
            this.ClientSize = new Size(712, 401);
            this.Controls.AddRange(new Control[5]
            {
        (Control) this.Pages,
        (Control) this.ExplorerSplitter,
        (Control) this.Explorer,
        (Control) this.StatusBar,
        (Control) this.MainToolBar
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World, (byte)0);
            this.Icon = (Icon)resourceManager.GetObject("$this.Icon");
            this.Menu = this.MainMenu;
            this.Name = nameof(MainForm);
            this.Text = "Labyrinth";
            this.Closing += new CancelEventHandler(this.MainForm_Closing);
            this.NameStatusPanel.EndInit();
            this.ElementStatusPanel.EndInit();
            this.StructureStatusPanel.EndInit();
            this.TimelineStatusPanel.EndInit();
            this.NoteStatusPanel.EndInit();
            this.ElementPage.ResumeLayout(false);
            this.StructurePage.ResumeLayout(false);
            this.TimelinePage.ResumeLayout(false);
            this.NotePage.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public Element SelectedElement
        {
            get
            {
                if (this.ElementList.SelectedItems.Count != 0)
                    return this.ElementList.SelectedItems[0].Tag as Element;
                return (Element)null;
            }
        }

        public Structure SelectedStructure
        {
            get
            {
                if (this.StructureList.SelectedItems.Count != 0)
                    return this.StructureList.SelectedItems[0].Tag as Structure;
                return (Structure)null;
            }
        }

        public Timeline SelectedTimeline
        {
            get
            {
                if (this.TimelineList.SelectedItems.Count != 0)
                    return this.TimelineList.SelectedItems[0].Tag as Timeline;
                return (Timeline)null;
            }
        }

        public Note SelectedNote
        {
            get
            {
                if (this.NoteList.SelectedItems.Count != 0)
                    return this.NoteList.SelectedItems[0].Tag as Note;
                return (Note)null;
            }
        }

        private void FileNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ask_for_save())
                    return;
                this.NewProject();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ask_for_save())
                    return;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Plot Files|*.plt|All Files|*.*";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                this.OpenProject(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (LabyrinthData.FileName == "")
                {
                    this.FileSaveAs_Click(sender, e);
                }
                else
                {
                    this.SaveProject(LabyrinthData.FileName);
                    this.update_ui();
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void FileSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                this.save_project_as();
                this.update_ui();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void FileImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Import";
                openFileDialog.Filter = "Plot Files|*.plt|All Files|*.*";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                XmlTextReader xmlTextReader = new XmlTextReader(openFileDialog.FileName);
                Project project = new XmlSerializer(typeof(Project)).Deserialize((XmlReader)xmlTextReader) as Project;
                xmlTextReader.Close();
                LabyrinthData.Project.Elements.AddRange(project.Elements);
                LabyrinthData.Project.Structures.AddRange(project.Structures);
                LabyrinthData.Project.Timelines.AddRange(project.Timelines);
                this.update_ui();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void FilePageSetup_Click(object sender, EventArgs e)
        {
            try
            {
                int num = (int)new PageSetupDialog()
                {
                    PageSettings = LabyrinthData.PageSettings,
                    PrinterSettings = LabyrinthData.PrinterSettings
                }.ShowDialog();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void FileExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ask_for_save())
                    return;
                this.Close();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditElementsNew_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "New Element";
                string name = str;
                int num = 1;
                for (; LabyrinthData.Project.Elements.IndexOf(name) != -1; name = str + " " + (object)num)
                    ++num;
                Element e1 = new Element();
                e1.Name = name;
                if (new ElementDlg(e1).ShowDialog() != DialogResult.OK)
                    return;
                LabyrinthData.Project.Elements.Add(e1);
                this.update_ui();
                this.view_element(e1);
                this.OnElementAdded(new ElementEventArgs(e1));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditElementsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedElement == null)
                    return;
                Element selectedElement = this.SelectedElement;
                if (MessageBox.Show("Delete element '" + selectedElement.Name + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                LabyrinthData.Project.RemoveElement(selectedElement);
                this.update_ui();
                this.OnElementDeleted(new ElementEventArgs(selectedElement));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditElementsProperties_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedElement == null)
                    return;
                Element selectedElement = this.SelectedElement;
                if (new ElementDlg(selectedElement).ShowDialog() != DialogResult.OK)
                    return;
                this.update_ui();
                this.OnElementModified(new ElementEventArgs(selectedElement));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditElementsView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedElement == null)
                    return;
                this.view_element(this.SelectedElement);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditStructuresNew_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "New Structure";
                string name = str;
                int num = 1;
                for (; LabyrinthData.Project.Structures.IndexOf(name) != -1; name = str + " " + (object)num)
                    ++num;
                Structure s = new Structure();
                s.Name = name;
                if (new StructureDlg(s).ShowDialog() != DialogResult.OK)
                    return;
                LabyrinthData.Project.Structures.Add(s);
                this.update_ui();
                this.view_structure(s);
                this.OnStructureAdded(new StructureEventArgs(s));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditStructuresDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedStructure == null)
                    return;
                Structure selectedStructure = this.SelectedStructure;
                if (MessageBox.Show("Delete structure '" + selectedStructure.Name + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                LabyrinthData.Project.Structures.Remove(selectedStructure);
                this.update_ui();
                this.OnStructureDeleted(new StructureEventArgs(selectedStructure));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditStructuresProperties_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedStructure == null)
                    return;
                Structure selectedStructure = this.SelectedStructure;
                if (new StructureDlg(selectedStructure).ShowDialog() != DialogResult.OK)
                    return;
                this.update_ui();
                this.OnStructureModified(new StructureEventArgs(selectedStructure));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditStructuresView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedStructure == null)
                    return;
                this.view_structure(this.SelectedStructure);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditTimelinesNew_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "New Timeline";
                string name = str;
                int num = 1;
                for (; LabyrinthData.Project.Timelines.IndexOf(name) != -1; name = str + " " + (object)num)
                    ++num;
                Timeline tl = new Timeline();
                tl.Name = name;
                if (new TimelineDlg(tl).ShowDialog() != DialogResult.OK)
                    return;
                LabyrinthData.Project.Timelines.Add(tl);
                this.update_ui();
                this.view_timeline(tl);
                this.OnTimelineAdded(new TimelineEventArgs(tl));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditTimelinesDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedTimeline == null)
                    return;
                Timeline selectedTimeline = this.SelectedTimeline;
                if (MessageBox.Show("Delete timeline '" + selectedTimeline.Name + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                LabyrinthData.Project.Timelines.Remove(selectedTimeline);
                this.update_ui();
                this.OnTimelineDeleted(new TimelineEventArgs(selectedTimeline));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditTimelinesProperties_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedTimeline == null)
                    return;
                Timeline selectedTimeline = this.SelectedTimeline;
                if (new TimelineDlg(selectedTimeline).ShowDialog() != DialogResult.OK)
                    return;
                this.update_ui();
                this.OnTimelineModified(new TimelineEventArgs(selectedTimeline));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditTimelinesView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedTimeline == null)
                    return;
                this.view_timeline(this.SelectedTimeline);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditNotesNew_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "New Note";
                string title = str;
                int num = 1;
                for (; LabyrinthData.Project.Notes.IndexOf(title) != -1; title = str + " " + (object)num)
                    ++num;
                Note n = new Note();
                n.Title = title;
                if (new NoteDlg(n).ShowDialog() != DialogResult.OK)
                    return;
                LabyrinthData.Project.Notes.Add(n);
                this.update_ui();
                this.view_note(n);
                this.OnNoteAdded(new NoteEventArgs(n));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditNotesDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedNote == null)
                    return;
                Note selectedNote = this.SelectedNote;
                if (MessageBox.Show("Delete note '" + selectedNote.Title + "': are you sure?", "Labyrinth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                LabyrinthData.Project.Notes.Remove(selectedNote);
                this.update_ui();
                this.OnNoteDeleted(new NoteEventArgs(selectedNote));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditNotesProperties_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedNote == null)
                    return;
                Note selectedNote = this.SelectedNote;
                if (new NoteDlg(selectedNote).ShowDialog() != DialogResult.OK)
                    return;
                this.update_ui();
                this.OnNoteModified(new NoteEventArgs(selectedNote));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditNotesView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedNote == null)
                    return;
                this.view_note(this.SelectedNote);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void EditProjectProperties_Click(object sender, EventArgs e)
        {
            try
            {
                if (new ProjectDlg(LabyrinthData.Project).ShowDialog() != DialogResult.OK)
                    return;
                this.update_ui();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ViewExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = !this.Explorer.Visible;
                this.Explorer.Visible = flag;
                this.ExplorerSplitter.Visible = flag;
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ViewToolbar_Click(object sender, EventArgs e)
        {
            try
            {
                this.MainToolBar.Visible = !this.MainToolBar.Visible;
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ViewStatusbar_Click(object sender, EventArgs e)
        {
            try
            {
                this.StatusBar.Visible = !this.StatusBar.Visible;
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ViewPageTabs_Click(object sender, EventArgs e)
        {
            try
            {
                this.Pages.HideTabsMode = this.Pages.HideTabsMode == Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways ? Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways : Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ToolsSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActivePage is SearchPage)
                    this.Pages_ClosePressed(sender, e);
                else
                    this.view_search();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ToolsTaskList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActivePage is TaskPage)
                    this.Pages_ClosePressed(sender, e);
                else
                    this.view_tasks();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ToolsAnnotations_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActivePage is AnnotationPage)
                    this.Pages_ClosePressed(sender, e);
                else
                    this.view_annotations();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ToolsCalendar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActivePage is CalendarPage)
                    this.Pages_ClosePressed(sender, e);
                else
                    this.view_calendar();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ToolsAddIns_Popup(object sender, EventArgs e)
        {
            try
            {
                if (this.fAddInMgr.AddIns.Count == 0)
                    return;
                this.ToolsAddIns.MenuItems.Clear();
                foreach (IAddIn addIn in this.fAddInMgr.AddIns)
                {
                    MenuItem menuItem1 = this.ToolsAddIns.MenuItems.Add(addIn.Name);
                    foreach (IAddInComponent component in addIn.Components)
                    {
                        ICommand command = component as ICommand;
                        if (command != null)
                        {
                            MenuItem menuItem2 = menuItem1.MenuItems.Add(command.Name, new EventHandler(command.Execute));
                            menuItem2.Enabled = command.Available;
                            menuItem2.Checked = command.Active;
                        }
                    }
                    if (menuItem1.MenuItems.Count == 0)
                        menuItem1.MenuItems.Add("(no commands)").Enabled = false;
                }
                this.ToolsAddIns.MenuItems.Add("-");
                this.ToolsAddIns.MenuItems.Add("Add-In Manager", new EventHandler(this.ToolsAddInManager_Click));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ToolsAddInManager_Click(object sender, EventArgs e)
        {
            int num = (int)new AddInDlg(this.fAddInMgr).ShowDialog();
        }

        private void ToolsMergeElements_Click(object sender, EventArgs e)
        {
            if (new MergeElementsDlg().ShowDialog() != DialogResult.OK)
                return;
            this.update_ui();
        }

        private void WindowMenu_Popup(object sender, EventArgs e)
        {
            this.WindowPages.MenuItems.Clear();
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
                this.WindowPages.MenuItems.Add(tabPage.Title, new EventHandler(this.PageActivate)).Checked = this.Pages.SelectedTab == tabPage;
            if (this.WindowPages.MenuItems.Count != 0)
                return;
            this.WindowPages.MenuItems.Add("None").Enabled = false;
        }

        private void WindowClose_Click(object sender, EventArgs e)
        {
            if (this.Pages.SelectedTab == null)
                return;
            this.Pages.TabPages.Remove(this.Pages.SelectedTab);
        }

        private void WindowCloseAll_Click(object sender, EventArgs e)
        {
            this.Pages.TabPages.Clear();
        }

        private void WindowCloseAllExcept_Click(object sender, EventArgs e)
        {
            Crownwood.Magic.Controls.TabPage selectedTab = this.Pages.SelectedTab;
            this.Pages.TabPages.Clear();
            if (selectedTab == null)
                return;
            this.Pages.TabPages.Add(selectedTab);
        }

        private void PageActivate(object sender, EventArgs e)
        {
            this.Pages.SelectedIndex = this.WindowPages.MenuItems.IndexOf(sender as MenuItem);
        }

        private void HelpContents_Click(object sender, EventArgs e)
        {
            try
            {
                string location = Assembly.GetEntryAssembly().Location;
                int length = location.LastIndexOf(".");
                string str = location.Substring(0, length) + ".chm";
                if (File.Exists(str))
                {
                    Help.ShowHelp((Control)this, str);
                }
                else
                {
                    int num = (int)MessageBox.Show("The help file '" + str + "' was not found.", "Labyrinth", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            try
            {
                int num = (int)new AboutDlg().ShowDialog();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void MainToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.MainNewBtn)
                    this.FileNew_Click(sender, (EventArgs)e);
                else if (e.Button == this.MainOpenBtn)
                    this.FileOpen_Click(sender, (EventArgs)e);
                else if (e.Button == this.MainSaveBtn)
                    this.FileSave_Click(sender, (EventArgs)e);
                else if (e.Button == this.MainPropertiesBtn)
                    this.EditProjectProperties_Click(sender, (EventArgs)e);
                else if (e.Button == this.MainSearchBtn)
                    this.ToolsSearch_Click(sender, (EventArgs)e);
                else if (e.Button == this.MainTasksBtn)
                    this.ToolsTaskList_Click(sender, (EventArgs)e);
                else if (e.Button == this.MainAnnotationsBtn)
                {
                    this.ToolsAnnotations_Click(sender, (EventArgs)e);
                }
                else
                {
                    if (e.Button != this.MainCalendarBtn)
                        return;
                    this.ToolsCalendar_Click(sender, (EventArgs)e);
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void ElementToolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.ElementNewBtn)
                    this.EditElementsNew_Click(sender, (EventArgs)e);
                else if (e.Button == this.ElementDeleteBtn)
                    this.EditElementsDelete_Click(sender, (EventArgs)e);
                else if (e.Button == this.ElementPropertiesBtn)
                {
                    this.EditElementsProperties_Click(sender, (EventArgs)e);
                }
                else
                {
                    if (e.Button != this.ElementViewBtn)
                        return;
                    this.EditElementsView_Click(sender, (EventArgs)e);
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void StructureToolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.StructureNewBtn)
                    this.EditStructuresNew_Click(sender, (EventArgs)e);
                else if (e.Button == this.StructureDeleteBtn)
                    this.EditStructuresDelete_Click(sender, (EventArgs)e);
                else if (e.Button == this.StructurePropertiesBtn)
                {
                    this.EditStructuresProperties_Click(sender, (EventArgs)e);
                }
                else
                {
                    if (e.Button != this.StructureViewBtn)
                        return;
                    this.EditStructuresView_Click(sender, (EventArgs)e);
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void TimelineToolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.TimelineNewBtn)
                    this.EditTimelinesNew_Click(sender, (EventArgs)e);
                else if (e.Button == this.TimelineDeleteBtn)
                    this.EditTimelinesDelete_Click(sender, (EventArgs)e);
                else if (e.Button == this.TimelinePropertiesBtn)
                {
                    this.EditTimelinesProperties_Click(sender, (EventArgs)e);
                }
                else
                {
                    if (e.Button != this.TimelineViewBtn)
                        return;
                    this.EditTimelinesView_Click(sender, (EventArgs)e);
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void NoteToolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.NoteNewBtn)
                    this.EditNotesNew_Click(sender, (EventArgs)e);
                else if (e.Button == this.NoteDeleteBtn)
                    this.EditNotesDelete_Click(sender, (EventArgs)e);
                else if (e.Button == this.NotePropertiesBtn)
                {
                    this.EditNotesProperties_Click(sender, (EventArgs)e);
                }
                else
                {
                    if (e.Button != this.NoteViewBtn)
                        return;
                    this.EditNotesView_Click(sender, (EventArgs)e);
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        private void new_project()
        {
            this.OnProjectClosing(new EventArgs());
            LabyrinthData.Project = new Project();
            LabyrinthData.Project.Name = "Untitled Project";
            LabyrinthData.FileName = "";
            LabyrinthData.MostRecent = this.get_project_string();
            this.OnProjectCreated(new EventArgs());
        }

        private bool open_project(string filename)
        {
            this.Cursor = Cursors.WaitCursor;
            bool flag;
            try
            {
                StreamReader streamReader = new StreamReader(filename, Encoding.UTF8);
                string end = streamReader.ReadToEnd();
                streamReader.Close();
                FileConversion.Convert(ref end);
                XmlTextReader xmlTextReader = new XmlTextReader((TextReader)new StringReader(end));
                Project project = new XmlSerializer(typeof(Project)).Deserialize((XmlReader)xmlTextReader) as Project;
                xmlTextReader.Close();
                this.OnProjectClosing(new EventArgs());
                LabyrinthData.Project = project;
                LabyrinthData.FileName = filename;
                LabyrinthData.MostRecent = this.get_project_string();
                flag = true;
                this.OnProjectOpened(new EventArgs());
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
                int num = (int)MessageBox.Show("There was an error opening this project." + "\nIt may have been created with a newer version of Labyrinth.", "Labyrinth", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            this.Cursor = Cursors.Default;
            return flag;
        }

        private bool save_project(string filename)
        {
            this.Cursor = Cursors.WaitCursor;
            bool flag;
            try
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(filename, Encoding.UTF8);
                xmlTextWriter.Formatting = Formatting.Indented;
                new XmlSerializer(typeof(Project)).Serialize((XmlWriter)xmlTextWriter, (object)LabyrinthData.Project);
                xmlTextWriter.Close();
                LabyrinthData.FileName = filename;
                LabyrinthData.MostRecent = this.get_project_string();
                flag = true;
                this.OnProjectSaved(new EventArgs());
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
                int num = (int)MessageBox.Show("There was an error saving this project.", "Labyrinth", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            this.Cursor = Cursors.Default;
            return flag;
        }

        private bool save_project_as()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = LabyrinthData.FileName != "" ? LabyrinthData.FileName : LabyrinthData.Project.Name;
            saveFileDialog.Filter = "Plot Files|*.plt|All Files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                return this.save_project(saveFileDialog.FileName);
            return false;
        }

        private bool ask_for_save()
        {
            if (LabyrinthData.MostRecent != this.get_project_string())
            {
                switch (MessageBox.Show("This project has been modified. Would you like to save it?", "Labyrinth", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel:
                        return false;

                    case DialogResult.Yes:
                        if (LabyrinthData.FileName != "")
                            return this.save_project(LabyrinthData.FileName);
                        return this.save_project_as();

                    case DialogResult.No:
                        return true;
                }
            }
            return true;
        }

        private string get_project_string()
        {
            try
            {
                StringWriter stringWriter = new StringWriter();
                new XmlSerializer(typeof(Project)).Serialize((TextWriter)stringWriter, (object)LabyrinthData.Project);
                stringWriter.Close();
                return stringWriter.ToString();
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
            return "";
        }

        private void OnIdle(object sender, EventArgs e)
        {
            this.FileNew.Enabled = true;
            this.FileOpen.Enabled = true;
            this.FileSave.Enabled = true;
            this.FileSaveAs.Enabled = true;
            this.FileExit.Enabled = true;
            this.EditElementsNew.Enabled = true;
            this.EditElementsDelete.Enabled = this.SelectedElement != null;
            this.EditElementsProperties.Enabled = this.SelectedElement != null;
            this.EditElementsView.Enabled = this.SelectedElement != null;
            this.EditStructuresNew.Enabled = true;
            this.EditStructuresDelete.Enabled = this.SelectedStructure != null;
            this.EditStructuresProperties.Enabled = this.SelectedStructure != null;
            this.EditStructuresView.Enabled = this.SelectedStructure != null;
            this.EditTimelinesNew.Enabled = true;
            this.EditTimelinesDelete.Enabled = this.SelectedTimeline != null;
            this.EditTimelinesProperties.Enabled = this.SelectedTimeline != null;
            this.EditTimelinesView.Enabled = this.SelectedTimeline != null;
            this.EditNotesNew.Enabled = true;
            this.EditNotesDelete.Enabled = this.SelectedNote != null;
            this.EditNotesProperties.Enabled = this.SelectedNote != null;
            this.EditNotesView.Enabled = this.SelectedNote != null;
            this.EditProjectProperties.Enabled = true;
            this.ViewExplorer.Enabled = true;
            this.ViewExplorer.Checked = this.Explorer.Visible;
            this.ViewToolbar.Enabled = true;
            this.ViewToolbar.Checked = this.MainToolBar.Visible;
            this.ViewStatusbar.Enabled = true;
            this.ViewStatusbar.Checked = this.StatusBar.Visible;
            this.ViewPageTabs.Enabled = true;
            this.ViewPageTabs.Checked = this.Pages.HideTabsMode == Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.ToolsSearch.Enabled = true;
            this.ToolsSearch.Checked = this.ActivePage is SearchPage;
            this.ToolsTaskList.Enabled = true;
            this.ToolsTaskList.Checked = this.ActivePage is TaskPage;
            this.ToolsAnnotations.Enabled = true;
            this.ToolsAnnotations.Checked = this.ActivePage is AnnotationPage;
            this.ToolsCalendar.Enabled = true;
            this.ToolsCalendar.Checked = this.ActivePage is CalendarPage;
            this.HelpAbout.Enabled = true;
            this.ElementNew.Enabled = this.EditElementsNew.Enabled;
            this.ElementDelete.Enabled = this.EditElementsDelete.Enabled;
            this.ElementProperties.Enabled = this.EditElementsProperties.Enabled;
            this.ElementView.Enabled = this.EditElementsView.Enabled;
            this.StructureNew.Enabled = this.EditStructuresNew.Enabled;
            this.StructureDelete.Enabled = this.EditStructuresDelete.Enabled;
            this.StructureProperties.Enabled = this.EditStructuresProperties.Enabled;
            this.StructureView.Enabled = this.EditStructuresView.Enabled;
            this.TimelineNew.Enabled = this.EditTimelinesNew.Enabled;
            this.TimelineDelete.Enabled = this.EditTimelinesDelete.Enabled;
            this.TimelineProperties.Enabled = this.EditTimelinesProperties.Enabled;
            this.TimelineView.Enabled = this.EditTimelinesView.Enabled;
            this.NoteNew.Enabled = this.EditNotesNew.Enabled;
            this.NoteDelete.Enabled = this.EditNotesDelete.Enabled;
            this.NoteProperties.Enabled = this.EditNotesProperties.Enabled;
            this.NoteView.Enabled = this.EditNotesView.Enabled;
            this.MainNewBtn.Enabled = this.FileNew.Enabled;
            this.MainOpenBtn.Enabled = this.FileOpen.Enabled;
            this.MainSaveBtn.Enabled = this.FileSave.Enabled;
            this.MainPropertiesBtn.Enabled = this.EditProjectProperties.Enabled;
            this.MainSearchBtn.Enabled = this.ToolsSearch.Enabled;
            this.MainSearchBtn.Pushed = this.ToolsSearch.Checked;
            this.MainTasksBtn.Enabled = this.ToolsTaskList.Enabled;
            this.MainTasksBtn.Pushed = this.ToolsTaskList.Checked;
            this.MainAnnotationsBtn.Enabled = this.ToolsAnnotations.Enabled;
            this.MainAnnotationsBtn.Pushed = this.ToolsAnnotations.Checked;
            this.MainCalendarBtn.Enabled = this.ToolsCalendar.Enabled;
            this.MainCalendarBtn.Pushed = this.ToolsCalendar.Checked;
            this.ElementNewBtn.Enabled = this.EditElementsNew.Enabled;
            this.ElementDeleteBtn.Enabled = this.EditElementsDelete.Enabled;
            this.ElementPropertiesBtn.Enabled = this.EditElementsProperties.Enabled;
            this.ElementViewBtn.Enabled = this.EditElementsView.Enabled;
            this.StructureNewBtn.Enabled = this.EditStructuresNew.Enabled;
            this.StructureDeleteBtn.Enabled = this.EditStructuresDelete.Enabled;
            this.StructurePropertiesBtn.Enabled = this.EditStructuresProperties.Enabled;
            this.StructureViewBtn.Enabled = this.EditStructuresView.Enabled;
            this.TimelineNewBtn.Enabled = this.EditTimelinesNew.Enabled;
            this.TimelineDeleteBtn.Enabled = this.EditTimelinesDelete.Enabled;
            this.TimelinePropertiesBtn.Enabled = this.EditTimelinesProperties.Enabled;
            this.TimelineViewBtn.Enabled = this.EditTimelinesView.Enabled;
            this.NoteNewBtn.Enabled = this.EditNotesNew.Enabled;
            this.NoteDeleteBtn.Enabled = this.EditNotesDelete.Enabled;
            this.NotePropertiesBtn.Enabled = this.EditNotesProperties.Enabled;
            this.NoteViewBtn.Enabled = this.EditNotesView.Enabled;
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
                (tabPage.Control as IPage)?.UpdateUI();
        }

        private void ElementList_MouseDown(object sender, MouseEventArgs e)
        {
            this.ElementList.SelectedItems.Clear();
            ListViewItem itemAt = this.ElementList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.OnIdle(sender, (EventArgs)e);
        }

        private void StructureList_MouseDown(object sender, MouseEventArgs e)
        {
            this.StructureList.SelectedItems.Clear();
            ListViewItem itemAt = this.StructureList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.OnIdle(sender, (EventArgs)e);
        }

        private void TimelineList_MouseDown(object sender, MouseEventArgs e)
        {
            this.TimelineList.SelectedItems.Clear();
            ListViewItem itemAt = this.TimelineList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.OnIdle(sender, (EventArgs)e);
        }

        private void NoteList_MouseDown(object sender, MouseEventArgs e)
        {
            this.NoteList.SelectedItems.Clear();
            ListViewItem itemAt = this.NoteList.GetItemAt(e.X, e.Y);
            if (itemAt != null)
                itemAt.Selected = true;
            this.OnIdle(sender, (EventArgs)e);
        }

        private void Pages_ClosePressed(object sender, EventArgs e)
        {
            this.WindowClose_Click(sender, e);
        }

        private void ElementList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.SelectedElement == null)
                return;
            int num = (int)this.DoDragDrop((object)this.SelectedElement, DragDropEffects.All);
        }

        private void StructureList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.SelectedStructure == null)
                return;
            int num = (int)this.DoDragDrop((object)this.SelectedStructure, DragDropEffects.All);
        }

        private void TimelineList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.SelectedTimeline == null)
                return;
            int num = (int)this.DoDragDrop((object)this.SelectedTimeline, DragDropEffects.All);
        }

        private void NoteList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.SelectedNote == null)
                return;
            int num = (int)this.DoDragDrop((object)this.SelectedNote, DragDropEffects.All);
        }

        private void ElementList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedElement != null)
                this.EditElementsView_Click(sender, e);
            else
                this.EditElementsNew_Click(sender, e);
        }

        private void StructureList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedStructure != null)
                this.EditStructuresView_Click(sender, e);
            else
                this.EditStructuresNew_Click(sender, e);
        }

        private void TimelineList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedTimeline != null)
                this.EditTimelinesView_Click(sender, e);
            else
                this.EditTimelinesNew_Click(sender, e);
        }

        private void NoteList_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedNote != null)
                this.EditNotesView_Click(sender, e);
            else
                this.EditNotesNew_Click(sender, e);
        }

        private void update_ui()
        {
            this.update_statusbar();
            this.update_explorer();
            this.update_pages();
            this.update_addins();
        }

        private void update_statusbar()
        {
            this.NameStatusPanel.Text = "Project: " + LabyrinthData.Project.Name;
            if (LabyrinthData.FileName != "")
            {
                FileInfo fileInfo = new FileInfo(LabyrinthData.FileName);
                if ((fileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    this.NameStatusPanel.Text += " (read-only)";
                if (fileInfo.Length < 1024L)
                {
                    StatusBarPanel nameStatusPanel = this.NameStatusPanel;
                    nameStatusPanel.Text = nameStatusPanel.Text + "; " + (object)fileInfo.Length + " bytes";
                }
                else if (fileInfo.Length < 1048576L)
                {
                    float num = (float)fileInfo.Length / 1024f;
                    StatusBarPanel nameStatusPanel = this.NameStatusPanel;
                    nameStatusPanel.Text = nameStatusPanel.Text + "; " + num.ToString("F1") + " kb";
                }
                else if (fileInfo.Length < 1073741824L)
                {
                    float num = (float)fileInfo.Length / 1048576f;
                    StatusBarPanel nameStatusPanel = this.NameStatusPanel;
                    nameStatusPanel.Text = nameStatusPanel.Text + "; " + num.ToString("F1") + " Mb";
                }
                else
                {
                    float num = (float)fileInfo.Length / 1.073742E+09f;
                    StatusBarPanel nameStatusPanel = this.NameStatusPanel;
                    nameStatusPanel.Text = nameStatusPanel.Text + "; " + num.ToString("F1") + " Gb";
                }
            }
            this.ElementStatusPanel.Text = "Elements: " + (object)LabyrinthData.Project.Elements.Count;
            this.StructureStatusPanel.Text = "Structures: " + (object)LabyrinthData.Project.Structures.Count;
            this.TimelineStatusPanel.Text = "Timelines: " + (object)LabyrinthData.Project.Timelines.Count;
            this.NoteStatusPanel.Text = "Notes: " + (object)LabyrinthData.Project.Notes.Count;
        }

        private void update_explorer()
        {
            this.update_elements();
            this.update_structures();
            this.update_timelines();
            this.update_notes();
        }

        private void update_elements()
        {
            this.ElementList.BeginUpdate();
            this.ElementList.Items.Clear();
            if (LabyrinthData.Project.Elements.Count != 0)
            {
                ArrayList arrayList = new ArrayList();
                foreach (Element element in LabyrinthData.Project.Elements)
                    arrayList.Add((object)new ListViewItem(element.Name)
                    {
                        ImageIndex = LabyrinthData.GetImageIndex(element.Type),
                        Tag = (object)element
                    });
                this.ElementList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            }
            else
            {
                ListViewItem listViewItem = this.ElementList.Items.Add("No elements");
                listViewItem.ImageIndex = -1;
                listViewItem.ForeColor = SystemColors.GrayText;
            }
            this.ElementList.EndUpdate();
        }

        private void update_structures()
        {
            this.StructureList.BeginUpdate();
            this.StructureList.Items.Clear();
            if (LabyrinthData.Project.Structures.Count != 0)
            {
                ArrayList arrayList = new ArrayList();
                foreach (Structure structure in LabyrinthData.Project.Structures)
                    arrayList.Add((object)new ListViewItem(structure.Name)
                    {
                        ImageIndex = LabyrinthData.GetImageIndex((object)structure),
                        Tag = (object)structure
                    });
                this.StructureList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            }
            else
            {
                ListViewItem listViewItem = this.StructureList.Items.Add("No structures");
                listViewItem.ImageIndex = -1;
                listViewItem.ForeColor = SystemColors.GrayText;
            }
            this.StructureList.EndUpdate();
        }

        private void update_timelines()
        {
            this.TimelineList.BeginUpdate();
            this.TimelineList.Items.Clear();
            if (LabyrinthData.Project.Timelines.Count != 0)
            {
                ArrayList arrayList = new ArrayList();
                foreach (Timeline timeline in LabyrinthData.Project.Timelines)
                    arrayList.Add((object)new ListViewItem(timeline.Name)
                    {
                        ImageIndex = LabyrinthData.GetImageIndex((object)timeline),
                        Tag = (object)timeline
                    });
                this.TimelineList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            }
            else
            {
                ListViewItem listViewItem = this.TimelineList.Items.Add("No timelines");
                listViewItem.ImageIndex = -1;
                listViewItem.ForeColor = SystemColors.GrayText;
            }
            this.TimelineList.EndUpdate();
        }

        private void update_notes()
        {
            this.NoteList.BeginUpdate();
            this.NoteList.Items.Clear();
            if (LabyrinthData.Project.Notes.Count != 0)
            {
                ArrayList arrayList = new ArrayList();
                foreach (Note note in LabyrinthData.Project.Notes)
                    arrayList.Add((object)new ListViewItem(note.Title)
                    {
                        ImageIndex = LabyrinthData.GetImageIndex((object)note),
                        Tag = (object)note
                    });
                this.NoteList.Items.AddRange((ListViewItem[])arrayList.ToArray(typeof(ListViewItem)));
            }
            else
            {
                ListViewItem listViewItem = this.NoteList.Items.Add("No notes");
                listViewItem.ImageIndex = -1;
                listViewItem.ForeColor = SystemColors.GrayText;
            }
            this.NoteList.EndUpdate();
        }

        private void update_pages()
        {
            ArrayList arrayList = new ArrayList();
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                IPage control = tabPage.Control as IPage;
                if (control != null && control.IsObsolete)
                    arrayList.Add((object)tabPage);
            }
            foreach (Crownwood.Magic.Controls.TabPage tabPage in arrayList)
                this.Pages.TabPages.Remove(tabPage);
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                IPage control = tabPage.Control as IPage;
                if (control != null)
                {
                    tabPage.Title = control.Title;
                    tabPage.ImageIndex = LabyrinthData.GetImageIndex((object)control);
                    control.UpdateData();
                }
            }
        }

        private void update_addins()
        {
            foreach (IAddIn addIn in this.fAddInMgr.AddIns)
            {
                foreach (IAddInComponent component in addIn.Components)
                    component.UpdateData();
            }
        }

        private void view_element(Element e)
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                Labyrinth.Pages.ElementPage control = tabPage.Control as Labyrinth.Pages.ElementPage;
                if (control != null && control.Element == e)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            Labyrinth.Pages.ElementPage elementPage = new Labyrinth.Pages.ElementPage(e);
            elementPage.ElementActivated += new ElementEventHandler(this.Page_ElementActivated);
            elementPage.ElementModified += new ElementEventHandler(this.Page_ElementModified);
            elementPage.TimelineModified += new TimelineEventHandler(this.Page_TimelineModified);
            elementPage.TimelineActivated += new TimelineEventHandler(this.Page_TimelineActivated);
            elementPage.StructureActivated += new StructureEventHandler(this.Page_StructureActivated);
            elementPage.StructureModified += new StructureEventHandler(this.Page_StructureModified);
            int imageIndex = LabyrinthData.GetImageIndex((object)elementPage);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(elementPage.Title, (Control)elementPage, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        private void view_structure(Structure s)
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                Labyrinth.Pages.StructurePage control = tabPage.Control as Labyrinth.Pages.StructurePage;
                if (control != null && control.Structure == s)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            Labyrinth.Pages.StructurePage structurePage = new Labyrinth.Pages.StructurePage(s);
            structurePage.StructureModified += new StructureEventHandler(this.Page_StructureModified);
            structurePage.ElementActivated += new ElementEventHandler(this.Page_ElementActivated);
            structurePage.ElementModified += new ElementEventHandler(this.Page_ElementModified);
            int imageIndex = LabyrinthData.GetImageIndex((object)structurePage);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(structurePage.Title, (Control)structurePage, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        private void view_timeline(Timeline tl)
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                Labyrinth.Pages.TimelinePage control = tabPage.Control as Labyrinth.Pages.TimelinePage;
                if (control != null && control.Timeline == tl)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            Labyrinth.Pages.TimelinePage timelinePage = new Labyrinth.Pages.TimelinePage(tl);
            timelinePage.TimelineModified += new TimelineEventHandler(this.Page_TimelineModified);
            timelinePage.ElementActivated += new ElementEventHandler(this.Page_ElementActivated);
            timelinePage.ElementModified += new ElementEventHandler(this.Page_ElementModified);
            int imageIndex = LabyrinthData.GetImageIndex((object)timelinePage);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(timelinePage.Title, (Control)timelinePage, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        private void view_note(Note n)
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                Labyrinth.Pages.NotePage control = tabPage.Control as Labyrinth.Pages.NotePage;
                if (control != null && control.Note == n)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            Labyrinth.Pages.NotePage notePage = new Labyrinth.Pages.NotePage(n);
            notePage.NoteModified += new NoteEventHandler(this.Page_NoteModified);
            int imageIndex = LabyrinthData.GetImageIndex((object)notePage);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(notePage.Title, (Control)notePage, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        private void view_search()
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                if (tabPage.Control is SearchPage)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            SearchPage searchPage = new SearchPage();
            searchPage.AddCustomSearches((ICustomSearch[])this.fCustomSearches.ToArray(typeof(ICustomSearch)));
            searchPage.ElementActivated += new ElementEventHandler(this.Page_ElementActivated);
            searchPage.ElementModified += new ElementEventHandler(this.Page_ElementModified);
            searchPage.TimelineModified += new TimelineEventHandler(this.Page_TimelineModified);
            searchPage.TimelineActivated += new TimelineEventHandler(this.Page_TimelineActivated);
            searchPage.StructureActivated += new StructureEventHandler(this.Page_StructureActivated);
            searchPage.StructureModified += new StructureEventHandler(this.Page_StructureModified);
            int imageIndex = LabyrinthData.GetImageIndex((object)searchPage);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(searchPage.Title, (Control)searchPage, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        private void view_tasks()
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                if (tabPage.Control is TaskPage)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            TaskPage taskPage = new TaskPage();
            int imageIndex = LabyrinthData.GetImageIndex((object)taskPage);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(taskPage.Title, (Control)taskPage, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        private void view_annotations()
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                if (tabPage.Control is AnnotationPage)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            AnnotationPage annotationPage = new AnnotationPage();
            annotationPage.ElementActivated += new ElementEventHandler(this.Page_ElementActivated);
            annotationPage.ElementModified += new ElementEventHandler(this.Page_ElementModified);
            annotationPage.TimelineModified += new TimelineEventHandler(this.Page_TimelineModified);
            annotationPage.TimelineActivated += new TimelineEventHandler(this.Page_TimelineActivated);
            int imageIndex = LabyrinthData.GetImageIndex((object)annotationPage);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(annotationPage.Title, (Control)annotationPage, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        private void view_calendar()
        {
            foreach (Crownwood.Magic.Controls.TabPage tabPage in (CollectionBase)this.Pages.TabPages)
            {
                if (tabPage.Control is CalendarPage)
                {
                    tabPage.Selected = true;
                    return;
                }
            }
            CalendarPage calendarPage = new CalendarPage();
            calendarPage.ElementActivated += new ElementEventHandler(this.Page_ElementActivated);
            calendarPage.ElementModified += new ElementEventHandler(this.Page_ElementModified);
            calendarPage.TimelineActivated += new TimelineEventHandler(this.Page_TimelineActivated);
            calendarPage.TimelineModified += new TimelineEventHandler(this.Page_TimelineModified);
            int imageIndex = LabyrinthData.GetImageIndex((object)calendarPage);
            Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage(calendarPage.Title, (Control)calendarPage, imageIndex);
            this.Pages.TabPages.Add(tabPage1);
            tabPage1.Selected = true;
        }

        private void Page_ElementModified(object sender, ElementEventArgs e)
        {
            this.update_ui();
            this.OnElementModified(e);
        }

        private void Page_StructureModified(object sender, StructureEventArgs e)
        {
            this.update_ui();
            this.OnStructureModified(e);
        }

        private void Page_TimelineModified(object sender, TimelineEventArgs e)
        {
            this.update_ui();
            this.OnTimelineModified(e);
        }

        private void Page_NoteModified(object sender, NoteEventArgs e)
        {
            this.update_ui();
            this.OnNoteModified(e);
        }

        private void Page_ElementActivated(object sender, ElementEventArgs e)
        {
            this.view_element(e.Element);
        }

        private void Page_StructureActivated(object sender, StructureEventArgs e)
        {
            this.view_structure(e.Structure);
        }

        private void Page_TimelineActivated(object sender, TimelineEventArgs e)
        {
            this.view_timeline(e.Timeline);
        }

        private void ElementList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.ElementList, e.Column);
        }

        private void StructureList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.StructureList, e.Column);
        }

        private void TimelineList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.TimelineList, e.Column);
        }

        private void NoteList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewSorter.Sort(this.NoteList, e.Column);
        }

        private void StatusBar_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks != 2)
                return;
            int num = this.StatusBar.Panels.IndexOf(e.StatusBarPanel);
            if (num == 0)
            {
                this.EditProjectProperties_Click(sender, (EventArgs)e);
            }
            else
            {
                if (num <= 0)
                    return;
                this.Explorer.TabPages[num - 1].Selected = true;
            }
        }
    }
}