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
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, layerMask))
            {
                if (hit.transform.gameObject.tag == clueController.targetHome._colour)
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
                    //Fetch the Renderer from the GameObject
                    Renderer rend = key.GetComponent<Renderer>();

                    //Set the main Color of the Material to green
                    rend.material.shader = Shader.Find("_Color");
                    rend.material.SetColor("_Color", c);

                    //Find the Specular shader and change its Color to red
                    rend.material.shader = Shader.Find("Specular");
                    rend.material.SetColor("_SpecColor", Color.black);

                    GameObject[] possibleValues = GameObject.FindGameObjectsWithTag(clueController.targetHome._colour);
                    foreach(GameObject g in possibleValues)
                    {
                        g.transform.GetChild(0).gameObject.SetActive(false);
                    }

                }
                else if (hit.transform.gameObject.tag == clueController.targetHome._size)
                {
                    if(clueController.targetHome._size == "House")
                    key.GetComponent<MeshFilter>().sharedMesh = key.GetComponent<keyMeshes>().keys[0];
                    else
                        key.GetComponent<MeshFilter>().sharedMesh = key.GetComponent<keyMeshes>().keys[1];
                    GameObject[] possibleValues = GameObject.FindGameObjectsWithTag(clueController.targetHome._size);
                    foreach (GameObject g in possibleValues)
                    {
                        g.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
                else if (hit.transform.gameObject.tag == "Number")
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
                    }
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
            }
        }
    }

