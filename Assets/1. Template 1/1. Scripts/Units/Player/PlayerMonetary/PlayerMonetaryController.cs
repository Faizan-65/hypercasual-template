using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonetaryController : MonoBehaviour
{
    public PlayerMonetaryBase currentState;


    //cached Components
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Collider thisCollider;
    //[HideInInspector] public CharacterController characterController;
    //[HideInInspector] public MyLeanDragTranslateRigidBody leanDragComponent;


    //instance Variables
    [HideInInspector] public Collider trigger;
    [HideInInspector] public Collision collision;
    // Start is called before the first frame update
    void Start()
    {
        //caching references
        rb = GetComponent<Rigidbody>();
        thisCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        this.trigger = other;
        currentState.OnTriggerEnter();
    }
    public void OnCollisionEnter(Collision collision)
    {
        this.collision = collision;
        currentState.OnCollisionEnter();
    }

    public void SwitchState(PlayerMonetaryBase state)
    {
        currentState = state;
        currentState.Enter(this);
    }
}
