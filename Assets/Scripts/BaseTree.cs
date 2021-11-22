using UnityEngine;

public class BaseTree : MonoBehaviour
{
    // Singleton
    public static BaseTree instance;
    public Material towerMaterial;
    private Color originalColor = Color.white;
    public Color highlightColor = Color.yellow;

    private Player player;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RestockPlayer()
    {
        
    }

}
