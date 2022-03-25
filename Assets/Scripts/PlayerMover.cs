using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _forceSpeed;
    //[SerializeField] private Cup _cupTemplate;
    private List<Cup> _cups;
    private Animator _anim;
    private Rigidbody _rigidbody;
    private Vector3 _targetDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _targetDirection = transform.position;
        _anim = GetComponent<Animator>();
        _cups = new List<Cup>();
        Vector3 spawnPoint = transform.position;
        //_cups.Add(Instantiate(_cupTemplate, spawnPoint, _cupTemplate.transform.rotation, transform));
    }


    private void FixedUpdate()
    {
        if (transform.position.x != _targetDirection.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetDirection, 3f * Time.fixedDeltaTime);
        }
    }

    public void SetPosition(float stepSize)
    {
        _rigidbody.AddForce(Vector3.up * _forceSpeed);
        _targetDirection = new Vector3(transform.position.x + stepSize, transform.position.y, transform.position.z);
    }


}
