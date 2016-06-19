using UnityEngine;
using System;
using System.Net;
using System.Collections;

public class colorSetter : MonoBehaviour {

	string URL = "http://223bce18.ngrok.io/cs";
	string JSON;

    void Colorize()
    {
        InvokeRepeating("GetRequest", 1, 1f);
    }

	// Use this for initialization
	void Start () {
        print("Hi!");
        Colorize();        
	}
	
	// Update is called once per frame
	void Update () {
        Console.Write("Hi!!");
    }

	void FixedUpdate() {
	}

	void GetRequest (){
		print ("Doing the thing!");
		using (WebClient webClient = new WebClient ()) {
			JSON = webClient.DownloadString (URL);
			print (JSON);
		}
	}
}
