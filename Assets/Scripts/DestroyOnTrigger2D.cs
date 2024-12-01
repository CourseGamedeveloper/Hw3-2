using System.Collections;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] private string triggeringTag;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            animator.SetTrigger("death"); // Trigger death animation
            Destroy(other.gameObject); // Destroy the other object (e.g., bullet)
            StartCoroutine(DestroyAfterAnimation()); // Wait for the animation before destroying this object
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject); // Destroy this GameObject after the animation is done
    }

    private void Update() { }
}
