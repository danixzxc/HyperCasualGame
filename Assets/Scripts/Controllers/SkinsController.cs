using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController 
{ 
    private GameObject[] Skins; 

    public void UpdateSkins(GameObject[] skins) 
    {
        Skins = skins;

        for (int i = 0; i < Skins.Length; i++)
        { 
            Skins[i].SetActive(false);
        }
        Skins[PlayerPrefs.GetInt("Skin")].SetActive(true);

    }
}