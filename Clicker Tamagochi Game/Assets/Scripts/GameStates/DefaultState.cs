using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DefaultState : GameState
{
    [SerializeField] RectTransform upgradePanel;
    float showX = 250;
    float hideX = -500;
    ClickController cc;

    private void Awake()
    {
        cc = FindObjectOfType<ClickController>();
    }

    public override void Activate()
    {
        cc.enabled = true;
        upgradePanel.DOAnchorPosX(showX, 1).SetEase(Ease.OutBack);
        CameraTransition.Instance.ToDefault();
    }

    public override void Deactivate()
    {
        cc.enabled = false;
        upgradePanel.DOAnchorPosX(hideX, 1).SetEase(Ease.InBack);
    }
}
