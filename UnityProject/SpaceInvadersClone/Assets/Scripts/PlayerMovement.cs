using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Velocidad de movimiento del jugador
    public float speed = 1.0f;

    // Valor del input horizontal
    private float horizontalInput = 0.1f;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        Movement(horizontalInput);
    }

    public void Movement(float horizontalInput)
    {
        /* 
            Calcula el movimiento horizontal del jugador
            y lo aplica a la posición del jugador
        */

        // Calcula el movimiento horizontal, para que
        // sea proporcional al tiempo que ha pasado desde 
        // el último frame
        float horizontalMovement = horizontalInput * speed * Time.deltaTime;

        transform.position += new Vector3(horizontalMovement, 0, 0);
    }
}
