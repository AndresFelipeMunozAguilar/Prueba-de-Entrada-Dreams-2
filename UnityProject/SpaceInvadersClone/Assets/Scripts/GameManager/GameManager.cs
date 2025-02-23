using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {

            Destroy(gameObject);
        }


    }

    private void OnDestroy()
    {
        instance = null;
    }


}
