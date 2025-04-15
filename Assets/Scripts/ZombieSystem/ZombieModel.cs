using UnityEngine;

[CreateAssetMenu(fileName = "ZombieModel", menuName = "Zombie/ZombieModel", order = 1)]
public class ZombieModel : ScriptableObject
{
    [Header("Zombie Properties")]
    public string zombieName = "Basic Zombie";
    public float health = 50f;
    public float speed = 2f;
    public float damage = 10f;

    [Header("Prefab Reference")]
    public GameObject zombiePrefab;
}