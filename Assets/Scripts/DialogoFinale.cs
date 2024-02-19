using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogoFinale : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject DialogueBox;
    //bool primoUtilizzo = true;

    /*private IEnumerator OnTriggerEnter2D(Collider2D collision)
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
    }*/
}
