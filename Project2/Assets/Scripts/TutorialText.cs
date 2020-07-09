using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour{
    // Start is called before the first frame update
    
    int textToShow;
    public string WelcomeText;
    public string BasicConceptText;
    public string BasicConceptText1;
    public string HUDText;
    public string AimText;
    public string MarkText;
    public string ShootText;
    public GameObject background;
    public GameObject sprite;

    void Start(){
        textToShow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (textToShow)
        {
            case 0:
                GetComponent<UnityEngine.UI.Text>().text = WelcomeText;
                sprite.SetActive(true);
                background.SetActive(true);
                gameObject.SetActive(true);
                break;
            case 1:
                GetComponent<UnityEngine.UI.Text>().text = BasicConceptText;
                break;
            case 2:
                GetComponent<UnityEngine.UI.Text>().text = BasicConceptText1;
                break;
            case 3:
                GetComponent<UnityEngine.UI.Text>().text = HUDText;
                break;
            case 4:
                GetComponent<UnityEngine.UI.Text>().text = AimText;
                break;
            case 5:
                GetComponent<UnityEngine.UI.Text>().text = MarkText;
                break;
            case 6:
                GetComponent<UnityEngine.UI.Text>().text = ShootText;
                break;
            case 7:
                sprite.SetActive(false);
                background.SetActive(false);
                gameObject.SetActive(false);
                break;

            default:
                break;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            textToShow++;
            if (textToShow > 7)
                textToShow = 0;
        }

    }
    int GetTextToShow() {
        return textToShow;
    }
}

