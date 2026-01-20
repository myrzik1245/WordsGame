using System;
using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    public abstract event Action<string> ChangeSceneReauested;

    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
