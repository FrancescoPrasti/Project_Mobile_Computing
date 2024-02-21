using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    public void setStato()
    {
        HealthManager.health = 3;
        HealthManager.cuoriColorati = 3;
        ManaManager.mana = 3;
        ManaManager.manaColorati = 3;
    }
}
