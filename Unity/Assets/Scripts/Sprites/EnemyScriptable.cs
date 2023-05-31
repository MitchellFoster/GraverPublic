using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy1")]
public class EnemyScriptable : ScriptableObject
{
    public int health = 100;
    public int experience = 0;
}
