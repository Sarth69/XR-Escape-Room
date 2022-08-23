using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    [Header("Button Data")]
    public Material buttonTouchedMaterial;
    public Material buttonBaseMaterial;

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        gameObject.
    }
}