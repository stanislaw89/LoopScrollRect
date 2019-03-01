using System.Collections;
using System.Collections.Generic;
using SG;
using UnityEngine;
using UnityEngine.UI;

public class MixedContentDemo : MonoBehaviour
{
    public LoopScrollRect scroll;
    public MixedContentRendererInt intRenderer;
    public MixedContentRendererString stringRenderer;

    private readonly List<object> items = new List<object>
    {
        "a",
        "b",
        1,
        2,
        "c",
        3,
        4
    };

    private void Start()
    {
        scroll.UpdateData(() => 500,
            i => items[i % items.Count],
            (i, item) =>
            {
                if (item is int)
                {
                    return intRenderer.gameObject;
                }
                else
                {
                    return stringRenderer.gameObject;
                }
            },
            contentRenderer => { },
            (i, item, go) => go.GetComponent<MixedContentRenderer>().UpdateState(item, i)
        );
    }
    
}