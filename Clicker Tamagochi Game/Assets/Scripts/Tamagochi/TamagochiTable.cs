using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiTable : MonoBehaviour
{
    TamagochiPlace[] places;
    [SerializeField] TamagochiContainer container;

    // Start is called before the first frame update
    void Start()
    {
        places = GetComponentsInChildren<TamagochiPlace>();
        FillPlaces();
    }

    private void OnEnable()
    {
        GameData.Instance.OnTamagochiBuy += FillPlaces;
    }

    private void OnDisable()
    {
        GameData.Instance.OnTamagochiBuy -= FillPlaces;
    }

    void FillPlaces()
    {
        for (int i = 0; i < GameData.Instance.tamagochies.Length; i++)
        {
            int id = GameData.Instance.tamagochies[i].SkinType;
            GameObject tam = container.tamagochies[id];
            if (places[i].worker != null) continue;
            places[i].AddToPlace(tam);
        }
    }

    
}
