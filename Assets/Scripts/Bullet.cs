using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Speed for the bullet")]
    private float speed; // The speed at which the bullet travels

    private float direction; // Direction of the bullet's movement (-1 for left, 1 for right)
    private bool hit; // Flag to check if the bullet has hit something
    private Animator anim; // Animator component for playing animations

    private void Awake()
    {
        // Initialize the Animator component
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // If the bullet has hit something, stop further updates
        if (hit) 
            return;

        // Calculate movement speed based on direction and deltaTime
        float movementSpeed = speed * Time.deltaTime * direction;

        // Move the bullet along the X-axis
        transform.Translate(movementSpeed, 0, 0);
    }
    /// Sets the direction of the bullet and activates it.
    public void SetDirection(float _direction)
    {
        // Set the direction and activate the bullet
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;

        // Adjust the bullet's local scale to face the correct direction
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }


    /// Deactivates the bullet 
    private void Deactivate()
    {
        // Disable the bullet game object
        gameObject.SetActive(false);
    }
}
