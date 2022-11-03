using System;
using System.Collections;
using System.Collections.Generic;
using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Strategy
{
    public class Consumer
    {
        private DataStore _dataStore;

        public Consumer(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Save()
        {
            object data = new Data("Hi", 4545);
            _dataStore.SetData(data, "data2");
        }

        public void Load()
        {
            var data = _dataStore.GetData<Data>("data2");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}

