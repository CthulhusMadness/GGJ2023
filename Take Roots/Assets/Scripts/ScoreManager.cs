using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private int birdScore;
    [SerializeField] private int dogScore;
    [SerializeField] private int cowScore;


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
