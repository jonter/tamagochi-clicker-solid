using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiIncome : MonoBehaviour
{
    TamagochiEarnBag earnBag;
    float earnPerMinute = 50;
    float multiplyer = 15;
    float earnBasic = 50;

    // Start is called before the first frame update
    void Awake()
    {
        earnBag = FindObjectOfType<TamagochiEarnBag>();
        CalculateEarning();
        StartCoroutine(EarnCoroutine());
    }

    public void GetOfflineEarn(TimeSpan offlineTime)
    {
        double mins = offlineTime.TotalMinutes;
        if (mins <= 0) return;
        if (mins > 360) mins = 360;

        float earn = (float)mins * earnPerMinute / 2;
        earnBag.AddMoney(earn);
    }

    private void OnEnable()
    {
        GameData.Instance.OnTamagochiBuy += CalculateEarning;
    }

    private void OnDisable()
    {
        GameData.Instance.OnTamagochiBuy -= CalculateEarning;
    }

    void CalculateEarning()
    {
        int count = GameData.Instance.tamagochies.Length;

        if (count == 0) earnPerMinute = 0;
        else if (count == 1) earnPerMinute = earnBasic;
        else earnPerMinute = earnBasic * Mathf.Pow(multiplyer, count);

        earnBag.maxMoney = earnPerMinute * 60;
    }

    IEnumerator EarnCoroutine()
    {
        yield return new WaitForSeconds(10);
        float earn = earnPerMinute / 6;
        earnBag.AddMoney(earn);

        StartCoroutine(EarnCoroutine());
    }

    
}
