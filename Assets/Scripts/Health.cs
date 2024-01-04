using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public int health = 3;
    public Image[] cuori;

    public Sprite cuorePieno;
    public Sprite cuoreVuoto;
    
    void FixedUpdate()
    {
        foreach(Image img in cuori)
        {
            img.sprite = cuoreVuoto;
        }

        for(int i = 0; i < health; i++)
        {
            cuori[i].sprite = cuorePieno;
        }

    }
}
