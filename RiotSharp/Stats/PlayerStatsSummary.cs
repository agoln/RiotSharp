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
    /// Stats summary of a player (Stats API).
    /// </summary>
    public class PlayerStatsSummary : Thing
    {
        public PlayerStatsSummary() { }

        public PlayerStatsSummary(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        /// <summary>
        /// Aggregated stats.
        /// </summary>
        [JsonProperty("aggregatedStats")]
        public AggregatedStat AggregatedStats { get; set; }

        /// <summary>
        /// Number of losses for this queue type. Returned for ranked queue types only.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Date stats were last modified specified as epoch milliseconds.
        /// </summary>
        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Player stats summary type.
        /// </summary>
        [JsonProperty("playerStatSummaryType")]
        [JsonConverter(typeof(PlayerStatsSummaryTypeConverter))]
        public PlayerStatsSummaryType PlayerStatSummaryType { get; set; }

        /// <summary>
        /// Number of wins for this queue type.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
