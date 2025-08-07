using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralRotate : MonoBehaviour
{
    RectTransform rect;
    public float rotateSpeed = 40f;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

   
    void Update()
    {
        rect.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
