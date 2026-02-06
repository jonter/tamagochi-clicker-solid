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

    public static CameraTransition Instance;
    private void Awake()
    {
        Instance = this;
        camera = Camera.main.transform;
    }

    private void OnDisable()
    {
        camera.DOKill();
    }

    void Move(Transform point)
    {
        camera.DOMove(point.position, animTime);
        camera.DORotate(point.eulerAngles, animTime);
    }

    public void ToDefault() { Move(defaultPoint); }
    public void ToTamagochiShop() { Move(tamagochiShopPoint); }


}
