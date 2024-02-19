using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public float textSpeed;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        DisplayMessage();

    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        StartCoroutine(BuildText(messageToDisplay));
        //messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            messageText.text = string.Empty;
            DisplayMessage();
        }
        else
        {
            messageText.text = string.Empty;
            isActive = false;
            this.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch t = Input.GetTouch(0);
        if(t.phase == UnityEngine.TouchPhase.Began /*Input.GetMouseButtonDown(0)*/ && isActive) 
        {
            NextMessage();
        }
    }

    IEnumerator BuildText(Message messageToDisplay)
    {
        foreach (char c in messageToDisplay.message.ToCharArray())
        {
            messageText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
