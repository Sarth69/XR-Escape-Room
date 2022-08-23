using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class TouchButton : XRBaseInteractable
{
    [Header("Button Data")]
    public Material buttonTouchedMaterial;
    public Material buttonBaseMaterial;
    public NumberPad numberPad;
    [SerializeField]
    private TMP_Text codeText;

    private string m_value;

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        GetComponent<MeshRenderer>().material = buttonTouchedMaterial;
        AddButtonToSequence();
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        GetComponent<MeshRenderer>().material = buttonBaseMaterial;
    }

    protected override void Awake()
    {
        base.Awake();
        m_value = gameObject.GetComponentInChildren<TMP_Text>().text;
    }

    private void AddButtonToSequence()
    {
        numberPad.m_currentSequence.Add(int.Parse(m_value));
        if (codeText.color != Color.black)
        {
            codeText.color = Color.black;
            codeText.text = "*";
        } else
        {
            codeText.text += "*";
        }
    }
}