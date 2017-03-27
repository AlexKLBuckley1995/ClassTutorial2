using System;
using System.Collections.Generic;

namespace Version_2_C
{
    sealed class clsNameComparer : IComparer<clsWork> //Sealed means you cant extend this class with inheritance
    {
        public clsNameComparer() {}
        public static readonly clsNameComparer Instance = new clsNameComparer(); //Generates the singleton

        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
