using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalWindowPanel : MonoBehaviour
{

    [Header("Header")]
    [SerializeField]
    private Transform headerArea;
    [SerializeField]
    private TextMeshProUGUI titleField;

    [Header("Content")]
    [SerializeField]
    private Transform contentArea;
    [SerializeField]
    private Transform verticalLayoutArea;
    [SerializeField]
    private Image heroImage;
    [SerializeField]
    private TextMeshProUGUI heroText;
    [Space()]
    [SerializeField]
    private Transform horizontalLayoutArea;
    [SerializeField]
    private Transform iconContainer;
    [SerializeField]
    private Image iconImage;
    [SerializeField]
    private TextMeshProUGUI iconText;

    [Header("Footer")]
    [SerializeField]
    private Transform footerArea;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private TextMeshProUGUI confirmText;
    [SerializeField]
    private Button declineButton;
    [SerializeField]
    private TextMeshProUGUI declineText;
    [SerializeField]
    private Button alternateButton;
    [SerializeField]
    private TextMeshProUGUI alternateText;

    private Action onConfirmAction;
    private Action onDeclineAction;
    private Action onAlternateAction;

    public void Confirm()
    {
        Close();
        onConfirmAction?.Invoke();
    }

    public void Decline()
    {
        Close();
        onDeclineAction?.Invoke();
    }
    public void Alternate()
    {
        Close();
        onAlternateAction?.Invoke();
    }

    private void Close()
    {
        //Animation
        gameObject.SetActive(false);
    }
    private void Show()
    {
        //Animation
        gameObject.SetActive(true);
    }

    public void ShowAsHero(string title, Sprite imageToShow, string message, string confirmMessage, string cancelMessage, string alternateMessage, Action confirmAction, Action declineAction = null, Action alternateAction = null)
    {
        horizontalLayoutArea.gameObject.SetActive(false);
        verticalLayoutArea.gameObject.SetActive(true);

        bool hasTitle = string.IsNullOrEmpty(title);
        headerArea.gameObject.SetActive(hasTitle);

        heroImage.sprite = imageToShow;
        heroText.text = message;

        onConfirmAction = confirmAction;
        confirmText.text = confirmMessage;

        bool hasDecline = (declineAction != null);
        declineButton.gameObject.SetActive(hasDecline);
        onDeclineAction = declineAction;
        declineText.text = cancelMessage;

        bool hasAlternate = (alternateAction != null);
        alternateButton.gameObject.SetActive(hasAlternate);
        onAlternateAction = alternateAction;
        alternateText.text = alternateMessage;

        Show();
    }


    public void ShowAsHero(string title, Sprite imageToShow, string message, Action confirmAction)
    {
        ShowAsHero(title, imageToShow, message, "Continue", "", "", confirmAction);
    }
    public void ShowAsHero(string title, Sprite imageToShow, string message, Action confirmAction, Action declineAction)
    {
        ShowAsHero(title, imageToShow, message, "Continue", "Back", "", confirmAction, declineAction);
    }

    public void ShowAsPrompt(string title,Sprite icon, string message, string confirmMessage, string cancelMessage, string alternateMessage, Action confirmAction, Action declineAction = null, Action alternateAction = null)
    {
        horizontalLayoutArea.gameObject.SetActive(true);
        verticalLayoutArea.gameObject.SetActive(false);
        iconImage.gameObject.SetActive(true);

        bool hasTitle = !string.IsNullOrEmpty(title);
        titleField.text = title;
        headerArea.gameObject.SetActive(hasTitle);

        iconContainer.gameObject.SetActive(true);
        iconImage.sprite = icon;
        iconText.text = message;

        onConfirmAction = confirmAction;
        confirmText.text = confirmMessage;

        bool hasDecline = (declineAction != null);
        declineButton.gameObject.SetActive(hasDecline);
        onDeclineAction = declineAction;
        declineText.text = cancelMessage;

        bool hasAlternate = (alternateAction != null);
        alternateButton.gameObject.SetActive(hasAlternate);
        onAlternateAction = alternateAction;
        alternateText.text = alternateMessage;

        Show();
    }

    public void ShowAsPrompt(string title, Sprite icon, string message)
    {
        ShowAsPrompt(title, icon, message, "Ok", "", "", Close);
    }
    public void ShowAsPrompt(string title, Sprite icon, string message, Action confirmAction, Action declineAction)
    {
        ShowAsPrompt(title, icon, message, "Ok", "Nope", "", confirmAction, declineAction);
    }


    public void ShowAsDialog(string title, string message, string confirmMessage, string cancelMessage, string alternateMessage, Action confirmAction, Action declineAction = null, Action alternateAction = null)
    {
        horizontalLayoutArea.gameObject.SetActive(true);
        verticalLayoutArea.gameObject.SetActive(false);
        iconImage.gameObject.SetActive(false);

        bool hasTitle = !string.IsNullOrEmpty(title);
        titleField.text = title;
        headerArea.gameObject.SetActive(hasTitle);

        iconContainer.gameObject.SetActive(false);
        iconText.text = message;

        onConfirmAction = confirmAction;
        confirmText.text = confirmMessage;

        bool hasDecline = (declineAction != null);
        declineButton.gameObject.SetActive(hasDecline);
        onDeclineAction = declineAction;
        declineText.text = cancelMessage;

        bool hasAlternate = (alternateAction != null);
        alternateButton.gameObject.SetActive(hasAlternate);
        onAlternateAction = alternateAction;
        alternateText.text = alternateMessage;

        Show();
    }
    public void ShowAsDialog(string title, string message)
    {
        ShowAsDialog(title, message, "Close", "", "", Close);
    }
    public void ShowAsDialog(string title, string message, Action confirmAction, Action declineAction)
    {
        ShowAsDialog(title, message, "Acept", "Cancel", "", confirmAction, declineAction);
    }
}
