using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonRAM : UpgradeButtonCPU
{
    protected override bool CheckBuy()
    {
        return GameData.Instance.computer.UpgradeRAM();
    }

    protected override int GetLevel()
    {
        return GameData.Instance.computer.RAMLevel;
    }

    protected override float GetPrice()
    {
        return GameData.Instance.computer.RAMPrice;
    }

    protected override void DisplayUpgradeLevel(int level)
    {
        float herts = level * level * 24;
        string str = " MB";
        if (herts >= 1000)
        {
            herts /= 1000;
            str = " GB";
        }
        string h = herts.ToString("#.#");

        infoText.text = h + str;
    }

}
