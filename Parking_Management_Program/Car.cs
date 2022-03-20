﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Management_Program
{
    [Serializable]
    public abstract class Car
    {

        protected string carNum;
        protected DateTime enterTime;
        protected DateTime exitTime;
        #region 추가
        protected long fee;
        protected long feePerHour;
        //private Utils utils;
        #endregion

        #region property
        public string CarNum { get { return carNum; } set { carNum = value; } }
        public DateTime EnterTime { get { return enterTime; } set { enterTime = value; } }
        public DateTime ExitTime { get { return exitTime; } set { exitTime = value; } }
        public long Fee { get { return fee; } set { fee = value; } }
        #endregion

        public Car(string carNum, DateTime enterTime)
        {
            this.carNum = carNum;
            this.enterTime = enterTime;
        }
        #region

        public TimeSpan GetParkingTime()
        {
            TimeSpan time = exitTime.Subtract(enterTime);
            return time;
        }

        public long GetFee()
        {
            TimeSpan parkingTime = GetParkingTime();
            long fee = (parkingTime.Hours + 1) * feePerHour;
            return fee;
        }

        #endregion
    }

    [Serializable]
    public class CompactCar : Car
    {
        public CompactCar(string carNum, DateTime enterTime) : base(carNum, enterTime)
        {
            this.feePerHour = 2000;
        }

        public override string ToString()
        {
            return $"차량번호 : {carNum} | 차종 : 소형 | 입차시간 : {enterTime} | 출차시간 : {exitTime} | 요금 : {fee}원";
        }
    }

    [Serializable]
    public class MidsizedCar : Car
    {
        public MidsizedCar(string carNum, DateTime enterTime) : base(carNum, enterTime)
        {
            this.feePerHour = 2500;
        }

        public override string ToString()
        {
            return $"차량번호 : {carNum} | 차종 : 중형 | 입차시간 : {enterTime} | 출차시간 : {exitTime} | 요금 : {fee}원";
        }

    }

    [Serializable]
    public class FullsizedCar : Car
    {
        public FullsizedCar(string carNum, DateTime enterTime) : base(carNum, enterTime)
        {
            this.feePerHour = 3000;
        }

        public override string ToString()
        {
            return $"차량번호 : {carNum} | 차종 : 대형 | 입차시간 : {enterTime} | 출차시간 : {exitTime} | 요금 : {fee}원";
        }

    }
}
