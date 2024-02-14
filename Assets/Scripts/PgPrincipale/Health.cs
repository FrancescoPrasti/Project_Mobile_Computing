using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public static int health;
    public static int cuoriColorati = 3;
    public Image[] cuori;

    public Sprite cuorePieno;
    public Sprite cuoreVuoto;

     void Awake()
    {
        health = 3;
        if (cuoriColorati < 3)
            health = cuoriColorati;
    }



    void FixedUpdate()
    {
        foreach (Image img in cuori)
        {
            img.sprite = cuoreVuoto;
        }

        for(int i = 0; i < health; i++)
        {
            cuori[i].sprite = cuorePieno;
        }

    }
}
