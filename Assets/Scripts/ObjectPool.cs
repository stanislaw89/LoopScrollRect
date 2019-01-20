using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
    public class ObjectPool
    {
        private readonly Transform container;
        private readonly GameObject prefab;

        private readonly Stack<GameObject> stack = new Stack<GameObject>();

        public ObjectPool(Transform container, GameObject prefab)
        {
            this.container = container;
            this.prefab = prefab;
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