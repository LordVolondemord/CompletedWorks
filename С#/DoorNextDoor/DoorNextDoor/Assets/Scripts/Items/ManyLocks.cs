using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyLocks : MonoBehaviour
{
    DoorLogic door;
    public GameObject[] locks;


    private void Start()
    {
        door = GetComponent<DoorLogic>();
    }
    // Update is called once per frame
    void Update()
    {
       foreach(GameObject oneLock in locks)
        {
            if (oneLock) return;
        }
        Debug.Log("active");
        door.ActiveButton();
    }
}
