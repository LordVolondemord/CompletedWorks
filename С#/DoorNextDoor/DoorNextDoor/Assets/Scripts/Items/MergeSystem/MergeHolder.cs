using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MergeHolder : MonoBehaviour, IDropHandler
{
    public GameObject firstKey;
    public GameObject secondKey;
    public bool isHold = false;
    bool canSet = true;

    public GameObject holdKey;

    public void OnDrop(PointerEventData eventData)
    {
        if (canSet)
        {
            GameObject key = eventData.pointerDrag;
            if (key == firstKey || key == secondKey)
            {
                key.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
                key.GetComponent<DragAndDrop>().enabled = false;

                holdKey = key;
                canSet = false;
                isHold = true;
            }
        }
        
    }
}
