using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickController : MonoBehaviour
{
    GameData data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameData.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            data.AddCoins(data.CoinsPerClick);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            bool success = data.SpendCoins(30);
            if (success) data.CoinsPerClick++;
        }

       
    }
}
