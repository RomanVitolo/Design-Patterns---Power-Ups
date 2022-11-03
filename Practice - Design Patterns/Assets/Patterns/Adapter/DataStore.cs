using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Adapter
{
    public interface DataStore
    {
        void SetData<T>(T data, string name);
        T GetData<T>(string name);
    }
}

