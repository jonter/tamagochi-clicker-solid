using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonSetup : UpgradeButtonCPU
{
    protected override bool CheckBuy()
    {
        return GameData.Instance.computer.UpgradeSetup();
    }

    protected override int GetLevel()
    {
        return GameData.Instance.computer.SetupLevel;
    }

    protected override float GetPrice()
    {
        return GameData.Instance.computer.GetSetupPrice();
    }

    protected override void DisplayUpgradeLevel(int level)
    {
        string label = "Бюждетный ПК";
        if (level == 1) label = "Игровой ПК";
        if (level == 2) label = "Суперкомьютер";
        if (level == 3) label = "Квантовый ПК";

        infoText.text = label;
    }

    protected override void DisplayInfo()
    {
        int level = GetLevel();
        if(level >= 3)
        {
            priceText.text = "[-MAX-]";
            button.interactable = false;
            DisplayUpgradeLevel(3);
        }
        else
        {
            float price = GetPrice();
            priceText.text = $"[{CoinsFormatter.Convert(price, "#.#")}]";
            button.interactable = true;
            DisplayUpgradeLevel(level);
        }
    }

}
