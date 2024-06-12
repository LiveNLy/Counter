using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStoper : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.TimeStoping += TurnOff;
    }

    private void OnDisable()
    {
        _timer.TimeStoping -= TurnOff;
    }

    private void TurnOff()
    {
        _timer.IsWorking = false;
    }
}
