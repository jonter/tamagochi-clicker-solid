using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineTimer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("time") == false) return;
      
        string exitDate = PlayerPrefs.GetString("time");
        DateTime exit = DateTime.Parse(exitDate);
        DateTime now = DateTime.UtcNow;

        TimeSpan offlineTime = now - exit;
        TamagochiIncome ti = FindObjectOfType<TamagochiIncome>();
        ti.GetOfflineEarn(offlineTime);
    }

    private void OnApplicationQuit()
    {
        SaveExitTime();
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause == true)
        {
            SaveExitTime();
        }
    }

    void SaveExitTime()
    {
        DateTime now = DateTime.UtcNow;
        string nowStr = now.ToString();
        PlayerPrefs.SetString("time", nowStr);
    }

}
