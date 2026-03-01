using System;
using TMPro;
using UnityEngine;

public class ContadorLlaves : MonoBehaviour
{
    public static ContadorLlaves Instance;
    public static int KeysObtains = 0;
    public GameObject[] IconsKey;
    public GameObject LastDoor;
    public GameObject panelFinal;
    public TextMeshProUGUI textoFinal;

    /*This is for time and Email*/
    public SimpleEmailSender emailSender;

    public TextMeshProUGUI TextTime;
    private float time = 0f;
    private bool ActiveGame = false;
    private bool EndedGame = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        foreach (GameObject key in IconsKey)
        {
            key.SetActive(false);
        }
    }

    public static void IncreaseCounter()
    {
        KeysObtains++;
        Debug.Log("Llaves obtenidas: " + KeysObtains);

        if (Instance != null && KeysObtains - 1 < Instance.IconsKey.Length)
        {
            Instance.IconsKey[KeysObtains - 1].SetActive(true);
        }
    }

    void Update()
    {
        if (ActiveGame)
        {
            time += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);

            TextTime.text = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);

        }
    }

    public void StartGame()
    {
        time = 0f;
        ActiveGame = true;
    }

    public void EndingGame()
    {
        Debug.Log("FINALIZAR JUEGO LLAMADO");

        if (EndedGame) return;

        ActiveGame = false;
        EndedGame = true;

        Debug.Log("Tiempo final: " + time);

        bool enviado = emailSender.SendEmail(time);

        panelFinal.SetActive(true);

        

        if (enviado)
        {
            textoFinal.text = "¡Correo enviado correctamente!";
        }
        else
        {
            textoFinal.text = "Error al enviar el correo.";
        }
    }

    public void CheckLastDoor(GameObject door)
    {
        if (door == LastDoor)
        {
            Debug.Log("ULTIMA PUERTA DETECTADA");
            EndingGame();
        }
    }
}
