using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoActive : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<DoorLogic>().ActiveButton();
    }

}
