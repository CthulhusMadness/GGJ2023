using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    public int Day = 1;
    [SerializeField] private int birdScore;
    [SerializeField] private int dogScore;
    [SerializeField] private int cowScore;

    public void ResetScore()
    {
        birdScore = 0;
        dogScore = 0;
        cowScore = 0;
    }

    public void setBirdScore(int score)
    {
        birdScore += score;
    }

    public void setDogScore(int score)
    {
        dogScore += score;
    }

    public void setCowScore(int score)
    {
        cowScore += score;
    }

    public int getBirdScore()
    {
        return birdScore;
    }

    public int getDogScore()
    {
        return dogScore;
    }

    public int getCowScore()
    {
        return cowScore;
    }
}
