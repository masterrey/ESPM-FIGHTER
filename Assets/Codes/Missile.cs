using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    GameObject target;
    Rigidbody rdb;
    public ParticleSystem smoke;
    public AudioSource aud;
    float count =0.5f;
    bool active = false;
    public GameObject explosionPrefab;
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }
    public void SetTarget(GameObject tgt)
    {
        active = true;
        aud.Play();
        smoke.Play();
        rdb.isKinematic = false;
        target = tgt;
        Destroy(gameObject, 5);
        transform.parent = null;
    }
    
    public void SetTarget()
    {
        active = true;
        aud.Play();
        smoke.Play();
        rdb.isKinematic = false;
        Destroy(gameObject, 5);
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            count -= Time.deltaTime;
        }
        if (target)
        {
            if(count<0)
            transform.LookAt(target.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (count < 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            RaycastHit[] all = Physics.SphereCastAll(transform.position, 100, Vector3.down);
            foreach(RaycastHit hit in all){
                Destroy(hit.collider.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
