using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private TankModel model; 
    [SerializeField] private TankView view;   

    private float shootTimer;    
    private int currentAmmo;     

    private void Start()
    {
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
        
        float vertical = Input.GetAxisRaw("Vertical");   
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        Vector3 moveDirection = tankBase.forward * vertical;
        moveDirection.Normalize();

        view.MoveTank(moveDirection, model.moveSpeed);
        view.RotateTank(horizontal, model.rotationSpeed);
    }

    private void HandleTurretRotation()
    {
        // for future purpose if want to rotate the turret too...
        /*float rotation = 0f;
        if (Input.GetKey(KeyCode.Q))
            rotation = -1f; 
        else if (Input.GetKey(KeyCode.E))
            rotation = 1f; */


        //view.RotateTurret(rotation, model.turretRotationSpeed);
    }

    private void HandleShooting()
    {
        
        shootTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && shootTimer <= 0f && currentAmmo > 0)
        {
            Shoot();
            shootTimer = model.fireRate; 
            currentAmmo--;              
            Debug.Log($"Ammo remaining: {currentAmmo}");
        }
    }

    private void Shoot()
    {
        
        Debug.Log("Tank fired!");
    }

    
    private Transform tankBase => view.turret.transform;
}