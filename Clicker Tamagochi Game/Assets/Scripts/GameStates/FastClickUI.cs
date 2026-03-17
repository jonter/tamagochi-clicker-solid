using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FastClickUI : MonoBehaviour
{
    [SerializeField] TMP_Text cpsText, maxText, clickText;
    ClickController cc;
    FastClickMinigame minigame;

    Vector2 startPosClick;
    RectTransform clickTextRect;
    bool gameOn = false;
    int clicks = 0;

    float maxCPS = 0;

    public int GetClicks () { return clicks; }
    public float GetMaxCPS () { return maxCPS; }

    private void OnEnable()
    {
        minigame = FindObjectOfType<FastClickMinigame>();
        cc = FindObjectOfType<ClickController>();
        clickTextRect = clickText.GetComponent<RectTransform>();
        startPosClick = clickTextRect.anchoredPosition;
        Color c = new Color(1, 1, 1, 0);
        cpsText.color = c;
        maxText.color = c;
        clickText.color = c;

        minigame.OnGameStart += StartMiniGame;
        cc.OnClick += Click;
    }

    private void OnDisable()
    {
        cpsText.DOKill();
        maxText.DOKill();
        clickText.DOKill();
        clickTextRect.DOKill();

        minigame.OnGameStart -= StartMiniGame;
        cc.OnClick -= Click;
    }

    void StartMiniGame()
    {
        maxCPS = 0;
        clicks = 0;
        gameOn = true;
        cpsText.DOColor(Color.white, 0.5f);
        maxText.DOColor(Color.white, 0.5f).SetDelay(1);
        clickText.DOColor(Color.white, 0.5f);
        clickText.text = "Clicks: 0";
    }

    public void HideUI()
    {
        gameOn = false;
        Color c = new Color(1, 1, 1, 0);
        cpsText.DOColor(c, 0.5f);
        maxText.DOColor(c, 0.5f);
        clickText.DOColor(c, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn == false) return;

        cpsText.text = "CPS: " + cc.CPS.ToString("#.#");
        if(cc.CPS > maxCPS)
        {
            maxCPS = cc.CPS;
            maxText.text = "max CPS: " + maxCPS.ToString("#.#");
        }
    }

    void Click()
    {
        if (gameOn == false) return;
        clicks++;
        clickText.text = "Clicks: " + clicks;
    }
}
