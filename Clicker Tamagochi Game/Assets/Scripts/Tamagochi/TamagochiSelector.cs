using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiSelector : MonoBehaviour
{
    TamagochiPlatform[] platforms;
    [SerializeField] TamagochiContainer container;

    private void Start()
    {
        platforms = GetComponentsInChildren<TamagochiPlatform>();
    }
    public void Activate()
    {
        foreach(TamagochiPlatform p in platforms)
        {
            int length = container.tamagochies.Length;
            int r = Random.Range(0, length);
            p.Activate(r);
        }
    }

    public void Deactivate()
    {
        foreach (TamagochiPlatform p in platforms)
        {
            p.Deactivate();
        }
        StartCoroutine(SwitchCoroutine());
    }

    IEnumerator SwitchCoroutine()
    {
        yield return new WaitForSeconds(1);
        DefaultState def = FindObjectOfType<DefaultState>();
        GameManager.Instance.SwitchState(def);
    }

}
