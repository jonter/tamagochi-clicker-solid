using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ClickController cc;
    Animator anim;

    float animSpeed = 1;
    float timer = 0;
    int clicks = 0;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        cc = FindAnyObjectByType<ClickController>();
        cc.OnClick += Code;
    }

    private void OnDisable()
    {
        cc.OnClick -= Code;
    }

    void Code()
    {
        clicks++;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            float clicksPerMinute = clicks * 60;
            print("CPM: " + clicksPerMinute);
            SetAnim(clicksPerMinute);
            clicks = 0;
            timer = 0;
        }
    }

    void SetAnim(float cpm)
    {
        if(cpm < 100)
        {
            anim.SetBool("code", false);
            animSpeed = 0.8f;
        }
        else
        {
            anim.SetBool("code", true);
            if (cpm < 200) animSpeed = 0.8f;
            else if (cpm < 300) animSpeed = 1.2f;
            else if (cpm < 400) animSpeed = 1.5f;
            else if(cpm < 500) animSpeed = 1.9f;
            anim.SetFloat("codespeed", animSpeed);
        }
        
    }

}
