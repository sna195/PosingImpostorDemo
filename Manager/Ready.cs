using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready
{
    private int _count = 0;

    private int _max;

    private GameEvent _gameEvent;

    
    public Ready(int max, GameEvent gameEvent)
    {
        _max = max;
        _gameEvent = gameEvent;
    }

    public void CountUp()
    {
        _count++;

        Debug.Log(_count);
        Debug.Log(_max);
        Debug.Log(_count % _max);

        if (_count % _max == 0) 
        {
            Debug.Log("count= " + _count);
            _gameEvent.Raise();
        }
    }
}
