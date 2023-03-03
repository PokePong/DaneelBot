using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DaneelBot.Utils;

public abstract class Service {
    internal void Init() {
        DoInit();
    }

    protected abstract void DoInit();
}

public static class Services {
    private static readonly Dictionary<Type, Service> _services = new Dictionary<Type, Service>();
    
    public static S Get<S>() where S : Service, new() {
        var serviceType = typeof(S);
        if (_services.TryGetValue(serviceType, out var value)) {
            return (value as S)!;
        }

        var service = new S();
        _services.Add(serviceType, service);
        service.Init();
        return service;
    }
}