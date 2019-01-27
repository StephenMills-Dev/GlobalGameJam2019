using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clueCamera : MonoBehaviour
{
    public GameObject key;
    ClueLogic clueController;
    // Use this for initialization
    void Start()
    {
        clueController = GameObject.Find("ClueLogicController").GetComponent<ClueLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 10;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 12f, layerMask))
            {
                if (hit.transform.gameObject.tag == clueController.targetHome._colour && !clueController.colourFound)
                {
                    Color c = new Color(1, 1, 1);
                    switch (clueController.targetHome._colour)
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




                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("We did it");
                    Renderer[] renderers =
                        {
                        key.GetComponent<Renderer>(),
                        key.GetComponent<keyMeshes>().keys[0].transform.GetChild(0).GetComponent<Renderer>(),
                        key.GetComponent<keyMeshes>().keys[1].gameObject.GetComponent<Renderer>()
                        };
                    //Fetch the Renderer from the GameObject


                    foreach (Renderer rend in renderers)
                    {
                        //Set the main Color of the Material to green
                        rend.material.shader = Shader.Find("_Color");
                        rend.material.SetColor("_Color", c);

                        //Find the Specular shader and change its Color to red
                        rend.material.shader = Shader.Find("Specular");
                        rend.material.SetColor("_SpecColor", Color.black);
                    }

                    GameObject[] possibleValues = GameObject.FindGameObjectsWithTag(clueController.targetHome._colour);
                    foreach(GameObject g in possibleValues)
                    {
                        g.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    clueController.colourFound = true;
                }
                else if (hit.transform.gameObject.tag == clueController.targetHome._size && !clueController.sizeFound)
                {
                    key.GetComponent<MeshRenderer>().enabled = false;
                    if(clueController.targetHome._size == "House")
                    key.GetComponent<keyMeshes>().keys[0].SetActive(true);
                    else
                        key.GetComponent<keyMeshes>().keys[1].SetActive(true);
                    GameObject[] possibleValues = GameObject.FindGameObjectsWithTag(clueController.targetHome._size);
                    foreach (GameObject g in possibleValues)
                    {
                        g.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    clueController.sizeFound = true;
                }
                else if (hit.transform.gameObject.tag == "Number" && clueController.numberFound != true)
                {
                    if (clueController.targetHome.Number == hit.transform.gameObject.GetComponent<Number>().value)
                    {
                        key.GetComponent<keyMeshes>().numbertxt = clueController.targetHome.Number.ToString();
                        GameObject[] possibleValues = GameObject.FindGameObjectsWithTag("Number");
                        foreach (GameObject g in possibleValues)
                        {
                            if(g.GetComponent<Number>().value == clueController.targetHome.Number)
                            g.transform.GetChild(0).gameObject.SetActive(false);
                        }
                        clueController.numberFound = true;
                    }
                }
                else if (hit.transform.gameObject.tag == "Home" && hit.transform.gameObject.GetComponent<Home>().hbeat.active && clueController.allClues)
                {
                    clueController.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
            }
        if(Input.GetButtonDown("Fire2"))
        {
            GetComponent<Animator>().Play("camera equip");
        }
        if (Input.GetButtonUp("Fire2"))
        {
            GetComponent<Animator>().Play("camera unequip");
        }
    }
    }

