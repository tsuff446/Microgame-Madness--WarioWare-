using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pos : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        rb.position = new Vector3(Random.Range(-3.0f,3.0f), rb.position.y,0);

       
    }

    // Update is called once per frame
    void Update()
    {
       rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
