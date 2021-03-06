﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace RiotSharp
{
    /// <summary>
    /// Page of runes (Summoner API).
    /// </summary>
    public class RunePage : Thing
    {
        public RunePage(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        /// <summary>
        /// Indicates if the page is the current page.
        /// </summary>
        [JsonProperty("current")]
        public bool Current { get; set; }

        /// <summary>
        /// Rune page ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Rune page name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of rune slots associated with the rune page.
        /// </summary>
        [JsonProperty("slots")]
        public List<RuneSlot> Slots { get; set; }
    }
}
