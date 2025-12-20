using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinsDisplay : MonoBehaviour
{
    TMP_Text coinsText;

    [SerializeField] float jumpAnimTime = 0.1f;
    [SerializeField] float jumpHeight = 20;
    Vector3 startTextPos;

    private void OnEnable()
    {
        
        coinsText = GetComponentInChildren<TMP_Text>();
        GameData.Instance.OnCoinsAdd += DisplayCoins;
        GameData.Instance.OnCoinsSpend += DisplayCoins;
        startTextPos = coinsText.rectTransform.localPosition;   
        GameData.Instance.AddCoins(0);
    }

    private void OnDisable()
    {
        GameData.Instance.OnCoinsAdd -= DisplayCoins;
        GameData.Instance.OnCoinsSpend -= DisplayCoins;
        coinsText.rectTransform.DOKill();
    }

    void DisplayCoins(float coins)
    {
        coinsText.text = CoinsFormatter.Convert(coins);
        AnimTextJump();
    }

    void AnimTextJump()
    {
        coinsText.rectTransform.DOKill();
        coinsText.rectTransform.localPosition = startTextPos;
        coinsText.rectTransform.DOLocalMoveY(jumpHeight, jumpAnimTime)
            .SetLoops(2, LoopType.Yoyo);
    }


    void DisplayCoins(float coins, bool success)
    {
        if(success)
        {
            coinsText.text = CoinsFormatter.Convert(coins);
            AnimTextJump();
        }
        else
        {
            AnimTextShake();
        }
    }

    void AnimTextShake()
    {
        coinsText.rectTransform.DOKill();
        coinsText.rectTransform.localPosition = startTextPos;
        coinsText.rectTransform.DOLocalMoveX(30, jumpAnimTime)
            .SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutBack);
    }




}
