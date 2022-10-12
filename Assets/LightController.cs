using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject player;
    public float speed = 2.0f;

    private bool amIcalled;
    private Vector3 targetDirection;
    private bool lightEmission;
    private Vector3 origin = new Vector3(10.0f, 10.0f, 10.0f);
    private Vector3 newTarget;

    void Start()
    {
        lightEmission = gameObject.GetComponent<Light>().enabled;
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        lightEmission = gameObject.GetComponent<Light>().enabled;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            amIcalled = true;
        }

        // this solution is temporary
        SetNewTarget(playerPos);
        targetDirection = playerPos - transform.position;


        if (!IsTargetReached(newTarget) && amIcalled)
        {
            transform.position += targetDirection.normalized * speed * Time.deltaTime;
        }
         
        if (IsTargetReached(newTarget))
        {
            amIcalled = false;
            gameObject.GetComponent<Light>().enabled = false;

        }

    }
    bool IsTargetReached(Vector3 target)
    {
        Vector3 distance = transform.position - target;
        if(distance.magnitude <= 0.1f)
        { return true; }
        return false;
    }
    void SetNewTarget(Vector3 target)
    {
        newTarget = target;
    }
}
