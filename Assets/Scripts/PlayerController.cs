using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    private Vector2 currentPos;

    private DirectionInput dirInput;
    private bool activeInput;

    private Position positionStand;


    public enum DirectionInput
    {
        Null, Left, Right, Up, Down
    }

    public enum Position
    {
        Middle, Left, Right
    }


    void Start()
    {

    }

    void Update()
    {
       
        KeyInput();
        CheckLane();
    }


    private void KeyInput()
    {

        if (Input.anyKeyDown)
        {
            activeInput = true;
        }

        if (activeInput)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                dirInput = DirectionInput.Left;
                activeInput = false;

            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {

                dirInput = DirectionInput.Right;
                activeInput = false;

            }

        }
        else
        {

            dirInput = DirectionInput.Null;
        }


    }


    private void CheckLane()
    {
        if (positionStand == Position.Middle)
        {
            if (dirInput == DirectionInput.Right)
            {
                positionStand = Position.Right;
            }
            else if (dirInput == DirectionInput.Left)
            {
                positionStand = Position.Left;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 6 * Time.deltaTime);
        }
        else if (positionStand == Position.Left)
        {
            if (dirInput == DirectionInput.Right)
            {
                positionStand = Position.Middle;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(-3.5f, transform.position.y, transform.position.z), 6 * Time.deltaTime);
        }
        else if (positionStand == Position.Right)
        {
            if (dirInput == DirectionInput.Left)
            {
                positionStand = Position.Middle;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(3.5f, transform.position.y, transform.position.z), 6 * Time.deltaTime);

        }
        
        
        /*float direction=0;
        if (dirInput == DirectionInput.Left)
        {
            direction = -3.5f;
        }else if (dirInput == DirectionInput.Right)
        {
            direction = 3.5f;
        }

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x+direction, transform.position.y, transform.position.z), 6 * Time.deltaTime);
   */ }

}
