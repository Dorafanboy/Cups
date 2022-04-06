using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float _forceSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private Cup _cupTemplate;
    private List<Cup> _cups;
    private bool _isClick = true;

    private void Start()
    {
        _cups = new List<Cup>();
        Vector3 spawnPoint = transform.position;
        _cups.Add(Instantiate(_cupTemplate, spawnPoint, _cupTemplate.transform.rotation, transform));
        _cups.Add(Instantiate(_cupTemplate, spawnPoint, _cupTemplate.transform.rotation, transform));
        Debug.Log("Count cups: " + _cups.Count);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isClick)
        {
            _isClick = false;
            StartCoroutine(Start(_stepSize, _forceSpeed, _cups));
        } 
    }

    private IEnumerator Start(float stepSize, float forceSpeed, List<Cup> cups)
    {
        for (int i = 0; i < cups.Count; i++)
        {
            StartCoroutine(cups[i].GetComponent<MoveToNextPosition>().StartAnimations(stepSize, forceSpeed));
            yield return new WaitForSeconds(0.5f);
        }
        cups.Reverse();
        _isClick = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent(out Cup cup))
    //    {
    //        cup.transform.parent = this.gameObject.transform;
    //        //Debug.Log("Name: " + cup.gameObject.name);
    //        _cups.Add(cup);
    //    }
    //}  
}
