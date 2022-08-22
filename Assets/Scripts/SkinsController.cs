using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController : MainMenu
{
    [SerializeField] GameObject[] Skins;
    // на каждом скрипте висят SerializeField менюшки и плейер контроллера, плюс я тут делаю через Update, а так работает, круто!!!

    // PlayerPrefs - сохранение скина и количества монет, открытых скинов

    void Update()
    {
        for (int i = 0; i < Skins.Length; i++)
        { 
            Skins[i].SetActive(false);
        }

        Skins[materialNum].SetActive(true);
    }
}
