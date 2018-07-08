// Decompiled with JetBrains decompiler
// Type: Labyrinth.Extensibility.AddInManager
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace Labyrinth.Extensibility
{
    public class AddInManager
    {
        private ArrayList fAddIns = new ArrayList();

        public ArrayList AddIns
        {
            get
            {
                return this.fAddIns;
            }
        }

        public void Load(string dir, IApplication app)
        {
            foreach (string searchFile in this.search_files(dir, "*.dll"))
                this.check_dll(searchFile, app);
        }

        private ArrayList search_files(string dir, string mask)
        {
            ArrayList arrayList1 = new ArrayList();
            if (Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir, mask);
                arrayList1.AddRange((ICollection)files);
                foreach (string directory in Directory.GetDirectories(dir))
                {
                    ArrayList arrayList2 = this.search_files(directory, mask);
                    arrayList1.AddRange((ICollection)arrayList2);
                }
            }
            return arrayList1;
        }

        private void check_dll(string filename, IApplication app)
        {
            try
            {
                foreach (Type type in Assembly.LoadFrom(filename).GetTypes())
                {
                    if (type.GetInterface(typeof(IAddIn).Name) != null)
                    {
                        ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                        if (constructor != null)
                        {
                            try
                            {
                                IAddIn addIn = constructor.Invoke((object[])null) as IAddIn;
                                if (addIn != null)
                                {
                                    if (addIn.Load(app))
                                        this.fAddIns.Add((object)addIn);
                                    else
                                        addIn.Unload();
                                }
                            }
                            catch (Exception ex)
                            {
                                LabyrinthData.Log((object)ex);
                            }
                        }
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