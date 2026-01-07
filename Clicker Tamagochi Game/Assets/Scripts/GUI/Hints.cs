using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Hints : MonoBehaviour
{
    TMP_Text myText;
    RectTransform myRect;
    Vector2 startPos;
    [SerializeField] float animTime = 0.5f;

    static Hints instance;
    // Start is called before the first frame update
    void Awake()
    {
        myRect = GetComponent<RectTransform>();
        myText = GetComponentInChildren<TMP_Text>();
        startPos = myRect.anchoredPosition;
        instance = this;
        myRect.localScale = new Vector3();
    }

    public static void Show(string str, float duration = 1.2f)
    {
        instance.myRect.DOKill();
        instance.myText.text = str;
        instance.myRect.localScale = new Vector3();
        instance.myRect.anchoredPosition = instance.startPos;

        instance.myRect.DOScale(1, instance.animTime)
            .SetEase(Ease.OutBack).SetUpdate(true);
        instance.myRect.DOAnchorPosY(-150, instance.animTime)
            .SetEase(Ease.InBack).SetUpdate(true).SetDelay(duration);
    }

    private void OnDisable()
    {
        myRect.DOKill();
    }


}
