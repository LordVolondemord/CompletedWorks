using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingsEasy : MonoBehaviour
{
    public SignLogic[] signs;
    // Start is called before the first frame update
    void Start()
    {
        foreach (SignLogic sign in signs)
        {
            sign.canUse = true;
           
        }
    }
}
