using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TachometerNeedle : MonoBehaviour
{
    // Start is called before the first frame update
   /* void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */

    private const float MAX_POWER_ANGLE = -128;
    private const float ZERO_POWER_ANGLE = 104;

    private const float MAX_SPEED_ANGLE = -129;
    private const float ZERO_SPEED_ANGLE = 107;

    private Transform tachometerNeedleTransform;
    private Transform powerLabelTemplateTransform;

    private Transform speedometerNeedleTransform;
    private Transform speedLabelTemplateTransform;


    private float powerMax;
    private float power;

    private float speedMax;
    private float speed;

    public Text tachoText;
    bool spacePressed2=false;

    private void Awake()
    {
        tachometerNeedleTransform = transform.Find("Tachometer Needle");

        power = 0f;
        powerMax = 8f;

        speed = 0f;
        speedMax = 240f;

        //peedometerNeedleTransform = transform.Find("Speedometer Needle");
        //speedLabelTemplateTransform = transform.Find("speedLabelTemplate");
        //speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;
        speedMax = 240f;
    }

    private void Update()
    {
        handlePlayerInput();
        
        // power += 30f * Time.deltaTime;
        // if (power > powerMax)
        // {
        //     power = powerMax;
        // }
        if(!spacePressed2)
{
        tachometerNeedleTransform.eulerAngles = new Vector3(0, 0, GetTachometerRotation());
        //speedometerNeedleTransform.eulerAngles = new Vector3(0, 0, GetSpeedometerRotation());

        int tachoint = (int) power;
        tachoText.text = tachoint.ToString() + " RPM";
    }
        
    }

private bool state =true;
private void handlePlayerInput()
    {
           if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log(speed);
            // float acceleration = 0f;
            // float deceleration = 0f;
            // speed += acceleration - deceleration * Time.deltaTime;
            spacePressed2 = !spacePressed2;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
           
            if(power<7 && state)
            {
                float incPower = 3f;
                power += incPower * Time.deltaTime;
            
            }
            else
            {
                
                state=false;
                float decPower = 2f;
                power -= decPower * Time.deltaTime;
                if(power<=2)
                    state=true;
                
            }
            

        }

    
        else
        {
            if (!spacePressed2){
            
            float decPower = 1f;
            if(power>=1)
            power -= decPower * Time.deltaTime;
            }
            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            float brakeDecPower = 3f;
            power -= brakeDecPower * Time.deltaTime;
        }

        power = Mathf.Clamp(power, 0f, powerMax);


        if (Input.GetKey(KeyCode.UpArrow))
        {
            float acceleration = 50f;
            speed += acceleration * Time.deltaTime;
        }
        else
        {
             if (!spacePressed2){
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
        power = Mathf.Clamp(power, 0f, powerMax);


        if (speed == 0f)
        {
            power = 0f;
        }
    }

    private float GetTachometerRotation()
    {
        float totalAngleSize = ZERO_POWER_ANGLE - MAX_POWER_ANGLE;

        float powerNormalized = power / powerMax;

        return ZERO_POWER_ANGLE - powerNormalized * totalAngleSize;
    }

    private float GetSpeedometerRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
    
}
