using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace SG
{
    [RequireComponent(typeof(UnityEngine.UI.LoopScrollRect))]
    [DisallowMultipleComponent]
    public class InitOnStart : MonoBehaviour
    {
        public int totalCount = -1;
        public LoopScrollRect scroll;
        public GameObject prefab;

        void Start()
        {
            scroll.UpdateData<int, Transform>(
                totalCount,
                i => i,
                prefab.transform,
                o => { },
                (i, o, view) => view.SendMessage("ScrollCellIndex", i)
            );
        }
    }
}