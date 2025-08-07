using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorSquare : MonoBehaviour, IDropHandler
{
    //public GameObject key;
    public GameObject coloredKey;
    public bool isActive = true;
    public Image imageBox;
    public Sprite emptyBox;

    public void OnDrop(PointerEventData eventData)
    {
        if (isActive)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
            coloredKey.SetActive(true);
            eventData.pointerDrag.SetActive(false);
            GetComponent<Image>().enabled = false;
            imageBox.sprite = emptyBox;

            isActive = false;
        }     
    }

}
