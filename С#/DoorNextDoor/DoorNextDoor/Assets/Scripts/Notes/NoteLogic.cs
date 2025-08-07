using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteLogic : MonoBehaviour
{
    public int noteIndex;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenNote);
    }

    void OpenNote()
    {
        MainUI.Instance.OpenNote(noteIndex);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
