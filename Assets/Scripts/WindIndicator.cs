using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindIndicator : MonoBehaviour
{
    [SerializeField] private GameRunner runner;
    [SerializeField] private float angleOffset;

    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        var angle = Mathf.Atan2(runner.WindDirection.normalized.z, runner.WindDirection.normalized.x) * Mathf.Rad2Deg;
        angle += angleOffset;
        _rectTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
