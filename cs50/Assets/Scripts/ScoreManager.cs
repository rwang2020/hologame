using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    Text textdisp;
    int score = 0;

    // Use this for initialization
    void Start () {
        textdisp = gameObject.GetComponent<Text>();
        textdisp.text = "Score [" + score.ToString("00") + "]";
    }
	
	// Update is called once per frame
	void Update () {
        textdisp.text = "Score [" + score.ToString("00") + "]";
    }

    // Increment Score Upon Successful Collision
    void scoreincrease()
    {
        score = score + 1;
    }
}
