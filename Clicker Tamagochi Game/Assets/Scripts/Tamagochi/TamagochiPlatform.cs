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
    [SerializeField] RuntimeAnimatorController animForTamagochi;

    bool chosen = false;
    public void Activate(int id)
    {
        TamagochiID = id;
        tam = Instantiate(container.tamagochies[id], transform);
        tam.transform.localPosition = Vector3.zero + new Vector3(0, 10, 0);
        tam.transform.localRotation = Quaternion.identity;
        SetAnim(tam);
        tam.transform.DOLocalMoveY(0.2f, animTime).SetEase(Ease.OutSine);
        Vector3 rot = new Vector3(0, 720, 0);
        tam.transform.DORotate(rot, animTime, RotateMode.LocalAxisAdd)
            .SetEase(Ease.OutBack);
        StartCoroutine(EnableClickCoroutine());
    }

    void SetAnim(GameObject newTamagochi)
    {
        Animator tanim = newTamagochi.GetComponent<Animator>();
        tanim.runtimeAnimatorController = animForTamagochi;

        int rand = Random.Range(0, 6);
        tanim.SetInteger("type", rand);
    }

    IEnumerator EnableClickCoroutine()
    {
        yield return new WaitForSeconds(1);
        activated = true;
    }

    private void OnMouseDown()
    {
        if (activated == false) return;
        GameData.Instance.AddTamagochi("Abobus", TamagochiID);
        Hints.Show("Тамагочи нанят!");
        GetComponentInParent<TamagochiSelector>().Deactivate();
        tam.GetComponent<Animator>().SetInteger("type", 6);
        chosen = true;
    }

    public void Deactivate()
    {
        if (activated == false) return;
        activated = false;

        if(chosen == false) tam.GetComponent<Animator>().SetInteger("type", 7);
        tam.transform.DOLocalMoveY(10, animTime).SetEase(Ease.OutSine).SetDelay(0.5f);
        Vector3 rot = new Vector3(0, Random.Range(400, 700), 0);
        tam.transform.DORotate(rot, animTime, RotateMode.LocalAxisAdd)
            .SetEase(Ease.OutBack).SetDelay(0.5f);
        StartCoroutine(DeleteTamagochi());
    }
    IEnumerator DeleteTamagochi()
    {
        yield return new WaitForSeconds(3);
        Destroy(tam);
    }
}
