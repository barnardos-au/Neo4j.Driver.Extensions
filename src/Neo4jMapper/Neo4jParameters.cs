﻿using System.Collections.Generic;
using System.Reflection;
using ServiceStack;

namespace Neo4jMapper
{
    // ReSharper disable once InconsistentNaming
    public class Neo4jParameters : Dictionary<string, object>
    {
        public void Add<T>(string key, T value)
        {
            var dictionary = value.ToObjectDictionary();
            base.Add(key, dictionary);
        }

        public void AddParams(object parameters)
        {
            if (parameters == null) return;
            foreach (var propertyInfo in (parameters.GetType().GetTypeInfo().DeclaredProperties))
            {
                var key = propertyInfo.Name;
                var value = propertyInfo.GetValue(parameters);
                base.Add(key, value);
            }
        }
    }
}