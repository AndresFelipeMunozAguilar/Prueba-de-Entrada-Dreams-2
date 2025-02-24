using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float maxReloadTime = 5.0f;
    private float currentReloadTime = 0.0f;
    private GameManager gameManager;

    private bool isAbleToShoot = false;


    private float randomValue;

    public float invokeToggleShooting = 0.1f;

    public float toggleShootingRate = 5f;

    // Probabilidad de que, en el primer frame,
    // el enemigo pueda disparar y de que, cada
    // cierto tiempo, se le permita o se le niegue
    // esta capacidad.
    // Ejemplo: Si Activation chance = 0.05f
    // Hay un 5% de probabilidad de que el enemigo
    // pueda disparar en el primer frame y, además,
    // cada cierto tiempo, hay un 5% de probabilidad
    // de que se le permita o se le niegue esta capacidad
    private float activationChance;

    /*
     * Debido a que la probabilidad de que a un enemigo
     * se le permita disparar y la probabilidad de que
     * otro enemigo se le permita o se le niegue esta
     * capacidad, depende del nivel actual del juego
     * se implementa una función lineal que modela la 
     * dificultad del juego, a través de una pendiente
     * de dificultad (Que tan dificil se hace por nivel)
     * y una base de dificultad (Que tan dificil es el
     * juego en el nivel 1)
     */
    public float pendienteDeDificultad = 0.1f;

    public float baseDeDificultad = 0.1f;
    void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager no encontrado");
        }

        // Genera un valor aleatorio entre 0 y 1 para cada 
        // instancia del prefab de enemigo
        randomValue = Random.Range(0f, 1f);

        activationChance = (gameManager.Level * pendienteDeDificultad) + baseDeDificultad;

        // Si el valor aleatorio es menor que activationChance, 
        // se permite que el enemigo dispare
        if (randomValue <= activationChance)
        {
            isAbleToShoot = true;
        }

        currentReloadTime = maxReloadTime;


        InvokeRepeating(nameof(ToggleShootingAbility), invokeToggleShooting, toggleShootingRate);
    }

    void Update()
    {
        if (!isAbleToShoot)
        {
            return;
        }

        if (currentReloadTime <= 0)
        {
            Shoot();
            currentReloadTime = maxReloadTime;
        }

        if (currentReloadTime > 0)
        {
            currentReloadTime -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        /**
         * Instancia un objeto de tipo Bullet en la
         * posición y la rotación del firePoint (El 
         * cañón del alien) 
         */
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


    private void ToggleShootingAbility()
    {

        /*
         * Función que cambia el valor de isAbleToShoot
         * basado en activationChance. En los primeros 
         * niveles, es más probable que sólo pocos enemigos
         * puedan disparar; en cambio, en niveles superiores,
         * es más proable que varios de los enemigos puedan disparar.
         */
        if (Random.Range(0f, 1f) <= activationChance)
        {
            isAbleToShoot = !isAbleToShoot;
        }
    }
}
