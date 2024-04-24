using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Text))]

public class TextLabelBehaviour : MonoBehaviour
{
    private Text label;
    public UnityEvent startEvent;

    private void Start()
    {
        label = GetComponent<Text>();
        startEvent.Invoke();
    }

    public void UpdateLabel(FloatData obj)
    {
        label.text = obj.value.ToString();
    }

    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString();
    }
}
