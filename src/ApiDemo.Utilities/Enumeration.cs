using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ApiDemo.Utilities
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        protected Enumeration(string name) => Name = name;

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;
            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Name.Equals(otherValue.Name);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Name.CompareTo(((Enumeration)other).Name);

        // Other utility methods ...
    }
}
