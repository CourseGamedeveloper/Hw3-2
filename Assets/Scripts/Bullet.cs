using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("speed for the bullet ")]
    private float speed;
    private float direction;
    private bool hit;
  

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

      
    }
  
    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
  

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
