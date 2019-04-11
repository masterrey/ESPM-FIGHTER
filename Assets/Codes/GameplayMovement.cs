using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMovement : MonoBehaviour
{
    public GameObject[] waypoints;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(transform.position, waypoints[index].transform.position) < 10)
        {
            index++;
        }

        Quaternion lookat= Quaternion.LookRotation(waypoints[index].transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookat, Time.deltaTime*0.1f);

        transform.position = Vector3.Lerp(transform.position, 
            waypoints[index].transform.position, Time.deltaTime);
    }
}
