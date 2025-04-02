using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private TankModel model;
    [SerializeField] private TankView view;
    private BulletTypeManager bulletTypeManager; // No longer serialized
    [SerializeField] private Transform firePoint;

    private InputManager inputManager;
    private BulletPoolManager bulletPoolManager;
    private float shootTimer;
    private int currentAmmo;

    private void Awake()
    {
        try
        {
            inputManager = ServiceLocator.Get<InputManager>();
        }
        catch
        {
            Debug.LogWarning("InputManager not found, using fallback.");
            inputManager = gameObject.AddComponent<InputManager>();
        }
    }

    private void Start()
    {
        bulletPoolManager = GetComponentInChildren<BulletPoolManager>();
        if (bulletPoolManager == null)
        {
            Debug.LogError("BulletPoolManager not found in children!");
            return;
        }

        
        shootTimer = 0f;
        currentAmmo = model.ammoCapacity;

        // BulletTypeManager will be set by TankSpawner
        if (bulletTypeManager == null)
        {
            Debug.LogWarning("BulletTypeManager not set yet, waiting for TankSpawner...");
        }
    }

    private void Update()
    {
        if (bulletPoolManager == null || bulletTypeManager == null) return;

        HandleMovement();
        HandleTurretRotation();
        HandleShooting();
    }

    private void HandleMovement()
    {
        float vertical = inputManager.GetVerticalAxis();
        float horizontal = inputManager.GetHorizontalAxis();

        Vector3 moveDirection = tankBase.forward * vertical;
        moveDirection.Normalize();

        view.MoveTank(moveDirection, model.moveSpeed);
        view.RotateTank(horizontal, model.rotationSpeed);
    }

    private void HandleTurretRotation()
    {
        /*float rotation = 0f;
        if (inputManager.IsQPressed())
            rotation = -1f;
        else if (inputManager.IsEPressed())
            rotation = 1f;

        view.RotateTurret(rotation, model.turretRotationSpeed);*/
    }

    private void HandleShooting()
    {
        shootTimer -= Time.deltaTime;

        if (inputManager.IsShootPressed() && shootTimer <= 0f && currentAmmo > 0)
        {
            Shoot();
            shootTimer = model.fireRate;
            currentAmmo--;
            Debug.Log($"Ammo remaining: {currentAmmo}");
        }
    }

    private void Shoot()
    {
        /*view.PlayShootAnimation();*/
        BulletController bullet = bulletPoolManager.GetBullet(firePoint.position, firePoint.rotation);
        bullet.Initialize(firePoint.forward, bulletPoolManager);
    }

    public void SetBulletTypeManager(BulletTypeManager manager)
    {
        bulletTypeManager = manager;
        Debug.Log("BulletTypeManager set in TankController");
    }

    private Transform tankBase => view.transform;
}