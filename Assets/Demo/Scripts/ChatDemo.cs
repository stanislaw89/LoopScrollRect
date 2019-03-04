using System.Collections.Generic;
using SG;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ChatDemo : MonoBehaviour
{
    public LoopScrollRect scroll;

    public ChatMessageRenderer messageRendererPrefab;
    public InputField inputField;

    private readonly List<string> messages = new List<string>
    {
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer non odio nunc.",
        "Suspendisse potenti.",
        "Cras tortor justo, vulputate at ipsum eget, auctor dapibus nibh. In in porta ante, sed cursus nulla.",
        "Yes.",
        "Phasellus sollicitudin ipsum sed egestas faucibus. Donec eget feugiat ipsum, at posuere nisi. Nullam at tellus diam. Nulla eget auctor ante, sed mattis magna. Duis sed aliquam justo. Nulla eu egestas magna.",
        "Curabitur sodales sagittis mi aliquam tempor.",
        "Quisque vulputate sed nunc vitae iaculis.",
        "Pellentesque posuere suscipit ligula ac maximus.",
        "Suspendisse et facilisis ligula, sit amet lobortis est.",
        "No",
        "Mauris convallis ipsum vitae tempus consectetur.",
        "Vestibulum ornare fringilla magna at pellentesque. Ut nisl odio, suscipit ac lacus sed, finibus vehicula turpis.",
        "Ut id ligula metus.",
        "Morbi aliquam purus volutpat mauris convallis, pretium efficitur tellus sagittis.",
        "Quisque lacinia vestibulum eros hendrerit porttitor.",
        "Integer auctor purus erat. ",
        "Vestibulum mattis pulvinar urna, nec pretium nibh interdum a. Sed cursus tincidunt ex, non vestibulum enim rutrum eget.",
        "Suspendisse cursus sagittis ex, vitae dignissim quam commodo viverra.",
        "Nullam at tellus diam. Nulla eget auctor ante, sed mattis magna. Duis sed aliquam justo. Nulla eu egestas magna.",
        "Sed sollicitudin elit vel malesuada mattis. Donec finibus vulputate libero, non rhoncus arcu. Phasellus et nunc ac nunc efficitur tristique nec nec purus. Quisque volutpat, felis eu mollis sagittis, sapien dui vestibulum nibh, nec vulputate ante massa id sem. Curabitur lectus velit, accumsan vel eleifend ut, finibus eleifend diam. Vestibulum ut leo convallis est scelerisque congue nec et lorem. Donec gravida, lorem quis consectetur gravida, velit turpis porttitor erat, et porta odio massa in justo. Phasellus ultrices eros at sapien convallis porttitor.",
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer non odio nunc.",
        "Suspendisse potenti.",
        "Cras tortor justo, vulputate at ipsum eget, auctor dapibus nibh. In in porta ante, sed cursus nulla.",
        "Yes.",
        "Phasellus sollicitudin ipsum sed egestas faucibus. Donec eget feugiat ipsum, at posuere nisi. Nullam at tellus diam. Nulla eget auctor ante, sed mattis magna. Duis sed aliquam justo. Nulla eu egestas magna.",
        "Curabitur sodales sagittis mi aliquam tempor.",
        "Quisque vulputate sed nunc vitae iaculis.",
        "Pellentesque posuere suscipit ligula ac maximus.",
        "Suspendisse et facilisis ligula, sit amet lobortis est.",
        "No",
        "Mauris convallis ipsum vitae tempus consectetur.",
        "Vestibulum ornare fringilla magna at pellentesque. Ut nisl odio, suscipit ac lacus sed, finibus vehicula turpis.",
        "Ut id ligula metus.",
        "Morbi aliquam purus volutpat mauris convallis, pretium efficitur tellus sagittis.",
        "Quisque lacinia vestibulum eros hendrerit porttitor.",
        "Integer auctor purus erat. ",
        "Vestibulum mattis pulvinar urna, nec pretium nibh interdum a. Sed cursus tincidunt ex, non vestibulum enim rutrum eget.",
        "Suspendisse cursus sagittis ex, vitae dignissim quam commodo viverra.",
        "Nullam at tellus diam. Nulla eget auctor ante, sed mattis magna. Duis sed aliquam justo. Nulla eu egestas magna.",
        "Sed sollicitudin elit vel malesuada mattis. Donec finibus vulputate libero, non rhoncus arcu. Phasellus et nunc ac nunc efficitur tristique nec nec purus. Quisque volutpat, felis eu mollis sagittis, sapien dui vestibulum nibh, nec vulputate ante massa id sem. Curabitur lectus velit, accumsan vel eleifend ut, finibus eleifend diam. Vestibulum ut leo convallis est scelerisque congue nec et lorem. Donec gravida, lorem quis consectetur gravida, velit turpis porttitor erat, et porta odio massa in justo. Phasellus ultrices eros at sapien convallis porttitor."
    };

    private void Start()
    {
        for (var i = 0; i < messages.Count; i++)
        {
            messages[i] = "<color=red>" + i + "</color> " + messages[i];
        }

        UpdateScroll();
    }

    public void ScrollToStart()
    {
        scroll.ScrollToCell(0);
    }

    public void ScrollToMid()
    {
        scroll.ScrollToCell(messages.Count / 2);
    }

    public void ScrollToEnd()
    {
        scroll.ScrollToCell(int.MaxValue);
    }

    public void SendChatMessage()
    {
        var positionAtEnd = scroll.normalizedPosition.y >= 1;
        messages.Add(inputField.text);
        UpdateScroll();
        if (positionAtEnd)
        {
            scroll.ScrollToCell(int.MaxValue);
        }
    }

    public void AppendMessages()
    {
        var appendix = "" + (int) (Time.time * 1000);
        for (var i = 0; i < messages.Count; i++)
        {
            messages[i] += " " + appendix;
        }

        UpdateScroll();
    }

    public void RemoveRandomMessages(int removeCount)
    {
        var rnd = new Random(0xBADFACE);
        while (messages.Count > 0 && removeCount > 0)
        {
            messages.RemoveAt(rnd.Next(messages.Count));
            removeCount--;
        }

        UpdateScroll();
    }

    private void OnRemoveClick(int index)
    {
        messages.RemoveAt(index);
        UpdateScroll();
    }

    public void UpdateScroll()
    {
        scroll.UpdateList(
            messages,
            messageRendererPrefab,
            view => view.Init(OnRemoveClick),
            (i, msg, view) =>
            {
                view.UpdateState(i, msg);
                LayoutRebuilder.ForceRebuildLayoutImmediate(view.GetComponent<RectTransform>());
            }
        );
    }
}