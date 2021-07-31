using it.example.dotnetcore5.domain.Models;
using System.Collections.Generic;

namespace it.example.dotnetcore5.dal.fake.Models
{
    public static class MemoryCache<T>
    {
        private static readonly List<T> ts = new();
        private static List<T> items = ts;

        public static List<T> Items { get => items; set => items = value; }
    }
}
