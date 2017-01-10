using UnityEngine;
using System.Collections;
using System;

public class TargetManager : MonoBehaviour {

    public GameObject TargetPrefab;
    //although we only have 1 target at the moment, having an array allows us to easily add more targets of different types later 
    public GameObject[] targets;
    public Vector3 spawnValues;
    public Vector3 minSpawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    public int maxNumTargets;
    public int numTargets;


    int randTarget;

    // Use this for initialization
    void Start () {
        StartCoroutine(waitSpawner());
    }

    //called by CollisionDetection
    void delete()
    {
        numTargets -= 1; 
    }

    void OnReset()
    {
        numTargets = 0;
        targets = GameObject.FindGameObjectsWithTag("TargetPrefab");
        for (int i = 0; i < targets.Length; i ++)
        {
            Destroy(targets[i]);
        }
    }


    // Update is called once per frame
    void Update () {
        //randomly change how long for targets to wait before spawning
        spawnWait = UnityEngine.Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait); 
        while (!stop)
        {
            if (numTargets < maxNumTargets)
            {
                randTarget = UnityEngine.Random.Range(0, 1);
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(minSpawnValues.x, spawnValues.x), UnityEngine.Random.Range(minSpawnValues.y, spawnValues.y), UnityEngine.Random.Range(minSpawnValues.z, spawnValues.z));

                Instantiate(targets[randTarget], (spawnPosition + transform.TransformPoint(0, 0, 0)), gameObject.transform.rotation);
                numTargets += 1;
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }

}
