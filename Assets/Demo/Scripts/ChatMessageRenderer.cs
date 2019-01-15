using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class ChatMessageRenderer : MonoBehaviour
    {
        public Text text;

        public void UpdateState(int index, string msg)
        {
            text.text = index + ": " + msg;
        }
    }
}