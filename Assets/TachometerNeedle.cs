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

    private void Awake()
    {
        tachometerNeedleTransform = transform.Find("Tachometer Needle");

        power = 0f;
        powerMax = 8f;

        speed = 0f;
        speedMax = 240f;

        speedometerNeedleTransform = transform.Find("Speedometer Needle");
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

        tachometerNeedleTransform.eulerAngles = new Vector3(0, 0, GetTachometerRotation());
        speedometerNeedleTransform.eulerAngles = new Vector3(0, 0, GetSpeedometerRotation());

        int tachoint = (int) power;
        tachoText.text = tachoint.ToString() + " RPM";
    }


private void handlePlayerInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float incPower = 3f;
            power += incPower * Time.deltaTime;
        }
        else
        {
            float decPower = 1f;
            power -= decPower * Time.deltaTime;
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
            float deceleration = 20f;
            speed -= deceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            float brakeSpeed = 100f;
            speed -= brakeSpeed * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, 0f, speedMax);


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
