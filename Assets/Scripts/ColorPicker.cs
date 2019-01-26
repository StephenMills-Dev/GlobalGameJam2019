using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour {

    public Color[] _types;
    // Use this for initialization
    void Start()
    {
        int colorChoice = Random.Range(0, 20);


        switch(colorChoice)
        {
            case 0:
                this.gameObject.tag = "Red";
            break;
            case 3:
                this.gameObject.tag = "Green";
                break;
            case 7:
                this.gameObject.tag = "Blue";
                break;
            case 10:
                this.gameObject.tag = "Yellow";
                break;
            case 14:
                this.gameObject.tag = "White";
                break;
            case 18:
                this.gameObject.tag = "Black";
                break;
            default:
                this.gameObject.tag = "Color";
                break;

        }


        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", _types[colorChoice]);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.black);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
