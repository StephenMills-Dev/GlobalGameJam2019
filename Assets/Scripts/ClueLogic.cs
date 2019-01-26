using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueLogic : MonoBehaviour {

    public Home targetHome;
    GameObject[] possibleHomes;
    bool chosen = false;

    // Use this for initialization
    void Start () {
       possibleHomes = GameObject.FindGameObjectsWithTag("Home");
        int homeChoice = UnityEngine.Random.Range(0, possibleHomes.Length - 1);
        targetHome = possibleHomes[homeChoice].GetComponent<Home>();
        if (targetHome != null)
        {
            FindClue(0);
            FindClue(1);
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
        if(possibleValues != null)
        foreach(GameObject clue in possibleValues)
        {
            clue.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            if(type == 1)
            {
                possibleValues = GameObject.FindGameObjectsWithTag("Red");
                foreach (GameObject clue in possibleValues)
                {
                    Color color = new Color(1,1,1);
                    Debug.Log("uh oh");
                    switch(value)
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
            FindClue(1);
            FindClue(2);
            chosen = true;
        }

    }

    void FindColor()
    {

    }

}
