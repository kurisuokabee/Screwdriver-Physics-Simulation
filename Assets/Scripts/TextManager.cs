using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{   
    [SerializeField] Transform screwDriver;
    [SerializeField] Rigidbody rbScrewDriver;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI velocityText;
    [SerializeField] TextMeshProUGUI displacementText;
    [SerializeField] TextMeshProUGUI heightText;

    [SerializeField] GameObject resultsPanel;
    [SerializeField] TextMeshProUGUI finalTimeText;
    [SerializeField] TextMeshProUGUI finalVelocityText;
    [SerializeField] TextMeshProUGUI finalDisplacementText;
    [SerializeField] GameObject restartButton;

    float time;
    bool trigger = false;

    float finalDisplacement;

    float maxVelocityY = 0f;

    
    void Update()
    {   
        if (Time.timeScale <= 0f) return;
    
        time += Time.deltaTime;
    
        timeText.text = "TIME\n" + time.ToString("F2");
        velocityText.text = " CURRENT VELOCITY = \n" + rbScrewDriver.linearVelocity.y.ToString("F2") + "M/S";
        heightText.text = "CURRENT HEIGHT = \n" + screwDriver.position.y.ToString("F0") + " METERS";

        float currentVelocityY = Mathf.Abs(rbScrewDriver.linearVelocity.y);
        if (currentVelocityY > maxVelocityY)
            maxVelocityY = currentVelocityY;
                
        if (time <= 0.1f) return;

        if (!trigger && Mathf.Abs(rbScrewDriver.linearVelocity.y) <= 0.01f)
        {
            trigger = true;
            Time.timeScale = 0;

            resultsPanel.SetActive(true);
            restartButton.SetActive(true);
            finalTimeText.text = "Total Time the screwdriver took to fall from 45 meters = " + time.ToString("F2") + " seconds";

    
            finalVelocityText.text = "Final VELOCITY before hitting the ground = " + maxVelocityY.ToString("F2") + "M/S";
            finalDisplacementText.text = "Final DISPLACEMENT = \n" + "-" + finalDisplacement.ToString("F2") + " METERS";
        }
        else if (Mathf.Abs(rbScrewDriver.linearVelocity.y) >= 0.01f)
        {   
            finalDisplacement = .5f * 9.80665f * time * time;
            displacementText.text = "DISPLACEMENT = \n" + "-" + finalDisplacement.ToString("F2") + " METERS";
        }
    }

}
 