using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public static class ReferenceHolder
{
    public static PathCreator path;
    public static float distancedTraveled;  
    public static float totalDistance;
    public static bool startWalking=false;

    public static float speedForward;

    public static Animator playerModelAnimator;
}
