using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
    public class ObjectPool
    {
        private readonly GameObject prefab;
        private readonly Transform root;
        private readonly Stack<GameObject> pool = new Stack<GameObject>();

        public ObjectPool(GameObject prefab, Transform root)
        {
            this.prefab = prefab;
            this.root = root;
        }

        public GameObject GetObject()
        {
            if (pool.Count > 0)
            {
                return pool.Pop();
            }
            else
            {
                return Object.Instantiate(prefab);
            }
        }

        public void ReturnObject(GameObject go)
        {
            go.transform.SetParent(root);
            pool.Push(go);
        }
    }
}