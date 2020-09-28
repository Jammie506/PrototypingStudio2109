using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollisionSmoke : MonoBehaviour
{
    public Transform smoke;
    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void OnCollisionEnter(Collision collision)
  //  {
       // Instantiate(smoke, transform.position, transform.rotation);
   // }
    public void OnTriggerEnter(Collider other)
    {
        Instantiate(smoke, transform.position, transform.rotation);
        AudioSource.Play();
    }






}
