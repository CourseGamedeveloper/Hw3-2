using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("speed the enemy movement")]
    private float speed;
    private Rigidbody2D _rigidbody;
    [Tooltip("this gameobject is target make the enemy attack ")]
    public GameObject Player;
    private float distance;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
        
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
