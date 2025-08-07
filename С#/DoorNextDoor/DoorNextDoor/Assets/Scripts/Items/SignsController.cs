using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignsController : MonoBehaviour
{
    public SignLogic[] signs;


    void Update()
    {
        foreach(SignLogic sign in signs)
        {
            if (sign) {
                sign.canUse = true;
                return;
            }
        }
    }


}
