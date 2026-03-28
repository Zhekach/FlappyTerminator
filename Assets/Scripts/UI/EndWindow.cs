using System;
using UnityEngine;

public class EndWindow : Window
{
    public event Action RestartButtonClick;
    
    protected override void OnButtonClick()
    {
        Debug.Log("OnButtonClick");
        RestartButtonClick?.Invoke();
    }

    public override void Open()
    {
        gameObject.SetActive(true);
    }

    public override void Close()
    {
        gameObject.SetActive(false);
    }
}
