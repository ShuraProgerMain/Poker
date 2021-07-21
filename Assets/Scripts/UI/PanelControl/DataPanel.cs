using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPanel : MonoBehaviour
{
    public bool horizontalOffset;
    public float offset;
    public RectTransform currentTransform;

    private void Awake()
    {
        currentTransform = GetComponent<RectTransform>();
    }
}
