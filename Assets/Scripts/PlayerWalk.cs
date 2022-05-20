using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float _forceSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private Cup _cupTemplate;
    [SerializeField] private Container _container;
    private List<Cup> _cups;
    private bool _isClick = true;
    public List<Cup> ThisList => _cups;
    public Cup LastElement => _cups.LastOrDefault();

    private void Start()
    {
        _cups = new List<Cup>();
        Vector3 spawnPoint = transform.position;
        _cups.Add(Instantiate(_cupTemplate, spawnPoint, _cupTemplate.transform.rotation, _container.transform));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isClick)
        {
            _isClick = false;
            StartCoroutine(Start(_stepSize, _forceSpeed, _cups));
        }
    }

    private IEnumerator Start(float stepSize, float forceSpeed, List<Cup> cups)
    {
        List<Cup> cupz = new List<Cup> (cups);
        IEnumerable<Cup> query = cupz.OrderBy(cup => cup.transform.position.y);
        List<Cup> j = query.Reverse().ToList();
        for (int i = 0; i < j.Count; i++)
        {
            StartCoroutine(j[i].GetComponent<MoveToNextPosition>().StartAnimations(stepSize, forceSpeed));
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(0.5f);

        _isClick = true;
    }

    public void CountUpdate(Cup cup)
    {
        _cups.Add(cup);
        cup.transform.parent = _container.transform;
    }

    public void DeleteCup(Cup cup)
    {
        _cups.Remove(cup);
        Destroy(cup.gameObject, 1f);
    }
}
