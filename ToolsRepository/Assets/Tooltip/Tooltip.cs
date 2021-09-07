using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headerField;
    [SerializeField] TextMeshProUGUI contentField;
    [SerializeField] LayoutElement layoutElement;
    [SerializeField] int characterWrapLimit;

    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }



    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;
        
        int headerLenght = headerField.text.Length;
        int contentLenght = contentField.text.Length;

        layoutElement.enabled = (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit) ? true : false;
        PositionTooltip();
    }

    private void Update()
    {
        PositionTooltip();
    }

    private void PositionTooltip()
    {
        Vector2 position = Input.mousePosition;
        float pivotX = Mathf.RoundToInt(position.x / Screen.width);
        float pivotY = Mathf.RoundToInt(position.y / Screen.height);

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }
}
