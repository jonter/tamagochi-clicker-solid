using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ShowEarnText : MonoBehaviour
{
    TMP_Text mytext;
    [SerializeField] float animTime = 0.1f;
    [SerializeField] float animScale = 1.2f;

    public static ShowEarnText Instance;

    private void OnEnable()
    {
        Instance = this;
        mytext = GetComponent<TMP_Text>();
    }

    private void OnDisable()
    {
        mytext.DOKill();
        transform.DOKill();
    }

    public void Show(string str)
    {
        mytext.text = str;
        mytext.transform.DOScale(animScale, animTime).SetLoops(2, LoopType.Yoyo);
    }

    public void Hide() 
    {
        StartCoroutine(HideCoroutine());
    }

    IEnumerator HideCoroutine()
    {
        mytext.transform.DOScale(0.5f, animTime);
        yield return new WaitForSeconds(animTime);
        mytext.text = "";
        mytext.transform.DOScale(1, 1);
    }
}
