using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        private DataStore _fileDataStoreAdapter;
        private void Awake()
        {
            _fileDataStoreAdapter = new PlayerPrefsDataStoreAdapter();
            var data = new Data("Dato1", 123);
            _fileDataStoreAdapter.SetData(data, "Data1");
        }

        private DataStore GetDataStore()
        {
            var isEven = Random.Range(0, 99) % 2 == 0;
            if (isEven)
            {
                return new PlayerPrefsDataStoreAdapter();
            }

            return new FileDataStoreAdapter();
        }

        private void Start()
        {
            var data = _fileDataStoreAdapter.GetData<Data>("Data1");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}