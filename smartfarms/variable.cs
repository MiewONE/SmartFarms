using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartfarms
{
    class variable
    {
        private static variable _instance;
        public static variable Instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance = new variable();
                }
                return _instance;
            }
        }
        public int? runTimeHH = 0;
        public int? runTimeMM = 0;
        public int? runTimeSS = 0;
        public int? stoptimeHH = 0;
        public int? stoptimeMM = 0;
        public int? stoptimeSS = 0;
        public int? auto_TempLOW = 0;
        public int? auto_TempHIGH = 0;
        public int? auto_HumLOW = 0;
        public int? auto_HumHIGH = 0;
        public int? save_period = 1000;
        public int? Pump_period = 0;

    //현재 자동,수동 구분
        public int Mode = 0; // 수동 0, 자동 1

    //운전 시작,정지 상황
        public bool temp = false;
        public bool humin = false;
        public bool pump = false;
        public bool light = false;
        public bool fan = false;

    //설정에서 지정된 온도의 평균값
        public double avg_tmp = (int)((variable._instance.auto_TempHIGH + variable._instance.auto_TempLOW) / 2);
        public double avg_hum = (int)((variable._instance.auto_HumHIGH + variable._instance.auto_HumLOW) / 2);


        //데이터 저장 주기
        public int set_savetime = 1000; //단위 ms
    }
}
