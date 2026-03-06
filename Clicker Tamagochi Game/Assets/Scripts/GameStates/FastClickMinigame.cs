using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastClickMinigame : MiniGameState
{
    public override void Activate()
    {
        StartCoroutine(StartMiniGame());
    }

    IEnumerator StartMiniGame()
    {
        Hints.Show("Мини-игра: Быстрый клик", 0.5f);
        yield return new WaitForSeconds(1);
        Hints.Show("Кликай на тамакодера как можно быстрее, " +
            "чтобы получить больше валюты", 1.5f);
        yield return StartCoroutine(CountToStart());
        isGameOn = true;
        yield return new WaitForSeconds(gameDuration);
        // подсчитать клики и накинуть за них бабла
        isGameOn = false;
        DefaultState state = FindObjectOfType<DefaultState>();
        GameManager.Instance.SwitchState(state);
    }

    IEnumerator CountToStart()
    {
        int seconds = Mathf.RoundToInt(prepareTime);
        for(int i = seconds; i > 0; i--)
        {
            print("Время до старта: " + i);
            yield return new WaitForSeconds(1);
        }
        print("Начали!");
    }

    public override void Deactivate()
    {
        
    }

}
