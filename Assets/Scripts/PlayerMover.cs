using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    
    private Transform[] Waypoints;

    public delegate void PlayerMovedHandler(object sender, int diceValue);
    public event PlayerMovedHandler PlayerMoved;

    private int WaypointIndex = 0;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void SetWayPoints(Transform[] waypoints, int waypointIndex = 0)
    {
        this.Waypoints = waypoints;
        WaypointIndex = waypointIndex;
        transform.position = Waypoints[WaypointIndex].position;
    }

    public void Move(int diceValue)
    {
        StartCoroutine(CoroutineMove(diceValue, GameController.PlayerMoveSpeedMultiplier));
    }

    IEnumerator CoroutineMove(int diceValue, float speed)
    {
        for (int i = 0; i < diceValue; i++)
        {
            WaypointIndex++;
            if (WaypointIndex > Waypoints.Length - 1)
            {
                WaypointIndex = 0;
            }
            var destination = Waypoints[WaypointIndex].transform.position;

            while (transform.position != destination)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }

        PlayerMoved(this, diceValue);
    }
}
