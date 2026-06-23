using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObjectRow> _spawnList;
    [SerializeField] private float _enemySpawnCooldown = 0.5f;
    [SerializeField] private float _newObjectSpawnCooldown = 1f;
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        foreach (var row in _spawnList)
        {
            foreach (var rowObject in row.row)
            {
                GameObject instantiated = Instantiate(rowObject);
                
                instantiated.transform.position = transform.position;
                instantiated.transform.rotation = transform.rotation;


                yield return new WaitForSeconds(_enemySpawnCooldown);
            }
            yield return new WaitForSeconds(_newObjectSpawnCooldown);
        }  
    }
}
