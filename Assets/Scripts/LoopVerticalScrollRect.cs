using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityEngine.UI
{
    [AddComponentMenu("UI/Loop Vertical Scroll Rect", 51)]
    [DisallowMultipleComponent]
    public class LoopVerticalScrollRect : LoopScrollRect
    {
        protected override float GetSize(RectTransform item)
        {
            float size = contentSpacing;
            if (m_GridLayout != null)
            {
                size += m_GridLayout.cellSize.y;
            }
            else
            {
                size += LayoutUtility.GetPreferredHeight(item);
            }

            return size;
        }

        protected override float GetDimension(Vector2 vector)
        {
            return vector.y;
        }

        protected override Vector2 GetVector(float value)
        {
            return new Vector2(0, value);
        }

        protected override void Awake()
        {
            base.Awake();
            directionSign = -1;

            GridLayoutGroup layout = content.GetComponent<GridLayoutGroup>();
            if (layout != null && layout.constraint != GridLayoutGroup.Constraint.FixedColumnCount)
            {
                Debug.LogError("[LoopHorizontalScrollRect] unsupported GridLayoutGroup constraint");
            }
        }

        protected override bool UpdateItems(Bounds viewBounds, Bounds contentBounds, bool refill)
        {
            bool changed = false;

            if (viewBounds.min.y < contentBounds.min.y)
            {
                float filled = 0;
                filled += AddItemsTill(true, filled, contentBounds.min.y - viewBounds.min.y);
                if (refill)
                    filled += AddItemsTill(false, filled, viewBounds.size.y);
                changed |= filled > 0;
            }
            else if (viewBounds.min.y > contentBounds.min.y + threshold)
            {
                changed |= DeleteItems(true, viewBounds.min.y - contentBounds.min.y - threshold);
            }

            if (viewBounds.max.y > contentBounds.max.y)
            {
                float filled = 0;
                filled += AddItemsTill(false, filled, viewBounds.max.y - contentBounds.max.y);
                if (refill)
                    filled += AddItemsTill(true, filled, viewBounds.size.y);
                changed |= filled > 0;
            }
            else if (viewBounds.max.y < contentBounds.max.y - threshold)
            {
                changed |= DeleteItems(false, contentBounds.max.y - threshold - viewBounds.max.y);
            }

            return changed;
        }
    }
}