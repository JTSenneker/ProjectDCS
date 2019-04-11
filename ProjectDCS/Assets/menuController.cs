using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour {
    public Button[] buttons;
    void OnEnable() {
        buttons[0].Select();
    }
}
