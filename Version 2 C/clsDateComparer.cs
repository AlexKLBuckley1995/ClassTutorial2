using System;
using System.Collections.Generic;

namespace Version_2_C
{
    sealed class clsDateComparer : IComparer<clsWork> //Sealed means you can't extend clsDateComparer with inheritance
    {
        private clsDateComparer() {}
        public static readonly clsDateComparer Instance = new clsDateComparer(); //Generates a singleton


        public int Compare(clsWork x, clsWork y)
        {
            //DateTime lcDateX = x.Date;
            //DateTime lcDateY = y.Date;

            return x.Date.CompareTo(y.Date);

            //return lcDateX.CompareTo(lcDateY);
        }
    }

    class clsDDateComparer : IComparer<clsWork>
    {
        public int Compare(clsWork x, clsWork y)
        {
            //DateTime lcDateX = x.Date;
            //DateTime lcDateY = y.Date;

            return y.Date.CompareTo(x.Date);

            //return lcDateX.CompareTo(lcDateY);
        }
    }
}
