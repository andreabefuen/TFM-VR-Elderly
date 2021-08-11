using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods 
{

    public static string BoolToString(bool b)
    {
        return b ? "true" : "false";
    }

    public static bool StringToBool(string str)
    {
        return true ? str == "true" : false;
    }
}
