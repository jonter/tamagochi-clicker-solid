using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeVFX : MonoBehaviour
{
    ClickController cc;
    ParticleSystem ps;
    private void OnEnable()
    {
        cc = FindObjectOfType<ClickController>();
        ps = GetComponent<ParticleSystem>();
        cc.OnClick += PlayVFX;
    }

    private void OnDisable()
    {
        cc.OnClick -= PlayVFX;
    }

    void PlayVFX()
    {
        int count = 1;
        if (cc.CPS > 5) count = 3;

        ps.Emit(count);
    }

}
