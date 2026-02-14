using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameState state;
    [SerializeField] float transitionTime = 1;
    bool isTransiting = false;

    public event Action<GameState> OnActivate;
    public event Action<GameState> OnDeactivate;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameState GetState() => state;

    public bool SwitchState(GameState newState)
    {
        if (isTransiting == true) return false;
        if(state == newState) return false;

        StartCoroutine(SwitchCoroutine(newState));

        return true;
    }

    IEnumerator SwitchCoroutine(GameState newState)
    {
        state.Deactivate();
        if (OnDeactivate != null) OnDeactivate(state);
        isTransiting = true;
        state = newState;
        yield return new WaitForSeconds(transitionTime/2);
        state.Activate();
        if(OnActivate != null) OnActivate(state);
        yield return new WaitForSeconds(transitionTime/2);
        isTransiting = false;
    }
   
    
}
