using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cup _cupTemplate;
    private List<Cup> _cups;

    private void Start()
    {
        _cups = new List<Cup>();
        Vector3 spawnPoint = transform.position;
        _cups.Add(Instantiate(_cupTemplate, spawnPoint, _cupTemplate.transform.rotation, transform));

    }

}
