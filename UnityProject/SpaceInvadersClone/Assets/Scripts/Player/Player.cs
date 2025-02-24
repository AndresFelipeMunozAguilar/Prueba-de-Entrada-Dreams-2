using UnityEngine;

public class Player : MonoBehaviour
{
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}