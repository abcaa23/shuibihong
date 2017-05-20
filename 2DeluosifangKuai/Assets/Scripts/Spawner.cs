using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Use this for initialization
    public GameObject[] groups;
	void Start () {
        StartNext();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void StartNext()
    {

        int i = Random.Range(0, groups.Length);
        GameObject gameOJ = Instantiate(groups[i], transform.position,Quaternion.identity) as GameObject;
    }
}
