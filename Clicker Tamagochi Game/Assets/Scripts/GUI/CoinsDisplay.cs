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
        coinsText = transform.GetChild(1).GetComponent<TMP_Text>(); 
        GameData.Instance.OnCoinsAdd += DisplayCoins;
        GameData.Instance.OnCoinsSpend += DisplayCoins;
        startTextPos = coinsText.rectTransform.localPosition;
        coinsText.text = CoinsFormatter.Convert(GameData.Instance.Coins);
    }

    private void OnDisable()
    {
        GameData.Instance.OnCoinsAdd -= DisplayCoins;
        GameData.Instance.OnCoinsSpend -= DisplayCoins;
        coinsText.rectTransform.DOKill();
    }

    void DisplayCoins(float add)
    {
        coinsText.text = CoinsFormatter.Convert(GameData.Instance.Coins);
        AnimTextJump();
    }

    void AnimTextJump()
    {
        coinsText.rectTransform.DOKill();
        coinsText.rectTransform.localPosition = startTextPos;
        coinsText.rectTransform.DOLocalMoveY(jumpHeight, jumpAnimTime)
            .SetLoops(2, LoopType.Yoyo);
    }


    void DisplayCoins(float spending, bool success)
    {
        if(success)
        {
            coinsText.text = CoinsFormatter.Convert(GameData.Instance.Coins);
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
