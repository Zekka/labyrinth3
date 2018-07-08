// Decompiled with JetBrains decompiler
// Type: Labyrinth.Controls.AnnotationPanel
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Plot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Controls
{
    public class AnnotationPanel : UserControl
    {
        private Container components = (Container)null;
        private List<Annotation> fAnnotations = new List<Annotation>();
        private Panel FilterPanel;
        private Label FilterLbl;
        private TextBox FilterBox;
        private AnnotationList AnnotationList;

        public AnnotationPanel()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.FilterPanel = new Panel();
            this.FilterBox = new TextBox();
            this.FilterLbl = new Label();
            this.AnnotationList = new AnnotationList();
            this.FilterPanel.SuspendLayout();
            this.SuspendLayout();
            this.FilterPanel.BorderStyle = BorderStyle.Fixed3D;
            this.FilterPanel.Controls.AddRange(new Control[2]
            {
        (Control) this.FilterBox,
        (Control) this.FilterLbl
            });
            this.FilterPanel.Dock = DockStyle.Top;
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new Size(408, 56);
            this.FilterPanel.TabIndex = 0;
            this.FilterPanel.Visible = false;
            this.FilterBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.FilterBox.Location = new Point(112, 16);
            this.FilterBox.Name = "FilterBox";
            this.FilterBox.ScrollBars = ScrollBars.Vertical;
            this.FilterBox.Size = new Size(276, 20);
            this.FilterBox.TabIndex = 1;
            this.FilterBox.Text = "";
            this.FilterBox.TextChanged += new EventHandler(this.FilterBox_TextChanged);
            this.FilterLbl.Location = new Point(8, 16);
            this.FilterLbl.Name = "FilterLbl";
            this.FilterLbl.Size = new Size(96, 24);
            this.FilterLbl.TabIndex = 0;
            this.FilterLbl.Text = "Show annotations containing:";
            this.FilterLbl.TextAlign = ContentAlignment.MiddleLeft;
            this.AnnotationList.Dock = DockStyle.Fill;
            this.AnnotationList.DrawMode = DrawMode.OwnerDrawVariable;
            this.AnnotationList.Location = new Point(0, 56);
            this.AnnotationList.Name = "AnnotationList";
            this.AnnotationList.SelectedAnnotation = (Annotation)null;
            this.AnnotationList.Size = new Size(408, 232);
            this.AnnotationList.TabIndex = 5;
            this.AnnotationList.DoubleClick += new EventHandler(this.AnnotationList_DoubleClick);
            this.Controls.AddRange(new Control[2]
            {
        (Control) this.AnnotationList,
        (Control) this.FilterPanel
            });
            this.Name = nameof(AnnotationPanel);
            this.Size = new Size(408, 288);
            this.FilterPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void FilterBox_TextChanged(object sender, EventArgs e)
        {
            this.update_list();
        }

        public Annotation SelectedAnnotation
        {
            get
            {
                return this.AnnotationList.SelectedAnnotation;
            }
            set
            {
                this.AnnotationList.SelectedAnnotation = value;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.AnnotationList.SelectedIndex;
            }
            set
            {
                this.AnnotationList.SelectedIndex = value;
            }
        }

        public bool ShowFilter
        {
            get
            {
                return this.FilterPanel.Visible;
            }
            set
            {
                this.FilterPanel.Visible = value;
            }
        }

        public bool FilterApplied
        {
            get
            {
                if (this.FilterPanel.Visible)
                    return this.FilterBox.Text != "";
                return false;
            }
        }

        public List<Annotation> Annotations
        {
            get
            {
                return this.fAnnotations;
            }
            set
            {
                this.fAnnotations = value;
                this.update_list();
            }
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            this.update_list();
        }

        private void update_list()
        {
            this.AnnotationList.BeginUpdate();
            this.AnnotationList.Items.Clear();
            foreach (Annotation fAnnotation in this.fAnnotations)
            {
                bool flag = true;
                if (this.FilterPanel.Visible && this.FilterBox.Text != "")
                {
                    foreach (string str in this.FilterBox.Text.ToLower().Split((char[])null))
                    {
                        if (fAnnotation.Title.ToLower().IndexOf(str) == -1 && fAnnotation.Content.ToLower().IndexOf(str) == -1)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                    this.AnnotationList.Items.Add((object)fAnnotation);
            }
            this.AnnotationList.EndUpdate();
        }

        private void AnnotationList_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);
        }
    }
}