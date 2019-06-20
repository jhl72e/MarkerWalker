using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float armSwingSpeed;
    public Transform rightArm, leftArm;

    public float legFoldSpeed;
    public Transform rightLeg_1, rightLeg_2;
    public Transform leftLeg_1, leftLeg_2;

    private float rightLegCurrentAngle, leftLegCurrentAngle;
    private bool isRightLegFold, isLeftLegFold;

    void Start()
    {
        rightLegCurrentAngle = leftLegCurrentAngle = 20;
        isRightLegFold = isLeftLegFold = false;
    }

    void Update()
    {
        ExcuteArmSwing();
        ExcuteLegFold();
    }

    void ExcuteArmSwing()
    {
        if (Input.GetKey(KeyCode.O))
        {
            RightArmSwing(true);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            RightArmSwing(false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            LeftArmSwing(true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            LeftArmSwing(false);
        }
    }
    
    void RightArmSwing(bool isUp)
    {
        if (isUp)
        {
            rightArm.Rotate(new Vector3(0f, 0f, armSwingSpeed) * Time.deltaTime);
            if(rightArm.localEulerAngles.z > 125f)
            {
                rightArm.localEulerAngles = new Vector3(0f, 0f, 125f);
            }
        }
        else
        {
            rightArm.Rotate(new Vector3(0f, 0f, -armSwingSpeed) * Time.deltaTime);
            if (rightArm.localEulerAngles.z < 20f)
            {
                rightArm.localEulerAngles = new Vector3(0f, 0f, 20f);
            }
        }
    }



    void LeftArmSwing(bool isUp)
    {
        if (isUp)
        {
            leftArm.Rotate(new Vector3(0f, 0f, -armSwingSpeed) * Time.deltaTime);
            if (leftArm.localEulerAngles.z < 235f)
            {
                leftArm.localEulerAngles = new Vector3(0f, 0f, 235f);
            }
        }
        else
        {
            leftArm.Rotate(new Vector3(0f, 0f, armSwingSpeed) * Time.deltaTime);
            if (leftArm.localEulerAngles.z > 340f)
            {
                leftArm.localEulerAngles = new Vector3(0f, 0f, 340f);
            }
        }
    }


    void ExcuteLegFold()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isRightLegFold = true;
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            isRightLegFold = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            isLeftLegFold = true;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            isLeftLegFold = false;
        }

        LegFold();
    }

    void LegFold()
    {
        if(isRightLegFold)
        {
            rightLegCurrentAngle += legFoldSpeed * Time.deltaTime;
            if (rightLegCurrentAngle > 100f)
            {
                rightLegCurrentAngle = 100f;
            }
        }
        else
        {
            rightLegCurrentAngle -= legFoldSpeed * Time.deltaTime;
            if (rightLegCurrentAngle < 20f)
            {
                rightLegCurrentAngle = 20f;
            }
        }
        rightLeg_1.localEulerAngles = new Vector3(0, 0, rightLegCurrentAngle);
        rightLeg_2.localEulerAngles = new Vector3(0, 0, -rightLegCurrentAngle);

        if (isLeftLegFold)
        {
            leftLegCurrentAngle += legFoldSpeed * Time.deltaTime;
            if (leftLegCurrentAngle > 100f)
            {
                leftLegCurrentAngle = 100f;
            }
        }
        else
        {
            leftLegCurrentAngle -= legFoldSpeed * Time.deltaTime;
            if (leftLegCurrentAngle < 20f)
            {
                leftLegCurrentAngle = 20f;
            }
        }
        leftLeg_1.localEulerAngles = new Vector3(0, 0, -leftLegCurrentAngle);
        leftLeg_2.localEulerAngles = new Vector3(0, 0, leftLegCurrentAngle);
    }

}