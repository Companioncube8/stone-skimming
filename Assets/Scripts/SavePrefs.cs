using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SavePrefs : MonoBehaviour {

    public GameObject shop;
    public static bool isLevelRestart = false;

    void OnApplicationQuit()
    {
        SaveInfo();
    }

    public void SaveInfo() {
        string begin = DateTime.Now.ToString();
        PlayerPrefs.SetString("Time", begin);
        PlayerPrefs.SetFloat("strenght", GetComponent<MoveRock>().strenghtReturn());
        PlayerPrefs.SetFloat("speed", GetComponent<MoveRock>().speedReturn());
        PlayerPrefs.SetFloat("skipping", GetComponent<MoveRock>().skippingReturn());
        PlayerPrefs.SetInt("offline", shop.GetComponent<MoneyChange>().offlineReturn());
        PlayerPrefs.SetInt("strenght price", shop.GetComponent<MoneyChange>().strenghtPriceGet());
        PlayerPrefs.SetInt("skipping price", shop.GetComponent<MoneyChange>().skippingPriceGet());
        PlayerPrefs.SetInt("offline price", shop.GetComponent<MoneyChange>().offlinePriceGet());
        PlayerPrefs.SetInt("speed price", shop.GetComponent<MoneyChange>().speedPriceGet());
        PlayerPrefs.SetInt("money", shop.GetComponent<MoneyChange>().moneyReturn());

        PlayerPrefs.Save();
    }

    public void setLevelRestart()
    {
        isLevelRestart = true;
    }

    private void Awake()
    {
        if (!isLevelRestart){
            if (PlayerPrefs.HasKey("Time"))
            {
                shop.GetComponent<MoneyChange>().moneySet(0);
                DateTime now = DateTime.Now;
                DateTime begin;
                string TimefromSave = PlayerPrefs.GetString("Time");
                DateTime.TryParse(TimefromSave, out begin);
                TimeSpan elapsedSpan = new TimeSpan(now.Ticks - begin.Ticks);
                shop.GetComponent<MoneyChange>().MoneyPlus((int)((int)(elapsedSpan.TotalMinutes) * (shop.GetComponent<MoneyChange>().offlineReturn() / 60)));
            }
            if (PlayerPrefs.HasKey("strenght"))
                GetComponent<MoveRock>().strenghtSet(PlayerPrefs.GetFloat("strenght"));
            if (PlayerPrefs.HasKey("speed"))
                GetComponent<MoveRock>().speedSet(PlayerPrefs.GetFloat("speed"));
            if (PlayerPrefs.HasKey("skipping"))
                GetComponent<MoveRock>().skippingSet(PlayerPrefs.GetFloat("skipping"));
            if (PlayerPrefs.HasKey("strenght price"))
                shop.GetComponent<MoneyChange>().offlineSet(PlayerPrefs.GetInt("offline"));
            if (PlayerPrefs.HasKey("offline"))
                shop.GetComponent<MoneyChange>().strenghtPriceSet(PlayerPrefs.GetInt("strenght price"));
            if (PlayerPrefs.HasKey("skipping price"))
                shop.GetComponent<MoneyChange>().skippingPriceSet(PlayerPrefs.GetInt("skipping price"));
            if (PlayerPrefs.HasKey("offline price"))
                shop.GetComponent<MoneyChange>().offlinePriceSet(PlayerPrefs.GetInt("offline price"));
            if (PlayerPrefs.HasKey("speed price"))
                shop.GetComponent<MoneyChange>().speedPriceSet(PlayerPrefs.GetInt("speed price"));
            if (PlayerPrefs.HasKey("money"))
            {
                shop.GetComponent<MoneyChange>().MoneyPlus(PlayerPrefs.GetInt("money"));
            }
        }
    }

}
