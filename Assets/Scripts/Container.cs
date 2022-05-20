using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private PlayerWalk _walk;

    private void Start()
    {
        _walk = GetComponent<PlayerWalk>();
    }

    public Cup GetCup()
    {
        return _walk.LastElement;
    }
}
