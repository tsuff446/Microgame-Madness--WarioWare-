using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point3 : MonoBehaviour
{
    // Start is called before the first frame update
     private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.position = new Vector2(Random.Range((float)-4.5, (float)4.5), Random.Range((float)-4, (float)4));
        if (PlayerScript.finalCount < 3)
            Point3.Destroy(rb.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;


    }
    private void OnCollisionEnter(Collision collision)
    {
        Point3.Destroy(rb.gameObject);
        PlayerScript.currCount = PlayerScript.currCount + 1;

    }
}
