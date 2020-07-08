using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartfarms
{
    class variable
    {
        static public int? runTimeHH = 0;
        static public int? runTimeMM = 0;
        static public int? runTimeSS = 0;
        static public int? stoptimeHH = 0;
        static public int? stoptimeMM = 0;
        static public int? stoptimeSS = 0;
        static public int? auto_TempLOW = 0;
        static public int? auto_TempHIGH = 0;
        static public int? auto_HumLOW = 0;
        static public int? auto_HumHIGH = 0;
        static public int? save_period = 1000;
        static public int? Pump_period = 0;

        //현재 자동,수동 구분
        static public int Mode = 0; // 수동 0, 자동 1

        //운전 시작,정지 상황
        static public bool temp = false;
        static public bool humin = false;
        static public bool pump = false;
        static public bool light = false;
        static public bool fan = false;

        //설정에서 지정된 온도의 평균값
        static public double avg_tmp = (int)((auto_TempHIGH + auto_TempLOW) / 2);
        static public double avg_hum = (int)((auto_HumHIGH + auto_HumLOW) / 2);
    }
}
