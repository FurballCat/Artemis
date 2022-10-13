using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float speed = 2.0f;

    private GameObject player;

    private Vector3 targetDirection;
    private Vector3 newTarget;

    private float speedFactor;
    private bool amIcalled;

    void Start()
    {
        speedFactor = speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            amIcalled = true;
            speedFactor = speed;
        }

        SetNewTarget(playerPos);

        if (!IsTargetReached(newTarget) && amIcalled)
        {
            transform.position += targetDirection.normalized * speedFactor * Time.deltaTime;
            speedFactor *= 1.05f; // let just leave it for now
        }
         
        if (IsTargetReached(newTarget))
        {
            Destroy(gameObject);
            amIcalled = false;
            gameObject.GetComponent<Light>().enabled = false;
        }

    }
    bool IsTargetReached(Vector3 target)
    {
        Vector3 distance = transform.position - target;

        if(distance.magnitude <= 0.1f)
        { 
            return true;
        }
        return false;
    }
    void SetNewTarget(Vector3 target)
    {
        newTarget = target;
        targetDirection = target - transform.position;
    }
}
