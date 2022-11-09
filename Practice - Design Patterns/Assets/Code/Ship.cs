using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ships
{
    public class Ship : MonoBehaviour
 {
     [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private Transform _myTransform;
    //[SerializeField] private float limitMinPosition;
    //[SerializeField] private float limitMaxPosition;
    
    private IInput _input;
    private ICheckLimits _checkLimits;
    
    private void Awake()
    {
        _myTransform = transform;
    }

    public void Configure(IInput input, ICheckLimits checkLimits)
    {
        _input = input;
        _checkLimits = checkLimits;
    }

    void Update()
    {
        var direction = GetDirection();
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (speed * Time.deltaTime));
        _checkLimits.ClampFinalPosition();
    }

    private Vector2 GetDirection()
    {
        return _input.GetDirection();
    }
 }
    
}
