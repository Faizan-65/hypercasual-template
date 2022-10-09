using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveTest : MonoBehaviour
{
    public float speed;
    public float minX, maxX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x>minX)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);

            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x<maxX)
            {
                transform.Translate(Vector3.right*speed*Time.deltaTime, Space.Self);
            }
        }
    }
}
