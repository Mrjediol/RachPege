using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    // Booleanos que indican la direcci�n en la que se encuentra el jugador
    public bool MovingUp;
    public bool MovingDown;
    public bool MovingLeft;
    public bool MovingRight;

    public int desiredDirection;

    // Referencia al objeto jugador
    Transform player;

    // Referencia al componente Animator del objeto enemigo
    private Animator animator;

    // Funci�n que se llama una vez al inicio del juego
    void Start()
    {
        // Obtener la referencia al componente Animator
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Funci�n que se llama una vez por cada frame
    void Update()
    {
        // Obtener la posici�n del jugador y del enemigo
        Vector3 playerPosition = player.position;
        Vector3 enemy = transform.position;

        // Calcular la diferencia de posici�n en X y en Y
        float diffX = playerPosition.x - enemy.x;
        float diffY = playerPosition.y - enemy.y;

        desiredDirection = GetDesiredDirection(diffY, diffX);
        Debug.Log(desiredDirection);
        // TODO:

        // Establecer los par�metros de la animaci�n en funci�n de los booleanos

        

        //animator.SetBool("MovingUp", MovingUp);
        //animator.SetBool("MovingDown", MovingDown);
        //animator.SetBool("MovingLeft", MovingLeft);
        //animator.SetBool("MovingRight", MovingRight);

        
    }

    int GetDesiredDirection(float diffY, float diffX)
    {
        // Establecer los booleanos correspondientes en funci�n de la diferencia de posici�n
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






