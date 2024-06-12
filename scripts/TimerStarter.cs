using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStarter : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.TimeStarting+= TurnOn;
    }

    private void OnDisable()
    {
        _timer.TimeStarting -= TurnOn;
    }

    private void TurnOn()
    {
        _timer.IsWorking = true;
    }
}
