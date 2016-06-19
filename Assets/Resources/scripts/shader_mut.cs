using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

public class shader_mut : MonoBehaviour {

	// Use this for initialization
	public Renderer albedo;
	public string mood;
	Dictionary<string, Color> moods_color = new Dictionary<string, Color>();
	/*
	public float red_val = 1.0F;
	public float blue_val = 0.5F;
	public float green_val = 0.0F;
	public float alpha_val = 0.6F;
	Color result;

	Dictionary<string, Texture> moods_texture = new Dictionary<string, Texture>();
	
	public Texture one;
	public Texture two;
	public Texture three;
		*/

	public int result;

	void Start () {
		/*
		result = new Color(red_val, green_val, blue_val, alpha_val);
		*/
			moods_color.Add("neutral", new Color(0.2F, 0.5F, 0.4F, 0.4F));
			moods_color.Add("positive", new Color(1.0F, 0.6F, 0.0F, 0.4F));
			moods_color.Add("negative", new Color(0.0F, 0.0F, 1.0F, 0.4F));


		/*
		one = Resources.Load<Texture>("textures/one");
		two = Resources.Load<Texture>("textures/two");
		three = Resources.Load<Texture>("textures/three");

		moods_texture.Add("angry", one);
		moods_texture.Add("happy", two);
		moods_texture.Add("sad", three);
		*/

		albedo = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		albedo.material.EnableKeyword("_EMISSION");

		if (moods_color.ContainsKey (mood)) {
			/*
			albedo.material.color = moods_color [mood];
			albedo.material.mainTexture = (moods_texture [mood]);
			albedo.material.SetColor ("_TintColor", moods_color [mood]);
			*/
			albedo.material.SetColor ("_EmissionColor", moods_color [mood]);

		}

		if(result == 0)
			albedo.material.SetColor ("_EmissionColor", new Color(0.2F, 0.5F, 0.4F, 0.4F));
		else if(result == 1)
			albedo.material.SetColor ("_EmissionColor", new Color(1.0F, 0.6F, 0.0F, 0.4F));
		else
			albedo.material.SetColor ("_EmissionColor", new Color(0.0F, 0.0F, 1.0F, 0.4F));
	}
}
