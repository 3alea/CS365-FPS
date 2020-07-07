using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour{
    // Start is called before the first frame update
    
    int textToShow;
    public string WelcomeText;
    public string BasicConceptText;
    public string HUDText;
    public string AimText;
    public string MarkText;
    public string ShootText;
    public GameObject background;

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
                break;
            case 1:
                GetComponent<UnityEngine.UI.Text>().text = BasicConceptText;
                break;
            case 2:
                GetComponent<UnityEngine.UI.Text>().text = HUDText;
                break;
            case 3:
                GetComponent<UnityEngine.UI.Text>().text = AimText;
                break;
            case 4:
                GetComponent<UnityEngine.UI.Text>().text = MarkText;
                break;
            case 5:
                GetComponent<UnityEngine.UI.Text>().text = ShootText;
                break;

            default:
                break;

        }

        if(textToShow == 3 && Input.GetMouseButtonDown(0)){
            background.active = false;
            gameObject.SetActive(false);
        }

        if (textToShow == 4 && Input.GetMouseButtonDown(0))        {
            background.active = false;
            gameObject.SetActive(false);
        }

        if (textToShow == 5 && Input.GetMouseButtonDown(0)){
            background.active = false;
            gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0)){
            textToShow++;   
        }

    }
    int GetTextToShow() {
        return textToShow;
    }
}

