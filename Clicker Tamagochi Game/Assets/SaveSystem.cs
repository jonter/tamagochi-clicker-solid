using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Awake()
    {
        GameData.Instance = new GameData();
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause == true) Save();
    }


    void Save()
    {
        string sdata = JsonUtility.ToJson(GameData.Instance);
        print(sdata);
        PlayerPrefs.SetString("data", sdata);
        print("Сохранились");
    }

    void Load()
    {
        if (PlayerPrefs.HasKey("data") == false) return;

        string sdata = PlayerPrefs.GetString("data");
        GameData.Instance = JsonUtility.FromJson<GameData>(sdata);
        print("Загрузка завершена");
    }

   
}
