using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    private GameObject Player;
	private bool IsPlayerMoving = false;
    // Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        if (Player != null && IsPlayerMoving)
        {
            transform.position = Player.transform.position;
        }
    }


    public void FollowPlayer()
    {
        IsPlayerMoving = true;
    }

    public void SetPlayer(GameObject player)
    {
        IsPlayerMoving = false;

        StartCoroutine(CoroutineMove(player, GameController.PlayerMoveSpeedMultiplier));
        Player = player;
    }

    IEnumerator CoroutineMove(GameObject player, float speed)
    {
        var destination = player.transform.position;

        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed*5 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        IsPlayerMoving = true;
    }
}
