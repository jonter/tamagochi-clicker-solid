using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] TMP_Text _coinsText;
    [SerializeField] TMP_Text _upgradeText;

    int _coins = 0;
    int _upgrades = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _coins += 1 + _upgrades;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(_coins >= 30)
            {
                _coins -= 30;
                _upgrades += 1;
            }
        }

        _coinsText.text = "Монетки: " + _coins;
        _upgradeText.text = "Прокачка: " + _upgrades;
        
    }
}
