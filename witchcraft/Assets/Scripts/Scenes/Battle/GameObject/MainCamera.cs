using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Object targetObject;
    Vector3 trackingPosition = new Vector3(0, 10, -15);
    // Start is called before the first frame update
    void Start()
    {
        targetObject = FindObjectOfType<PlayerObject>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveByTarget();
    }

    // Update is called once per frame
    void MoveByTarget()
    {
        if(targetObject == null)
        {
            Debug.LogError("targetObjectが定義されていません");
            return;
        }

        Vector3 targetPos = targetObject.transform.position;
        this.transform.position = new Vector3(targetPos.x + trackingPosition.x, targetPos.y + trackingPosition.y, targetPos.z + trackingPosition.z);
        this.transform.LookAt(targetObject.transform.position);
    }
}
