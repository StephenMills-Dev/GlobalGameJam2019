
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueLogic : MonoBehaviour {

    public Home targetHome;
    GameObject[] possibleHomes;
    bool chosen = false;
    public Color[] _types;

    // Use this for initialization
    void Start () {
       possibleHomes = GameObject.FindGameObjectsWithTag("Home");
        int homeChoice = UnityEngine.Random.Range(0, possibleHomes.Length - 1);
        targetHome = possibleHomes[homeChoice].GetComponent<Home>();
        if (targetHome != null)
        {
            FindClue(0);
            FindColor();
            FindClue(2);
            chosen = true;
        }
        //FindLocation();


    }

    private void FindClue(int type)
    {
        string value = "";
        switch(type)
        {
            case 0:
                value = "Finish";
                break;
            case 1:
                value = targetHome._colour;
                Debug.Log(value);
                break;
            case 2:
                value = targetHome._size;
                Debug.Log(value);

                break;
            default:
                break;
        }
        GameObject[] possibleValues = GameObject.FindGameObjectsWithTag(value);
        if (possibleValues.Length != 0)
        {
            foreach (GameObject clue in possibleValues)
            {
                clue.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            if (type == 1)
            {
                possibleValues = GameObject.FindGameObjectsWithTag("Red");
                foreach (GameObject clue in possibleValues)
                {
                    Color color = new Color(1, 1, 1);
                    Debug.Log("uh oh");
                    switch (value)
                    {
                        case "Blue":
                            color = Color.blue;
                            break;
                        case "Green":
                            color = Color.green;
                            break;
                        case "Yellow":
                            color = Color.yellow;
                            break;
                        case "Black":
                            color = Color.black;
                            break;
                        case "White":
                            color = Color.white;
                            break;
                    }
                    //Fetch the Renderer from the GameObject
                    Renderer rend = clue.GetComponent<Renderer>();

                    //Set the main Color of the Material to green
                    rend.material.shader = Shader.Find("_Color");
                    rend.material.SetColor("_Color", color);

                    //Find the Specular shader and change its Color to red
                    rend.material.shader = Shader.Find("Specular");
                    rend.material.SetColor("_SpecColor", Color.black);
                    clue.transform.GetChild(0).gameObject.SetActive(true);

                    clue.tag = value;
                }
            }
        }
        //GameObject clue = possibleValues[UnityEngine.Random.Range(0, possibleValues.Length)];
      
        

    }

    private void FindSize()
    {
    }

    // Update is called once per frame
    void Update () {
        if (targetHome != null && !chosen)
        {
            FindClue(0);
            FindClue(2);
            chosen = true;
        }

    }

    void FindColor()
    {
        GameObject[] colorObjects = GameObject.FindGameObjectsWithTag("Color");
        int[] clues = new int[4];
        for(int i = 0; i < clues.Length;i++)
        {
            clues[i] = Random.Range(0, colorObjects.Length);
            colorObjects[clues[i]].tag = targetHome._colour;
            colorObjects[clues[i]].transform.GetChild(0).gameObject.SetActive(true);
        }
        foreach (GameObject g in colorObjects)
        {
            int colorChoice = Random.Range(0, 20);
            if(g.tag != targetHome._colour)
            switch (colorChoice)
            {
                case 0:
                    g.gameObject.tag = "Red";
                    break;
                case 3:
                    g.gameObject.tag = "Green";
                    break;
                case 7:
                    g.gameObject.tag = "Blue";
                    break;
                case 10:
                    g.gameObject.tag = "Yellow";
                    break;
                case 14:
                    g.gameObject.tag = "White";
                    break;
                case 18:
                    g.gameObject.tag = "Black";
                    break;
                default:
                    g.gameObject.tag = "Color";
                    break;

            }
            else
            {
                switch(targetHome._colour)
                {
                    case "Red":
                        colorChoice = 0;
                        break;
                    case "Blue":
                        colorChoice = 3;
                        break;
                    case "Green":
                        colorChoice = 7;
                        break;
                    case "Yellow":
                        colorChoice = 10;
                        break;
                    case "Black":
                        colorChoice = 14;
                        break;
                    case "White":
                        colorChoice = 18;
                        break;
                }
            }


            //Fetch the Renderer from the GameObject
            Renderer rend = g.GetComponent<Renderer>();

            //Set the main Color of the Material to green
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", _types[colorChoice]);

            //Find the Specular shader and change its Color to red
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.black);
        }
    }

}
