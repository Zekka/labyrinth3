// Decompiled with JetBrains decompiler
// Type: Labyrinth.Controls.AnnotationList
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Plot;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.Controls
{
    public class AnnotationList : ListBox
    {
        public AnnotationList()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void InitializeComponent()
        {
            this.Size = new Size(512, 264);
        }

        public Annotation SelectedAnnotation
        {
            get
            {
                try
                {
                    return this.SelectedItem as Annotation;
                }
                catch (Exception ex)
                {
                    LabyrinthData.Log((object)ex);
                }
                return (Annotation)null;
            }
            set
            {
                this.SelectedItem = (object)value;
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            try
            {
                if (e.Index == -1 || e.Index >= this.Items.Count)
                    return;
                Annotation a = this.Items[e.Index] as Annotation;
                if (a == null)
                    return;
                e.ItemHeight = Annotations.MeasureHeight(a, this.Width, this.Font, e.Graphics);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                if (e.Index == -1 || e.Index >= this.Items.Count)
                    return;
                Annotation a = this.Items[e.Index] as Annotation;
                if (a == null)
                    return;
                e.DrawBackground();
                bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                Annotations.Render(a, e.Bounds, this.Font, e.Graphics, selected, true);
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int num = this.IndexFromPoint(e.X, e.Y);
            if (num >= 0 && num < this.Items.Count)
                this.SelectedIndex = num;
            else
                this.SelectedItem = (object)null;
        }
    }
}