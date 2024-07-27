using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class CSVWriter : MonoBehaviour
{
    string _filename = "";

    // Start is called before the first frame update
    public void Start()
    {
        _filename = Path.Combine(Application.dataPath, "GameData.csv");
    }

    // Update is called once per frame
    public void Update()
    {

    }



}
