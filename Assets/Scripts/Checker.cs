using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checker : MonoBehaviour
{
    private PlayerWalk _walk;
    public event UnityAction<Cup> OnAddCup;

    private void Awake()
    {
        _walk = FindObjectOfType<PlayerWalk>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Cup cup))
        {
            if (_walk.ThisList.Contains(cup))
                return;

            //cup.transform.parent = FindObjectOfType<Spawner>().transform;
            OnAddCup?.Invoke(cup);
        }
    }
}
