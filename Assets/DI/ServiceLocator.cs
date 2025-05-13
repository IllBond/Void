using System;
using System.Collections.Generic;
using UnityEngine;

namespace FinisOmnibus.Core
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void Registration<T>(T instance)
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
            {
                Debug.LogWarning($"Service {type} already registered.");
                return;
            }
            _services[type] = instance;
        }

        public static void RegisterNew<T>() where T : new()
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
            {
                Debug.LogWarning($"Service {type} already registered.");
                return;
            }
            _services[type] = new T();
        }


        public static T Get<T>()
        {
            var type = typeof(T);
            if (_services.TryGetValue(type, out var service))
            {
                return (T)service;
            }
            else
            {
                Debug.LogError($"Service {type} not found! Did you forget to register it?");
                return default;
            }
        }

        public static void Clear()
        {
            _services.Clear();
        }
    }
}