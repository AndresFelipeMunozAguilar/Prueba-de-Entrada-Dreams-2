using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.Instance;
    }


    public void TakeDamage()
    {
        gameManager.Score += 10;
        Destroy(gameObject);
    }

}
