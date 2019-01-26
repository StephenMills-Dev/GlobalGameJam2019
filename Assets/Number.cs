using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Number : MonoBehaviour {
    public int value;
    [SerializeField]
    TextMeshProUGUI tmp;
	// Use this for initialization
	void Start () {
        tmp.text = value.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        tmp.text = value.ToString();
    }
}
