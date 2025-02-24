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

    // Incremento de la velocidad por nivel
    public float speedIncrease = 0.3f;

    // Velocidad actual del movimiento de los enemigos
    public float speed = 0f;

    private bool canChangeDirection = true;

    public float lockChangeDirectionTime = 1f;

    private bool canHeightKill = true;

    public Player player;

    public Transform playerTransform;

    private float playerHeight;
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
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerHeight = playerTransform.position.y;
        // Debug.Log("Player height: " + playerHeight);

    }

    void Start()
    {
        gameManager = GameManager.Instance;

        // Inicializa la dirección del movimiento hacia la derecha
        direction = 1f;

        // Calcula la velocidad de los enemigos basada en el nivel actual
        // del juego
        speed = speedIncrease * (gameManager.Level - 1) + baseSpeed;
        // Debug.Log("Current Level: " + gameManager.Level);
        // Debug.Log("Current Speed: " + speed);



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

        // Debug.Log("Current direction: " + direction);
    }



    public void ChangeDirection()
    {
        /**
         * Cambia la dirección de los enemigos, sin embargo,
         * previamente los hace descender una distancia predefinida.
         */

        // Si la función está bloqueada, no permite que se
        // cambie la dirección, nuevamente        
        if (!canChangeDirection)
        {
            return;
        }

        // Se bloquea la función para evitar 
        // multiples llamadas a la misma función
        canChangeDirection = false;

        // Debug.Log("ChangeDirection() llamado - Dirección antes: " + direction);
        transform.position += Vector3.down * baseDropDistance;
        direction *= -1;
        // Debug.Log("Dirección después: " + direction);


        Invoke(nameof(ResetDirectionChange), lockChangeDirectionTime);
    }


    public void ResetDirectionChange()
    {
        canChangeDirection = true;
    }

    public void HeightKill()
    {

        if (!canHeightKill)
        {
            return;
        }

        canHeightKill = false;

        player.TakeDamage();

        Invoke(nameof(ResetHeightKill), 1f);
    }

    public void ResetHeightKill()
    {
        canHeightKill = true;
    }

    public float PlayerHeight
    {
        get { return playerHeight; }
    }
}
