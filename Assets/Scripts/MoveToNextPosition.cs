using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class MoveToNextPosition : MonoBehaviour
{
    private Vector3 _targetDirection;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _targetDirection = transform.position;
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (transform.position.x != _targetDirection.x)
             transform.position = Vector3.MoveTowards(transform.position, _targetDirection, 3f * Time.fixedDeltaTime);
    }

    private void SetPosition(float stepSize, float forceSpeed)
    {
        _rigidbody.AddForce(Vector3.up * forceSpeed);
        _targetDirection = new Vector3(transform.position.x + stepSize, transform.position.y, transform.position.z);
    }

    public IEnumerator StartAnimations(float stepSize, float forceSpeed)
    {
        SetPosition(stepSize, forceSpeed);
        _animator.SetBool("SetTrigger", true);
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("SetTrigger", false);
    }  
}
