using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private GameRunner gameRunner;
    private Rigidbody _rigidbody;
    [SerializeField] private float minDot = -.5f;
    
    void Start()
    {
        gameRunner = GameObject.Find("GameRunner").GetComponent<GameRunner>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        var dot = Vector3.Dot(gameRunner.WindDirection, transform.forward);
        var speed = Mathf.Clamp01((dot + minDot) / 1f + minDot);
        _rigidbody.velocity = transform.forward * gameRunner.WindDirection.magnitude * speed;
    }

    private void OnDrawGizmos()
    {
        if(gameRunner == null) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, gameRunner.WindDirection * 30f);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, _rigidbody.velocity * 30f);
    }
}
