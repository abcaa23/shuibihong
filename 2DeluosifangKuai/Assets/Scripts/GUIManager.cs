using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    float time, StartTime;
    Text timer;
    
	// Use this for initialization
	void Start () {
        timer = GameObject.Find("Canvas/Timer").GetComponent<Text>();
        StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        time = Time.time - StartTime;
        //miao
        int seconds = (int)(time % 60);
        //fen
        int minutes = (int)(time / 60);

        string strTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timer.text = strTime;

    }
}
