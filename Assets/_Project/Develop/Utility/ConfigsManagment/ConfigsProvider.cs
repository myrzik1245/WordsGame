using System;
using System.Collections;
using System.Collections.Generic;

public class ConfigsProvider
{
    private Dictionary<Type, object> _configs = new();
    private IConfigsLoader[] _loaders;

    public ConfigsProvider(params IConfigsLoader[] loaders)
    {
        _loaders = loaders;
    }

    public IEnumerator LoadAsync()
    {
        _configs.Clear();

        foreach(IConfigsLoader loader in _loaders)
            yield return loader.LoadAsync((type, config) => _configs.Add(type, config));
    }

    public T GetConfig<T>()
    {
        if (_configs.ContainsKey(typeof(T)) == false)
            throw new InvalidOperationException($"Not found config {typeof(T)}");

        return (T)_configs[typeof(T)];
    }
}
