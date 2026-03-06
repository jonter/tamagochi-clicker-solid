using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MiniGameManager : MonoBehaviour
{
    Button activateButton;
    RectTransform myrect;

    bool canPress = false;
    int clickCount = 0;
    int maxCount = 50;

    ClickController cc;

    // Start is called before the first frame update
    void Start()
    {
        myrect = GetComponent<RectTransform>();
        float anchorX = myrect.anchoredPosition.x;
        myrect.anchoredPosition = new Vector2(anchorX, -100);
    }

    private void OnEnable()
    {
        activateButton = GetComponent<Button>();
        cc = FindObjectOfType<ClickController>();
        cc.OnClick += IncreaseClicks;
        activateButton.onClick.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        cc.OnClick -= IncreaseClicks;
        activateButton.onClick.RemoveListener(OnButtonPressed);
    }

    void IncreaseClicks()
    {
        if (canPress == true) return;
        if (GameManager.Instance.GetState() is not DefaultState) return;
        clickCount++;
        if(clickCount >= maxCount)
        {
            canPress = true;
            myrect.DOAnchorPosY(75, 1);
        }
    }

    void OnButtonPressed()
    {
        if (canPress == false) return;
        if (GameManager.Instance.GetState() is not DefaultState) return;
        canPress = false;
        clickCount = 0;
        myrect.DOAnchorPosY(-100, 1);
        // выбрать случайную мини игру
        FastClickMinigame game = FindObjectOfType<FastClickMinigame>();
        GameManager.Instance.SwitchState(game);
    }

   
}
