using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] float animTime = 1;
    Transform camera;

    [Header("All Points For Camera")]
    [SerializeField] Transform defaultPoint;
    [SerializeField] Transform tamagochiShopPoint;
    [SerializeField] Transform overviewPoint;

    private void Awake()
    {
        camera = Camera.main.transform;
    }

    private void OnEnable()
    {
        GameManager.Instance.OnActivate += OnChangeState;
    }

    private void OnDisable()
    {
        camera.DOKill();
        GameManager.Instance.OnActivate -= OnChangeState;
    }

    void Move(Transform point)
    {
        camera.DOMove(point.position, animTime);
        camera.DORotate(point.eulerAngles, animTime);
    }


    void OnChangeState(GameState state)
    {
        if (state is DefaultState) Move(defaultPoint);
        else if (state is TamagochiSelectState) Move(tamagochiShopPoint);
        else if (state is OverviewState) Move(overviewPoint);
    }


}
