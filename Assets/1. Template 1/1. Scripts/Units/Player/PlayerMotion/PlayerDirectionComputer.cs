using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionComputer : MonoBehaviour
{
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = transform.forward;
        v.y = 0;
        v.Normalize();

        if (Vector3.Angle(v, Vector3.forward) <= 45.0)
        {
            controller.playerDirection = Directions.EAST;
            //Debug.Log("East");
        }
        else if (Vector3.Angle(v, Vector3.right) <= 45.0)
        {
            controller.playerDirection = Directions.NORTH;
            //Debug.Log("North");
        }
        else if (Vector3.Angle(v, Vector3.back) <= 45.0)
        {
            controller.playerDirection = Directions.WEST;
            //Debug.Log("West");
        }
        else
        {
            controller.playerDirection = Directions.SOUTH;
            //Debug.Log("South");
        }
    }
}
