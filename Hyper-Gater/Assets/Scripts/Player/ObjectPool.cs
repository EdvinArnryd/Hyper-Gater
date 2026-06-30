using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private Transform _poolParent;
    [SerializeField] private int _startAmount = 10;
    private Queue<GameObject> _queue;

    void Awake()
    {
        Instance = this;
        _queue = new Queue<GameObject>();

        for (int i = 0; i < _startAmount; i++)
        {
            GameObject obj = Instantiate<GameObject>(_objectPrefab, transform.position, Quaternion.identity, _poolParent);
            obj.SetActive(false);
            _queue.Enqueue(obj);
        }
    }

    public GameObject Spawn(Vector3 position)
    {
        if(_queue.Count <= 0)
        {
            Instantiate<GameObject>(_objectPrefab, position, Quaternion.identity, _poolParent);
        }
        GameObject obj = _queue.Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        return obj;
    }

    public void DeSpawn(GameObject obj)
    {
        _queue.Enqueue(obj);
        obj.SetActive(false);
    }
}
