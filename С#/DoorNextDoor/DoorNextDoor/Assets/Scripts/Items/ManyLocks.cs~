using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyLocks : MonoBehaviour
{
    public DoorLogic door;
    public GameObject[] locks;

    // Update is called once per frame
    void Update()
    {
       foreach(GameObject oneLock in locks)
        {
            if (oneLock) return;
        }

        door.ActiveButton();
    }
}
