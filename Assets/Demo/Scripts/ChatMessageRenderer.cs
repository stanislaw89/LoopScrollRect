using System;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class ChatMessageRenderer : MonoBehaviour
    {
        public Text text;
        public Button removeButton;

        private int messageIndex;

        public ChatMessageRenderer Init(Action<int> onRemoveClick)
        {
            removeButton.onClick.RemoveAllListeners();
            removeButton.onClick.AddListener(() => onRemoveClick(messageIndex));
            return this;
        }

        public void UpdateState(int index, string msg)
        {
            messageIndex = index;
            text.text = "[" + index + "]: " + msg;
        }
    }
}