using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public void TakeDamage()
    {

        Destroy(gameObject);
        ReloadScene();

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}