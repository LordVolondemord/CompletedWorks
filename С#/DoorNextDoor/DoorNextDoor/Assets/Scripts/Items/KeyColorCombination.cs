using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyColorCombination : MonoBehaviour, IDropHandler
{
    public GameObject firstKey;
    public GameObject secondKey;
    public GameObject coloredKey;

    public int state = 0;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == firstKey)
        {
            state++;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
            coloredKey.GetComponent<RectTransform>().anchoredPosition =
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;
        }
        else {
            if (eventData.pointerDrag == secondKey)
            {
                state++;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
                coloredKey.GetComponent<RectTransform>().anchoredPosition =
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;

            }
        }

        if(state == 2)
        {
            secondKey.SetActive(false);
            firstKey.SetActive(false);
            coloredKey.SetActive(true);
        }
    }

    // Start is called before the first frame update
   
    // Update is called once per frame
   
}
