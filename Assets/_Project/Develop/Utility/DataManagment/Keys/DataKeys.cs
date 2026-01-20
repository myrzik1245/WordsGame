using Assets._Project.Develop.Data.Meta.Player;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Utility.DataManagment.Keys
{
    public class DataKeys : IDataKeys
    {
        private Dictionary<Type, string> _keys = new Dictionary<Type, string>()
        {
            { typeof(PlayerData), "PlayerData" },
        };

        public string GetKeyByType<T>()
        {
            return _keys[typeof(T)];
        }
    }
}