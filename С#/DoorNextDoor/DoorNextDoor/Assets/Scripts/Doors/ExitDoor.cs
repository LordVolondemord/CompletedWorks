using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CrabStuff;

public class ExitDoor : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Open);
    }

    public void Open()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        AudioManager.Instance.PlaySound("Door");
        yield return new WaitForSeconds(0.3f);
        Loader.ToMainMenu();
    }
}
