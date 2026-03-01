using UnityEngine;

public class keys : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ContadorLlaves.IncreaseCounter();
            Destroy(gameObject);
        }
    }
}
