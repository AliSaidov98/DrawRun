using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerAnim _playerAnim;
    private Material _myMaterial;
    
    public PlayerPositions playerPositions;
    public SkinnedMeshRenderer mesh;
    public GameStage gameStage;
    
    private void Awake()
    {
        playerPositions = GetComponentInParent<PlayerPositions>();
        gameStage = FindObjectOfType<GameStage>();
        _playerAnim = GetComponent<PlayerAnim>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _myMaterial = mesh.material;
        
        if (other.CompareTag("Trap"))
        {
            _playerAnim.Die();
            playerPositions.RemoveGuy(transform);
        }
        else if (other.CompareTag("Guy"))
        {
            var otherPlayerTrigger = other.GetComponent<PlayerTrigger>();
            otherPlayerTrigger.gameStage = gameStage;
            otherPlayerTrigger.playerPositions = playerPositions;
            otherPlayerTrigger.mesh.material = _myMaterial;
            
            playerPositions.AddGuy(other.transform);
            other.tag = "Untagged";
        }
        else if(other.CompareTag("Finish"))
        {
            transform.SetParent(null);
            _playerAnim.Finish();
            gameStage.FinishGame();
        }
    }
}
