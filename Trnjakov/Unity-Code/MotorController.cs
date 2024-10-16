using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 /*public enum AXIS{
    AXIS_ONE,
    AXIS_TWO,
    AXIS_THREE,
    AXIS_FOUR,
    AXIS_FIVE,
    AXIS_SIX };*/


public class MotorController : MonoBehaviour
{
    const int motor_count = 6;

    public Stepper[] _stepper = new Stepper[motor_count];
    
    public Transform[] motorTransform = new Transform[motor_count];

    float newPos = 0;

    public float[] angle = new float[motor_count];
    public float timeRemaining;
    public float path;
    public float time;
    public float[] _dps = new float[motor_count];

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < _stepper.Length; i++)
        {
            _stepper[i].transform = motorTransform[i];
        }

        timeRemaining = time;

        _dps = Calc_Speeds(angle);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            RotateMotors(_dps);
            timeRemaining -= Time.deltaTime;
        }
    }

    public float[] Calc_Speeds(float[] paths)
    {
        float[] speed = new float[motor_count];

        for (int i = 0;  i< motor_count; i++)
            speed[i] = paths[i] / time;

        return speed;
    }

    public void RotateMotors(float[] speed)
    {
        Vector3 rotationToAdd = new Vector3(0, 0, 0);

        for (int i = 0; i < motor_count; i++)
        {
            rotationToAdd = new Vector3(0, 0, 0);
            switch (i)
            {
                case (int)AXIS.AXIS_ONE:
                    rotationToAdd.z = speed[i] * Time.deltaTime;
                    _stepper[i].transform.Rotate(rotationToAdd);
                    break;

                case (int)AXIS.AXIS_TWO:
                    rotationToAdd.z = speed[i] * Time.deltaTime;
                    _stepper[i].transform.Rotate(rotationToAdd);
                    break;

                case (int)AXIS.AXIS_THREE:
                    rotationToAdd.y = speed[i] * Time.deltaTime;
                    _stepper[i].transform.Rotate(rotationToAdd);
                    break;

                case (int)AXIS.AXIS_FOUR:
                    rotationToAdd.y = speed[i] * Time.deltaTime;
                    _stepper[i].transform.Rotate(rotationToAdd);
                    break;

                case (int)AXIS.AXIS_FIVE:
                    rotationToAdd.y = speed[i] * Time.deltaTime;
                    _stepper[i].transform.Rotate(rotationToAdd);
                    break;

                case (int)AXIS.AXIS_SIX:
                    rotationToAdd.x = speed[i] * Time.deltaTime;
                    _stepper[i].transform.Rotate(rotationToAdd);
                    break;

            }

        }        
    }


    public struct Stepper {

        public Transform transform;
        public float toNull;
    }

    public enum AXIS : int
    {
        AXIS_ONE,
        AXIS_TWO,
        AXIS_THREE,
        AXIS_FOUR,
        AXIS_FIVE,
        AXIS_SIX
    }
}
