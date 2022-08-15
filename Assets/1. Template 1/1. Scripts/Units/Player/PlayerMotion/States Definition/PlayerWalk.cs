using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerWalk : PlayerMotion
{
    PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log($"WalkState");
        this.controller = controller;
    }
    public override void UpdateState()
    {
        //BetterJump();
        Vector3 newPos = controller.transform.position + (controller.transform.forward*controller.speedFWD * Time.deltaTime);
        controller.rb.MovePosition(newPos);
        //controller.rb.velocity = controller.transform.forward * controller.speedFWD * Time.deltaTime; //speedFWD=500
    }


    public override void OnCollisionEnter()
    {

    }

    public override void OnTriggerEnter()
    {
        if (controller.trigger.tag==TagsManager.jump)
        {
            Exit(controller.jumpState);
        }
        if (controller.trigger.tag == TagsManager.stairs)
        {
            Exit(controller.stairsState);
        }
        if (controller.trigger.tag == TagsManager.turnRight)
        {
            if (controller.playerDirection==Directions.EAST)
            {
                controller.transform.DORotate(new Vector3(0, 90, 0), 1f);
            }
            else if (controller.playerDirection==Directions.NORTH)
            {
                controller.transform.DORotate(new Vector3(0, 0, 0), 1f);
            }
            
        }
        if (controller.trigger.tag == TagsManager.turnLeft)
        {
            if (controller.playerDirection == Directions.EAST)
            {
                controller.transform.DORotate(new Vector3(0, -90, 0), 1f);
            }
            else if (controller.playerDirection == Directions.NORTH)
            {
                controller.transform.DORotate(new Vector3(0, 0, 0), 1f);
            }
        }
    }

    public override void Exit(PlayerMotion state)
    {
        controller.SwitchState(state);
    }


    //public void BetterJump()
    //{
    //    if (controller.rb.velocity.y < 0f)
    //    {
    //        controller.rb.velocity += Vector3.up * Physics.gravity.y * (controller.fallMultiplier-2) * Time.deltaTime;
    //    }
    //    else if (controller.rb.velocity.y > 0f)
    //    {
    //        controller.rb.velocity += Vector3.up * Physics.gravity.y * (controller.fallMultiplier) * Time.deltaTime;
    //    }
    //}
}
