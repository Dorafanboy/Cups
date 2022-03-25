using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _stepSize;
    private PlayerMover _mover;
    private bool _isGrounded = true;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGrounded == true)
        {
            _isGrounded = false;
            _mover.SetPosition(_stepSize);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cup cup))
            _isGrounded = true;
        
    }
}
