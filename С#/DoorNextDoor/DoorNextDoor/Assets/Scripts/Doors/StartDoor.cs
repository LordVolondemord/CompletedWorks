using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CrabStuff;

public class StartDoor : MonoBehaviour
{
    Button button;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        anim = GetComponent<Animator>();

        button.onClick.AddListener(Open);
    }

    public void Open()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        anim.Play("Open");
        AudioManager.Instance.PlaySound("Door");
        yield return new WaitForSeconds(1f);
        Loader.NextLevel();
    }


}
