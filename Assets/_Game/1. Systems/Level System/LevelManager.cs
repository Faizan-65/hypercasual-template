using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class LevelManager : MonoBehaviour
{

    //Events
    public GameEvent levelSpawned;
    public List<Level> allLevels;
    public Transform levelParent;
    public PathCreator path;

    //public Path
    [SerializeField] private Transform poser;


    private Level _currentLevel;
    private void Start()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        levelParent.DestroyChildren();
        _currentLevel = Instantiate(allLevels[Random.Range(0, allLevels.Count)],levelParent.transform);
        _currentLevel.GenerateLevel(poser);

        MakeSpline();
        levelSpawned.Raise();
    }
    private void MakeSpline()
    {
        List<Transform> waypoints=new List<Transform>();
        foreach (Chunk chunk in _currentLevel.allChunks)
        {
            waypoints.AddRange(chunk.waypoints);
        }
        BezierPath bezierPath = new BezierPath(waypoints, false, PathSpace.xyz);
        path.bezierPath = bezierPath;
        ReferenceHolder.path = path;

        
        //assign this path to player using event
    }
}
;