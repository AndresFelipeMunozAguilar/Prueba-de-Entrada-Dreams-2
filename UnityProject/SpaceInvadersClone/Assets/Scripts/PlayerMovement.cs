using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento del jugador
    public float speed = 1.0f;

    // Valor del input horizontal
    private float horizontalInput = 0.1f;

    // Límites de la pantalla en coordenadas del mundo
    private Vector2 screenBounds;
    private float leftBound;
    private float rightBound;

    // Se almacena la mitad del ancho del jugador,
    // porque, servirá para que la completitud del sprite
    // se encuentre dentro de los límites de la pantalla.
    // Esto, pues, de lo contrario, el método que limita
    // el movimiento del jugador, permitiría que se salga de
    // la pantalla la mitad del sprite del jugador.
    private float playerHalfWidth;

    // Variable auxiliar para almacenar la posición del jugador
    private Vector3 positionAux;

    void Start()
    {
        // Calcula los límites de la pantalla en coordenadas del mundo
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rightBound = screenBounds.x;
        leftBound = -screenBounds.x;


        playerHalfWidth = (GetComponent<SpriteRenderer>().bounds.size.x) / 2;
    }

    // Update se llama una vez por frame
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");


        Movement(horizontalInput);
    }


    public void Movement(float horizontalInput)
    {
        /* 
            Calcula el movimiento horizontal del jugador,
            lo restringe a los límites de la pantalla
            y lo aplica a la posición del jugador
        */

        // Calcula el movimiento horizontal, para que
        // sea proporcional al tiempo que ha pasado entre
        // un frame y otro.
        float horizontalMovement = horizontalInput * speed * Time.deltaTime;


        transform.position += new Vector3(horizontalMovement, 0, 0);


        positionAux = transform.position;

        // Limita la posición del jugador dentro de los límites de la pantalla
        positionAux.x = Mathf.Clamp(positionAux.x, leftBound + playerHalfWidth, rightBound - playerHalfWidth);

        // Actualiza la posición del jugador con la posición limitada
        transform.position = positionAux;
    }
}
