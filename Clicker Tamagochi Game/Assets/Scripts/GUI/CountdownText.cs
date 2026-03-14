using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CountdownText : MonoBehaviour
{
    public static CountdownText Instance;
    TMP_Text mytext;
    RectTransform rect;

    [SerializeField] float animTime = 0.2f;
    private void OnEnable()
    {
        Instance = this;
        mytext = GetComponent<TMP_Text>();
        mytext.text = "";
        rect = GetComponent<RectTransform>();
    }

    private void OnDisable()
    {
        mytext.DOKill();
        rect.DOKill();
        transform.DOKill();
    }

    public void Count(int seconds)
    {
        transform.localScale = new Vector3(1,1,1);
        StartCoroutine(CountCoroutine(seconds));
    }

    IEnumerator CountCoroutine(int seconds)
    {
        
        for(int i = seconds; i > 0; i--)
        {
            mytext.text = "" + i;
            transform.DOScale(1.4f, animTime).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(1);
        }
        mytext.text = "Погнали!";
        transform.DOScale(1.2f, animTime);
        yield return new WaitForSeconds(animTime * 2);
        transform.DOScale(0, animTime);
        yield return new WaitForSeconds(1);
        mytext.text = "";
    }


}
