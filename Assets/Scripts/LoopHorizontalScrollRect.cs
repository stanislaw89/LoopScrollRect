using UnityEngine;
using System.Collections;

namespace UnityEngine.UI
{
    [AddComponentMenu("UI/Loop Horizontal Scroll Rect", 50)]
    [DisallowMultipleComponent]
    public class LoopHorizontalScrollRect : LoopScrollRect
    {
        protected override float GetSize(RectTransform item)
        {
            float size = contentSpacing;
            if (m_GridLayout != null)
            {
                size += m_GridLayout.cellSize.x;
            }
            else
            {
                size += LayoutUtility.GetPreferredWidth(item);
            }

            return size;
        }

        protected override float GetDimension(Vector2 vector)
        {
            return -vector.x;
        }

        protected override Vector2 GetVector(float value)
        {
            return new Vector2(-value, 0);
        }

        protected override void Awake()
        {
            base.Awake();
            directionSign = 1;

            GridLayoutGroup layout = content.GetComponent<GridLayoutGroup>();
            if (layout != null && layout.constraint != GridLayoutGroup.Constraint.FixedRowCount)
            {
                Debug.LogError("[LoopHorizontalScrollRect] unsupported GridLayoutGroup constraint");
            }
        }

        protected override bool UpdateItems(Bounds viewBounds, Bounds contentBounds, bool refill)
        {
            bool changed = false;

            if (viewBounds.max.x > contentBounds.max.x)
            {
                float filled = 0;
                filled += AddItemsTill(true, filled, viewBounds.max.x - contentBounds.max.x);
                if (refill)
                    filled += AddItemsTill(false, filled, viewBounds.size.x);
                changed |= filled > 0;
            }
            else if (viewBounds.max.x < contentBounds.max.x - threshold)
            {
                changed |= DeleteItems(true, contentBounds.max.x - threshold - viewBounds.max.x);
            }

            if (viewBounds.min.x < contentBounds.min.x)
            {
                float filled = 0;
                filled += AddItemsTill(false, filled, contentBounds.min.x - viewBounds.min.x);
                if (refill)
                    filled += AddItemsTill(true, filled, viewBounds.size.x);
                changed |= filled > 0;
            }
            else if (viewBounds.min.x > contentBounds.min.x + threshold)
            {
                changed |= DeleteItems(false, viewBounds.min.x - contentBounds.min.x - threshold);
            }

            return changed;
        }
    }
}