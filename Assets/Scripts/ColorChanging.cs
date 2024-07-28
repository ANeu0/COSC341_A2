using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    public int score = 0;
    public InputHandler inputHandler;
    public DataLogger dataLogger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor(GameObject g)
    {
        if(g.name == "Background1")
        {
            dataLogger.wrong = 1;
        }
        dataLogger.WriteCSV();
        _spriteRenderer = g.GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(179f, 168f, 168f, 255f);
    }
}
