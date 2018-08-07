using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public Text Description;
    public GameObject player;
    public GameObject canvas;

    public GameObject buyStrenght;
    public GameObject buySkipping;
    public GameObject buySpeed;
    public GameObject buyOffline;

    public Text Price;

    public void Start()
    {
        buyStrenght.SetActive(false);
        buySkipping.SetActive(false);
        buySpeed.SetActive(false);
        buyOffline.SetActive(false);
    }

    public void changePrice(int price, int point)
    {
        Price.text = ("Price: " + price);
        if (point == 1)
            Description.text = ("Throw " + (((player.GetComponent<MoveRock>().strenghtReturn()) - 10) / 10) * 100 + "% harder");
        if (point == 2)
            Description.text = ("Stones go " + (((player.GetComponent<MoveRock>().speedReturn()) - 10) / 10) * 100 + "% faster");
        if (point == 3)
            Description.text = ("Stones skip " + (((player.GetComponent<MoveRock>().skippingReturn()) - 6) / 6) * 100 + "% more");
        if (point == 4)
            Description.text = ("Earning " + canvas.GetComponent<MoneyChange>().offlineReturn() + " per hour");
    }

    public void BuyButtonOff()
    {
        buyStrenght.SetActive(false);
        buySkipping.SetActive(false);
        buySpeed.SetActive(false);
        buyOffline.SetActive(false);
    }

    public void strenghtClickOn()
    {
        BuyButtonOff();
        changePrice(canvas.GetComponent<MoneyChange>().strenghtPriceGet(), 1);
        buyStrenght.SetActive(true);
    }

    public void skippingClickOn()
    {
        BuyButtonOff();
        changePrice(canvas.GetComponent<MoneyChange>().skippingPriceGet(), 3);
        buySkipping.SetActive(true);
    }

    public void speedClickOn()
    {
        BuyButtonOff();
        changePrice(canvas.GetComponent<MoneyChange>().speedPriceGet(), 2);
        buySpeed.SetActive(true);
    }

    public void offlineClickOn()
    {
        BuyButtonOff();
        changePrice(canvas.GetComponent<MoneyChange>().offlinePriceGet(), 4);
        buyOffline.SetActive(true);
    }

}
