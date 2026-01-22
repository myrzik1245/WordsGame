using Assets._Project.Develop.Configs.Meta;
using Assets._Project.Develop.Utility.ResourceLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Utility.ConfigsManagment
{
    public class ResourcesConfigLoader : IConfigsLoader
    {
        private ResourcesLoader _resourcesLoader;
        private Dictionary<Type, string> _configsPaths = new()
        {
            { typeof(SymbolsInBehaviors), "Configs/Gameplay/SymbolsInBehavior" },
            { typeof(DifficultiesSettings), "Configs/Gameplay/DifficultiesSettings" },
            { typeof(WalletConfig), "Configs/Gameplay/WalletConfig" },
            { typeof(ResetProgressConfigs), "Configs/Meta/ResetConfig" }
        };

        public ResourcesConfigLoader(ResourcesLoader resourcesLoader)
        {
            _resourcesLoader = resourcesLoader;
        }

        public IEnumerator LoadAsync(Action<Type, object> onLoadConfig)
        {
            foreach (KeyValuePair<Type, string> configPath in _configsPaths)
            {
                ScriptableObject config = _resourcesLoader.Load<ScriptableObject>(configPath.Value);
                onLoadConfig.Invoke(configPath.Key, config);
                yield return null;
            }
        }
    }
}
