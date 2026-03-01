using UnityEngine;

public class Puerta : MonoBehaviour
{
    public int NecessaryKeys = 1; 
    public float ActiveRange = 5f;
    public Transform player;          

    private bool ActiveKey = false;
    public bool IsLastDoor = false;

    void Update()
    {
        float distancia = Vector3.Distance(player.position, transform.position);

        if (Input.GetKeyDown(KeyCode.E))
            if (ContadorLlaves.KeysObtains >= NecessaryKeys)
            {
                if (distancia <= ActiveRange)
                {
                    ActiveKey = true;
                    OpenDoor();
                }
            }
    }

    void OpenDoor()
    {

        ContadorLlaves.Instance.CheckLastDoor(gameObject);

        Destroy(gameObject); // Destruir la door visualmente
    }
}
