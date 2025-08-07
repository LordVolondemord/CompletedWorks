using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrbHolder : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject orb = eventData.pointerDrag;
            orb.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;

            orb.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            orb.GetComponent<DragAndDrop>().enabled = false;

            Destroy(gameObject);
        }
    }

}
