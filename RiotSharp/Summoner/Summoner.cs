﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a Summoner in the API.
    /// </summary>
    public class Summoner : SummonerBase
    {
        internal Summoner(string summoner, RateLimitedRequester requester, Region region)
            : base(summoner, requester, region) { }

        /// <summary>
        /// ID of the summoner icon associated with the summoner.
        /// </summary>
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        /// <summary>
        /// Date summoner was last modified.
        /// </summary>
        [JsonProperty("revisionDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime RevisionDate { get; set; }

        /// <summary>
        /// Summoner level associated with the summoner.
        /// </summary>
        [JsonProperty("summonerLevel")]
        public long Level { get; set; }
    }
}
