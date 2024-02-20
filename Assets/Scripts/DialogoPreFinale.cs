using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogoPreFinale : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject DialogueBox;
    bool primoUtilizzo = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (primoUtilizzo)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
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
