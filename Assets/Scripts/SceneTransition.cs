using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    FadeInOut fade;
    public string sceneToLoad;
    public Button TransitionButton;


    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();

        
        
    }

    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
       
        SceneManager.LoadScene(sceneToLoad);
        
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
           
           TransitionButton.gameObject.SetActive(true);


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           
            TransitionButton.gameObject.SetActive(false);

        }
    }

    public void Transizione()
    {
        
        StartCoroutine(ChangeScene());
        
       
        
        

    }
}
