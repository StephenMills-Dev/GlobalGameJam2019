using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
    
    public enum Color
    {
        Red,
        Black,
        Blue,
        Yellow,
        Green,
        White
    };
    public Color selector;
    string _colour;
    public int Number;
    public string Size;
    public string Location;

    private void Start()
    {
        _colour = selector.ToString();
    }
}
