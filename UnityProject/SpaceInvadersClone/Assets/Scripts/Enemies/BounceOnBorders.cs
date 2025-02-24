using UnityEngine;

public class BounceOnBorders : MonoBehaviour
{

    private EnemyController enemyController;

    void Start()
    {
        // Obtiene la instancia del controlador de enemigos
        enemyController = EnemyController.Instance;

        if (enemyController == null)
        {
            // Debug.LogError("EnemyController is null");
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Si colisiona con un objeto que tiene la etiqueta "AlienBorder"
        if (other.gameObject.CompareTag("AlienBorder"))
        {
            /*
             * Si cualquier alien llega a los bordes de la pantalla
             * los enemigos bajan una fila y se invierte la dirección
             * de movimiento de los enemigos
             */

            // Debug.Log("Alien colisiona contra borde");
            // Cambia la dirección del movimiento de los enemigos
            enemyController.ChangeDirection();
        }
    }
}
