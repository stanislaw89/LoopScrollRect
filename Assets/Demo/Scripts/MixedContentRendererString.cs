using UnityEngine.UI;

namespace SG
{
    public class MixedContentRendererString : MixedContentRenderer
    {
        public Text text;

        public override void UpdateState(object item, int i)
        {
            text.text = "String " + i + " " + item;
        }
    }
}