using UnityEngine;

namespace SG
{
    public abstract class MixedContentRenderer : MonoBehaviour
    {
        public abstract void UpdateState(object item, int i);
    }
}