using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignLogic : MonoBehaviour
{
    public bool canUse;

    private void Awake()
    {
        canUse = false;
    }

    public void Use()
    {
        if (canUse) Destroy(gameObject);
    }

}
