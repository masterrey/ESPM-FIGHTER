using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Vector3 randonrot;
    public ParticleSystem explo;
    // Start is called before the first frame update
    void Start()
    {
        randonrot = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }
        // Update is called once per frame
    void Update()
    {
        transform.Rotate(randonrot*Time.deltaTime);
    }
    private void OnParticleCollision(GameObject other)
    {
        explo.Play();
        Destroy(gameObject, 1);
    }

  
}

