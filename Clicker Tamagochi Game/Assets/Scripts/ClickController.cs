using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ClickController : MonoBehaviour
{
    GameData data;
    public event Action OnClick;

    // Start is called before the first frame update
    void Start()
    {
        data = GameData.Instance;
    }

    private void OnMouseDown()
    {
        data.EarnCoinsForClick();
        if (OnClick != null) OnClick();
    }

}
