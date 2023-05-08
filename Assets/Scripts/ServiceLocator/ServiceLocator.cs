using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    public static void Register<T>(T service)
    {
        Type type = typeof(T);

        if (services.ContainsKey(type))
        {
            Debug.LogWarning($"Service of type {type} is already registered. Overwriting...");
            services[type] = service;
        }
        else
        {
            services.Add(type, service);
        }
    }

    public static T Resolve<T>()
    {
        Type type = typeof(T);

        if (!services.ContainsKey(type))
        {
            Debug.LogError($"Service of type {type} is not registered.");
            return default(T);
        }

        return (T)services[type];
    }
}
