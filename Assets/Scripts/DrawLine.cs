using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawLine : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private Vector2 _offset;
    
    private Vector2 _pos;

    private List<Vector2> _fingerPositions;

    private PlayerPositions _player;

    private Rect _rect;

    private GameStage _gameStage;

    private void Awake()
    {
        _fingerPositions = new List<Vector2>();
        _rect = GetComponent<RectTransform>().rect;
        _player = FindObjectOfType<PlayerPositions>();
        _gameStage = FindObjectOfType<GameStage>();
    }
    
    private void SettingPosition(PointerEventData eventData)
    {
        _pos = eventData.position;
        _pos.x -= _rect.width * 0.5f;
        _pos.y -= _rect.height * 0.5f;
        _pos -= _offset;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        SettingPosition(eventData);

        _fingerPositions.Add(_pos);
        _fingerPositions.Add(_pos);
        _lineRenderer.SetPosition(0, _fingerPositions[0]);
        _lineRenderer.SetPosition(1, _fingerPositions[1]);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject != gameObject) return;
     
        SettingPosition(eventData);

        _fingerPositions.Add(_pos);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _pos);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        _player.AssignPositions(_fingerPositions);
        _fingerPositions.Clear();
        _lineRenderer.positionCount = 2;
        _gameStage.StartGame();
    }
}
