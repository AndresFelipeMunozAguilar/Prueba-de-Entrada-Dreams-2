using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Transform firePoint;

    public GameObject bulletPrefab;

    public float maxReloadTime = 5.0f;

    private float currentReloadTime = 0.0f;

    private GameManager gameManager;

    public float upperReloadLimit = 15f;
    public float lowerReloadLimit = 14f;

    void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager no encontrado");
        }

        maxReloadTime = Random.Range(lowerReloadLimit - gameManager.Level, upperReloadLimit);

        currentReloadTime = maxReloadTime;
    }
    void Update()
    {
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
      * Instancia on objeto de tipo Bullet en la
      * posición y la rotación del firePoint (El 
      * cañón del alien) 
      */

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
