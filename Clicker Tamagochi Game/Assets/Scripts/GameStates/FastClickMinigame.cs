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
        Hints.Show("ћини-игра: Ѕыстрый клик", 1f);
        yield return new WaitForSeconds(1.5f);
        Hints.Show(" ликай на тамакодера как можно быстрее, " +
            "чтобы получить больше валюты", 2);
        CountdownText.Instance.Count(3);
        yield return new WaitForSeconds(3.5f);
        if(OnGameStart != null) OnGameStart();
        isGameOn = true;
        yield return new WaitForSeconds(gameDuration);
        // подсчитать клики и накинуть за них бабла
        isGameOn = false;
        DefaultState state = FindObjectOfType<DefaultState>();
        GameManager.Instance.SwitchState(state);
    }

 

    public override void Deactivate()
    {
        
    }

}
