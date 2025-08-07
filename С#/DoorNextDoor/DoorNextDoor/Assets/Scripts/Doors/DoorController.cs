using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrabStuff;

public class DoorController : MonoBehaviour
{
    public GameObject[] doors;
    int doorIndex;

    void Start()
    {
        doorIndex = 0;
        NextDoor();
    }

    public void NextDoor()
    {
        if (doorIndex == doors.Length) Loader.NextLevel();
        else Instantiate(doors[doorIndex++], transform);
    }
}
