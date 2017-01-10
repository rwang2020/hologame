using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

    public GameObject TargetSpawner;
    public GameObject ScoreDisplay;
    public AudioClip ImpactClip;
    void Awake()
    {
        ImpactClip = Resources.Load<AudioClip>("Impact");
    }
    //called when the projectile and target collide
    void OnTriggerEnter(Collider other)
    {
        //get other objects 
        ScoreDisplay = GameObject.FindGameObjectWithTag("ScoreDisplay");
        TargetSpawner = GameObject.FindGameObjectWithTag("Respawn");

        //send messages to other objects to change relevent variables 
        TargetSpawner.gameObject.SendMessage("delete");
        ScoreDisplay.gameObject.SendMessage("scoreincrease");

        //we want to destroy the target and the projectile.  
        Destroy(gameObject);
        Destroy(other.gameObject);

        AudioSource Impact = GetComponent<AudioSource>();
        Impact.clip = ImpactClip;
        Impact.Play();


        



    }
}
