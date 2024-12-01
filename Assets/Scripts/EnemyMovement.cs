using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Speed of the enemy movement")]
    private float speed;

    private Rigidbody2D _rigidbody;

    [Tooltip("This GameObject is the target that the enemy will attack")]
    public GameObject Player;

    private float distance;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player"); // Assign the Player GameObject dynamically
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance > 2f) // If the enemy is farther than 2 units from the player
        {
            // Calculate the direction to the player
            Vector2 direction = (Player.transform.position - transform.position).normalized;

            // Move the enemy towards the player
            _rigidbody.linearVelocity = direction * speed;
        }
        else
        {
            // Stop the enemy's movement
            _rigidbody.linearVelocity = Vector2.zero;
        }
    }
}
