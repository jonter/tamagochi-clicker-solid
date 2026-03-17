using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DefaultState : GameState
{
    [SerializeField] RectTransform upgradePanel;
    float showX = 250;
    float hideX = -500;

    public override void Activate()
    {
        upgradePanel.DOAnchorPosX(showX, 1).SetEase(Ease.InOutSine);
    }

    public override void Deactivate()
    {
        upgradePanel.DOAnchorPosX(hideX, 1).SetEase(Ease.InOutSine);
    }
}
