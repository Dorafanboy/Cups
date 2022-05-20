using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cup _cupTemplate;
    [SerializeField] private Pole _poleTemplate;
    [SerializeField] private float _distanceBetweenCups;
    [SerializeField] private int _repeatCount;
    [SerializeField] private int _spawnChance;

    private CupSpawnPoint _cupSpawnPoint;
    private PoleSpawnPoint _poleSpawnPoint;


    private void Start()    
    {
        _cupSpawnPoint = GetComponentInChildren<CupSpawnPoint>();
        _poleSpawnPoint = GetComponentInChildren<PoleSpawnPoint>();

        for (int i = 0; i < _repeatCount; i++)
        {
            GenerateCup(_cupSpawnPoint.transform, _cupTemplate.gameObject, _spawnChance);
            MoveSpawner(_cupSpawnPoint, _distanceBetweenCups);
            GenerateCup(_poleSpawnPoint.transform, _poleTemplate.gameObject, _spawnChance);
            MoveSpawner(_cupSpawnPoint, _distanceBetweenCups * 2);
        }
    }

    private void GenerateCup(Transform spawnPoint, GameObject generatedElement, int spawnChance)
    {
        if(Random.Range(0, 10) < spawnChance)
            Instantiate(generatedElement, spawnPoint.transform.position, generatedElement.transform.rotation, transform);    
    }

    private void MoveSpawner(CupSpawnPoint spawnPoint, float distance)
    {
        spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x + distance, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
    }
}
