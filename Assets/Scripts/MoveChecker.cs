using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChecker : MonoBehaviour
{
    private Checker _checker;
    private PlayerWalk _walk;

    private void Awake()
    {
        _checker = GetComponentInChildren<Checker>();
        _walk = FindObjectOfType<PlayerWalk>();
    }

    private void OnEnable()
    {
        _checker.OnAddCup += OnCountCupsUpdated;
    }

    private void OnCountCupsUpdated(Cup cup)
    {
        _walk.CountUpdate(cup);
       // _checker.OnAddCup -= OnCountCupsUpdated;        
    }
}
