using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private Transform _fixationPoint;
    public Transform FixationPoint => _fixationPoint;
}
