using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private void Start()
    {
        ShowDialog();
    }

    public void ShowDialog()
    {
        UIManager.instance.ModalWindow.ShowAsDialog("", "This will close the game, any of your current progress will be lost since your last save. Are you sure?", SaveAndQuit, QuitWithoutSaving);
    }

    void SaveAndQuit()
    {

    }

    void QuitWithoutSaving()
    {

    }

    void Cancel() 
    {

    }
}
