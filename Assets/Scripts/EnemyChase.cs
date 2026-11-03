using UnityEngine;

// The enemy (red capsule) constantly chases the player.
// If it touches the player (trigger) - the player loses.
public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform target;   // drag the Player here in the Editor
    [SerializeField] private float speed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null)   // the player was destroyed - stop moving
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over - the enemy caught you!");
            Destroy(other.gameObject);
        }
    }
}
