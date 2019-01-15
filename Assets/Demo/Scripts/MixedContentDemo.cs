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
        scroll.UpdateData<object, MixedContentRenderer>(500,
            i => items[i % items.Count],
            (i, item) =>
            {
                if (item is int)
                {
                    return intRenderer;
                }
                else
                {
                    return stringRenderer;
                }
            },
            (i, item, view) => view.UpdateState(item, i)
        );
    }
}