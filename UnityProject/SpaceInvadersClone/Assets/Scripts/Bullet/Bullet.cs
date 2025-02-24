using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.1f;

    private Vector2 direction;

    private Vector2 screenBounds;
    private float upperBound;

    // Distancia a la que la bala se destruirá
    // con respecto al límite superior de la pantalla
    public float despawningOffset;

    private float bulletHalfHeight;

    private float outsideCondition;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        upperBound = screenBounds.y;
        bulletHalfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        outsideCondition = upperBound + bulletHalfHeight + despawningOffset;

        direction = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {

        // Mueve el objeto hacia arriba

        // Mueve la bala, de manera proporcional al tiempo
        // entre frames
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (transform.position.y > outsideCondition)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
