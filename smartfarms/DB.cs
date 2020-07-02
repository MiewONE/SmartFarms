using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace smartfarms
{
    class DB
    {
        private static DB _instance;
        public static DB Instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance = new DB();
                }
                return _instance;
            }
        }
        static public MySqlConnection con = null;
        static public MySqlCommand cmd = null;
        string db_ip =
        public DB()
        {
        }
        public DB(string _para_db_ip, string _para_db_id, string _para_db_pwd, string _para_db_port)
        {
            this.db_ip = _para_db_ip;
            this.db_id = _para_db_id;
            this.db_pwd = _para_db_pwd;
            this.db_port = _para_db_port;
        }
        public bool DBcon()
        {
            try
            {
                string conString = string.Format($"SERVER={db_ip};user={db_id};password={db_pwd};port={db_port};");
                con = new MySqlConnection(conString);
                con.Open();
                return con.State == System.Data.ConnectionState.Open;
            }
            catch
            {
                return false;
            }
            
        }
        static public void query_execute(string _para_query)
        {
            Con_Open();
            cmd = new MySqlCommand(_para_query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static private void Con_Open()
        {
            if (con != null && con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void query_execute(string _para_query, string mode)
        {
            Con_Open();
            switch (mode)
            {
                case "select":
                    cmd = new MySqlCommand(_para_query, con);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    //System.Windows.Forms.MessageBox.Show(rd.Read().ToString());
                    if (rd.Read())
                    {
                        variable.Instance.runTimeHH = (int?)rd["runTimeHH"] ?? 0;
                        variable.Instance.runTimeMM = (int?)rd["runTimeMM"] ?? 0;
                        variable.Instance.runTimeSS = (int?)rd["runTimeSS"] ?? 0;
                        variable.Instance.stoptimeHH = (int?)rd["stoptimeHH"] ?? 0;
                        variable.Instance.stoptimeMM = (int?)rd["stoptimeMM"] ?? 0;
                        variable.Instance.stoptimeSS = (int?)rd["stoptimeSS"] ?? 0;
                        variable.Instance.auto_TempLOW = (int?)rd["auto_TempLOW"] ?? 0;
                        variable.Instance.auto_TempHIGH = (int?)rd["auto_TempHIGH"] ?? 0;
                        variable.Instance.auto_HumLOW = (int?)rd["auto_HumLOW"] ?? 0;
                        variable.Instance.auto_HumHIGH = (int?)rd["auto_HumHIGH"] ?? 0;
                        variable.Instance.save_period = (int?)rd["save_period"] ?? 0;
                        if (variable.Instance.save_period == 0 || variable.Instance.save_period == null)
                        {
                            variable.Instance.save_period = 1000;
                        }
                        variable.Instance.Pump_period = (int?)rd["PumP_period"] ?? 0;

                        variable.Instance.avg_tmp = (int)((variable.Instance.auto_TempHIGH + variable.Instance.auto_TempLOW) / 2);
                        variable.Instance.avg_hum = (int)((variable.Instance.auto_HumHIGH + variable.Instance.auto_HumLOW) / 2);
                    }
                    else
                    {
                        variable.Instance.runTimeHH = 00;
                        variable.Instance.runTimeMM = 00;
                        variable.Instance.runTimeSS = 00;
                        variable.Instance.stoptimeHH = 00;
                        variable.Instance.stoptimeMM = 00;
                        variable.Instance.stoptimeSS = 00;
                        variable.Instance.auto_TempLOW = 00;
                        variable.Instance.auto_TempHIGH = 00;
                        variable.Instance.auto_HumLOW = 00;
                        variable.Instance.auto_HumHIGH = 00;
                        variable.Instance.save_period = 1000;
                        variable.Instance.Pump_period = 00;
                    }
                    break;
                case "insert":
                    cmd = new MySqlCommand(_para_query, con);
                    cmd.ExecuteNonQuery();
                    break;
                default:
                    break;
            }
            con.Close();
        }
        public void DBorTable_Create()
        {
            //server=localhost;user=root;port=3306;password=mysql

            try
            {
                Con_Open();
                //query_execute("show databases'", con);
                query_execute("create database if not exists `smartfarm`;");
                query_execute("use smartfarm;");
                query_execute("create table if not exists save_state (" +
                    "temperature int," +
                    "humidity int," +
                    "Fan bool," +
                    "Pump bool," +
                    "Datetimes varchar(50)"+
                    ");"); 
                query_execute("create table if not exists setting (" +
                    "runtimeHH int," +
                    "runtimeMM int," +
                    "runtimeSS int," +
                    "stoptimeHH int," +
                    "stoptimeMM int," +
                    "stoptimeSS int," +
                    "auto_TempLOW int," +
                    "auto_TempHIGH int," +
                    "auto_HumLOW int," +
                    "auto_HumHIGH int," +
                    "save_period int," +
                    "PumP_period int);");
                #region 디비주석
                //query = "create database if not exists `smartfarm`;";
                //cmd = new MySqlCommand(query, con);
                //cmd.ExecuteNonQuery();
                //query = "create table if not exists save_state (" +
                //    "temperature int," +
                //    "humidity int," +
                //    "Fan bool," +
                //    "Pump bool);";
                //cmd.ExecuteNonQuery();
                //query = "create table if not exists setting (" +
                //    "runtimeHH int," +
                //    "runtimeMM int," +
                //    "runtimeSS int," +
                //    "stoptimeHH int," +
                //    "stoptimeMM int," +
                //    "stoptimeSS int," +
                //    "auto_TempLOW int," +
                //    "auto_TempHIGH int," +
                //    "auto_HumLOW int," +
                //    "auto_HumHIGH int," +
                //    "save_period int," +
                //    "PumP_period int);";
                #endregion
                //cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                if (con != null && con.State == System.Data.ConnectionState.Closed)
                {
                    System.Windows.Forms.MessageBox.Show("데이터베이스 연결에 실패하였습니다.");
                }
                System.Windows.Forms.MessageBox.Show(e.StackTrace);
                con.Close();
            }
        }
        void save_state()
        {

        }
    }
}
