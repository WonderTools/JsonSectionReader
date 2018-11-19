using System;
using System.Collections.Generic;
using System.Linq;

namespace WonderTools.JsonReader
{
    public static class JsonSectionExtentions
    {
        public static List<TObject> GetTableAsObjectList<TObject, T1>(this JsonSection section, Func<T1, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1));
            return output.Select(x => objectFactory.Invoke((T1) x.ElementAt(0))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2>(this JsonSection section, Func<T1, T2, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2));
            return output.Select(x => objectFactory.Invoke((T1)x.ElementAt(0), (T2)x.ElementAt(1))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3>(this JsonSection section, Func<T1, T2, T3, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2)
            )).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4>(this JsonSection section, 
            Func<T1, T2, T3, T4, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3))).ToList();
        }
    }
}