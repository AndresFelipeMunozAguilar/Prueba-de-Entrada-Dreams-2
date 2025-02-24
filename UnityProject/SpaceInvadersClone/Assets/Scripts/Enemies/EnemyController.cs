using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance { get; private set; }

    private GameManager gameManager;

    // Dirección del movimiento de los enemigos
    private float direction;

    // Distancia base que los enemigos descienden al cambiar de dirección
    public float baseDropDistance = 4.0f;

    // Velocidad base del movimiento de los enemigos
    public float baseSpeed = 1.0f;

    // Incremento de dificultad por nivel
    public float difficultyIncrease = 0.3f;

    // Velocidad actual del movimiento de los enemigos
    public float speed = 0f;

    void Awake()
    {
        /*
            * Implementación simple del patrón
            * Singleton para el controlador de enemigos.
            * Es necesario, pues, no pueden haber dos instancias
            * o, de lo contrario, el movimiento de los enemigos y
            * sus interacciones serían inconsistentes.
        */
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

        // Inicializa la dirección del movimiento hacia la derecha
        direction = 1f;

        // Calcula la velocidad de los enemigos basada en el nivel actual
        // del juego
        speed = difficultyIncrease * (gameManager.Level - 1) + baseSpeed;
        Debug.Log("Current Level: " + gameManager.Level);
        Debug.Log("Current Speed: " + speed);
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
         * Mueve a los enemigos hacia la izquierda o derecha
         * dependiendo de la dirección actual.
         */
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
    }



    public void ChangeDirection()
    {
        /**
         * Cambia la dirección de los enemigos, sin embargo,
         * previamente los hace descender una distancia predefinida.
         */
        transform.position += Vector3.down * baseDropDistance;
        direction *= -1;
    }
}
