using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    private List<Cup> _cups;
    private List<Animator> _ani;
    private bool _check = false;

    private void Start()
    {
        _cups = new List<Cup>();
        Vector3 spawnPoint = transform.position;
        _ani = new List<Animator>();
        _ani.Add(gameObject.GetComponentInChildren<Animator>());

    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(StartAnimations(_ani));
            _check = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Animator anim))
        {
            Debug.Log(_ani.Count);
            _ani.Add(anim);
        }
    }

    IEnumerator StartAnimations(List<Animator> anims)
    {
        Debug.Log(anims.Count);
        for (int i = 0; i < anims.Count; i++)
        {
            Debug.Log(i);
            anims[i].SetBool("SetTrigger", true);
            yield return new WaitForSeconds(2f);
            anims[i].SetBool("SetTrigger", false);
        }
    }
}
