// Decompiled with JetBrains decompiler
// Type: Labyrinth.Annotations
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Forms;
using Labyrinth.Plot;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth
{
    public class Annotations
    {
        private const int fMaxLines = 5;

        public static bool Open(Annotation a)
        {
            TextAnnotation note1 = a as TextAnnotation;
            if (note1 != null)
                return new TextAnnotationDlg(note1).ShowDialog() == DialogResult.OK;
            LinkAnnotation note2 = a as LinkAnnotation;
            if (note2 != null)
                return new FileLinkAnnotationDlg(note2).ShowDialog() == DialogResult.OK;
            SketchAnnotation note3 = a as SketchAnnotation;
            if (note3 != null)
                return new SketchAnnotationDlg(note3).ShowDialog() == DialogResult.OK;
            return false;
        }

        public static string SimplifyContent(Annotation a)
        {
            string str1 = a.Content.Trim();
            string str2;
            do
            {
                str2 = str1;
                str1 = str1.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);
            }
            while (!(str1 == str2));
            return str1;
        }

        public static int MeasureHeight(Annotation a, int maxwidth, Font f, Graphics g)
        {
            Image image = Annotations.GetImage(a);
            int width = image != null ? maxwidth - image.Width : maxwidth;
            float num1 = 0.0f;
            SizeF sizeF;
            if (a.Title != "")
            {
                Font font = new Font(f, f.Style | FontStyle.Bold);
                sizeF = g.MeasureString(a.Title, f, width);
                num1 = sizeF.Height;
            }
            float num2;
            if (a is SketchAnnotation)
            {
                num2 = (float)(5 * f.Height);
            }
            else
            {
                string text = Annotations.SimplifyContent(a);
                sizeF = g.MeasureString(text, f, width);
                num2 = Math.Min(sizeF.Height, (float)(5 * f.Height));
            }
            int val1 = (int)((double)num1 + (double)num2);
            if (image == null)
                return val1;
            return Math.Max(val1, image.Height);
        }

        public static void Render(Annotation a, Rectangle rect, Font f, Graphics g, bool selected, bool showicon)
        {
            if (showicon)
            {
                Image image = Annotations.GetImage(a);
                if (image != null)
                    g.DrawImage(image, rect.X, rect.Y);
                if (image != null)
                {
                    rect.X += image.Width;
                    rect.Width -= image.Width;
                }
            }
            Brush brush = SystemBrushes.WindowText;
            if (selected)
                brush = SystemBrushes.HighlightText;
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.EllipsisWord;
            format.FormatFlags |= StringFormatFlags.LineLimit;
            float num = 0.0f;
            if (a.Title != "")
            {
                Font font = new Font(f, f.Style | FontStyle.Bold);
                num = g.MeasureString(a.Title, font, rect.Width).Height;
                g.DrawString(a.Title, font, brush, (RectangleF)rect, format);
            }
            rect.Y += (int)num;
            rect.Height -= (int)num;
            if (a is SketchAnnotation)
            {
                rect.Inflate(-1, -1);
                SketchAnnotation sketchAnnotation = a as SketchAnnotation;
                g.DrawImage(sketchAnnotation.Sketch, rect);
            }
            else
            {
                string s = Annotations.SimplifyContent(a);
                g.DrawString(s, f, brush, (RectangleF)rect, format);
            }
        }

        public static Image GetImage(Annotation a)
        {
            int imageIndex = LabyrinthData.GetImageIndex(a);
            if (imageIndex != -1)
                return LabyrinthData.ElementImages.Images[imageIndex];
            return (Image)null;
        }
    }
}