﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Sito.Custom
{
    public class Helper
    {
        public static string GetResponseFromUrl(string url, string[] headers, string method = "GET")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Accept = "application/json";
            headers.ToList().ForEach(header => {
                request.Headers.Add(header);
            });

            string responseString;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;
        }

        public static List<GameDetails> GetGameDetailsFromJSON(string json)
        {
            List<GameDetails> gamedetails = new List<GameDetails>();
            JArray jarray = JArray.Parse(json);
            foreach (JObject je in jarray)
            {
                string name = (string)je.GetValue("name");
                int id = (int)je.GetValue("id");
                double rating = (double)je.GetValue("rating");
                gamedetails.Add(new GameDetails { id = id, name = name, rating = rating });
            }
            return gamedetails;
        }
    }
}