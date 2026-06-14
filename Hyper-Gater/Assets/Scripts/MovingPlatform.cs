using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private int _rows = 5;
    [SerializeField] private int _cols = 5;
    private float _widthMax;
    private float _widthMin = 0;
    private float _heightMax;
    private float _heightMin = 0;

    private Vector3 _startPoint;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        _widthMax = GetComponent<Renderer>().bounds.size.x;
        _heightMax = GetComponent<Renderer>().bounds.size.z;
        Vector3 boundsMin = GetComponent<Renderer>().bounds.min;
        Vector3 boundsMax = GetComponent<Renderer>().bounds.max;
        
        Vector3 firstRay = boundsMin + new Vector3(0,transform.position.y * 2,0);
        // Gizmos.DrawRay(firstRay , new Vector3(_widthMax, 0 ,0));
        // Gizmos.DrawRay(firstRay , new Vector3(0, 0 ,_heightMax));

        // Draw Cols
        for (int i = 0; i <= _cols; i++)
        {
            float xVal = i * (_widthMax/_cols);
            Gizmos.DrawRay(firstRay + new Vector3(xVal,0,0) , new Vector3(0, 0 ,_heightMax));
        }

        for (int i = 0; i <= _rows; i++)
        {
            float yVal = i * (_heightMax/_rows);
            Gizmos.DrawRay(firstRay + new Vector3(0,0,yVal) , new Vector3(_widthMax, 0 ,0));
        }
    }

    void Awake()
    {
       

    }
}
