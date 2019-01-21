using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
    public class ObjectPool
    {
        public static readonly Action<GameObject> EmptyInitializer = o => { };

        private readonly Transform container;
        private readonly GameObject prefab;
        private readonly Action<GameObject> prefabInitializer;

        private readonly Stack<GameObject> stack = new Stack<GameObject>();

        public ObjectPool(Transform container, GameObject prefab, Action<GameObject> prefabInitializer)
        {
            this.container = container;
            this.prefab = prefab;
            this.prefabInitializer = prefabInitializer;
        }

        public GameObject GetObject()
        {
            if (stack.Count > 0)
            {
                var existingObject = stack.Pop();
                existingObject.GetComponent<PooledObject>().ownerPool = this;
                return existingObject;
            }
            else
            {
                var newObject = Object.Instantiate(prefab);
                newObject.AddComponent<PooledObject>().ownerPool = this;
                prefabInitializer(newObject);
                return newObject;
            }
        }

        public static void ReleaseObject(GameObject go)
        {
            var pooledObject = go.GetComponent<PooledObject>();
            if (pooledObject != null && pooledObject.ownerPool != null)
            {
                go.transform.SetParent(pooledObject.ownerPool.container, false);
                pooledObject.ownerPool.stack.Push(go);
                pooledObject.ownerPool = null;
            }
        }
    }
}