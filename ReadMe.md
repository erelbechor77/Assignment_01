# Assignment_01 - Coin Collector (Unity 2D)

**Scene:** `Assets/Scenes/Assignment_01.unity`
**Unity version:** 6000.3.27f1

## Game description
The player (white capsule) collects coins to reach the target score (1000).
A red enemy capsule constantly chases the player. If the enemy reaches the player
before the target score is reached - the player loses.

## Controls
`W` `A` `S` `D` - move the player.

## Scripts (`Assets/Scripts`)
| Script | Attached to | What it does |
|---|---|---|
| `PlayerMovement.cs` | Player | Reads WASD input in `Update`, moves the player with `Rigidbody2D.linearVelocity` in `FixedUpdate`. |
| `EnemyChase.cs` | Enemy | Chases the player every `FixedUpdate` using `Rigidbody2D`. Trigger with the `Player` tag -> Game Over (player is destroyed). |
| `Coin.cs` | Coin prefab | Trigger collider. Disappears (`Destroy`) **only** when touched by an object tagged `Player`. Enemy / other coins are ignored. |
| `CoinSpawner.cs` | CoinSpawner (empty GameObject) | Creates coins at runtime with the prefab + `Instantiate`, keeps the score, spawns a new batch when all coins are collected and checks for a win. |

## Coins
- `Assets/Prefabs/Coin.prefab` - a circle with a trigger `CircleCollider2D` and the `Coin` script.
- **3 coin types** are defined in the Editor (CoinSpawner -> *Coin Types*), each with a value and a color:
  - Orange - 50
  - Green - 20
  - Blue - 10
- For every coin the type is chosen randomly (`Random.Range`) when it is created.
- Coin positions are random inside a range that is set in the Editor (*Min Position* / *Max Position*).
- A batch of 5 coins (*Coins Per Batch*, editable) appears at the start. When all are collected, a new batch is created.

## Physics setup
- Player and Enemy: `Rigidbody2D` (Dynamic, Gravity Scale 0, Freeze Rotation Z). Movement is done in `FixedUpdate`.
- Player: `CapsuleCollider2D`. Enemy: `CapsuleCollider2D` with **Is Trigger**. Coin: `CircleCollider2D` with **Is Trigger**.
- Tags used: `Player`, `Enemy`.

## Win / Lose
- **Win:** score >= Win Score (1000) -> "You Win!" in the Console and the enemy is removed.
- **Lose:** the enemy touches the player -> "Game Over" in the Console and the player is removed.
