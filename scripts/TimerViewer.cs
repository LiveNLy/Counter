
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;


    private void Start()
    {
        _text.text = "";
    }

    private void OnEnable()
    {
        _timer.TimerDrowing += DisplayTimer;
    }

    private void OnDisable()
    {
        _timer.TimerDrowing -= DisplayTimer;
    }

    public void DisplayTimer()
    {
        float time = _timer.CurrentTime;
        _text.text = time.ToString();
    }
}