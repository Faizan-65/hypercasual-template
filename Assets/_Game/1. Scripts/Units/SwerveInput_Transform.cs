using CW.Common;
using Lean.Touch;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInput_Transform : MonoBehaviour
{
    public float minX, maxX;
    public float Sensitivity { set { sensitivity = value; } get { return sensitivity; } }
    [SerializeField] private float sensitivity = 1.0f;

    public float Damping { set { damping = value; } get { return damping; } }
    [SerializeField] private float damping = 10.0f;

    private Camera mainCamera;
    private LeanFingerFilter leanFingerFilter = new LeanFingerFilter(true);

    //private float
    private void Start()
    {
        mainCamera = Camera.main;
        finalTransform = transform;
    }

    //private void Update()
    //{
    //    Vector3 oldPosition = transform.localPosition;
    //    List<LeanFinger> finger = leanFingerFilter.UpdateAndGetFingers();
    //    Vector2 screenDelta = LeanGesture.GetScreenDelta(finger);
    //    screenDelta.y = 0;

    //    if (screenDelta != Vector2.zero)
    //    {
    //        //Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.position);
    //        //screenPoint += (Vector3)screenDelta * Sensitivity;

    //        //Vector3 newWorldPoint = mainCamera.ScreenToWorldPoint(screenPoint);
    //        Vector3 newWorldPoint = screenDelta;
    //        newWorldPoint.x = Mathf.Clamp(newWorldPoint.x, minX, maxX);
    //        newWorldPoint.z = 0;
    //        float factor = CwHelper.DampenFactor(Damping, Time.deltaTime);
    //        transform.localPosition = Vector3.Lerp(oldPosition, newWorldPoint, factor);

    //    }

    //    //get screen delta
    //    //convert it to vector 3
    //    //add it to a ""remaining delta"". this remaining delta tends to remain zero through lerping
    //    //

    //    //if (Input.GetKey(KeyCode.LeftArrow) && transform.localPosition.x>minX)
    //    //{
    //    //    transform.localPosition += Vector3.left* sensitivity * Time.deltaTime;
    //    //}
    //    //if (Input.GetKey(KeyCode.RightArrow) && transform.localPosition.x<maxX)
    //    //{
    //    //    transform.localPosition += Vector3.right * sensitivity * Time.deltaTime;
    //    //}
    //}
    private Vector3 remainingDelta;
    private Transform finalTransform;
    private void Update()
    {
        List<LeanFinger> finger = leanFingerFilter.UpdateAndGetFingers();
        var screenFrom = LeanGesture.GetLastScreenCenter(finger);
        var screenTo = LeanGesture.GetScreenCenter(finger);
        var finalDelta = screenTo - screenFrom;


        Vector3 vector = finalDelta;
        remainingDelta += vector * sensitivity;
        
        var factor = CwHelper.DampenFactor(damping, Time.deltaTime);
        UpdatePosition(factor);
    }

    private void UpdatePosition(float factor)
    {
        var newDelta = Vector3.Lerp(remainingDelta, Vector3.zero, factor);
        var resultantVector = finalTransform.localPosition;
        resultantVector += remainingDelta - newDelta;
        resultantVector.y = transform.localPosition.y;
        resultantVector.x = Mathf.Clamp(resultantVector.x, minX, maxX);
        Debug.Log(resultantVector);
        finalTransform.localPosition = resultantVector;

        remainingDelta = newDelta;
    }

}







































//if (screenDelta != Vector2.zero)
//{
//    Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.position);
//    screenPoint += (Vector3)screenDelta * Sensitivity;

//    Vector3 newWorldPoint = mainCamera.ScreenToWorldPoint(screenPoint);
//    //newWorldPoint.x = Mathf.Clamp(newWorldPoint.x, minX, maxX);
//    newWorldPoint.y = 0;
//    //Debug.Log();
//    float factor = CwHelper.DampenFactor(Damping, Time.deltaTime);
//    transform.Translate(newWorldPoint *Time.deltaTime, Space.World);
//}