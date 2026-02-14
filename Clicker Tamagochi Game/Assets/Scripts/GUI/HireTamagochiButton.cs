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
        TamagochiSelectState tss = FindObjectOfType<TamagochiSelectState>();
        GameManager.Instance.SwitchState(tss);
    }


    void UpdateInfoOnState(GameState state)
    {
        if (state is TamagochiSelectState) DisplayInfo();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.Instance.OnDeactivate += UpdateInfoOnState;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.Instance.OnDeactivate -= UpdateInfoOnState;
    }


    protected override void DisplayInfo()
    {
        float price = GetPrice();
        priceText.text = $"[{CoinsFormatter.Convert(price, "#.#")}]";
        int level = GetLevel();
        
        if (price < 0)
        {
            button.interactable = false;
            priceText.text = "[Максимум работников]";
        }
        else
        {
            button.interactable = true;
        }
        DisplayUpgradeLevel(level);
    }

}
