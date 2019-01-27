using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyMeshes : MonoBehaviour {

    public GameObject[] keys;
    public string numbertxt;
    [SerializeField]
    TextMeshProUGUI txtmsh;
	// Use this for initialization
	void Start () {
        txtmsh.text = numbertxt;
	}
	
	// Update is called once per frame
	void Update () {
        txtmsh.text = numbertxt;
    }
}
