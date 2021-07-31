using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace it.example.dotnetcore5.dal.json.Models
{
    public static class MemoryCache<T>
    {
        private static readonly List<T> ts = new();
        private static List<T> items = ts;

        public static List<T> Items { get => items; set => items = value; }
    }
}
