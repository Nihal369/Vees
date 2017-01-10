﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreBoard : MonoBehaviour
{

    public Text typeBoard;

    static int showRewardedAdAfter = 6, showNoRewardAdAfter = 7, numberOfGames = 0, numberOfLapseGames = 0, numberOfEqualsGames;

    const string oneWayLeaderBoardID = "CgkIiY779uUNEAIQEw";
    const string equalsLeaderBoardID = "CgkIiY779uUNEAIQFA";
    const string escapeLeaderBoardID = "CgkIiY779uUNEAIQFQ";
    const string lapseLeaderBoardID = "CgkIiY779uUNEAIQFg";
    const string boomLeaderBoardID = "CgkIiY779uUNEAIQFw";

    static string filePath = Application.persistentDataPath + "/px094g346f0ls.dat";

    //Set scoreboard for gameOver level

    void Start()
    {
        postScoreToLeaderBoard();
        checkForAchievements();
        saveHighScore();
        loadHighScore();
        //checkIfHighScore();
        if (GameManager.hasGameBeenRestarted())
        {
            numberOfGames = 0;
        }
        else
        {
            numberOfGames++;
        }

        //Ad Script
        if (!IAPManager.hasUserPurchasedVees())
        {
            if (numberOfGames % showNoRewardAdAfter == 0 && !GameManager.hasGameBeenRestarted() && Advertisement.IsReady())//Show ad only if user didnt view ad for restarting
            {
                AdManager.showNoRewardedAd();
            }
        }

        if (!VolumeManager.getIsMuted())
        {
            VolumeManager.setMusicPlayerOnIfSilent();
        }

        if (LevelManager.getFromLevel() == 6)
        {
            //Wave number for level EQUALS
            gameObject.GetComponent<Text>().text = EnemySpawner.getWaveNumber().ToString();
            //PlayerPrefsManager.saveHighScore(EnemySpawner.getWaveNumber(), LevelManager.getFromLevel());
            GoalDetector.fromEquals = false;
            typeBoard.text = "WAVE";
        }
        else if (LevelManager.getFromLevel() == 5)
        {
            typeBoard.text = "ESCAPES";
            //PlayerPrefsManager.saveHighScore(GameManager.getScore(), LevelManager.getFromLevel());
            gameObject.GetComponent<Text>().text = GameManager.getScore().ToString();
        }

        else
        {
            typeBoard.text = "HITS";
            //PlayerPrefsManager.saveHighScore(GameManager.getScore(), LevelManager.getFromLevel());
            gameObject.GetComponent<Text>().text = GameManager.getScore().ToString();
        }
    }

    void Update()
    {
        if (LevelManager.getFromLevel() == 6)
        {
            //Wave number for level EQUALS
            gameObject.GetComponent<Text>().text = EnemySpawner.getWaveNumber().ToString();
            GoalDetector.fromEquals = false;
        }
        else
        {
            if (LevelManager.getFromLevel() != 5)
            {
                gameObject.GetComponent<Text>().text = GameManager.getScore().ToString();
            }
            else
            {
                gameObject.GetComponent<Text>().text = GameManager.getScore().ToString();
            }
        }
    }

    void checkForAchievements()
    {
        if (Advertisement.IsReady())
        {
            if (LevelManager.getFromLevel() == 7)
            {
                numberOfLapseGames++;
            }
            else
            {
                numberOfLapseGames = 0;
            }
            if (numberOfLapseGames == 10)
            {
                Social.ReportProgress(GPGSIds.achievement_lapse_love, 100, (bool sucess) =>
                {
                    if (sucess)
                    {

                    }
                    else
                    {

                    }
                });

            }



            if (LevelManager.getFromLevel() == 6)
            {
                numberOfEqualsGames++;
            }
            else
            {
                numberOfEqualsGames = 0;
            }
            if (numberOfEqualsGames == 10)
            {
                Social.ReportProgress(GPGSIds.achievement_equals_love, 100, (bool sucess) =>
                {
                    if (sucess)
                    {

                    }
                    else
                    {

                    }
                });
            }
        }
    }

    public void postScoreToLeaderBoard()
    {
        switch (LevelManager.getFromLevel())
        {
            case 3:
                Social.ReportScore(GameManager.getScore(), oneWayLeaderBoardID, (bool success) =>
                {
                    if (success)
                    {

                    }
                    else
                    {

                    }
                });

                break;
            case 6:
                Social.ReportScore(EnemySpawner.getWaveNumber(), equalsLeaderBoardID, (bool success) =>
                {
                    if (success)
                    {

                    }
                    else
                    {

                    }
                });
                break;
            case 5:
                Social.ReportScore(GameManager.getScore(), escapeLeaderBoardID, (bool success) =>
                {
                    if (success)
                    {

                    }
                    else
                    {
                    }
                });
                break;
            case 7:
                Social.ReportScore(GameManager.getScore(), lapseLeaderBoardID, (bool success) =>
                {
                    if (success)
                    {

                    }
                    else
                    {

                    }
                });
                break;
            case 4:
                Social.ReportScore(GameManager.getScore(), boomLeaderBoardID, (bool success) =>
                {
                    if (success)
                    {

                    }
                    else
                    {

                    }
                });
                break;
        }
    }

    static float nihalEncryption(float input)
    {
        return (Mathf.Log10(input));
    }

    static float nihalDecryption(float input)
    {
        return (Mathf.Pow(10, input));
    }

    public static void saveHighScore()
    {
        BinaryFormatter myBinaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        veesData obj = new veesData();
        //Save scores here
        switch (LevelManager.getFromLevel())
        {
            case 3:
                obj._sys = (GameManager.getScore());
                break;
            case 5:
                obj._cache = (GameManager.getScore());
                break;
            case 6:
                obj._config = (EnemySpawner.getWaveNumber());
                break;
            case 7:
                obj._tmp = (GameManager.getScore());
                break;
        }
        //Save scores here
        myBinaryFormatter.Serialize(file, obj);
        file.Close();
    }

    static void saveOneWayHigh(float score)
    {

        BinaryFormatter myBinaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        veesData obj = new veesData();
        obj.sys = score;
        myBinaryFormatter.Serialize(file, obj);
        file.Close();
    }

    public static void loadHighScore()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter myBinaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            veesData obj = (veesData)myBinaryFormatter.Deserialize(file);
            file.Close();

            float previousScoreOneWay = (obj._sys);
            float previousScoreEscape = (obj._cache);
            float previousScoreEquals = (obj._config);
            float previousScoreLapse = (obj._tmp);

            float oneWayHighScore = (obj.sys);
            float escapeHighScore = (obj.cache);
            float equalsHighScore = (obj.config);
            float lapseHighScore = (obj.tmp);

            //If previousScore>HighScore without errors BINGO! commit here
            if (previousScoreOneWay > oneWayHighScore)
            {
                Debug.Log("High Score Successful");
                saveOneWayHigh(previousScoreOneWay);
            }
        }
    }

    public static float setHighScoreDisplay()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter myBinaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            veesData obj = (veesData)myBinaryFormatter.Deserialize(file);
            file.Close();
            switch (LevelManager.getFromLevel())
            {
                case 3: return ((obj.sys));
                case 5: return ((obj.cache));
                case 6: return ((obj.config));
                case 7: return ((obj.tmp));
            }
        }
        return 99;
    }
}

[Serializable]
public class veesData
{
    public float sys;//One Way HighScore
    public float cache;//Escape HighScore
    public float config;//Equals HighScore
    public float tmp;//Lapse HighScore

    public float _sys;//One Way current score
    public float _cache;//Escape current score
    public float _config;//Equals current score
    public float _tmp;//Lapse current score
}