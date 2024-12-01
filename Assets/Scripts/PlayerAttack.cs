using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject bulletPrefab; 
    private bool fireContinuously;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the player object.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Fire bullet on mouse click
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        // Trigger animation
        if (animator != null)
        {
            animator.SetTrigger("shooter");
        }
        Vector3 pos=new Vector3(transform.position.x+1.5f, transform.position.y+1f,transform.position.z);

        // Instantiate and fire the bullet
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localScale.x));
    }



}
