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
                value = "Number";
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
        GameObject clue = possibleValues[UnityEngine.Random.Range(0, possibleValues.Length)];
        clue.transform.GetChild(0).gameObject.SetActive(true);
        

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
