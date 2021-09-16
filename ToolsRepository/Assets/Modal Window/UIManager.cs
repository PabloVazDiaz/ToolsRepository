using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    [SerializeField]
    private ModalWindowPanel modalWindow;

    public ModalWindowPanel ModalWindow => modalWindow;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this);
        }

    }
}
