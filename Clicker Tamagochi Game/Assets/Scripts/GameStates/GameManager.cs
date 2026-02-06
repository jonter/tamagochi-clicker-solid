using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameState state;
    [SerializeField] float transitionTime = 1;
    bool isTransiting = false;

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
        isTransiting = true;
        state = newState;
        yield return new WaitForSeconds(transitionTime/2);
        state.Activate();
        yield return new WaitForSeconds(transitionTime/2);
        isTransiting = false;
    }
    

    
}
