using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform targetObj;
    private GameObject vampiro;
    
    void Start()
    {
        vampiro = GameObject.Find("Slime");
        targetObj = vampiro.transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 3*Time.deltaTime);
    }
}
