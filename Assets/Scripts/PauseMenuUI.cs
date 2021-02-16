
using UnityEngine;
using TMPro;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject topLabel;
    private TextMeshProUGUI topText;


    private void Awake()
    {
        topText = topLabel.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTopText(string newText)
    {
        topText.text = newText;
        
    }
}
