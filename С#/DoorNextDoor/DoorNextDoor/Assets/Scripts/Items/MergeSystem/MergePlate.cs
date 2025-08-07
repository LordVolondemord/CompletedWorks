using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergePlate : MonoBehaviour
{
    public MergeHolder holder1;
    public MergeHolder holder2;
    public GameObject coloredKey;

    bool canMerge = true;

    void Update()
    {
        if(holder1.isHold && holder2.isHold && canMerge)
        {
            holder1.holdKey.SetActive(false);
            holder2.holdKey.SetActive(false);

            coloredKey.SetActive(true);
            canMerge = false;
        }
    }
}
