// Decompiled with JetBrains decompiler
// Type: Labyrinth.ListViewSorter
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using System;
using System.Collections;
using System.Windows.Forms;

namespace Labyrinth
{
    public class ListViewSorter : IComparer
    {
        private int fColumn = 0;
        private bool fAscending = true;

        public int Column
        {
            get
            {
                return this.fColumn;
            }
            set
            {
                this.fColumn = value;
            }
        }

        public bool Ascending
        {
            get
            {
                return this.fAscending;
            }
            set
            {
                this.fAscending = value;
            }
        }

        public void SetColumn(int col)
        {
            if (this.fColumn == col)
            {
                this.fAscending = !this.fAscending;
            }
            else
            {
                this.fColumn = col;
                this.fAscending = true;
            }
        }

        public int Compare(object x, object y)
        {
            ListViewItem listViewItem1 = x as ListViewItem;
            ListViewItem listViewItem2 = y as ListViewItem;
            if (listViewItem1 == null || listViewItem2 == null)
                throw new ArgumentException();
            string text1 = listViewItem1.SubItems[this.Column].Text;
            string text2 = listViewItem2.SubItems[this.Column].Text;
            try
            {
                return int.Parse(text1).CompareTo((object)int.Parse(text2)) * (this.fAscending ? 1 : -1);
            }
            catch
            {
            }
            try
            {
                return float.Parse(text1).CompareTo((object)float.Parse(text2)) * (this.fAscending ? 1 : -1);
            }
            catch
            {
            }
            try
            {
                return DateTime.Parse(text1).CompareTo((object)DateTime.Parse(text2)) * (this.fAscending ? 1 : -1);
            }
            catch
            {
            }
            return text1.CompareTo(text2) * (this.fAscending ? 1 : -1);
        }

        public static void Sort(ListView list, int column)
        {
            ListViewSorter listViewItemSorter = list.ListViewItemSorter as ListViewSorter;
            if (listViewItemSorter == null)
                return;
            listViewItemSorter.SetColumn(column);
            list.Sort();
        }
    }
}