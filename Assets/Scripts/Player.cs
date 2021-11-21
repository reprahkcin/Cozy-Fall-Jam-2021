using UnityEngine;

public class Player : MonoBehaviour
{
    // Singleton
    public static Player instance;

    public Transform[] treeSpots;
    
    public float speed = 4f;

    private Rigidbody rb;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }
    public void MoveToPosition(Transform target)
    {
        // move to target at speed
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        rb.velocity = direction.normalized * speed;
    }
}
