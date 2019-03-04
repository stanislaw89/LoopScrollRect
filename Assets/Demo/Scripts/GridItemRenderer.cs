using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class GridItemRenderer : MonoBehaviour
    {
        public Text text;

        public void UpdateState(int i, string msg)
        {
            text.text = msg;
        }
    }
}