using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMode : MonoBehaviour
{
    public GameObject color;
    public GameObject sculpt;

    public Button ColorBtn;
    public Button SculptBtn;

    private void Start()
    {
        ColorBtn.onClick.AddListener(SetColorPanelActive);
        SculptBtn.onClick.AddListener(SetSculptPanelActive);
    }

    void SetColorPanelActive()
    {
        color.SetActive(true);
        sculpt.SetActive(false);

    }
    void SetSculptPanelActive()
    {
        color.SetActive(false);
        sculpt.SetActive(true);
    }
}
