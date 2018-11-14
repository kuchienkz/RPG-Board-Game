using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    [SerializeField]
    public static int PlayerMoveSpeedMultiplier = 10;

    [SerializeField]
    public GameObject PlayerFolder;

    [SerializeField]
    public Transform[] Waypoints;

    [SerializeField]
    DicesController DiceController;

    [SerializeField]
    GameObject Camera;

    private CameraMover CameraMover;
    private List<GameObject> Players;
    private int PlayerIndex = -1;

    // Use this for initialization
    void Start ()
    {
        instance = this;

        Players = new List<GameObject>();
        foreach (Transform player in PlayerFolder.transform)
        {
            if (player.gameObject.tag == "Player")
            {
                Players.Add(player.gameObject);
            }
        }
        foreach (GameObject player in Players)
        {
            player.GetComponent<PlayerMover>().SetWayPoints(Waypoints);
            player.GetComponent<PlayerMover>().PlayerMoved += GameController_PlayerMoved;
        }

        CameraMover = Camera.GetComponent<CameraMover>();
        DiceController.DicesRolled += DiceController_DicesRolled;

        NextPlayerTurn();
	}

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void NextPlayerTurn()
    {
        PlayerIndex++;
        if (PlayerIndex > Players.Count - 1)
        {
            PlayerIndex = 0;
        }

        CameraMover.SetPlayer(Players[PlayerIndex]);
    }

    public void RollDice()
    {
        DiceController.Roll();
    }

    private void DiceController_DicesRolled(object sender, int firstDiceValue, int secondDiceValue)
    {
        Players[PlayerIndex].GetComponent<PlayerMover>().Move(firstDiceValue + secondDiceValue);
        
    }

    private void GameController_PlayerMoved(object sender, int diceValue)
    {
        NextPlayerTurn();
    }

}
