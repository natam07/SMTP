###### **Evento que Dispara la Notificación**



El obtener todas las llaves y abrir la última puerta genera dinámicamente el cuerpo del mensaje indicándole al jugador cuanto tiempo se demoró resolviendo el juego. 

1\. Obtiene el tiempo del jugador 

2\. Construye dinámicamente el cuerpo del correo donde se incluye el tiempo

3\. Llama el evento de SendMail para realizar el envío



###### **Flujo del Evento**



Obtener todas las llaves y abrir la última puerta -> Generación dinámica de mensaje -> Se cumple el protocolo de envío -> Se obtiene un resultado del correo (satisfactorio o negativo)



###### **Manejo de Respuestas del Servidor** 



El servidor arroja respuesta al usuario de 3 formas: 

* Al ingreso del correo, pues si no cumple con el requisito de ser un correo electrónico no inicia el juego. 
* Al enviar al correo de forma positiva, pues si logra completar el proceso se activa un panel con un mensaje de "¡Correo enviado correctamente!" 
* Si por algún motivo se genera un error y no se envía el correo, se activa un panel con un mensaje de "Error al enviar el correo."
