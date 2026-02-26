using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiPlace : MonoBehaviour
{
    public GameObject worker;
    [SerializeField] RuntimeAnimatorController animForTamagochi;

    public void AddToPlace(GameObject tamagochiPrefab)
    {
        worker = Instantiate(tamagochiPrefab, transform);
        // возможно обнулить ему положение и вращение
        worker.AddComponent<TamagochiAtTable>();
        Animator tanim = worker.GetComponent<Animator>();
        tanim.runtimeAnimatorController = animForTamagochi;
    }
}
