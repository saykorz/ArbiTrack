using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Components.Library.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll)
                c.Add(e);
            return c;
        }

        public static void TryRemove<T>(this ObservableCollection<T> source, T value)
        {
            if (source.Contains(value))
                source.Remove(value);
        }

        public static ICollection<T> AddRange<T>(this ICollection<T> source, ICollection<T> items)
        {
            foreach (T item in items)
            {
                source.Add(item);
            }
            return source;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
                action(item);
        }
    }
}
