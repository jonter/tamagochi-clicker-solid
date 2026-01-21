using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    ClickController cc;
    Animator anim;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        cc = FindAnyObjectByType<ClickController>();
    }

    private void Update()
    {
        anim.SetFloat("codespeed", cc.CPS);
    }

    

}
