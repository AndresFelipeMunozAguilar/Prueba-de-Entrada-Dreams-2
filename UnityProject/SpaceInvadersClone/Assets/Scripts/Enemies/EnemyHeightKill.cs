using UnityEngine;
using System.Collections;

public class EnemyHeightKill : MonoBehaviour
{

    private float playerHeight;

    void Start()
    {

        // if (playerObject == null)
        // {

        //     Debug.LogError("Player object is null\n\n\n");
        // }

        if (EnemyController.Instance != null)
        {
            playerHeight = EnemyController.Instance.playerTransform.position.y;
            // Debug.Log("Player height is set to: " + playerHeight);

        }
        else
        {
            Debug.LogError("EnemyController is null");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= playerHeight
            && transform.position.y <= 0)
        {

            // Debug.Log("Im an enemy and my height is: " + transform.position.y);
            // Debug.Log("Im an enemy and player height is: " + playerHeight);

            HeightKill();
        }


    }

    public void HeightKill()
    {

        EnemyController.Instance.HeightKill();

    }
}
