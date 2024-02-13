using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    FadeInOut fade;
    public string sceneToLoad;
    public Button TransitionButton;

    public new Vector3 posRitorno;
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
        StartCoroutine(ChangeScene());

    }
}
