using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public string Name;

    public int Gold;
    public List<CardClass> Inventory;
    

    // True Stats
    public int ATK;
    public int LIVES;

    private void RecalculateStats()
    {
        int bonus_ATK = 0;

        foreach (var card in Inventory)
        {
            bonus_ATK += card.GetBonus_ATK();
        }

        ATK = base_ATK + bonus_ATK;  
    }

    // Use this for initialization
    void Start ()
    {
        Gold = 500;
        Inventory = new List<CardClass>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
