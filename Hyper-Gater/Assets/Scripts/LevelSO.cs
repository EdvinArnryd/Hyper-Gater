using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level")]
public class LevelSO : MonoBehaviour
{
    [SerializeField] private int _enemiesAmount;
    [SerializeField] private int _bossAmount;
    [SerializeField] private int _upgradesAmount;

    
}
