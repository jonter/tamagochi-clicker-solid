using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FastClickMinigame : MiniGameState
{
    public event Action OnGameStart;
    public override void Activate()
    {
        StartCoroutine(StartMiniGame());
    }

    IEnumerator StartMiniGame()
    {
        Hints.Show("Мини-игра: Быстрый клик", 1f);
        yield return new WaitForSeconds(1.5f);
        Hints.Show("Кликай на тамакодера как можно быстрее, " +
            "чтобы получить больше валюты", 2);
        CountdownText.Instance.Count(3);
        yield return new WaitForSeconds(3.5f);
        if(OnGameStart != null) OnGameStart();
        isGameOn = true;
        yield return new WaitForSeconds(gameDuration);
        yield return StartCoroutine(FinishMiniGame());
        isGameOn = false;
        DefaultState state = FindObjectOfType<DefaultState>();
        GameManager.Instance.SwitchState(state);
    }

    IEnumerator FinishMiniGame()
    {
        FastClickUI ui = FindObjectOfType<FastClickUI>();
        ShowEarnText.Instance.Show("Миниигра закончена");
        ui.HideUI();
        yield return new WaitForSeconds(1);
        ShowEarnText.Instance.Show("Клики = "+ ui.GetClicks());
        yield return new WaitForSeconds(1);
        ShowEarnText.Instance.Show("max CPS = " + ui.GetMaxCPS().ToString("#.#"));
        yield return new WaitForSeconds(1);
        string earnStr = CoinsFormatter.Convert(GameData.Instance.Earn);
        ShowEarnText.Instance.Show($"Общая прокачка {earnStr} за клик");
        yield return new WaitForSeconds(1);
        float allMoney = ui.GetClicks() * ui.GetMaxCPS() * GameData.Instance.Earn;
        string allMoneyStr = CoinsFormatter.Convert(allMoney);
        ShowEarnText.Instance.Show($"Всего заработано {allMoneyStr}" );
        yield return new WaitForSeconds(3);
        ShowEarnText.Instance.Hide();
        GameData.Instance.AddCoins(allMoney);
    }

 

    public override void Deactivate()
    {
        
    }

}
