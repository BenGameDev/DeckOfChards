using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUIElements : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform rectTransform;
    public Vector2 hoverTransform;
    public int siblingIndex;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        siblingIndex = transform.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, hoverTransform.y);
        this.GetComponent<LayoutElement>().ignoreLayout = true;
        rectTransform.SetSiblingIndex(5);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
        rectTransform.SetSiblingIndex(siblingIndex);
        this.GetComponent<LayoutElement>().ignoreLayout = false;
    }
}
