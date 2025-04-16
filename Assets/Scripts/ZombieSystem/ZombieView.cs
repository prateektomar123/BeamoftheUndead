using UnityEngine;

public class ZombieView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void UpdateVisuals(ZombieModel model)
    {
        Debug.Log($"ZombieView updated for {model.zombieName}");
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
        animator.SetBool("IsWalking", true);
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("Die");
    }

    public void Deactivate()
    {
        animator.SetBool("IsWalking", false);
        gameObject.SetActive(false);
    }
}