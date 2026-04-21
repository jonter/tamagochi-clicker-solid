using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EarnText : MonoBehaviour
{
    RectTransform myrect;
    TMP_Text mytext;

    Color startColor;
    Vector2 startPosition;

    [SerializeField] float animTime = 0.2f;

    private void OnEnable()
    {
        myrect = GetComponent<RectTransform>();
        mytext = GetComponent<TMP_Text>();
        startColor = mytext.color;
        startPosition = myrect.anchoredPosition;

        GameData.Instance.OnCoinsAdd += Earn;
        GameData.Instance.OnCoinsSpend += Spend;

        startColor.a = 0;
        mytext.color = startColor;
        startColor.a = 1;
    }

    private void OnDisable()
    {
        myrect.DOKill();
        mytext.DOKill();
        GameData.Instance.OnCoinsAdd -= Earn;
        GameData.Instance.OnCoinsSpend -= Spend;
    }

    void Earn(float earn)
    {
        string earnStr = CoinsFormatter.Convert(earn);
        mytext.text = "+ " + earnStr;
        StopAllCoroutines();
        StartCoroutine(PlayAnim(startColor, true));
    }

    void Spend(float spending, bool success)
    {
        if (success == false) return;
        string spendStr = CoinsFormatter.Convert(spending);
        mytext.text = "- " + spendStr;
        StopAllCoroutines();
        StartCoroutine(PlayAnim(Color.red, false));
    }

    IEnumerator PlayAnim(Color c, bool isUp)
    {
        float startY = -50;
        if (isUp == false) startY = 50;

        float endY = 30;
        if(isUp == false) endY = -30;

        mytext.DOKill();
        myrect.DOKill();
        myrect.anchoredPosition = new Vector2(startPosition.x, startPosition.y + startY);
        mytext.color = new Color(1, 1, 1, 0);
        mytext.DOColor(c, animTime);
        myrect.DOAnchorPosY(startPosition.y, animTime);

        yield return new WaitForSeconds(animTime);
        mytext.DOColor(new Color(1, 1, 1, 0), animTime);
        myrect.DOAnchorPosY(startPosition.y + endY, animTime);
    }

}
