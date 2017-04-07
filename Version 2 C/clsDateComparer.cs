using System;
using System.Collections.Generic;

namespace Version_2_C
{
    sealed class clsDateComparer : IComparer<clsWork> //Sealed means you can't extend clsDateComparer with inheritance
    {
        private clsDateComparer() {} //This constructor needs to be here even though it is not creating anything. Also it must be private in order to make sure ony one instance of the clsDateComparer exists at a time
        private static readonly clsDateComparer _Instance = new clsDateComparer(); //Generates a singleton

        public static clsDateComparer Instance
        {
            get
            {
                return _Instance;
            }
        }

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
