using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed;

    void Update()
    {
        transform.position += transform.forward * _walkingSpeed * Time.deltaTime;
    }
}
