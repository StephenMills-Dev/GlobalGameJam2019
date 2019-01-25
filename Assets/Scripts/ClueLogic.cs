using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueLogic : MonoBehaviour {

    public Home targetHome;
    GameObject[] possibleHomes;
    // Use this for initialization
    void Start () {
       possibleHomes = GameObject.FindGameObjectsWithTag("Home");
        int homeChoice = UnityEngine.Random.Range(0, possibleHomes.Length - 1);
        targetHome = possibleHomes[homeChoice].GetComponent<Home>();

        FindClue(0);
        FindClue(1);
        FindClue(2);
        //FindLocation();


    }

    private void FindClue(int type)
    {
        string[] colours = { "Red", "Green", "Blue", "Yellow", "White", "Black" };
        string[] size = { "House", "Apartment" };
        string value = "";
        switch(type)
        {
            case 0:
                value = "Number";
                break;
            case 1:
                value = colours[UnityEngine.Random.Range(0, colours.Length)];
                break;
            case 2:
                value = size[UnityEngine.Random.Range(0, size.Length)];

                break;
            default:
                break;
        }
        GameObject[] possibleValues = GameObject.FindGameObjectsWithTag(value);
        GameObject clue = possibleValues[UnityEngine.Random.Range(0, possibleValues.Length)];
        clue.transform.GetChild(0).gameObject.SetActive(true);

    }

    private void FindSize()
    {
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FindColor()
    {

    }

}
