using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameState : GameState
{
    protected float gameDuration = 10;
    protected float prepareTime = 3;

    protected bool isGameOn = false;

}
