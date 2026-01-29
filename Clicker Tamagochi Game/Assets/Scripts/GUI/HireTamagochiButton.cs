using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireTamagochiButton : UpgradeButtonCPU
{
    protected override float GetPrice()
    {
        return GameData.Instance.GetTamagochiPrice();
    }

    protected override int GetLevel()
    {
        return GameData.Instance.tamagochies.Length;
    }

    protected override bool CheckBuy()
    {
        return GameData.Instance.BuyTamagochi();
    }

    protected override void DisplayUpgradeLevel(int level)
    {
        infoText.text = "" + level;
    }

    protected override void OnSuccess()
    {
        GameObject posObj = GameObject.Find("TamagochiShop Position");
        Camera.main.transform.DOMove(posObj.transform.position, 1);
        Camera.main.transform.DORotate(posObj.transform.eulerAngles, 1);
        FindAnyObjectByType<TamagochiSelector>().Activate();
    }


}
