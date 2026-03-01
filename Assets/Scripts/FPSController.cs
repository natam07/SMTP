using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 5.0f;               // Velocidad del movimiento
    public float sensitivity = 2.0f;         // Sensibilidad del mouse
    public float jumpHeight = 2.0f;          // Altura del salto

    private float rotationX = 0.0f;          // Rotación en el eje X (para el movimiento de la cámara)
    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool isGrounded;

    public Camera playerCamera;

    void Start()
    {
        // Inicializamos el CharacterController
        characterController = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;  // Bloqueamos el cursor en el centro
        //Cursor.visible = false;                    // Ocultamos el cursor
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        // Movimiento
        MovePlayer();

        // Rotación de la cámara
        RotateCamera();

        // Salto
        Jump();
    }

    private void MovePlayer()
    {
        float moveDirectionY = moveDirection.y; // Guardamos el movimiento en Y antes de sobrescribirlo

        // Reemplazamos los Input de las teclas por teclas específicas:
        float moveDirectionX = 0f;
        float moveDirectionZ = 0f;

        // Movimientos con teclas personalizadas
        if (Input.GetKey("w"))  // Hacia adelante
            moveDirectionZ = 1f;
        if (Input.GetKey("s"))  // Hacia atrás
            moveDirectionZ = -1f;
        if (Input.GetKey("d"))  // Hacia la derecha
            moveDirectionX = 1f;
        if (Input.GetKey("a"))  // Hacia la izquierda
            moveDirectionX = -1f;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * moveDirectionZ;
        Vector3 right = transform.TransformDirection(Vector3.right) * moveDirectionX;

        moveDirection = forward + right;
        moveDirection.y = moveDirectionY; // Restablecemos el valor de Y

        // Aplicamos la velocidad
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }

    private void RotateCamera()
    {
        // Rotación del ratón en el eje X (horizontal)
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, mouseX, 0);

        // Rotación del ratón en el eje Y (vertical)
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);  // Limita el rango de la rotación vertical
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))  // Tecla de salto personalizada (J)
        {
            moveDirection.y = Mathf.Sqrt(jumpHeight * -1f * Physics.gravity.y);  // Aplicamos el salto
        }

        // Aplicamos la gravedad
        if (!isGrounded)
        {
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
        }
    }
}
