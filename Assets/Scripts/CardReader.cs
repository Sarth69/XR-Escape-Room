using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    [Header("CardReader Data")]
    public Transform swipeStartPoint;
    public Transform swipeEndPoint;

    private Vector3 cardSwipeStart;
    private Vector3 cardSwipeEnd;
    private Transform keyCardTransform;

    private bool swipeInProgress = false;
    private float uprightErrorRange = 0.1f;

    public GameObject lockBar;

    void Update()
    {
        if (swipeInProgress)
        {
            float dot = Vector3.Dot(Vector3.up, keyCardTransform.forward);

            if(dot < 1-uprightErrorRange)
            {
                swipeInProgress = false;
            }
        }
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        cardSwipeStart = args.interactableObject.transform.position;
        swipeInProgress = true;
        keyCardTransform = args.interactableObject.transform;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        cardSwipeEnd = args.interactableObject.transform.position;
        if (swipeInProgress)
        {
            if ((cardSwipeEnd - cardSwipeStart).y < -0.8f * (swipeEndPoint.position - swipeStartPoint.position).y)
            {
                //Remove the lock
                lockBar.SetActive(false);
            }
        }
        swipeInProgress = false;
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return false;
    }
}
