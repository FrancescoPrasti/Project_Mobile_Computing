using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoIniziale : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject DialogueBox;
    public bool primoUtilizzo;

    void Start()
    {
        if (primoUtilizzo)
        {
            DialogueBox.SetActive(true);
            trigger.StartDialogue();
        }
        else
        {
            Destroy(this);
        }
    }
}
