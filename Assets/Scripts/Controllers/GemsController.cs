using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsController : MonoBehaviour
{
    public static int money; // статика = красный флаг? или для гемов норм
    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        Debug.Log(PlayerPrefs.GetInt("money"));
        Debug.Log(money);
    }
    public static void CountMoney()
    {
        money++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        PlayerPrefs.Save();
    }
}
