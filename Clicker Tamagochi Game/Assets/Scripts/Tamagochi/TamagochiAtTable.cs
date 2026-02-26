using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiAtTable : MonoBehaviour
{
    int animCount = 6;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(SwitchState());
    }

    IEnumerator SwitchState()
    {
        int randAnim = Random.Range(0, animCount);
        anim.SetInteger("type", randAnim);
        float animSpeed = Random.Range(0.8f, 1.4f);
        anim.SetFloat("speed", animSpeed);

        float randTime = Random.Range(4f, 7f);
        yield return new WaitForSeconds(randTime);
        StartCoroutine(SwitchState());
    }
}
