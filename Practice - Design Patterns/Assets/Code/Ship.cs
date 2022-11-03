using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ships
{
    public class Ship : MonoBehaviour
{
    [Header("Input Settings")]
    [SerializeField] private IInput _input;
    
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float limitMinPosition;
    [SerializeField] private float limitMaxPosition;
    
    private Transform _myTransform;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _myTransform = transform;  //Option 2 = GetComponent<Transform>()
    }

    public void Configure(IInput input)
    {
        _input = input;
    }

    void Update()
    {
        var direction = GetDirection();
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (speed * Time.deltaTime));
        ClampFinalPosition();
    }

    private void ClampFinalPosition()
    {
        var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, limitMinPosition, limitMaxPosition);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, limitMinPosition, limitMaxPosition);
        _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
    }

    private Vector2 GetDirection()
    {
        return _input.GetDirection();
    }
 }
}
