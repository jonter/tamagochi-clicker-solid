using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UpgradeButtonCPU : MonoBehaviour
{
    [SerializeField] protected TMP_Text priceText;
    protected Button button;

    Vector3 startPos;
    RectTransform rect;
    [SerializeField] float animTime = 0.1f;

    [SerializeField] protected TMP_Text infoText;

    private void OnEnable()
    {
        rect = GetComponent<RectTransform>(); 
        button = GetComponent<Button>();
        DisplayInfo();
        startPos = rect.anchoredPosition;
        button.onClick.AddListener(OnButtonClick);
        GameData.Instance.computer.OnSetupUpgrade += UpdateInfoOnSetup;
    }

    private void OnDisable()
    {
        rect.DOKill();
        button.onClick.RemoveListener(OnButtonClick);
        GameData.Instance.computer.OnSetupUpgrade -= UpdateInfoOnSetup;
    }

    void UpdateInfoOnSetup(int level)
    {
        DisplayInfo();
    }

    void OnButtonClick()
    {
        bool success = CheckBuy();
        rect.DOKill();
        rect.anchoredPosition = startPos;
        rect.localScale = new Vector3(1, 1, 1);
        if (success)
        {
            // сыграть позитивный звук
            rect.DOScale(1.1f, animTime).SetLoops(2, LoopType.Yoyo);
            rect.DOAnchorPosY(rect.anchoredPosition.y + 20, animTime)
                .SetLoops(2, LoopType.Yoyo);
            OnSuccess();
        }
        else
        {
            // сыграть негативный звук
            Hints.Show("Недостаточно денег :(");
            rect.DOScale(0.9f, animTime).SetLoops(2, LoopType.Yoyo);
        }
    }

    protected virtual void OnSuccess()
    {
        DisplayInfo();
    }

    protected virtual bool CheckBuy()
    {
        return GameData.Instance.computer.UpgradeCPU();
    }

    protected virtual float GetPrice()
    {
        return GameData.Instance.computer.CPUPrice;
    }

    protected virtual int GetLevel()
    {
        return GameData.Instance.computer.CPULevel;
    }
    
    protected virtual void DisplayInfo()
    {
        float price = GetPrice();
        priceText.text = $"[{CoinsFormatter.Convert(price, "#.#")}]";
        int level = GetLevel();
        bool checkMax = GameData.Instance.computer.CheckLevelLimit(level);
        if (checkMax)
        {
            button.interactable = false;
            priceText.text = "[Достигнут лимит]";
        }
        else
        {
            button.interactable = true;
        }
        DisplayUpgradeLevel(level);
    }

    protected virtual void DisplayUpgradeLevel(int level)
    {
        float herts = level * level * 12;
        string str = " MHz";
        if(herts >= 1000)
        {
            herts /= 1000;
            str = " GHz";
        }
        string h = herts.ToString("#.##");

        infoText.text = h + str;
    }

}
