using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditRoll : MonoBehaviour
{
    public float waitTime = 5f;
    public float rollSpeed = 5f;

    public float stopTimer = 100f;
    float Timer;

    bool isMove;
    void Start()
    {
        isMove = false;
        StartCoroutine(WaitAndMove(waitTime));
        Timer = 0;
    }

    void Update()
    {
        if (isMove && Timer < stopTimer)
        {
            transform.Translate(Vector3.up * rollSpeed * Time.deltaTime);
            Timer += Time.deltaTime;
        }
    }

    IEnumerator WaitAndMove(float time)
    {
        yield return new WaitForSeconds(time);
        isMove = true;
    }
}
