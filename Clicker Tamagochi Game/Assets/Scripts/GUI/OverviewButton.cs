using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OverviewButton : MonoBehaviour
{
    [SerializeField] Image img;
    Button btn;
    [SerializeField] float eyeAnimTime = 0.8f;
    private void OnEnable()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ButtonPressed);
    }

    private void OnDisable()
    {
        btn.onClick.RemoveListener(ButtonPressed);
    }

    void ButtonPressed()
    {
        GameState state = GameManager.Instance.GetState();
        if (state is DefaultState) SwitchToOverview();
        else if (state is OverviewState) SwitchToDefault();

    }

    void SwitchToOverview()
    {
        OverviewState state = FindObjectOfType<OverviewState>();
        bool success = GameManager.Instance.SwitchState(state);
        if(success)
        {
            Vector3 rot = new Vector3(0,0, 300);
            img.transform.DOLocalRotate(rot, eyeAnimTime).SetEase(Ease.OutElastic);
        }
    }

    void SwitchToDefault()
    {
        DefaultState state = FindObjectOfType<DefaultState>();
        bool success = GameManager.Instance.SwitchState(state);
        if (success)
        {
            Vector3 rot = new Vector3(0, 0, 120);
            img.transform.DOLocalRotate(rot, eyeAnimTime).SetEase(Ease.OutElastic);
        }
    }




}
