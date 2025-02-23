using UnityEngine;

public class BounceOnBorders : MonoBehaviour
{

    private EnemyController enemyController;

    void Start()
    {
        enemyController = EnemyController.Instance;

        if (enemyController == null)
        {
            Debug.LogError("EnemyController is null");
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AlienBorder"))
        {
            Debug.Log("Alien colisiona contra borde");
            enemyController.ChangeDirection();
        }
    }
}
