using UnityEngine;

// A coin disappears only when the PLAYER touches it.
// If the enemy or another coin touches it - nothing happens.
public class Coin : MonoBehaviour
{
    public int value;               // set by the spawner when the coin is created
    public CoinSpawner spawner;     // set by the spawner when the coin is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.CoinCollected(value);
            Destroy(gameObject);
        }
    }
}
