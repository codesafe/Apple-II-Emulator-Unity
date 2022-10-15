using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Action<string> hitKBD = null;

    private void Awake()
    {
        Instance = this;
    }

    public void AddLetter(string letter)
    {
        hitKBD?.Invoke(letter);
    }

    // Back Space
    public void DeleteLetter()
    {
        hitKBD?.Invoke("BS");
    }

    // Enter
    public void SubmitWord()
    {
        hitKBD?.Invoke("ENTER");
    }

    bool shift = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            shift = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            shift = false;
        if (Input.GetKeyDown(KeyCode.RightShift))
            shift = true;
        if (Input.GetKeyUp(KeyCode.RightShift))
            shift = false;

        if (Input.GetKeyDown(KeyCode.Space))
            AddLetter(" ");
        else if (Input.GetKeyDown(KeyCode.Return))
            AddLetter("ENTER");
        else if (Input.GetKeyDown(KeyCode.Backspace))
            AddLetter("BS");
        else if (Input.GetKeyDown(KeyCode.Escape))
            AddLetter("ESC");

        if (Input.GetKeyDown(KeyCode.A))
            AddLetter("A");
        else if (Input.GetKeyDown(KeyCode.B))
            AddLetter("B");
        else if (Input.GetKeyDown(KeyCode.C))
            AddLetter("C");
        else if (Input.GetKeyDown(KeyCode.D))
            AddLetter("D");
        else if (Input.GetKeyDown(KeyCode.E))
            AddLetter("E");
        else if (Input.GetKeyDown(KeyCode.F))
            AddLetter("F");
        else if (Input.GetKeyDown(KeyCode.G))
            AddLetter("G");
        else if (Input.GetKeyDown(KeyCode.H))
            AddLetter("H");
        else if (Input.GetKeyDown(KeyCode.I))
            AddLetter("I");
        else if (Input.GetKeyDown(KeyCode.J))
            AddLetter("J");
        else if (Input.GetKeyDown(KeyCode.K))
            AddLetter("K");
        else if (Input.GetKeyDown(KeyCode.L))
            AddLetter("L");
        else if (Input.GetKeyDown(KeyCode.M))
            AddLetter("M");
        else if (Input.GetKeyDown(KeyCode.N))
            AddLetter("N");
        else if (Input.GetKeyDown(KeyCode.O))
            AddLetter("O");
        else if (Input.GetKeyDown(KeyCode.P))
            AddLetter("P");
        else if (Input.GetKeyDown(KeyCode.Q))
            AddLetter("Q");
        else if (Input.GetKeyDown(KeyCode.R))
            AddLetter("R");
        else if (Input.GetKeyDown(KeyCode.S))
            AddLetter("S");
        else if (Input.GetKeyDown(KeyCode.T))
            AddLetter("T");
        else if (Input.GetKeyDown(KeyCode.U))
            AddLetter("U");
        else if (Input.GetKeyDown(KeyCode.V))
            AddLetter("V");
        else if (Input.GetKeyDown(KeyCode.W))
            AddLetter("W");
        else if (Input.GetKeyDown(KeyCode.X))
            AddLetter("C");
        else if (Input.GetKeyDown(KeyCode.Y))
            AddLetter("Y");
        else if (Input.GetKeyDown(KeyCode.Z))
            AddLetter("Z");
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if( shift )
                AddLetter(")");
            else
                AddLetter("0");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (shift)
                AddLetter("!");
            else
                AddLetter("1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (shift)
                AddLetter("@");
            else
                AddLetter("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (shift)
                AddLetter("#");
            else
                AddLetter("3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (shift)
                AddLetter("$");
            else
                AddLetter("4");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (shift)
                AddLetter("%");
            else
                AddLetter("5");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (shift)
                AddLetter("^");
            else
                AddLetter("6");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (shift)
                AddLetter("&");
            else
                AddLetter("7");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (shift)
                AddLetter("*");
            else
                AddLetter("8");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (shift)
                AddLetter("(");
            else
                AddLetter("9");
        }
        else if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (shift)
                AddLetter("?");
            else
                AddLetter("/");
        }
        else if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (shift)
                AddLetter("+");
            else
                AddLetter("=");
        }
        else if (Input.GetKeyDown(KeyCode.Comma))
        {
            if (shift)
                AddLetter("<");
            else
                AddLetter(",");
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (shift)
                AddLetter("-");
            else
                AddLetter("-");
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            if (shift)
                AddLetter(">");
            else
                AddLetter(".");
        }
        else if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            if (shift)
                AddLetter(";");
            else
                AddLetter(":");
        }

    }

}
