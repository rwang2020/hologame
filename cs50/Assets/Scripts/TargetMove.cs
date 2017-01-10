using UnityEngine;
using System.Collections;

public class TargetMove : MonoBehaviour {
    public float speed; 
    public float height;
    private Vector3 pivot;
    // Use this for initialization
    void Start() {
        //set a random speed for the balls and set the corordinate of the pivot 
        speed = UnityEngine.Random.Range(-speed, speed);
        height = gameObject.transform.position.x;
        pivot = new Vector3(0, height, 0);
    }


// Update is called once per frame
void Update () {
        //actually move the ball
        transform.RotateAround(pivot, Vector3.up, speed * Time.deltaTime);
    }


}
