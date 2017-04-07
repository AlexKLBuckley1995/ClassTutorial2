using System;
using System.Collections.Generic;

namespace Version_2_C
{
    sealed class clsNameComparer : IComparer<clsWork> //Sealed means you cant extend this class with inheritance
    {
        private clsNameComparer() {}
        private static readonly clsNameComparer _Instance = new clsNameComparer(); //Generates the singleton

        public static clsNameComparer Instance
        {
            get
            {
                return _Instance;
            }
        }

        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
