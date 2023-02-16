using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    // Booleanos que indican la dirección en la que se encuentra el jugador
    public bool MovingUp;
    public bool MovingDown;
    public bool MovingLeft;
    public bool MovingRight;

    public int desiredDirection;

    // Referencia al objeto jugador
    Transform player;

    // Referencia al componente Animator del objeto enemigo
    private Animator animator;

    // Función que se llama una vez al inicio del juego
    void Start()
    {
        // Obtener la referencia al componente Animator
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Función que se llama una vez por cada frame
    void Update()
    {
        // Obtener la posición del jugador y del enemigo
        Vector3 playerPosition = player.position;
        Vector3 enemy = transform.position;

        // Calcular la diferencia de posición en X y en Y
        float diffX = playerPosition.x - enemy.x;
        float diffY = playerPosition.y - enemy.y;

        desiredDirection = GetDesiredDirection(diffY, diffX);
        Debug.Log(desiredDirection);
        // TODO:

        // Establecer los parámetros de la animación en función de los booleanos

        

        //animator.SetBool("MovingUp", MovingUp);
        //animator.SetBool("MovingDown", MovingDown);
        //animator.SetBool("MovingLeft", MovingLeft);
        //animator.SetBool("MovingRight", MovingRight);

        
    }

    int GetDesiredDirection(float diffY, float diffX)
    {
        // Establecer los booleanos correspondientes en función de la diferencia de posición
        MovingUp = diffY > 0 && Mathf.Abs(diffY) > Mathf.Abs(diffX);
        MovingDown = diffY < 0 && Mathf.Abs(diffY) > Mathf.Abs(diffX);
        MovingLeft = diffX < 0 && Mathf.Abs(diffX) > Mathf.Abs(diffY);
        MovingRight = diffX > 0 && Mathf.Abs(diffX) > Mathf.Abs(diffY);


        if (MovingRight)
            return 0;
        if (MovingLeft)
            return 1;
        if (MovingUp)
            return 2;
        if (MovingDown)
            return 3;
        //bool[] directions = new bool[] { (bool)MovingDown, (bool)MovingUp, (bool)MovingLeft, (bool)MovingRight };
        return -1;
    }
}






