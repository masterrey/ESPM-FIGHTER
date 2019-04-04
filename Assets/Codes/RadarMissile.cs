using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarMissile : MonoBehaviour
{
    public Missile[] missile;
    int index=0;
    GameObject lasttarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (lasttarget)
            {
                missile[index].SetTarget(lasttarget);
            }
            else
            {
                missile[index].SetTarget();
            }
            index++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            lasttarget = other.gameObject;
            print(other.gameObject.name);
        }
    }
}
