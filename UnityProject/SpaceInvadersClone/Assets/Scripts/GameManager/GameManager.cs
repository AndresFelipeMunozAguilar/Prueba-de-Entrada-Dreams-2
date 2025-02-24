using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private int level;

    [SerializeField]
    private int score;

    void Awake()
    {
        /* 
         * Implementacion el patrón de diseño Singleton.
         * Debido a que la clase GameManager es responsable de 
         * gestionar el estado del juego, debe existir solo una 
         * instanciade, pues, evita inconsistencias en el estado
         * del juego, tales como el nivel actual, la puntuación, etc.
         */
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }


    public void Initialize(int initialLevel)
    {
        /* 
            * Método para inicializar las propiedades de la clase
        */

        level = initialLevel;
    }

    // Getter y Setter públicos para la propiedad level
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
}
