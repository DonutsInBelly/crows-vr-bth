using UnityEngine;
using System;
using System.Net;
using System.Collections;
using System.Globalization;
//using Newtonsoft.Json;

public class colorSetter : MonoBehaviour {

	public string URL = "http://af74cc87.ngrok.io/cs";
	string JSON;
    sentiment sentimentVals = new sentiment();
	//GameObject go = GetComponent("colorsphere");
	GameObject go; //= GameObject.Find("colorsphere");
	//shader_mut shad = go.GetComponent<shader_mut>();
	shader_mut shad = new shader_mut();

    void Colorize()
    {
        InvokeRepeating("GetRequest", 2, 5f);
    }

	// Use this for initialization
	void Start () {
		go = GameObject.Find ("colorsphere");
		if (go == null)
			print ("FUCK");
		else
			print ("AYYYYYYY LMAO");
		shad = go.GetComponent<shader_mut> ();
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

			int negEnd = JSON.IndexOf (',');
			print (JSON.Substring (1, negEnd));
			float neg = float.Parse(JSON.Substring(1,negEnd-1), CultureInfo.InvariantCulture);
			print ("neg: " + neg);

			JSON = JSON.Substring (negEnd+1);
			print ("after split: "+JSON);
			int neuEnd = JSON.IndexOf (',');
			print (neuEnd);
			float neu = float.Parse(JSON.Substring (0, neuEnd-1), CultureInfo.InvariantCulture);
			JSON = JSON.Substring (neuEnd+1);
			print ("after split 2: " +JSON);

			int posEnd = JSON.IndexOf (',');
			print (posEnd);
			float pos = float.Parse(JSON.Substring (0, posEnd-1), CultureInfo.InvariantCulture);
			print ("neg: " + neg  + " neu: " + neu   + " pos: " + pos  );

			if (neg>neu && neg>pos)
			{
				shad.result = -1;
				print ("neg");
			}else if (neu>neg && neu>pos)
			{
				print ("neu");
				shad.result = 0;
			}else{
				print ("pos");
				shad.result = 1;
			}
				

            //sentimentVals = JsonConvert.DeserializeObject<sentiment>(JSON);
            //print("Sentiment: \npos: " + sentimentVals.positive + "\nneu: " + sentimentVals.neutral + "\nneg: " + sentimentVals.negative);
		}
	}
}

public class sentiment
{
    public int negative;
    public int neutral;
    public int positive;
    public float latitude;
    public float longitude;

}