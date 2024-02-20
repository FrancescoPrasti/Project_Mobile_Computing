using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    FadeInOut fade;
    public string sceneToLoad;
    public string actualScene;
    public Button TransitionButton;

    //public new Vector3 posRitorno;
    private GameObject player;
    public PlayerManager playerManager;

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        //playerManager.posIniziale = posRitorno;
        //player.transform.position = posRitorno;
        SceneManager.LoadScene(sceneToLoad);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
           TransitionButton.gameObject.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            TransitionButton.gameObject.SetActive(false);

        }
    }

    public void Transizione()
    {
        //playerManager.posIniziale = new Vector3(38.4f, -0.03f, 0);
        if(sceneToLoad.Equals("Castello") && actualScene.Equals("SampleScene"))
            PlayerManager.lastCheckPointPos = new Vector3(41.14154f, -15.2566f, 0);
        else if(sceneToLoad.Equals("SampleScene") && actualScene.Equals("Castello"))
            PlayerManager.lastCheckPointPos = new Vector3(38.4f, -0.03f, 0);
        else if(sceneToLoad.Equals("Stanza1") && actualScene.Equals("Castello"))
            PlayerManager.lastCheckPointPos = new Vector3(1.65f, 1.876995f, 0);
        else if(sceneToLoad.Equals("Castello") && actualScene.Equals("Stanza1"))
            PlayerManager.lastCheckPointPos = new Vector3(60.48f, -15.75f, 0);
        else if(sceneToLoad.Equals("Stanza2") && actualScene.Equals("Castello"))
            PlayerManager.lastCheckPointPos = new Vector3(-10.31241f, -1.948063f, 0);
        else if(sceneToLoad.Equals("Castello") && actualScene.Equals("Stanza2"))
            PlayerManager.lastCheckPointPos = new Vector3(21.86f, -15.75f, 0);
        else if(sceneToLoad.Equals("SampleScene") && actualScene.Equals("Menu"))
            PlayerManager.lastCheckPointPos = new Vector3(-12.4f, -3.838769f, 0);

        StartCoroutine(ChangeScene());
    }
}
