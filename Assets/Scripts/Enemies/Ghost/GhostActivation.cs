using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostActivation : MonoBehaviour
{
    public GameObject ghost;
    GameObject target;
    GameObject go = null;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && go == null)
        {
            if(this.tag == "Activation1")
                go = Instantiate(ghost, new Vector2(31.68f, -14.21f), ghost.transform.rotation);
            else if(this.tag == "Activation2")
                go = Instantiate(ghost, new Vector2(50.9f, -14.21f), ghost.transform.rotation);

            yield return new WaitForSeconds(0.5f);
            go.GetComponent<Animator>().SetBool("idle", true);
        }
        else if(collision.transform.tag == "Player" && go.GetComponent<Animator>().GetBool("idle") == true)
        {
            go.GetComponent<Animator>().SetTrigger("vanish");
            yield return new WaitForSeconds(0.7f);
            Destroy(go);
            go = null;
        }
        /*else if(collision.transform.tag == "Player" && go.GetComponent<Animator>().GetBool("idle") == false)
        {
            go.GetComponent<Animator>().SetBool("idle", true);
        }*/
    }
}
