using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTrigger : MonoBehaviour
{
    [SerializeField]
    LevelChanger levelChanger;

    [SerializeField]
    int level;

    [SerializeField]
    float timeToChange;

    private void Start()
    {
        StartCoroutine(DelayChange(timeToChange));
    }

    IEnumerator DelayChange(float time)
    {
        yield return new WaitForSeconds(time);
        levelChanger.FadeToLevel(level);
    }
}
