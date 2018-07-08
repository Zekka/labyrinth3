// Decompiled with JetBrains decompiler
// Type: Labyrinth.StartupData
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using System.IO;

namespace Labyrinth
{
    public class StartupData
    {
        private string fFileName = "";
        private string fAddInPath = "";

        public string FileName
        {
            get
            {
                return this.fFileName;
            }
            set
            {
                if (!File.Exists(value))
                    return;
                this.fFileName = value;
            }
        }

        public string AddInPath
        {
            get
            {
                return this.fAddInPath;
            }
            set
            {
                if (!Directory.Exists(value))
                    return;
                this.fAddInPath = value;
            }
        }
    }
}