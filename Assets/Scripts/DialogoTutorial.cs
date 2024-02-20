using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTutorial : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject DialogueBox;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        DialogueBox.SetActive(true);
        trigger.StartDialogue();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        DialogueBox.SetActive(true);
        trigger.StartDialogue();
    }*/
}
