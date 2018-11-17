using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public string Name;

    public int Gold { get; set; }

    public List<CardClass> Deck { get; set; }

    public int Lives { get; set; }

    // Use this for initialization
    void Start ()
    {
        Gold = 500;
        Deck = new List<CardClass>();
        Lives = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
