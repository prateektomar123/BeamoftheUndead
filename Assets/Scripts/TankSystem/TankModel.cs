using UnityEngine;

[CreateAssetMenu(fileName = "TankModel", menuName = "Tank/TankModel", order = 1)]
public class TankModel : ScriptableObject
{
    public enum TurretType { Basic, Rapid, Heavy, Spread }

    [Header("Tank Properties")]
    public string tankName = "Default Tank";
    public float maxSpeed = 5f;          
    public float acceleration = 10f;     
    public float turnSpeed = 50f;        
    public float vibrationAmplitude = 0.1f; 
    public float vibrationFrequency = 10f;  

    [Header("Turret Properties")]
    public string turretName = "Default Turret";
    public TurretType turretType = TurretType.Basic;
    public float turretRotationSpeed = 100f;
    public float damage = 10f;
    public float fireRate = 0.5f;
    public int ammoCapacity = 50;

    [Header("Prefab Reference")]
    public GameObject tankPrefab;
}