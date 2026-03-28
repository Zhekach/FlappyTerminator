
using System;
using UnityEngine;

public class StartWindow : Window
{
    public event Action PlayButtonClick;
    
    protected override void OnButtonClick()
    {
        Debug.Log("START Button OnEnable");
        PlayButtonClick?.Invoke();
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1f;
        Button.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0f;
        Button.interactable = false;
    }
}
