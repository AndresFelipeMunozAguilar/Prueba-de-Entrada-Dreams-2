using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameManager gameManager;

    public int scoreIncrease = 10;

    void Start()
    {
        gameManager = GameManager.Instance;
    }


    public void TakeDamage()
    {
        gameManager.Score += scoreIncrease;
        Destroy(gameObject);
    }

}
