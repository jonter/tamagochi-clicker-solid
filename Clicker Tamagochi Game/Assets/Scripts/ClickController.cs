using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour
{
    GameData data;
    public event Action OnClick;

    float lastTimeClick = 0;
    float realCPS = 0;

    public float CPS = 0;
    bool canClick = true;
    // Start is called before the first frame update
    void Start()
    {
        data = GameData.Instance;
        GameManager.Instance.OnActivate += OnSwitchState;
    }

    private void OnMouseDown()
    {
        if (canClick == false) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (EventSystem.current.IsPointerOverGameObject(1)) return;
        data.EarnCoinsForClick();
        if (OnClick != null) OnClick();
        CalculateCPS();
    }

    void CalculateCPS()
    {
        float currentTime = Time.time;
        float delta = currentTime - lastTimeClick;
        if (delta > 10) delta = 10;
        realCPS = 1 / delta;
        lastTimeClick = currentTime;
        //print("CPS: "+ realCPS);
    }

    private void Update()
    {
        CPS = Mathf.Lerp(CPS, realCPS, 4 * Time.deltaTime);
        realCPS -= Time.deltaTime * 3;
        if (realCPS < 0) realCPS = 0;
    }

    void OnSwitchState(GameState state)
    {
        if (state is DefaultState) canClick = true;
        else if (state is FastClickMinigame) canClick = true;
        else canClick = false;
    }

}
