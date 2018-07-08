// Decompiled with JetBrains decompiler
// Type: Labyrinth.LabyrinthData
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using Labyrinth.Extensibility;
using Labyrinth.Pages;
using Labyrinth.Plot;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Labyrinth
{
    public class LabyrinthData
    {
        private static Project fProject = new Project();
        private static string fFileName = "";
        private static string fMostRecent = "";
        private static PageSettings fPageSettings = new PageSettings();
        private static PrinterSettings fPrinterSettings = new PrinterSettings();
        private static ImageList fImages = (ImageList)null;

        public static Project Project
        {
            get
            {
                return LabyrinthData.fProject;
            }
            set
            {
                LabyrinthData.fProject = value;
            }
        }

        public static string FileName
        {
            get
            {
                return LabyrinthData.fFileName;
            }
            set
            {
                LabyrinthData.fFileName = value;
            }
        }

        public static string MostRecent
        {
            get
            {
                return LabyrinthData.fMostRecent;
            }
            set
            {
                LabyrinthData.fMostRecent = value;
            }
        }

        public static PageSettings PageSettings
        {
            get
            {
                return LabyrinthData.fPageSettings;
            }
        }

        public static PrinterSettings PrinterSettings
        {
            get
            {
                return LabyrinthData.fPrinterSettings;
            }
        }

        public static ImageList ElementImages
        {
            get
            {
                if (LabyrinthData.fImages == null)
                {
                    LabyrinthData.fImages = new ImageList();
                    LabyrinthData.fImages.ColorDepth = ColorDepth.Depth8Bit;
                    LabyrinthData.fImages.ImageSize = new Size(16, 16);
                    LabyrinthData.fImages.TransparentColor = Color.Magenta;
                    ResourceManager resourceManager = new ResourceManager(typeof(MainForm));
                    LabyrinthData.fImages.ImageStream = (ImageListStreamer)resourceManager.GetObject("ElementImages.ImageStream");
                }
                return LabyrinthData.fImages;
            }
        }

        public static string HTMLHeader(string title)
        {
            return "<head>" + Environment.NewLine + "<meta name=\"generator\" content=\"" + LabyrinthData.HTMLGenerator + "\">" + Environment.NewLine + "<title>" + title + "</title>" + Environment.NewLine + LabyrinthData.HTMLStyles + Environment.NewLine + "</head>";
        }

        public static string HTMLGenerator
        {
            get
            {
                AssemblyName name = Assembly.GetEntryAssembly().GetName();
                return name.Name + " " + name.Version.ToString(2);
            }
        }

        public static string HTMLStyles
        {
            get
            {
                return "<style type=\"text/css\">" + Environment.NewLine + "p {font-family:Tahoma; font-size:10pt}" + Environment.NewLine + "p.header {font-size:16pt}" + Environment.NewLine + "p.rowhdr {font-weight:bold}" + Environment.NewLine + "p.colhdr {font-weight:bold}" + Environment.NewLine + "p.pointheader {font-size:12pt; font-weight:bold}" + Environment.NewLine + "p.schedule {}" + Environment.NewLine + "p.annotationtitle {font-weight:bold}" + Environment.NewLine + "p.annotationsource {font-size:8pt}" + Environment.NewLine + "p.annotationcontent {}" + Environment.NewLine + "p.tasktitle {font-weight:bold}" + Environment.NewLine + "p.taskflags {font-size:8pt}" + Environment.NewLine + "p.taskdetails {}" + Environment.NewLine + "</style>";
            }
        }

        public static int GetImageIndex(ElementType type)
        {
            switch (type)
            {
                case ElementType.Generic:
                    return 1;

                case ElementType.Character:
                    return 2;

                case ElementType.Organisation:
                    return 3;

                case ElementType.Website:
                    return 4;

                case ElementType.EmailAccount:
                    return 5;

                case ElementType.PhoneNumber:
                    return 6;

                case ElementType.File:
                    return 7;

                case ElementType.Puzzle:
                    return 8;

                case ElementType.Location:
                    return 9;

                case ElementType.Vehicle:
                    return 10;

                case ElementType.Concept:
                    return 11;

                case ElementType.Object:
                    return 12;

                case ElementType.Event:
                    return 13;

                default:
                    return 0;
            }
        }

        public static int GetImageIndex(Annotation a)
        {
            if (a is TextAnnotation)
                return 14;
            if (a is LinkAnnotation)
                return 15;
            return a is SketchAnnotation ? 16 : 0;
        }

        public static int GetImageIndex(Task t)
        {
            if (!t.HasDeadline)
                return 21;
            return !(t.Deadline - DateTime.Now > TimeSpan.Zero) ? 23 : 22;
        }

        public static int GetImageIndex(object obj)
        {
            if (obj is ElementPage)
                return LabyrinthData.GetImageIndex((obj as ElementPage).Element.Type);
            if (obj is Element)
                return LabyrinthData.GetImageIndex((obj as Element).Type);
            if (obj is AnnotationPage)
                return 14;
            if (obj is Annotation)
                return LabyrinthData.GetImageIndex(obj as Annotation);
            if (obj is Labyrinth.Plot.Link)
                return 17;
            if (obj is Structure || obj is StructurePage)
                return 18;
            if (obj is Timeline || obj is TimelinePage)
                return 19;
            if (obj is SearchPage)
                return 20;
            if (obj is TaskPage)
                return 21;
            if (obj is Task)
                return LabyrinthData.GetImageIndex(obj as Task);
            if (obj is CalendarPage)
                return 24;
            if (obj is Note || obj is NotePage)
                return 25;
            return obj is IPage ? 26 : 0;
        }

        public static void Log(object obj)
        {
            try
            {
                string location = Assembly.GetEntryAssembly().Location;
                int length = location.LastIndexOf(".");
                StreamWriter streamWriter = File.AppendText(location.Substring(0, length) + ".log");
                streamWriter.WriteLine(LabyrinthData.HTMLGenerator + "; " + (object)DateTime.Now);
                streamWriter.WriteLine(obj);
                streamWriter.WriteLine();
                streamWriter.Close();
            }
            catch
            {
            }
        }
    }
}