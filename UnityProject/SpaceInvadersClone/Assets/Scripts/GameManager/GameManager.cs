using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private int level;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    // Método para inicializar las propiedades de la clase
    public void Initialize(int initialLevel)
    {
        level = initialLevel;
    }

    // Getter y Setter públicos para la propiedad level
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
}
