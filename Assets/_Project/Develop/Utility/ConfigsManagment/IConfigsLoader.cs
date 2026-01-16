using System;
using System.Collections;

public interface IConfigsLoader
{
    IEnumerator LoadAsync(Action<Type, object> onLoad);
}
