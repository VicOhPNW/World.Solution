using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;
using System;

namespace World.Models
{
    public class City
    {
        private int _id;
        private string _cityName;

        public City(int id, string cityName)
        {
            _id = id;
            _cityName = cityName;
        }

        public int GetId()
        {
            return _id;
        }
        public void SetId(int Id)
        {
            _id = Id;
        }

        public string GetCityName()
        {
            return _cityName;
        }
        public void SetCityName(string cityName)
        {
            _cityName = cityName;
        }


        public static List<City> GetAll()
        {
            List<City> allCities = new List<City>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int cityId = rdr.GetInt32(0);
                string cityName = rdr.GetString(1);
                City newCity = new City(cityId, cityName);
                allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
        }
    }
}