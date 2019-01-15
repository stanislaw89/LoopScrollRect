using UnityEngine.UI;

namespace SG
{
    public class MixedContentRendererInt : MixedContentRenderer
    {
        public Text text;

        public override void UpdateState(object item, int i)
        {
            text.text = "Int " + i + " " + item;
        }
    }
}