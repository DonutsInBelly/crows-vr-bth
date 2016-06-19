using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

public class shader_mut : MonoBehaviour {

	// Use this for initialization
	public Renderer albedo;
	public String mood;
	public var argList;
	void Start () {
		argList = new List<KeyValuePair<string, Color>>();
		albedo = GetComponent<Renderer>();
		argList.Add(new KeyValuePair<string, Color>("sad", Color.blue));
		argList.Add(new KeyValuePair<string, Color>("happy", Color.yellow));
		argList.Add(new KeyValuePair<string, Color>("angry", Color.red));
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i <= argList.Length(); i++) {
			
		}
	}
}
