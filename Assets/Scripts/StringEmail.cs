using UnityEngine;
using TMPro;

public class StringEmail : MonoBehaviour
{
    public TMP_InputField emailInput;
    public GameObject panelInicial;

    public string UserEmail;

    public void OnSendEmail()
    {
        string email = emailInput.text;

        if (email.Contains("@"))
        {
            UserEmail = email;
            Debug.Log("Email válido: " + UserEmail);

            panelInicial.SetActive(false);

            ContadorLlaves.Instance.StartGame();
        }
        else
        {
            Debug.Log("Email inválido");
        }
    }

    public string GetEmail()
    {
        return UserEmail;
    }
}