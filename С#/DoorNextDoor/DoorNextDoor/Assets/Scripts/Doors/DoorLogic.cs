using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorLogic : MonoBehaviour
{
    public float pitchChange = 0f;

    DoorController control;
    Button button;
    Animator anim;


    void Start()
    {
        control = GetComponentInParent<DoorController>();
        button = GetComponent<Button>();
        anim = GetComponent<Animator>();
        button.enabled = false;

        if (button) button.onClick.AddListener(Open);
    }

    public void ActiveButton() => button.enabled = true;

    public void Open()
    {
        AudioManager.Instance.PlaySound("Door");
        anim.Play("Open");
        StartCoroutine(NextDoorDelay());
    }

    IEnumerator NextDoorDelay()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.ChangePitch(pitchChange);
        control.NextDoor();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
