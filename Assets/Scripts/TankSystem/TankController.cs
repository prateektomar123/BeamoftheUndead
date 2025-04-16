using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private TankModel model;
    [SerializeField] private TankView view;
    [SerializeField] private Transform firePoint;

    private InputService inputService;
    private BulletPoolManager bulletPoolManager;
    private BulletTypeManager bulletTypeManager;
    private ICommand shootCommand;
    private float shootTimer;
    private int currentAmmo;
    private Vector3 targetVelocity;

    private void Awake()
    {
        inputService = ServiceLocator.Get<InputService>();
        bulletPoolManager = GetComponentInChildren<BulletPoolManager>();
        bulletTypeManager = FindObjectOfType<BulletTypeManager>();
        shootCommand = new ShootCommand(view, bulletPoolManager, firePoint, 1);
    }

    private void Start()
    {
        view.UpdateVisuals(model);
        shootTimer = 0f;
        currentAmmo = model.ammoCapacity;
    }

    private void Update()
    {
        HandleMovement();
        HandleTurretRotation();
        HandleShooting();
        HandleVibration();
    }

    private void HandleMovement()
    {
        float vertical = inputService.GetVerticalAxis();
        float horizontal = inputService.GetHorizontalAxis();

        Vector3 moveDirection = tankBase.forward * vertical;
        moveDirection.Normalize();
        targetVelocity = Vector3.MoveTowards(targetVelocity, moveDirection * model.maxSpeed, model.acceleration * Time.deltaTime);

        Vector3 groundNormal = view.GetGroundNormal();
        view.MoveTank(targetVelocity, groundNormal);

        view.RotateTank(horizontal, model.turnSpeed);
    }

    private void HandleTurretRotation()
    {
        float rotation = 0f;
        if (inputService.IsQPressed())
            rotation = -1f;
        else if (inputService.IsEPressed())
            rotation = 1f;

        view.RotateTurret(rotation, model.turretRotationSpeed);
    }

    private void HandleShooting()
    {
        shootTimer -= Time.deltaTime;

        if (inputService.IsShootPressed() && shootTimer <= 0f && currentAmmo > 0)
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