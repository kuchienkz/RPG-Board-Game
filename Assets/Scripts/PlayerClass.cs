using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public string Name;

    public int CurrentHealthPoint;
    public int MaximumHealthPoint;
    public int CurrentActionPoint;
    public int MaximumActionPoint;

    public int EXPToNextLevel;
    public int Level;

    public int Gold;
    public List<ItemClass> Inventory;

    // Base Stats
    private int base_ATK = 50;
    private int base_DEF = 40;
    private int base_EVA = 20;

    // True Stats
    public int ATK;
    public int DEF;
    public int EVA;


    // Job Class
    private JobClass cls;
    public JobClass Class
    {
        get { return cls; }
        set
        {
            cls = value;
            RecalculateStats();
        }
    }


    private void RecalculateStats()
    {
        ATK = base_ATK + Class.bonus_ATK;
        DEF = base_DEF + Class.bonus_DEF;
        EVA = base_EVA + Class.bonus_EVA;
    }

    // Use this for initialization
    void Start ()
    {
        Gold = 1000;
        Inventory = new List<ItemClass>();
        Level = 1;
        Class = new Adventurer();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
