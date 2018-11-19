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

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4, T5>(this JsonSection section,
            Func<T1, T2, T3, T4, T5, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3), 
                (T5)x.ElementAt(4))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4, T5, T6>(this JsonSection section,
            Func<T1, T2, T3, T4, T5, T6, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3),
                (T5)x.ElementAt(4),
                (T6)x.ElementAt(5))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4, T5, T6, T7>(this JsonSection section,
            Func<T1, T2, T3, T4, T5, T6, T7, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3),
                (T5)x.ElementAt(4),
                (T6)x.ElementAt(5), 
                (T7)x.ElementAt(6))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4, T5, T6, T7, T8>(this JsonSection section,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3),
                (T5)x.ElementAt(4),
                (T6)x.ElementAt(5),
                (T7)x.ElementAt(6),
                (T8)x.ElementAt(7))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this JsonSection section,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3),
                (T5)x.ElementAt(4),
                (T6)x.ElementAt(5),
                (T7)x.ElementAt(6),
                (T8)x.ElementAt(7),
                (T9)x.ElementAt(8))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this JsonSection section,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), 
                typeof(T7), typeof(T8), typeof(T9), typeof(T10));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3),
                (T5)x.ElementAt(4),
                (T6)x.ElementAt(5),
                (T7)x.ElementAt(6),
                (T8)x.ElementAt(7),
                (T9)x.ElementAt(8), 
                (T10)x.ElementAt(9))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this JsonSection section,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3),
                (T5)x.ElementAt(4),
                (T6)x.ElementAt(5),
                (T7)x.ElementAt(6),
                (T8)x.ElementAt(7),
                (T9)x.ElementAt(8),
                (T10)x.ElementAt(9),
                (T11)x.ElementAt(10))).ToList();
        }

        public static List<TObject> GetTableAsObjectList<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this JsonSection section,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TObject> objectFactory)
        {
            var output = section.GetTable(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12));
            return output.Select(x => objectFactory.Invoke(
                (T1)x.ElementAt(0),
                (T2)x.ElementAt(1),
                (T3)x.ElementAt(2),
                (T4)x.ElementAt(3),
                (T5)x.ElementAt(4),
                (T6)x.ElementAt(5),
                (T7)x.ElementAt(6),
                (T8)x.ElementAt(7),
                (T9)x.ElementAt(8),
                (T10)x.ElementAt(9),
                (T11)x.ElementAt(10),
                (T12)x.ElementAt(11))).ToList();
        }
    }
}