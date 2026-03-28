using UnityEngine;

public class EndWindow : Window
{
    
    
    protected override void OnButtonClick()
    {
        throw new System.NotImplementedException();
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
