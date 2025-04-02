using UnityEngine;

public class TankController : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private TankModel model; 
    [SerializeField] private TankView view;   

    private float shootTimer;    
    private int currentAmmo;     

    private void Start()
    {
=======
    [SerializeField] private TankModel model;
    [SerializeField] private TankView view;
    [SerializeField] private BulletTypeManager bulletTypeManager; 
    [SerializeField] private Transform firePoint;                

    private InputManager inputManager;
    private BulletPoolManager bulletPoolManager; 
    private float shootTimer;
    private int currentAmmo;

    private void Start()
    {
        inputManager = ServiceLocator.Get<InputManager>();
        bulletPoolManager = GetComponentInChildren<BulletPoolManager>(); // Assumes child of tank
        //view.UpdateVisuals(model);
>>>>>>> Stashed changes
        shootTimer = 0f;
        currentAmmo = model.ammoCapacity;
    }

    private void Update()
    {
        HandleMovement();
        HandleTurretRotation();
        HandleShooting();
    }

    private void HandleMovement()
    {
<<<<<<< Updated upstream
        
        float vertical = Input.GetAxisRaw("Vertical");   
        float horizontal = Input.GetAxisRaw("Horizontal"); 
=======
        float vertical = inputManager.GetVerticalAxis();
        float horizontal = inputManager.GetHorizontalAxis();

>>>>>>> Stashed changes
        Vector3 moveDirection = tankBase.forward * vertical;
        moveDirection.Normalize();

        view.MoveTank(moveDirection, model.moveSpeed);
        view.RotateTank(horizontal, model.rotationSpeed);
    }

    private void HandleTurretRotation()
    {
<<<<<<< Updated upstream
        // for future purpose if want to rotate the turret too...
        /*float rotation = 0f;
        if (Input.GetKey(KeyCode.Q))
            rotation = -1f; 
        else if (Input.GetKey(KeyCode.E))
            rotation = 1f; */

=======
        float rotation = 0f;
        // if (inputManager.IsQPressed())
        //     rotation = -1f;
        // else if (inputManager.IsEPressed())
        //     rotation = 1f;
>>>>>>> Stashed changes

        //view.RotateTurret(rotation, model.turretRotationSpeed);
    }

    private void HandleShooting()
    {
        shootTimer -= Time.deltaTime;
<<<<<<< Updated upstream
        if (Input.GetMouseButtonDown(0) && shootTimer <= 0f && currentAmmo > 0)
=======

        if (inputManager.IsShootPressed() && shootTimer <= 0f && currentAmmo > 0)
>>>>>>> Stashed changes
        {
            Shoot();
            shootTimer = model.fireRate;
            currentAmmo--;
            Debug.Log($"Ammo remaining: {currentAmmo}");
        }
    }

    private void Shoot()
    {
        //view.PlayShootAnimation();
        BulletController bullet = bulletPoolManager.GetBullet(firePoint.position, firePoint.rotation);
        bullet.Initialize(firePoint.forward, bulletPoolManager);
    }

    private Transform tankBase => view.transform;
}