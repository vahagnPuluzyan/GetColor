using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    string dance = "";
    int price;
    int haved = 0;
    Text priceText;
    Image diamondImage;
    RawImage danceImage;
    Image background;
    int diamonds = 0;

    private void Start()
    {
        //Ինտիլիզացիա
        diamonds = PlayerPrefs.GetInt("Diamonds");
        priceText = GetComponentInChildren<Text>();
        diamondImage = priceText.GetComponentInChildren<Image>();
        danceImage = diamondImage.GetComponentInChildren<RawImage>();
        background = GetComponent<Image>();
        danceImage.enabled = false;

        haved = PlayerPrefs.GetInt(name);

        //եթտ ունենք ուրեմն ցույց ենք տալիս
        if (haved == 1)
        {
            priceText.enabled = false;
            diamondImage.enabled = false;
            danceImage.enabled = true;

        }

    }
    //գտնում ենք գինը
    public void GetPrice(string priceStr)
    {
        int.TryParse(priceStr, out price);
    }

    public void BuyDance(string name)
    {
        diamonds = PlayerPrefs.GetInt("Diamonds");
        //եթե բռլիանտը հերիքումա ու չունենք
        if (diamonds >= price && haved == 0)
        {
            priceText.enabled = false;
            diamondImage.enabled = false;
            danceImage.enabled = true;
            PlayerPrefs.SetInt("Diamonds", diamonds-price);
            PlayerPrefs.SetString("Dance", name);
            haved = 1;
            PlayerPrefs.SetInt(name, haved);
        }
        //եթե սխմելու ժամանակ ունենք
        if (haved == 1)
        {
            PlayerPrefs.SetString("Dance", name);
            StartCoroutine(ChangeColorBlue());
        }
        //եթե բռլիանտ չունենք
        if (diamonds < price)
        {
            //եթե ապրանքնել չունենք
            if (haved == 0) {
                StartCoroutine(ChangeColorRed());
            }
        }
    }
    //գույնը փոխել կարմիր
    IEnumerator ChangeColorRed()
    {
        background.color = new Color(background.color.r + 30, background.color.g, background.color.b, 1f);
        yield return new WaitForSecondsRealtime(1f);
        background.color = new Color(background.color.r - 30, background.color.g, background.color.b, 1f);
    }
    //գույնը փոխել կապույտ
    IEnumerator ChangeColorBlue()
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b + 30, 1f);
        yield return new WaitForSecondsRealtime(1f);
        background.color = new Color(background.color.r, background.color.g, background.color.b - 30, 1f);
    }
}