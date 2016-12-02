﻿using UnityEngine;
using System.Collections;

public class PlayerFormation : MonoBehaviour {

    //Destroy enemies colliding with player except for levels FAST_ESCAPE

    public AudioClip destroyClip;
    static int totalEnemiesKilledInThisWave;

    void Start()
    {
        totalEnemiesKilledInThisWave = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        //Player Formation for arcade
        if(GameManager.getLevelName()=="ARCADE")
        {
            //Destroy enemy Vees and player vees
            if (collider.gameObject.GetComponent<EnemyFormation>())
            {

                    AudioSource.PlayClipAtPoint(destroyClip, transform.position, 1);
                
                GameManager.incrementScore();
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }
        }

        //For Time Lapse and One Direction
        else if (GameManager.getLevelName() != "FAST_ESCAPE" && GameManager.getLevelName() != "EQUALS")
        {
            //Destroy enemy Vees only
            if (collider.gameObject.GetComponent<EnemyFormation>())
            {

                    AudioSource.PlayClipAtPoint(destroyClip, transform.position, 1);
       
                GameManager.incrementScore();
                Destroy(collider.gameObject);
            }
        }

        //For equals only
        else if (GameManager.getLevelName() == "EQUALS")
        {
            //Destroy player and enemey Vees
            if (collider.gameObject.GetComponent<EnemyFormation>())
            {
                totalEnemiesKilledInThisWave++;

                    AudioSource.PlayClipAtPoint(destroyClip, transform.position, 1);

                GameManager.incrementScore();
                Destroy(collider.gameObject);
                Destroy(gameObject);
                EnemySpawner.resumeTrigger = true;
            }
        }


        //Handle Bomb collission
        if(collider.gameObject.GetComponent<BombFormation>())
        {
            Application.LoadLevel("GAME_OVER");
        }
    }
}
