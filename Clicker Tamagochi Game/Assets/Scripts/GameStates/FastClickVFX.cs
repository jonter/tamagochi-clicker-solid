using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastClickVFX : MonoBehaviour
{
    FastClickMinigame clickGame;

    private void OnEnable()
    {
        clickGame = FindAnyObjectByType<FastClickMinigame>();
        GameManager.Instance.OnDeactivate += OnDeactivate;
        clickGame.OnGameStart += Activate;
    }

    private void OnDisable()
    {
        clickGame.OnGameStart -= Activate;
        GameManager.Instance.OnDeactivate -= OnDeactivate;
    }

    void Activate()
    {
        GetComponent<ParticleSystem>().Play();
    }

    void OnDeactivate(GameState state)
    {
        if (state is FastClickMinigame)
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }


}
