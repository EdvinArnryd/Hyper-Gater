using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _soldierPrefab;
    [SerializeField] private GameObject[] _positions;
    [SerializeField] private int _startingSoldiers;

    void Awake()
    {
        for (int i = 0; i < _startingSoldiers; i++)
        {
            Instantiate(_soldierPrefab, _positions[i].gameObject.transform);
        }
    }

    public void AddSoldiers(int amount)
    {
        
    }

}
