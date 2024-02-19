using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public Button openButton;
    public GameObject[] itemDrops;

    void FixedUpdate()
    {
        /*if(this.tag == "ChestStanza1" && Demon.enemyHP <= 0){
            Debug.Log("Seee");
            this.gameObject.SetActive(true);
        }*/
    }
    public void openChest()
    {
        animator.SetTrigger("Open");
        AudioManager.instance.Play("ChestOpen");
        openButton.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.tag == "ChestStanza1")
        {
            if (collision.gameObject.tag == "Player" && HealthManager.health > 0 && Demon.enemyHP <= 0)
                openButton.gameObject.SetActive(true);
        }
        else if (collision.gameObject.tag == "Player" && HealthManager.health > 0)
        {
            openButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            openButton.gameObject.SetActive(false);
        }
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

}
