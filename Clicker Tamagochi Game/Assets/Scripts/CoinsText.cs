using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsText : MonoBehaviour
{
    TMP_Text mytext;

    private void OnEnable()
    {
        mytext = GetComponent<TMP_Text>();
        GameData.Instance.OnCoinsAdd += UpdateText;
        GameData.Instance.OnCoinsSpend += UpdateTextNegative;
        GameData.Instance.AddCoins(0);
    }

    private void OnDisable()
    {
        GameData.Instance.OnCoinsAdd -= UpdateText;
        GameData.Instance.OnCoinsSpend -= UpdateTextNegative;
    }

    void UpdateText(float coins)
    {
        mytext.text = "Монетки = " + coins;
        mytext.color = Color.black;
    }

    void UpdateTextNegative(float coins, bool success)
    {
        UpdateText(coins);
        if (success == false) mytext.color = Color.red;
    }



}
