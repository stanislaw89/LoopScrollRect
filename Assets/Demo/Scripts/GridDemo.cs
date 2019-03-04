using System.Collections.Generic;
using SG;
using UnityEngine;
using UnityEngine.UI;

public class GridDemo : MonoBehaviour
{
    public InputField countInput;
    public LoopScrollRect scroll;
    public GridItemRenderer prefab;

    private readonly List<string> model = new List<string>();

    void Start()
    {
        UpdateScroll();
    }

    public void UpdateScroll()
    {
        var count = int.Parse(countInput.text);
        model.Clear();
        for (var i = 0; i < count; i++)
        {
            model.Add("" + i);
        }

        scroll.UpdateList(
            model,
            prefab,
            (i, msg, view) => view.UpdateState(i, msg)
        );
    }
}