using UnityEngine;
using UnityEngine.EventSystems;

public class PcMenu : MonoBehaviour
{
    //[SerializeField] private Camera targetCamera;
    //[SerializeField] private RectTransform rawImageRect;

    [SerializeField] private Canvas targetCanvas;
    [SerializeField] private Transform objectToSnapUi;
    [SerializeField] private RectTransform UiElemenet;


    private void LateUpdate()
    {

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectToSnapUi.position);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            targetCanvas.transform as RectTransform,
            screenPosition,
            targetCanvas.worldCamera,
            out localPoint
        );

        UiElemenet.anchoredPosition = localPoint;
    }

}
