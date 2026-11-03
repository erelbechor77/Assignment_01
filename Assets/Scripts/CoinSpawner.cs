using UnityEngine;

// One coin type: its score value and its color (both set in the Editor).
[System.Serializable]
public class CoinType
{
    public string name;
    public int value;
    public Color color = Color.white;
}

// Creates batches of coins at random positions, keeps the score and checks for a win.
public class CoinSpawner : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private CoinType[] coinTypes;     // 3 types - set in the Editor
    [SerializeField] private int coinsPerBatch = 5;

    [Header("Spawn range")]
    [SerializeField] private Vector2 minPosition = new Vector2(-8f, -4f);
    [SerializeField] private Vector2 maxPosition = new Vector2(8f, 4f);

    [Header("Game")]
    [SerializeField] private int winScore = 1000;
    [SerializeField] private GameObject enemy;          // destroyed when the player wins

    private int score = 0;
    private int coinsLeft = 0;
    private bool gameWon = false;

    void Start()
    {
        SpawnBatch();
    }

    private void SpawnBatch()
    {
        for (int i = 0; i < coinsPerBatch; i++)
        {
            // random type
            CoinType type = coinTypes[Random.Range(0, coinTypes.Length)];

            // random position inside the range
            float x = Random.Range(minPosition.x, maxPosition.x);
            float y = Random.Range(minPosition.y, maxPosition.y);
            Vector2 position = new Vector2(x, y);

            GameObject newCoin = Instantiate(coinPrefab, position, Quaternion.identity);

            // apply the type: color + value
            newCoin.GetComponent<SpriteRenderer>().color = type.color;
            Coin coin = newCoin.GetComponent<Coin>();
            coin.value = type.value;
            coin.spawner = this;
        }

        coinsLeft = coinsPerBatch;
    }

    // Called by a coin when the player collects it.
    public void CoinCollected(int value)
    {
        if (gameWon) return;   // the game already ended with a win

        score += value;
        coinsLeft--;
        Debug.Log("Score: " + score);

        if (score >= winScore)
        {
            gameWon = true;
            Debug.Log("You Win! Final score: " + score);
            Destroy(enemy);
            return;            // game over - no more coins
        }

        if (coinsLeft == 0)
        {
            SpawnBatch();
        }
    }
}
