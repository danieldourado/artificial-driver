using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private List<CarFrameMoveInfo> m_CarFrameMoveInfos;
        private CarFrameMoveInfo m_CurrentFrameMoveInfo;
        public Vector3 CurrentFrameMoveInfo;
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            m_CarFrameMoveInfos = new List<CarFrameMoveInfo>();
            m_CarFrameMoveInfos.Add(new CarFrameMoveInfo());

        }

        private void FixedUpdate()
        {
            m_CurrentFrameMoveInfo = new CarFrameMoveInfo();
            m_CurrentFrameMoveInfo.AddFrameMoveInfo(m_CarFrameMoveInfos[m_CarFrameMoveInfos.Count - 1]);
            m_CarFrameMoveInfos.Add(m_CurrentFrameMoveInfo);
            
            m_Car.Move(m_CurrentFrameMoveInfo.h, m_CurrentFrameMoveInfo.v, m_CurrentFrameMoveInfo.v, 0);
            SetCurrentFrameMoveInfo(m_CurrentFrameMoveInfo);
        }

        private void SetCurrentFrameMoveInfo(CarFrameMoveInfo carFrameMoveInfo)
        {
            CurrentFrameMoveInfo = new Vector3(carFrameMoveInfo.h, carFrameMoveInfo.v, carFrameMoveInfo.handbrake);
        }
    }

    public class CarFrameMoveInfo
    {
        private float m_MinClamp = -1f;
        private float m_MaxClamp = 1f;

        public float randomFactor = 0.1f;

        public float h;
        public float v;
        public float handbrake;

        public CarFrameMoveInfo()
        {
            SetRandomFrameMoveInfo();
        }

        public void SetRandomFrameMoveInfo() 
        {
            h = UnityEngine.Random.Range(-randomFactor, randomFactor);
            v = UnityEngine.Random.Range(-randomFactor, randomFactor);
            handbrake = UnityEngine.Random.Range(-randomFactor, randomFactor);
        }

        public void AddFrameMoveInfo(CarFrameMoveInfo carFrameMoveInfo)
        {
            this.h += carFrameMoveInfo.h;
            this.v += carFrameMoveInfo.v;
            this.handbrake += carFrameMoveInfo.handbrake;

            this.h = Mathf.Clamp(this.h, m_MinClamp, m_MaxClamp);
            this.v = Mathf.Clamp(this.v, m_MinClamp, m_MaxClamp);
            this.handbrake = Mathf.Clamp(this.handbrake, m_MinClamp, m_MaxClamp);
        }

    }
}
