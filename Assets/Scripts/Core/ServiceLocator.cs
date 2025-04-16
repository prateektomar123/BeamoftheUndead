using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    public static void Register<T>(T service)
    {
        if (service == null)
        {
            throw new ArgumentNullException(nameof(service));
        }
        services[typeof(T)] = service;
        Debug.Log($"Registered service: {typeof(T).Name}");
    }

    public static T Get<T>()
    {
        if (services.TryGetValue(typeof(T), out object service))
        {
            return (T)service;
        }
        throw new KeyNotFoundException($"Service of type {typeof(T).Name} not found.");
    }
}