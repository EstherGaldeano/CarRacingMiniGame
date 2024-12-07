using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private float h;
        private float v;
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            if (m_Car.enabled)
            {
                if (this.gameObject.tag == "Player")
                {
                    h = CrossPlatformInputManager.GetAxis("Horizontal");
                    v = CrossPlatformInputManager.GetAxis("Vertical");
                }
                else if (this.gameObject.tag == "SecondCar")
                {
                    h = CrossPlatformInputManager.GetAxis("HorizontalSecondCar");
                    v = CrossPlatformInputManager.GetAxis("VerticalSecondCar");
                }
                else if (this.gameObject.tag == "ThirdCar")
                {
                    h = CrossPlatformInputManager.GetAxis("HorizontalThirdCar");
                    v = CrossPlatformInputManager.GetAxis("VerticalThirdCar");
                }
                else if (this.gameObject.tag == "FourthCar")
                {
                    h = CrossPlatformInputManager.GetAxis("HorizontalFourthCar");
                    v = CrossPlatformInputManager.GetAxis("VerticalFourthCar");
                }

                // pass the input to the car!

#if !MOBILE_INPUT
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
#else
                m_Car.Move(h, v, v, 0f);
#endif
            }            
        }
    }
}
