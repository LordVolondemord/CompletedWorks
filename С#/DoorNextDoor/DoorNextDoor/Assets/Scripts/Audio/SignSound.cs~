using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSound : MonoBehaviour
{
    [SerializeField]
    string[] sounds;
    //private InteractiveObject interact;

    void Start()
    {
        //interact = transform.GetComponent<InteractiveObject>();
        //interact.OnInteract += PlaySound;
    }

    private void PlaySound(object sender, System.EventArgs e)
    {
        int index = Random.Range(0, sounds.Length);
        AudioManager.Instance.PlaySound(sounds[index]);
    }
}
