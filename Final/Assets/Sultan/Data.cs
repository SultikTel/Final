using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data 
{
    private static Data _current;
    public static Data current
    {
        get
        {
            if(_current == null)
            {
                _current = new Data();
            }

            return _current;
        }
    }



}
