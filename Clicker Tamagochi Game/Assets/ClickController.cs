using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickController : MonoBehaviour
{
    [SerializeField] TMP_Text _coinsText;
    [SerializeField] TMP_Text _upgradeText;

    GameData data;

    // Start is called before the first frame update
    void Start()
    {
        data = SaveSystem.Data;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            data.Coins += data.CoinsPerClick;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(data.Coins >= 30)
            {
                data.Coins -= 30;
                data.CoinsPerClick += 1;
            }
        }

        _coinsText.text = "Монетки: " + data.Coins;
        _upgradeText.text = "Прокачка: " + data.CoinsPerClick;
        
    }
}
