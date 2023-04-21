using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextDisplayer _textDisplayer = default;
    
    private float _score = 0;

    public void UpdateScore(float score)
    {
        _score += score;
        _textDisplayer.DisplayText(_score);
    }

}
