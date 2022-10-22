// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsListener : MonoBehaviour
{
    public List<GameEventListener> ListenTo;

    private void OnEnable()
    {
        foreach (var item in ListenTo)
        {
            item.Event.RegisterListener(item);
        }
    }
    private void OnDisable()
    {
        foreach (var item in ListenTo)
        {
            item.Event.UnregisterListener(item);
        }
    }

}

[System.Serializable]
public class GameEventListener 
{
    [Tooltip("Event to register with.")]
    public GameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent Response;

    public void OnEventRaised()
    {
        
        Response.Invoke();
    }
}
