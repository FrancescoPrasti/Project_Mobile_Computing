using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDrop : MonoBehaviour
{
    public GameObject[] itemDrops;
    private bool itemDropped = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(itemDropped == false)
        {
            if (collision.transform.tag == "Player")
            {
                ItemDrop();
                itemDropped = true;
            }
        }
    }

    private void ItemDrop()
    {
        for(int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
