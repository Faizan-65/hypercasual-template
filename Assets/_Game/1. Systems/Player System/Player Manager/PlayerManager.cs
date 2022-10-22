using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Events")]
    public GameEvent playerSpawned;

    [Header("References")]
    public PlayerController playerController;
    public CharacterSO characterSO;
    public PathCreator pathCreator;

    [Header("Parameters")]
    public float distanceTravelled;
    public float followerSpeed;

    //private
    private bool gameRunning = false;

    public void LevelSpawnedHandler()
    {
        pathCreator = ReferenceHolder.path;
        ReferenceHolder.speedForward = 0;
        gameRunning = false;
        ReferenceHolder.totalDistance = ReferenceHolder.path.path.length;
        ReferenceHolder.distancedTraveled = 0;

        //spawn Player
        playerController.transform.DestroyChildren();
        GameObject modelToSpawn=characterSO.characters[0].gamePrefab;
        foreach (var character in characterSO.characters)
        {
            if (character.id.Equals(DataManager.gameData.characterId))
            {
                modelToSpawn = character.gamePrefab;
            }
        }
        GameObject model= Instantiate(modelToSpawn, playerController.transform);
        ReferenceHolder.playerModelAnimator = model.GetComponent<Animator>();
        playerSpawned.Raise();
    }
    public void PlayButtonClickedHandler()
    {
        gameRunning = true;
        ReferenceHolder.speedForward = followerSpeed;
    }


   

    void Start()
    {
        if (pathCreator != null)
        {
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    void Update()
    {
        if (pathCreator != null && gameRunning)
        {
            distanceTravelled += ReferenceHolder.speedForward * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            var rot = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop).eulerAngles;
            rot.x = 0;
            rot.z = 0;
            transform.rotation = Quaternion.Euler(rot);
            ReferenceHolder.distancedTraveled = distanceTravelled;
            //if (distanceTravelled >= pathCreator.path.length)
            //{
            //    gameRunning = false;
            //    levelCompleted.Raise();
            //}
        }
        
    }
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }

}
