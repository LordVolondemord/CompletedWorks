using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossController : MonoBehaviour
{
    float horizon;
    float vertical;
    float timer;

    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        horizon = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //Debug.Log(horizon +" "+ vertical);
    }

    private void FixedUpdate()
    {
        if(horizon != 0 || vertical != 0)
        {
            if (timer <= 0)
            {
                rect.position += new Vector3(horizon * 0.5f, vertical * 0.5f, 0);
                Debug.Log(rect.position);
                timer = 0.2f;
            }
        }
       
        timer -= Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(collision.gameObject);
    }
}
