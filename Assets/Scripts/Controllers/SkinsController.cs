using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController 
{ 
    private GameObject[] _skins;

    public SkinsController(GameObject[] skins)
    {
        _skins = skins;
    }
    public void Start()
    {
        Actions.OnGameStateChange += UpdateSkins;
    }

    public void UpdateSkins(StateController.gameState gameState)
    {
        if (gameState == StateController.gameState.changeSkin)
        {
            for (int i = 0; i < _skins.Length; i++)
            {
                _skins[i].SetActive(false);
            }
            _skins[PlayerPrefs.GetInt("Skin")].SetActive(true);
        }
    }
}