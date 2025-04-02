using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform tankBase;
    [SerializeField] private Transform turret;
    // [SerializeField] private Animator tankAnimator;
    // [SerializeField] private Animator turretAnimator;

    // private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    // private static readonly int Shoot = Animator.StringToHash("Shoot");
    private Vector3 originalTurretPosition;

    private void Start()
    {
        originalTurretPosition = turret.localPosition;
    }

    public void UpdateVisuals(TankModel model)
    {
        Debug.Log($"TankView updated for {model.tankName} with {model.turretName}");
    }

    public void MoveTank(Vector3 velocity, Vector3 groundNormal)
    {
        
        Vector3 adjustedVelocity = Vector3.ProjectOnPlane(velocity, groundNormal).normalized * velocity.magnitude;
        rb.velocity = Vector3.Lerp(rb.velocity, adjustedVelocity, Time.deltaTime * 5f);
        //tankAnimator.SetBool(IsMoving, rb.velocity.magnitude > 0.1f);

        
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    public void RotateTank(float rotation, float speed)
    {
        rb.angularVelocity = new Vector3(0f, rotation * speed, 0f); 
    }

    public void RotateTurret(float rotation, float speed)
    {
        turret.Rotate(0f, rotation * speed * Time.deltaTime, 0f);
    }

    public void VibrateTurret(float amplitude, float frequency)
    {
        float noiseX = Mathf.PerlinNoise(Time.time * frequency, 0f) - 0.5f;
        float noiseY = Mathf.PerlinNoise(0f, Time.time * frequency) - 0.5f;
        Vector3 vibration = new Vector3(noiseX, noiseY, 0f) * amplitude;
        turret.localPosition = originalTurretPosition + vibration;
    }

    public void PlayShootAnimation()
    {
        // turretAnimator.SetTrigger(Shoot);
    }

    
    public Vector3 GetGroundNormal()
    {
        if (Physics.Raycast(tankBase.position, Vector3.down, out RaycastHit hit, 2f))
        {
            return hit.normal;
        }
        return Vector3.up; 
    }
}