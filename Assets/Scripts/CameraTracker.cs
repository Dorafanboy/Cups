using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Container _container;
    [SerializeField] private float _offset;
    private Cup _cup;

    //private void Start()
    //{
    //    _cup = _container.GetCup();
    //    Debug.Log("Name: " + _cup.name);
    //}

    //private void FixedUpdate()
    //{
    //    transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), _speed * Time.fixedDeltaTime);
    //    if (_cup != null)
    //        return;
    //    else
    //        _cup = _container.GetCup();
    //}

    //private Vector3 GetTargetPosition()
    //{
    //    return new Vector3(_cup.transform.position.x + _offset, transform.position.y, transform.position.z);
    //}
}
