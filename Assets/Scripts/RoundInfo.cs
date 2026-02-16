using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundInfo : MonoBehaviour{
    
    // UI Text Component
    static private Text _roundInfo;
    
    // Round number used to be displayed in the displayed string (round 0 = game over)
    static private int _roundNum; 

    void Awake(){
        _roundInfo = GetComponent<Text>();
    }

    // sets the current round number and display string (round 0 = game over)
    static public int roundNum{
        get{
            return _roundNum;
        }
        set{
            _roundNum = value;
            if(_roundInfo == null) return;
            
            // if the round number is 0 then display game over, else display the round number
            if(value == 0){
                _roundInfo.text = "Game Over";
            }
            else{
                _roundInfo.text = "Round: " + value.ToString("#,0");
            }
        }
    }
}
