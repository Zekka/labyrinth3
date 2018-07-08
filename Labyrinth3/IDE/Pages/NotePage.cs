// Decompiled with JetBrains decompiler
// Type: Labyrinth.Pages.NotePage
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Controls;
using Labyrinth.Events;
using Labyrinth.Extensibility;
using Labyrinth.Forms;
using Labyrinth.Plot;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth.Pages
{
    public class NotePage : UserControl, INotePage, IPage
    {
        private Note fNote = (Note)null;
        private ToolBar Toolbar;
        private ImageList Images;
        private ToolBarButton PropertiesBtn;
        private RTFPanel RTFPanel;
        private ToolBarButton Sep1;
        private ToolBarButton ExportBtn;
        private IContainer components;

        public NotePage(Note n)
        {
            this.InitializeComponent();
            Application.Idle += new EventHandler(this.update_rtfpanel);
            this.fNote = n;
            this.UpdateData();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            ResourceManager resourceManager = new ResourceManager(typeof(NotePage));
            this.Toolbar = new ToolBar();
            this.PropertiesBtn = new ToolBarButton();
            this.Sep1 = new ToolBarButton();
            this.ExportBtn = new ToolBarButton();
            this.Images = new ImageList(this.components);
            this.RTFPanel = new RTFPanel();
            this.SuspendLayout();
            this.Toolbar.Appearance = ToolBarAppearance.Flat;
            this.Toolbar.Buttons.AddRange(new ToolBarButton[3]
            {
        this.PropertiesBtn,
        this.Sep1,
        this.ExportBtn
            });
            this.Toolbar.DropDownArrows = true;
            this.Toolbar.ImageList = this.Images;
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.ShowToolTips = true;
            this.Toolbar.Size = new Size(432, 25);
            this.Toolbar.TabIndex = 1;
            this.Toolbar.ButtonClick += new ToolBarButtonClickEventHandler(this.Toolbar_ButtonClick);
            this.PropertiesBtn.ImageIndex = 0;
            this.PropertiesBtn.ToolTipText = "Properties";
            this.Sep1.Style = ToolBarButtonStyle.Separator;
            this.ExportBtn.ImageIndex = 1;
            this.ExportBtn.ToolTipText = "Export";
            this.Images.ColorDepth = ColorDepth.Depth8Bit;
            this.Images.ImageSize = new Size(16, 16);
            this.Images.ImageStream = (ImageListStreamer)resourceManager.GetObject("Images.ImageStream");
            this.Images.TransparentColor = Color.Magenta;
            this.RTFPanel.Dock = DockStyle.Fill;
            this.RTFPanel.Location = new Point(0, 25);
            this.RTFPanel.Name = "RTFPanel";
            this.RTFPanel.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang2057{\\fonttbl{\\f0\\fnil\\fcharset0 Tahoma;}}\r\n{\\*\\generator Riched20 5.40.11.2212;}\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n\0";
            this.RTFPanel.Size = new Size(432, 215);
            this.RTFPanel.TabIndex = 2;
            this.RTFPanel.ContentModified += new EventHandler(this.RTFPanel_ContentModified);
            this.Controls.AddRange(new Control[2]
            {
        (Control) this.RTFPanel,
        (Control) this.Toolbar
            });
            this.Font = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.World);
            this.Name = nameof(NotePage);
            this.Size = new Size(432, 240);
            this.ResumeLayout(false);
        }

        public string Title
        {
            get
            {
                return this.fNote.Title;
            }
        }

        public bool IsObsolete
        {
            get
            {
                return LabyrinthData.Project.Notes.IndexOf(this.fNote) == -1;
            }
        }

        public void UpdateUI()
        {
        }

        public void UpdateData()
        {
            if (this.fNote.RTF != "")
                this.RTFPanel.RTF = this.fNote.RTF;
            else
                this.RTFPanel.Text = this.fNote.Text;
        }

        public Note Note
        {
            get
            {
                return this.fNote;
            }
        }

        public event NoteEventHandler NoteModified;

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

        private void RTFPanel_ContentModified(object sender, EventArgs e)
        {
            this.fNote.Text = this.RTFPanel.Text;
            this.fNote.RTF = this.RTFPanel.RTF;
            this.OnNoteModified(new NoteEventArgs(this.fNote));
        }

        private void update_rtfpanel(object sender, EventArgs e)
        {
            this.RTFPanel.UpdateUI();
        }

        private void Toolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.PropertiesBtn)
                {
                    if (new NoteDlg(this.fNote).ShowDialog() != DialogResult.OK)
                        return;
                    this.UpdateData();
                    this.OnNoteModified(new NoteEventArgs(this.fNote));
                }
                else
                {
                    if (e.Button != this.ExportBtn)
                        return;
                    string str = "Rich Text Files|*.rtf|HTML Files|*.html|Text Files|*.txt";
                    try
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.FileName = this.fNote.Title;
                        saveFileDialog.Filter = str;
                        if (saveFileDialog.ShowDialog() != DialogResult.OK)
                            return;
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1:
                                StreamWriter streamWriter1 = new StreamWriter(saveFileDialog.FileName);
                                streamWriter1.Write(this.RTFPanel.RTF);
                                streamWriter1.Close();
                                break;

                            case 2:
                                StreamWriter streamWriter2 = new StreamWriter(saveFileDialog.FileName);
                                streamWriter2.WriteLine(LabyrinthData.HTMLHeader(this.fNote.Title));
                                streamWriter2.WriteLine("<body>");
                                streamWriter2.WriteLine("<pre>");
                                streamWriter2.WriteLine(this.RTFPanel.Text);
                                streamWriter2.WriteLine("</pre>");
                                streamWriter2.WriteLine("</body>");
                                streamWriter2.WriteLine("</html>");
                                streamWriter2.Close();
                                break;

                            case 3:
                                StreamWriter streamWriter3 = new StreamWriter(saveFileDialog.FileName);
                                streamWriter3.Write(this.RTFPanel.Text);
                                streamWriter3.Close();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        LabyrinthData.Log((object)ex);
                    }
                }
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }
    }
}