// Decompiled with JetBrains decompiler
// Type: Labyrinth.LabyrinthMain
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace Labyrinth
{
    public class LabyrinthMain
    {
        [STAThread]
        private static void Main(string[] args)
        {
            foreach (var resource in typeof(LabyrinthMain).Assembly.GetManifestResourceNames())
            {
                Debug.WriteLine(resource);
            }

            try
            {
                StartupData sd = new StartupData();
                ArrayList arrayList = new ArrayList((ICollection)args);
                if (arrayList.Count != 0)
                {
                    int index1 = arrayList.IndexOf((object)"/addin");
                    if (index1 != -1)
                    {
                        sd.AddInPath = arrayList[index1 + 1] as string;
                        arrayList.RemoveRange(index1, 2);
                    }
                    if (arrayList.Count != 0)
                    {
                        int index2 = arrayList.Count - 1;
                        sd.FileName = arrayList[index2] as string;
                        arrayList.RemoveAt(index2);
                    }
                }
                Application.Run((Form)new MainForm(sd));
            }
            catch (Exception ex)
            {
                LabyrinthData.Log((object)ex);
                int num = (int)MessageBox.Show(ex.Message + "\n" + (object)ex.InnerException, "Labyrinth", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}