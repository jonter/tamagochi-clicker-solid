using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TamagochiPlatform : MonoBehaviour
{
    public int TamagochiID = -1;
    [SerializeField] TamagochiContainer container;
    bool activated = false;
    [SerializeField] float animTime = 1.5f;

    GameObject tam;
    public void Activate(int id)
    {
        activated = true;
        TamagochiID = id;
        tam = Instantiate(container.tamagochies[id], transform);
        tam.transform.localPosition = Vector3.zero + new Vector3(0, 10, 0);
        tam.transform.localRotation = Quaternion.identity;

        tam.transform.DOLocalMoveY(0.2f, animTime).SetEase(Ease.OutSine);
        Vector3 rot = new Vector3(0, 720, 0);
        tam.transform.DORotate(rot, animTime, RotateMode.LocalAxisAdd)
            .SetEase(Ease.OutBack);
    }

    private void OnMouseDown()
    {
        if (activated == false) return;
        GameData.Instance.AddTamagochi("Abobus", TamagochiID);
        Hints.Show("“амагочи нан€т!");
        GetComponentInParent<TamagochiSelector>().Deactivate();
        // вернуть камеру обратно
    }

    public void Deactivate()
    {
        if (activated == false) return;
        activated = false;

        tam.transform.DOLocalMoveY(10, animTime).SetEase(Ease.OutSine);
        Vector3 rot = new Vector3(0, Random.Range(400, 700), 0);
        tam.transform.DORotate(rot, animTime, RotateMode.LocalAxisAdd)
            .SetEase(Ease.OutBack);
    }
}
