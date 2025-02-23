using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;

    // Variable para almacenar la tecla de disparo
    public KeyCode shootKey = KeyCode.Space;

    private bool isShooting = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si la tecla de disparo está siendo presionada
        isShooting = Input.GetKey(shootKey);

        if (isShooting)
        {
            Shoot();
        }
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
