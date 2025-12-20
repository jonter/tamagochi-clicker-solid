using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonVC : UpgradeButtonCPU
{
    protected override bool CheckBuy()
    {
        return GameData.Instance.computer.UpgradeVC();
    }

    protected override int GetLevel()
    {
        return GameData.Instance.computer.VCLevel;
    }

    protected override float GetPrice()
    {
        return GameData.Instance.computer.VCPrice;
    }

    protected override void DisplayUpgradeLevel(int level)
    {
        float herts = level * level * 6;
        string str = " Fl";
        if (herts >= 1000)
        {
            herts /= 1000;
            str = " TFl";
        }
        string h = herts.ToString("#.#");

        infoText.text = h + str;
    }
}
