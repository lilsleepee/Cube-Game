using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    public static Score Instance;

    private Text _scoreText;
    private int _scoreAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _scoreText = gameObject.GetComponent<Text>();
        _scoreText.text = "" + _scoreAmount;
    }

    public void AddScore(int scoreAmount)
    {
        _scoreAmount += scoreAmount;
        _scoreText.text = "" + _scoreAmount;
    }
}
