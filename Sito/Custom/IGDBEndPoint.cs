using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sito.Custom
{
    public class IGDBEndPoint : IIgdb
    {

        private const string URL_API = "https://api-v3.igdb.com";
        private const string USER_KEY = "4aa74ccdaef43e0c08af80501237ca27";

        private static IGDBEndPoint instance = null;

        private IGDBEndPoint() { }

        public static IGDBEndPoint GetInstance()
        {
            return (instance == null ? new IGDBEndPoint() : instance);
        }

        public List<GameDetails> getBest10Games()
        {
            return Helper.GetGameDetailsFromJSON(
                Helper.GetResponseFromUrl(
                    url: URL_API + "/games/?fields=name,rating&filter[rating][gte]=1&order=rating:desc",
                    method: "POST",
                    headers: new[] { "user-key: " + USER_KEY }
                )
            );
        }

        public List<GameDetails> getWorst10Games()
        {
            return Helper.GetGameDetailsFromJSON(
                Helper.GetResponseFromUrl(
                    url: URL_API + "/games/?fields=name,rating&order=rating:asc",
                    method: "POST",
                    headers: new[] { "user-key: " + USER_KEY }
                )
            );
        }
        

    }
}