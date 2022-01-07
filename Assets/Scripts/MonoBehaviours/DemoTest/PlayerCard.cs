using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public int cardOwner;
    [SerializeField]
    CardManager cardManager;
    RectTransform m_rect;
    Transform canvasTransform;
    Image m_image;
    void Awake()
    {
        m_rect = GetComponent<RectTransform>();
        m_image = GetComponent<Image>();
    }
    void Start()
    {
        canvasTransform = transform.parent.parent;
    }
    // If the Card Manager instantiates cards, it could call this method to assign itself here.
    public void SetManager(CardManager theManager)
    {
        cardManager = theManager;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 lp;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform.GetComponent<RectTransform>(), Input.mousePosition, null, out lp);
        m_rect.localPosition = lp;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (cardManager.playerTurn != cardOwner) eventData.pointerDrag = null;
        else
        {
            transform.SetParent(canvasTransform, true);
            m_image.raycastTarget = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_image.raycastTarget = true;
    }
}
