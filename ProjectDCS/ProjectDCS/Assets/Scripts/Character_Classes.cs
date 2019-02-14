using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Classes : MonoBehaviour
{
    int classSelection; //what the player selects
    enum ClassType { SUPPORT = 1, BALANCED, TANK, SNIPER };
    
    //the reason it's int is because the enum is an integer. 
    int selectClass() {
        //ask user to select class
        //Set their answer to the matching enumerator (support, balanced, etc)

        //TODO: Add buttons with UI to allow class selection? 
        switch (ClassType) {
            case 1:
                classSelection = ClassType.SUPPORT;
                break;
            case 2:
                classSelection = ClassType.BALANCED;
                break;
            case 3:
                classSelection = ClassType.TANK;
                break;
            case 4:
                classSelection = ClassType.SNIPER;
                break;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        selectClass();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
