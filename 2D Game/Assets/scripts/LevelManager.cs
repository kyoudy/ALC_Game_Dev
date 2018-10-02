﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    private Rigidbody2D PC;

    // Particles
    public GameObject DeathParticles;
    public GameObject RespawnParticles;

    //Respawn Delay
    public float RespawnDelay;


    // Point Penalty on Death
    public int PointPenaltyOnDeath;

    // Store Gravity Value
    private float GravityStore;


    // Use this for initialization
    void Start(){
        PC = FindObjectOfType<Rigidbody2D>();
    }

    public void RespawnPlayer(){
        StartCoroutine("RespawnPCCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        //Generate Death Particle
        Instantiate(DeathParticles, PC.transform.position, PC.transform.rotation);
        //hide Player
        //PC.enable = false;
        PC.GetComponent<Renderer>().enabled = false;
        //Gravity Reset
        GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
        PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
        PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Point Penalty
        ScoreManager.AddPoints(-PointPenaltyOnDeath);
        //Debug Message
        Debug.Log("Player Respawn");
        //Respawn Delay
        yield return new WaitForSeconds(RespawnDelay);
        //Gravity Restore
        PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
        //Math Player transform position
        RespawnPlayer.transform.position = currentCheckPoint.transform.position;
        //Show PC
        //PC.enable = true;
        PC.GetComponent<Renderer>().enabled = true;
        //Spawn PC
        Instantiate(RespawnParticles, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}
