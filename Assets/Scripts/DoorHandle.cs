using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{
    [Header("DoorHandle Data")]
    public GameObject doorLock;
    public GameObject door;
    public Transform doorStartPosition;
    public Transform doorEndPosition;

    private Transform m_interactorTransform;
    private bool m_isUnlocked = false;
    private Vector3 m_doorSlideDirection;
    [SerializeField]
    private float doorWeight = 3f;

    private void Start()
    {
        m_doorSlideDirection = (doorEndPosition.position - doorStartPosition.position).normalized;        
    }
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        // Check if the lock opened
        if (!m_isUnlocked && !doorLock.activeSelf)
        {
            m_isUnlocked = true;
        }
        if (isSelected && m_isUnlocked)
        {
            m_interactorTransform = firstInteractorSelecting.GetAttachTransform(this);
            MoveDoor();
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        m_interactorTransform = args.interactorObject.transform;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        m_interactorTransform = null;
    }

    private void MoveDoor()
    {
        float dot = Vector3.Dot(m_doorSlideDirection, m_interactorTransform.position-transform.position);
        float maxDistanceToTravel = Mathf.Abs(dot) / doorWeight;
        Vector3 targetPosition = dot > 0 ? doorEndPosition.position : doorStartPosition.position;
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, maxDistanceToTravel);
    }
}
