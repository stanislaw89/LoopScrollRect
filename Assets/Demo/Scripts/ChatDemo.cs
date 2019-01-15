using System.Collections;
using System.Collections.Generic;
using SG;
using UnityEngine;
using UnityEngine.UI;

public class ChatDemo : MonoBehaviour
{
    public LoopScrollRect scroll;

    public ChatMessageRenderer messageRendererPrefab;

    private readonly List<string> messages = new List<string>()
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
        scroll.UpdateList(
            messages,
            messageRendererPrefab,
            (i, msg, view) => view.UpdateState(i, msg)
        );
    }
}