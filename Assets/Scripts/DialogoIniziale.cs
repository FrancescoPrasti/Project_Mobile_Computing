using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoIniziale : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject DialogueBox;
    bool primoUtilizzo = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (primoUtilizzo)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            DialogueBox.SetActive(true);
            trigger.StartDialogue();
            primoUtilizzo = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
