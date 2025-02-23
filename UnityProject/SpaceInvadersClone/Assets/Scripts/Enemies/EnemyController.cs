using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance { get; private set; }

    private GameManager gameManager;


    private float direction;

    public float dropDistance = 4.0f;
    public float speed = 1.0f;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameManager = GameManager.Instance;

        direction = 1f;
    }

    void Update()
    {
        EnemiesMovement();
    }


    private void OnDestroy()
    {
        Instance = null;
    }

    public void EnemiesMovement()
    {
        /**
         * Mueve a los enemigos hacia la izquierda
         * y hacia abajo, en caso de que lleguen a los
         * límites de la pantalla.
         */

        transform.position += Vector3.right * direction * speed * Time.deltaTime;
    }

    public void ChangeDirection()
    {
        /**
         * Cambia la dirección de los enemigos
         * hacia la derecha.
         */

        transform.position += Vector3.down * dropDistance;

        direction *= -1;

    }
}
