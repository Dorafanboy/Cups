using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupDeleter : MonoBehaviour
{
    private int _counter = 0;
    private PlayerWalk _walk;
    private void Start()
    {
        _walk = FindObjectOfType<PlayerWalk>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(_counter != 1)
        {
            //слделать через ивенты
            if (other.gameObject.TryGetComponent(out Cup cup))
            {
                _walk.DeleteCup(cup);
                Destroy(cup);
                _counter++;
                Debug.Log("delete");
            }
        }
    }
}
