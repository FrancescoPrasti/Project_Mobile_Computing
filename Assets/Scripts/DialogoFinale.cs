using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoFinale : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject DialogueBox;
    bool primoUtilizzo = true;

    public void Fin()
    {
        if (primoUtilizzo)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            DialogueBox.SetActive(true);
            trigger.StartDialogue();
            DialogueManager.finale = true;
            primoUtilizzo = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
