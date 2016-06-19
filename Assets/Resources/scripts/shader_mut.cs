using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

public class shader_mut : MonoBehaviour {

	// Use this for initialization
	public Renderer albedo;
	public string mood;
	Dictionary<string, Color> moods_color = new Dictionary<string, Color>();
	Dictionary<string, Texture> moods_texture = new Dictionary<string, Texture>();

	public Texture one;
	public Texture two;
	public Texture three;


	void Start () {
		moods_color.Add("angry", Color.red);
		moods_color.Add("happy", Color.yellow);
		moods_color.Add("sad", Color.blue);

		one = Resources.Load<Texture>("textures/one");
		two = Resources.Load<Texture>("textures/two");
		three = Resources.Load<Texture>("textures/three");

		moods_texture.Add("angry", one);
		moods_texture.Add("happy", two);
		moods_texture.Add("sad", three);

		albedo = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (moods_color.ContainsKey (mood)) {
			albedo.material.color = moods_color [mood];
			albedo.material.mainTexture = (moods_texture [mood]);
		}
	}
}
