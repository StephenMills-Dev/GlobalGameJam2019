using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
    
    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Black
    };
    public Color cSelector;
    public enum Size
    {
        House,
        Apartment
    };
    public Size sSelector;
    public string _colour;
    public int Number;
    public string _size;
    public string Location;
    public GameObject hbeat;

    private void Start()
    {
        _colour = cSelector.ToString();
        _size = sSelector.ToString();
    }
}
