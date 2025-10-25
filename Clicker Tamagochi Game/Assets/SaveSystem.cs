using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static GameData Data;
    
    // Start is called before the first frame update
    void Awake()
    {
        Data = new GameData();
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
        string sdata = JsonUtility.ToJson(Data);
        print(sdata);
        PlayerPrefs.SetString("data", sdata);
        print("Сохранились");
    }

    void Load()
    {
        if (PlayerPrefs.HasKey("data") == false) return;

        string sdata = PlayerPrefs.GetString("data");
        Data = JsonUtility.FromJson<GameData>(sdata);
        print("Загрузка завершена");
    }

   
}
