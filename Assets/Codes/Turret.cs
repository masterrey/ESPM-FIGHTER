using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject support, pipe;
    GameObject target;
    public ParticleSystem fire;
    bool enableshoot = false;
    // Start is called before the first frame update
    void Start()
    {
        target= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enableshoot)
        {
            float dist = Vector3.Distance(target.transform.position, transform.position);
            pipe.transform.LookAt(target.transform.position + target.transform.forward * dist * 0.5f);

            support.transform.rotation = Quaternion.Euler(
                -90, pipe.transform.rotation.eulerAngles.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enableshoot = true;
        fire.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        fire.Stop();
        enableshoot = false;
    }
}
