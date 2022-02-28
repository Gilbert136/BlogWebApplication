using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace BlogWebApplication.Data.Convertors
{
    public class IntegerCollectionJsonValueConvertor : ValueConverter<ICollection<int>, string> 
    {
        public IntegerCollectionJsonValueConvertor() : base(
            v => JsonConvert.SerializeObject(v.Select(e => e.ToString()).ToList()),
            v => JsonConvert.DeserializeObject<ICollection<string>>(v).Select(e => Convert.ToInt32(e)).ToList())
        {
        }
    }

    public class StringCollectionJsonValueConvertor : ValueConverter<ICollection<string>, string> 
    {
        public StringCollectionJsonValueConvertor() : base(
            v => JsonConvert.SerializeObject(v.Select(e => e.ToString()).ToList()),
            v => JsonConvert.DeserializeObject<ICollection<string>>(v).Select(e => e.ToString()).ToList())
        {
        }
    }
    public class CollectionValueComparer<T> : ValueComparer<ICollection<T>>
    {
        public CollectionValueComparer() : base(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => (ICollection<T>)c.ToHashSet())
        {
        }
    }
}