using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private AudioSource source;
    public AudioClip noise2;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.position = new Vector2(Random.Range((float)-4.5, (float)4.5), Random.Range((float)-4, (float)4));
       
  

    }

    // Update is called once per frame
    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;


    }
    private void OnCollisionEnter(Collision collision)
    {
        Point2.Destroy(rb.gameObject);
        PlayerScript.currCount = PlayerScript.currCount + 1;

    }
}
