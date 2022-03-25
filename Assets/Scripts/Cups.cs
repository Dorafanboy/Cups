using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cups : MonoBehaviour
{
    private List<Cup> _cups;

    private void Start()
    {
        _cups = new List<Cup>();
    }

    private void Update()
    {
        //Debug.Log(_cups.Count);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cup cup))
        {
            cup.transform.parent = transform;
            _cups.Add(cup);
        }
    }
}
