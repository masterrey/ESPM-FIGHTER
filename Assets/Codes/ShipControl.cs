using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public float velocity=1;
    public GameObject shipmesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyControl();



    }

    void KeyControl()
    {
        shipmesh.transform.localRotation = Quaternion.Euler(
            Input.GetAxis("Vertical") * -10,
            Input.GetAxis("Horizontal") * 10,
            Input.GetAxis("Horizontal") * -20);

        transform.Translate(
            Time.deltaTime * Input.GetAxis("Horizontal") * velocity
            , Time.deltaTime * Input.GetAxis("Vertical")* velocity
            , 0);

        

    }
}
