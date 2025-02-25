using UnityEngine;

public class BonusEnemy : MonoBehaviour
{
    private Vector3 screenBounds;
    private float rightBound;
    private float leftBound;
    public float offSet = 1f;
    private float currentSpeed;
    private float direction;
    private float enemyHalfWidth;
    private Vector3 positionAux;
    private GameManager gameManager;
    public int scoreIncrease = 10;
    public float baseSpeed = 5f;
    public float speedIncrease = 0.33333f;
    public float firstMovementTime = 6f;
    public float timeBetweenMovements = 10f;
    private float waitingTimeAux;
    private bool isMoving = false;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width,
            Screen.height,
            Camera.main.transform.position.z)
        );

        rightBound = screenBounds.x;
        leftBound = -screenBounds.x;
        direction = 1f;
        enemyHalfWidth = (GetComponent<SpriteRenderer>().bounds.size.x) / 2;
        gameManager = GameManager.Instance;
        currentSpeed = (speedIncrease * (gameManager.Level - 1)) + baseSpeed;
        waitingTimeAux = firstMovementTime;
    }

    void Update()
    {
        if (isMoving)
        {
            Movement();
            if (Mathf.Abs(transform.position.x - (direction * (rightBound + enemyHalfWidth + offSet))) <= 0.01f)
            {
                isMoving = false;
                waitingTimeAux = timeBetweenMovements;
                ChangeDirection();
            }
        }
        else
        {
            waitingTimeAux -= Time.deltaTime;
            if (waitingTimeAux <= 0)
            {

                isMoving = true;

            }
        }
    }

    public void Movement()
    {
        transform.position += Vector3.right * direction * currentSpeed * Time.deltaTime;
        positionAux = transform.position;
        positionAux.x = Mathf.Clamp(
            positionAux.x,
            leftBound - enemyHalfWidth - offSet,
            rightBound + enemyHalfWidth + offSet
        );
        transform.position = positionAux;
    }

    public void ChangeDirection()
    {
        direction *= -1f;
    }

    public void TakeDamage()
    {
        gameManager.Score += scoreIncrease;
        transform.position = new Vector3(direction * (rightBound + enemyHalfWidth + offSet), transform.position.y, transform.position.z);
        ChangeDirection();
    }
}
