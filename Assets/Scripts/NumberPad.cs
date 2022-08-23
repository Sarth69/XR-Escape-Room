using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberPad : MonoBehaviour
{
    [SerializeField]
    private TMP_Text codeText;
    private List<int> correctSequence = new List<int> { 1, 2, 3, 4 };

    public List<int> m_currentSequence = new List<int>();
    public GameObject cardPrefab;

    private void Update()
    {
        if (m_currentSequence.Count == 4)
        {
            if (CompareLists(m_currentSequence,correctSequence))
            {
                codeText.text = "Code valid!";
                codeText.color = Color.green;
                Instantiate(cardPrefab, new Vector3(0.15f, 1.4f, 0.4f), new Quaternion());
            } 
            else
            {
                codeText.text = "Invalid code!";
                codeText.color = Color.red;
            }
            m_currentSequence = new List<int>();
        }
    }

    private bool CompareLists(List<int> required, List<int> taken)
    {
        int idx = 0;

        while (idx < required.Count && idx < taken.Count)
        {
            if (required[idx] == taken[idx])
            {
                idx++;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
