using UnityEngine;
using System.Collections;
using CartyLib.CardsImplementation;
using System;

public class SimpleCard : MonoBehaviour, ICard
{
    public int GetCost()
    {
        return 1;
    }

    public string GetDescription()
    {
        return "I don't do much.";
    }

    public string GetTitle()
    {
        return "Simple card";
    }

    public string GetUniqueID()
    {
        return "simplecard";
    }
}
