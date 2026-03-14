using System;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private int _maxNumOfLives = 3;

    private int _numOfLives;


    public int NumOfLives
    {
        get => _numOfLives;
        private set => _numOfLives = Mathf.Clamp(value, 0, _maxNumOfLives);
    }

    private void Awake()
    {
        _numOfLives = _maxNumOfLives;
    }

    public void AddLife(int num = 1)
    {
        NumOfLives += num;
    }

    public void RemoveLife(int num = 1)
    {
        NumOfLives -= num;

        if (NumOfLives <= 0)
        {
            gameOverManager.SetGameOver();
        }
    }
}