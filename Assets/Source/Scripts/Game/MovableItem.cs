using System;
using NaughtyAttributes;
using UnityEngine;

public class MovableItem : MonoBehaviour
{
    [BoxGroup("SETTINGS")] [SerializeField]
    private Vector3 _firstPoint;
    [BoxGroup("SETTINGS")] [SerializeField]
    private Vector3 _secondPoint;
    [BoxGroup("SETTINGS")] [SerializeField]
    private float _speed;

    private bool _isMovingToFirst;
    private Vector3 _target;

    [Button]
    private void SetFirstPoint()
    {
        _firstPoint = transform.position;
    }
    
    [Button]
    private void SetSecondPoint()
    {
        _secondPoint = transform.position;
    }

    private void Start()
    {
        _isMovingToFirst = false;
        _target = _secondPoint;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _target) < 0.01f)
        {
            _target = _isMovingToFirst ? _secondPoint : _firstPoint;
            _isMovingToFirst = !_isMovingToFirst;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}
