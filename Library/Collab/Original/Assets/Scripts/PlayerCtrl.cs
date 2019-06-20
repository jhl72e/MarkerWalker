using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float armSwingSpeed;
    public Transform rightArm, leftArm;

    void Update()
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
            if(rightArm.rotation.z > 125f)
            {
                rightArm.rotation = Quaternion.Euler(0f, 0f, 125f);
            }
        }
        else
        {
            rightArm.Rotate(new Vector3(0f, 0f, -armSwingSpeed) * Time.deltaTime);
            if (rightArm.rotation.z < 20f)
            {
                rightArm.rotation = Quaternion.Euler(0f, 0f, 20f);
            }
        }
    }



    void LeftArmSwing(bool isUp)
    {
        if (isUp)
        {
            leftArm.Rotate(new Vector3(0f, 0f, -armSwingSpeed) * Time.deltaTime);
            if (leftArm.rotation.z > -20f)
            {
                leftArm.rotation = Quaternion.Euler(0f, 0f, -20f);
            }
        }
        else
        {
            leftArm.Rotate(new Vector3(0f, 0f, armSwingSpeed) * Time.deltaTime);
            if (leftArm.rotation.z < -125f)
            {
                leftArm.rotation = Quaternion.Euler(0f, 0f, -125f);
            }
        }
    }

}
