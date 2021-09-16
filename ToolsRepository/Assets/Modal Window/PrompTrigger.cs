using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrompTrigger : MonoBehaviour
{

    public string title;
    public Sprite sprite;
    public string message;

    private void OnMouseDown()
    {
        Interact();
    }

    public void Interact()
    {
        UIManager.instance.ModalWindow.ShowAsPrompt(title, sprite, message);
    }
    
}
