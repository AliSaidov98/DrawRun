using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class PlayerPositions : MonoBehaviour
{
    private bool _isStarted;
    private List<Transform> _guys = new List<Transform>();
    private SplineFollower _splineFollower;

    private GameStage _gameStage;
    
    
    private void Awake()
    {
        _splineFollower = GetComponent<SplineFollower>();
        _gameStage = FindObjectOfType<GameStage>();
        AssignChildren();
    }

    private void AssignChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _guys.Add(transform.GetChild(i));
        }
    }

    public void AssignPositions(List<Vector2> positions)
    {
        var indexModifier = positions.Count / _guys.Count;
        var posIndex = 0;
        
        foreach (var guy in _guys)
        {
            positions[posIndex] /= 100;
            guy.localPosition =
                Vector3.right * positions[posIndex].x + Vector3.forward * positions[posIndex].y;
            
            posIndex += indexModifier;
        }
    }

    public void RemoveGuy(Transform guy)
    {
        _guys.Remove(guy);
        guy.SetParent(null);
        
        if(_guys.Count == 0)
            _gameStage.GameOver();
    }

    public void AddGuy(Transform guy)
    {
        _guys.Add(guy);
        guy.GetComponent<PlayerAnim>().Run();
        guy.SetParent(transform);
    }

    public void StartMovement()
    {
        _splineFollower.enabled = true;
        
        foreach (var guy in _guys)
        {
            guy.GetComponent<PlayerAnim>().Run();
        }
    }

    public void StopMovement()
    {
        _splineFollower.enabled = false;
    }
}
