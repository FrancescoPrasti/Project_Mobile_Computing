using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public static int mana;
    public Image[] manaV;

    public Sprite manaPieno;
    public Sprite manaVuoto;

    void Awake()
    {
        mana = 3;
    }

    void FixedUpdate()
    {
        foreach (Image img in manaV)
        {
            img.sprite = manaVuoto;
        }

        for (int i = 0; i < mana; i++)
        {
            manaV[i].sprite = manaPieno;
        }
    }

}
