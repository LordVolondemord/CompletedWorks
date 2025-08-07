using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField]
    LevelChanger levelChanger;

    [SerializeField]
    int level;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) levelChanger.FadeToLevel(level);
    }
}
