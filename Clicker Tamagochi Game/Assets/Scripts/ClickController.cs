using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

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
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (EventSystem.current.IsPointerOverGameObject(1)) return;
        data.EarnCoinsForClick();
        if (OnClick != null) OnClick();
    }

}
