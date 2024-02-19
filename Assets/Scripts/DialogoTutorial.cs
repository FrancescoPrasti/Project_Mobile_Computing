using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTutorial : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject DialogueBox;

    void Start()
    {
        DialogueBox.SetActive(true);
        trigger.StartDialogue();
        
    }
}
