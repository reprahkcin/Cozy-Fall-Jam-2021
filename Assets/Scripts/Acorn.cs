using UnityEngine;

public class Acorn : MonoBehaviour
{
    private float _damage;
    public float lifetime = 0.3f;
    public float Damage
    {
        get { return _damage; }
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") || other.CompareTag("Patron"))
        {
            Destroy(gameObject);
        }
    }
}
