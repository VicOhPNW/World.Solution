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
        private List<City> _city;

        public City(string CityName, int Id=0)
        {
            _id = Id;
            _cityName = CityName;
        }

        public int GetId() => _id;
        public void SetID(int Id) => _id = Id;

        public string GetCityName() => _cityName;
        public void SetCityName() => _cityName = CityName;

        public static List<City> GetAll()
        {
            List<City> allCities = new List<City>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;"
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int cityId = rdr.GetInt32(0);
                string cityName = rdr.GetString(1);
                City newCity = new City(cityName, cityId);
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