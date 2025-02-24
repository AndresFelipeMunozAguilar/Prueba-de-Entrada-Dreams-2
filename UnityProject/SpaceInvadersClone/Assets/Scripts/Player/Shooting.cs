using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;


    public GameObject bulletPrefab;

    // Variable para almacenar la tecla de disparo
    public KeyCode shootKey = KeyCode.Space;

    private bool isShooting = false;


    // Variables para controlar el tiempo de recarga
    // en segundos
    [SerializeField]
    private float maxReloadTime;
    private float currentReloadTime = 0.0f;

    public float reloadIncrease = 0.22222f;
    public float baseReload = 5f;
    void Start()
    {
        if (GameManager.Instance != null)
        {
            maxReloadTime = (reloadIncrease * (GameManager.Instance.Level - 1)) + baseReload;

        }
        else
        {
            Debug.LogError("GameManager no encontrado");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si la tecla de disparo está siendo presionada
        isShooting = Input.GetKey(shootKey);

        if (isShooting && currentReloadTime <= 0)
        {
            Shoot();
            currentReloadTime = maxReloadTime;
        }

        if (currentReloadTime > 0)
        {
            currentReloadTime -= Time.deltaTime;
        }

        // Debug.Log("Current Reload Time: " + currentReloadTime);
    }

    public void Shoot()
    {
        /**
         * Instancia on objeto de tipo Bullet en la
         * posición y la rotación del firePoint (El 
         * cañón del jugador) 
         */

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
