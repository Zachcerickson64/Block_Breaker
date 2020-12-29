using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Paddle : MonoBehaviour
{

    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 16f;

    // cached references
    GameSession theGameSession;
    Ball theBall;
    

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    public float ToUnits(float i)
    {
        return i / Screen.width * ScreenWidthInUnits;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return ToUnits(Input.mousePosition.x);
        }
    }

}
