using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ClickController cc;
    Animator anim;

    float animSpeed = 1;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        cc = FindAnyObjectByType<ClickController>();
    }

    private void Update()
    {
        SetAnim();
    }

    void SetAnim()
    {
        if(cc.CPS < 1)
        {
            anim.SetBool("code", false);
            animSpeed = 0.8f;
        }
        else
        {
            anim.SetBool("code", true);
            if (cc.CPS < 2) animSpeed = 0.8f;
            else if (cc.CPS < 3) animSpeed = 1.2f;
            else if (cc.CPS < 4.5f) animSpeed = 1.5f;
            else if(cc.CPS < 6) animSpeed = 1.9f;
            anim.SetFloat("codespeed", animSpeed);
        }
        
    }

}
