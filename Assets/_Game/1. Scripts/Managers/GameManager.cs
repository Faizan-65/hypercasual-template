using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class GameManager : MonoBehaviour
{
    public PathCreator path;
    //public List<PathCreator> paths;
    void Start()
    {
        path.bezierPath.AutoControlLength = 0.41f;
        //foreach (PathCreator path in paths)
        //{
        //    //path.bezierPath.
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
