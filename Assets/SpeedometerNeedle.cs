using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerNeedle : MonoBehaviour
{
    // Start is called before the first frame update
   /* void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */

    private const float MAX_SPEED_ANGLE = -129;
    private const float ZERO_SPEED_ANGLE = 107;

    private Transform speedometerNeedleTransform;
    private Transform speedLabelTemplateTransform;

    private float speedMax;
    private float speed;

    public Text speedText;
    bool spacePressed = false;

    private void Awake()
    {
        speedometerNeedleTransform = transform.Find("Speedometer Needle");
        //speedLabelTemplateTransform = transform.Find("speedLabelTemplate");
        //speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;
        speedMax = 240f;

        //CreateSpeedLabels();
    }

    private void Update()
    {
        
        // speed += 30f * Time.deltaTime;
        // if (speed > speedMax)
        // {
        //     speed = speedMax;
        // }

    
        handlePlayerInput();
if (!spacePressed)
        {
            speedometerNeedleTransform.eulerAngles = new Vector3(0, 0, GetSpeedometerRotation());
            int speedint = (int) speed;
            speedText.text = speedint.ToString() + " MPH";
         }
    }

    private void handlePlayerInput()
    {
           if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log(speed);
            // float acceleration = 0f;
            // float deceleration = 0f;
            // speed += acceleration - deceleration * Time.deltaTime;
            spacePressed = !spacePressed;
        }
       
        
        Debug.Log(spacePressed);
       
            if (Input.GetKey(KeyCode.UpArrow))
            {
                float acceleration = 50f;
                speed += acceleration * Time.deltaTime;
            }

            else  
        
            {
                if (!spacePressed){
 float deceleration = 20f;
                speed -= deceleration * Time.deltaTime;
                }
               
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                float brakeSpeed = 100f;
                speed -= brakeSpeed * Time.deltaTime;
            }

        

     

        speed = Mathf.Clamp(speed, 0f, speedMax);
    }

    // private void CreateSpeedLabels()
    // {
    //     int labelAmount = 13;
    //     float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

    //     for (int i = 0; i <= labelAmount; i++)
    //     {
    //         Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
    //         float labelSpeedNormalized = (float)i / labelAmount;
    //         float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
    //         speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
    //         speedLabelTransform.Find("speedText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();

    //     }
    // }

    private float GetSpeedometerRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }


}
