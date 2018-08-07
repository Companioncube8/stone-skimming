using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyChange : MonoBehaviour {

    private static int money = 600;
    private static int offline = 300;
    public GameObject player;
    [SerializeField] private Text Cash;
    public static int strenghtPrice = 300;
    public static int speedPrice = 300;
    public static int skippingPrice = 300;
    public GameObject shop;
    public static int offlinePrice = 300;


    public void Start()
    {
        Cash.text = ("Money: " + money);
    }

    public void Collect()
    {
        money += (int)player.GetComponent<MoveRock>().transform.position.z;
        Cash.text = ("Money: " + money);
        player.GetComponent<SavePrefs>().setLevelRestart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MoneyPlus(int price)
    {
        money += price;
        Cash.text = ("Money: " + money);
    }

    public void MoneyMinus(int price)
    {
        money -= price;
        Cash.text = ("Money: " + money);
    }

    public void StrenghtBuy()
    {
        if (strenghtPrice <= money)
        {
            player.GetComponent<MoveRock>().strenghtUp();
            MoneyMinus(strenghtPrice);
            strenghtPrice += strenghtPrice / 10;
            shop.GetComponent<Shop>().changePrice(strenghtPrice, 1);
            player.GetComponent<SavePrefs>().SaveInfo();
        }
    }


    public void SpeedBuy()
    {

        if (speedPrice <= money)
        {
            player.GetComponent<MoveRock>().speedUp();
            MoneyMinus(speedPrice);
            speedPrice += speedPrice / 10;
            shop.GetComponent<Shop>().changePrice(speedPrice, 2);
            player.GetComponent<SavePrefs>().SaveInfo();
        }
    }

    public void SkippingBuy()
    {
        if (skippingPrice <= money)
        {
            player.GetComponent<MoveRock>().skippingUp();
            MoneyMinus(skippingPrice);
            skippingPrice += skippingPrice / 10;
            shop.GetComponent<Shop>().changePrice(skippingPrice, 3);
            player.GetComponent<SavePrefs>().SaveInfo();
        }
    }

    public void offlineBuy()
    {
        if (offlinePrice <= money)
        {
            offline += 10;
            MoneyMinus(offlinePrice);
            offlinePrice += offlinePrice / 10;
            shop.GetComponent<Shop>().changePrice(offlinePrice, 4);
            player.GetComponent<SavePrefs>().SaveInfo();
        }
    }

    public int offlineReturn()
    {
        return (offline);
    }

    public int moneyReturn()
    {
        return (money);
    }

    public void offlineSet(int newOffline)
    {
        offline = newOffline;
    }

    public void moneySet(int newMoney)
    {
        money = newMoney;
    }

    public int skippingPriceGet()
    {
        return (skippingPrice);
    }
    public int speedPriceGet()
    {
        return (speedPrice);
    }
    public int offlinePriceGet()
    {
        return (offlinePrice);
    }
    public int strenghtPriceGet()
    {
        return (strenghtPrice);
    }
    public void skippingPriceSet(int _skippingPrice)
    {
        skippingPrice = _skippingPrice;
    }
    public void speedPriceSet(int _speedPrice)
    {
        speedPrice = _speedPrice;
    }
    public void offlinePriceSet(int _offlinePrice)
    {
        offlinePrice = _offlinePrice;
    }
    public void strenghtPriceSet(int _strenghtPrice)
    {
        strenghtPrice = _strenghtPrice;
    }
}
