
using TMPro;
using UnityEngine;

public static class QuestLog 
{

    public static Color colour = Color.gray;
    

    public static void FormatString(TMP_Text text) 
    {  
        text.text = "<s>" + text.text + "</s>"; 

        text.color = colour;
    }

    
}
