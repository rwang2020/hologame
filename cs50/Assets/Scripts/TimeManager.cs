using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections;

public class TimeManager : MonoBehaviour
{

    Text textdisp;
    float Timer = 0;

    // Use this for initialization
    void Start()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        textdisp = gameObject.GetComponent<Text>();
        textdisp.text = "Time Elapsed [" + Timer.ToString("0.0") + "]";
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.
        textdisp.text = "Time Elapsed [" + Timer.ToString("0.0") + "]";
    }
}
