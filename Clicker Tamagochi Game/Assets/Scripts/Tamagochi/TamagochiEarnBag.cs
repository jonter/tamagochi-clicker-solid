using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

[SelectionBase]
public class TamagochiEarnBag : MonoBehaviour
{
    TMP_Text mytext;

    float currentMoney = 0;
    public float maxMoney = 3500;

    [SerializeField] Transform bagMesh;
    // Start is called before the first frame update
    void Awake()
    {
        mytext = GetComponentInChildren<TMP_Text>();
        DisplayText();
    }

    public void AddMoney(float add)
    {
        if (add < 0.1f) return;
        currentMoney += add;
        if(currentMoney > maxMoney) currentMoney = maxMoney;
        DisplayText();
        bagMesh.DOScale(3.3f, 0.1f).SetLoops(2,LoopType.Yoyo);
    }

    void DisplayText()
    {
        if(currentMoney <= 0.1f)
        {
            Color c = mytext.color;
            c.a = 0;
            mytext.DOColor(c, 0.5f);
        }
        else
        {
            Color c = mytext.color;
            c.a = 1;
            mytext.DOColor(c, 0.5f);
        }
        string moneyStr = CoinsFormatter.Convert(currentMoney);
        mytext.text = "Заработок: "+ moneyStr;
    }


    private void OnMouseDown()
    {
        if (GameManager.Instance.GetState() is not OverviewState) return;
        if (currentMoney <= 0.1f) return;
        GameData.Instance.AddCoins(currentMoney);
        currentMoney = 0;
        DisplayText();
        bagMesh.localScale = new Vector3(3, 3, 3);
        bagMesh.DOScaleY(2, 0.1f).SetLoops(2, LoopType.Yoyo);
    }

}

