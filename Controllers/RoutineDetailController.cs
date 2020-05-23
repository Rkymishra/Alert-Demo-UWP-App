using Alert.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alert.Controllers
{
    class RoutineDetailController
    {
        private static string connectionString = ConnectionManager.ConnectionString;
        public static ObservableCollection<RoutineDetail> GetRoutines()
        {
            const string GetProductsQuery = "select * from RoutineDetail";
            var routines = new ObservableCollection<RoutineDetail>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var routine = new RoutineDetail
                                    {
                                        RoutineId = reader.GetInt32(0),
                                        RoutineTitle = reader.GetString(1),
                                        RoutineScheduledFor = reader.GetDateTime(2),
                                        RoutineScheduleTime = reader.GetDateTime(2).ToString("h:mm tt")
                                    };
                                    routines.Add(routine);
                                }
                            }
                        }
                    }
                }
                return routines;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
        public static RoutineDetail GetSelectedRoutine(int SelectedRoutineId)
        {
            const string GetProductsQuery = "select * from RoutineDetail where RoutineId = @RoutineId";
            try
            {
                var routine = new RoutineDetail();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            cmd.Parameters.AddWithValue("@RoutineId", SqlDbType.Int).Value = SelectedRoutineId;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    routine.RoutineId = reader.GetInt32(0);
                                    routine.RoutineTitle = reader.GetString(1);
                                    routine.RoutineScheduledFor = reader.GetDateTime(2);
                                    routine.RoutineScheduleTime = reader.GetDateTime(2).ToString("h:mm tt");
                                }
                            }
                        }
                    }
                }
                return routine;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
        public bool InsertNewRoutine(RoutineDetail routineDetail)
        {
            string GetProductsQuery = string.Format(@"insert into RoutineDetail values (@RoutineTitle,@RoutineTime)");
            try
            {
                var routine = new RoutineDetail();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            cmd.Parameters.AddWithValue("@RoutineTitle", SqlDbType.VarChar).Value = routineDetail.RoutineTitle;
                            cmd.Parameters.AddWithValue("@RoutineTime", SqlDbType.DateTime).Value = routineDetail.RoutineScheduleTime;
                            return cmd.ExecuteNonQuery() > 0;
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return false;
        } 
    }
}
