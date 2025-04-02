using UnityEngine;

[CreateAssetMenu(fileName = "BulletModel", menuName = "Bullet/BulletModel", order = 1)]
public class BulletModel : ScriptableObject
{
    public enum BulletType { Basic, Rapid, Heavy, Spread }

    [Header("Bullet Properties")]
    public string bulletName = "Default Bullet";
    public BulletType bulletType = BulletType.Basic;
    public float damage = 10f;          
    public float speed = 20f;           
    public float lifetime = 2f;         
    public int cost = 0;                

    [Header("Prefab Reference")]
    public GameObject bulletPrefab;     
}