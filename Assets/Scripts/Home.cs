using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
    
    public enum cColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Black
    };
    public cColor cSelector;
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
    public GameObject House;

    private void Start()
    {
        _colour = cSelector.ToString();
        _size = sSelector.ToString();

        Color c = new Color(1, 1, 1);
        switch (_colour)
        {
            case "Red":
                c = Color.red;
                break;
            case "Blue":
                c = Color.blue;
                break;
            case "Green":
                c = Color.green;
                break;
            case "Yellow":
                c = Color.yellow;
                break;
            case "Black":
                c = Color.black;
                break;
            case "White":
                c = Color.white;
                break;
        }


        //Fetch the Renderer from the GameObject
        Renderer rend = House.GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", c);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.black);
    }
}
