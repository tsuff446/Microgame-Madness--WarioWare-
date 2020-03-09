using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point1 : MonoBehaviour
{
    private Rigidbody rb;
     private AudioSource source;
    public AudioClip noise;
   
    // Start is called before the first frame update
    void Start()
    {
        
       source = GetComponent<AudioSource>();
       // Debug.Log(source);
        rb = GetComponent<Rigidbody>();
        if (PlayerScript.currCount > 0)
        {
            PlayerScript.currCount = 0;
        }
        rb.position = new Vector2(Random.Range((float)-4.5,(float) 4.5), Random.Range((float)-4,(float) 4));
       // Debug.Log("Before");
     //  source.PlayOneShot(noise,1f);
      

    }

    // Update is called once per frame
    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
            
    }
    private void OnCollisionEnter(Collision collision)
    {

            Point1.Destroy(rb.gameObject);
            PlayerScript.currCount = PlayerScript.currCount + 1;

        
                
        
        

    }
}
