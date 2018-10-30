using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public CharMove Player;
    public bool isFollowing;


    //Camera position offset
    public float xOffset;
    public float yOffset;

    // Use this for initialization
	void Start () {
        Player = FindObjectOfType<CharMove>();

        isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(isFollowing){
            transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, transform.position.z);
        }
		
	}
}
