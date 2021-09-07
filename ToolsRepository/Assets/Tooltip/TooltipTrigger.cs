using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] string header;
    [Multiline()]
    [SerializeField] string content;


    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ShowDelayedTooltip());
    } 
    public void OnMouseEnter()
    {
        StartCoroutine(ShowDelayedTooltip());
    }

    private IEnumerator ShowDelayedTooltip()
    {
        yield return new WaitForSeconds(0.5f);
        TooltipSystem.Show(content, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        TooltipSystem.Hide();
    }

    public void OnMouseExit()
    {
        StopAllCoroutines();
        TooltipSystem.Hide();
    }
        
}
