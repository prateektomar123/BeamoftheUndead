using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private TankModel model;
    [SerializeField] private TankView view;
    private BulletTypeManager bulletTypeManager;
    [SerializeField] private Transform firePoint;

    private InputManager inputManager;
    private BulletPoolManager bulletPoolManager;
    private float shootTimer;
    private int currentAmmo;
    private Vector3 targetVelocity;
    private ICommand shootCommand;

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

        view.UpdateVisuals(model);
        shootTimer = 0f;
        currentAmmo = model.ammoCapacity;

        if (bulletTypeManager == null)
        {
            Debug.LogWarning("BulletTypeManager not set yet, waiting for TankSpawner...");
        }

        shootCommand = new ShootCommand(view, bulletPoolManager, firePoint, 1);
    }

    private void Update()
    {
        if (bulletPoolManager == null || bulletTypeManager == null) return;

        HandleMovement();
        HandleTurretRotation();
        HandleShooting();
        HandleVibration();
    }

    private void HandleMovement()
    {
        float vertical = inputManager.GetVerticalAxis();
        float horizontal = inputManager.GetHorizontalAxis();

        Vector3 moveDirection = tankBase.forward * vertical;
        moveDirection.Normalize();
        targetVelocity = Vector3.MoveTowards(targetVelocity, moveDirection * model.maxSpeed, model.acceleration * Time.deltaTime);

        Vector3 groundNormal = view.GetGroundNormal();
        view.MoveTank(targetVelocity, groundNormal);

        view.RotateTank(horizontal, model.turnSpeed);
    }

    private void HandleTurretRotation()
    {
        // float rotation = 0f;
        // if (inputManager.IsQPressed())
        //     rotation = -1f;
        // else if (inputManager.IsEPressed())
        //     rotation = 1f;

        // view.RotateTurret(rotation, model.turretRotationSpeed);
    }

    private void HandleShooting()
    {
        shootTimer -= Time.deltaTime;

        if (inputManager.IsShootPressed() && shootTimer <= 0f && currentAmmo > 0)
        {
            shootCommand.Execute();
            shootTimer = model.fireRate;
            currentAmmo--;
            Debug.Log($"Ammo remaining: {currentAmmo}");
        }
    }

    private void HandleVibration()
    {
        view.VibrateTurret(model.vibrationAmplitude, model.vibrationFrequency);
    }

    public void SetBulletTypeManager(BulletTypeManager manager)
    {
        bulletTypeManager = manager;
        Debug.Log("BulletTypeManager set in TankController");
    }

    private Transform tankBase => view.transform;
}