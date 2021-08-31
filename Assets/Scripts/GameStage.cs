using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    [SerializeField] private PlayerPositions _playerPositions;
    
    private bool _isStarted;
    private bool _isFinished;

    public void StartGame()
    {
        if(_isStarted) return;

        _isStarted = true;
        
        _playerPositions.StartMovement();
    }

    public void GameOver()
    {
        _playerPositions.StopMovement();
        Debug.Log("GameOver");
    }

    public void FinishGame()
    { 
        if(_isFinished) return;

        _isFinished = true;
        
       // _playerPositions.StopMovement();
        Debug.Log("WinWIn");
    }
}
