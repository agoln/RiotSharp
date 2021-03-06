﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace RiotSharpTest
{
    [TestClass]
    public class SummonerTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        private static RiotApi api = RiotApi.GetInstance(apiKey, false);
        private static Summoner summoner = api.GetSummoner(Region.euw, id);

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRunePages_Test()
        {
            var runePages = summoner.GetRunePages();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRunePagesAsync_Test()
        {
            var runePages = summoner.GetRunePagesAsync();

            Assert.IsNotNull(runePages.Result);
            Assert.IsTrue(runePages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetRunePagesV12_Test()
        {
            var runePages = summoner.GetRunePagesV12();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetRunePagesV12Async_Test()
        {
            var runePages = summoner.GetRunePagesV12Async();

            Assert.IsNotNull(runePages.Result);
            Assert.IsTrue(runePages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetRunePagesV11_Test()
        {
            var runePages = summoner.GetRunePagesV11();

            Assert.IsNotNull(runePages);
            Assert.IsTrue(runePages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetRunePagesV11Async_Test()
        {
            var runePages = summoner.GetRunePagesV11Async();

            Assert.IsNotNull(runePages.Result);
            Assert.IsTrue(runePages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetMasteryPages_Test()
        {
            var masteryPages = summoner.GetMasteryPages();

            Assert.IsNotNull(masteryPages);
            Assert.IsTrue(masteryPages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetMasteryPagesAsync_Test()
        {
            var masteryPages = summoner.GetMasteryPagesAsync();

            Assert.IsNotNull(masteryPages.Result);
            Assert.IsTrue(masteryPages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetMasteryPagesV12_Test()
        {
            var masteryPages = summoner.GetMasteryPagesV12();

            Assert.IsNotNull(masteryPages);
            Assert.IsTrue(masteryPages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetMasteryPagesV12Async_Test()
        {
            var masteryPages = summoner.GetMasteryPagesV12Async();

            Assert.IsNotNull(masteryPages.Result);
            Assert.IsTrue(masteryPages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetMasteryPagesV11_Test()
        {
            var masteryPages = summoner.GetMasteryPagesV11();

            Assert.IsNotNull(masteryPages);
            Assert.IsTrue(masteryPages.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetMasteryPagesV11Async_Test()
        {
            var masteryPages = summoner.GetMasteryPagesV11Async();

            Assert.IsNotNull(masteryPages.Result);
            Assert.IsTrue(masteryPages.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetRecentGames_Test()
        {
            var games = summoner.GetRecentGames();

            Assert.IsNotNull(games);
            Assert.IsTrue(games.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetRecentGamesAsync_Test()
        {
            var games = summoner.GetRecentGamesAsync();

            Assert.IsNotNull(games.Result);
            Assert.IsTrue(games.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetRecentGamesV12_Test()
        {
            var recentGames = summoner.GetRecentGamesV12();

            Assert.IsNotNull(recentGames);
            Assert.IsTrue(recentGames.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetRecentGamesV12Async_Test()
        {
            var recentGames = summoner.GetRecentGamesV12Async();

            Assert.IsNotNull(recentGames.Result);
            Assert.IsTrue(recentGames.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetRecentGamesV11_Test()
        {
            var recentGames = summoner.GetRecentGamesV11();

            Assert.IsNotNull(recentGames);
            Assert.IsTrue(recentGames.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetRecentGamesV11Async_Test()
        {
            var recentGames = summoner.GetRecentGamesV11Async();

            Assert.IsNotNull(recentGames.Result);
            Assert.IsTrue(recentGames.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetLeagues_Test()
        {
            var leagues = summoner.GetLeagues();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetLeaguesAsync_Test()
        {
            var leagues = summoner.GetLeaguesAsync();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetEntireLeagues_Test()
        {
            var leagues = summoner.GetEntireLeagues();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetEntireLeaguesAsync_Test()
        {
            var leagues = summoner.GetEntireLeaguesAsync();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV22_Test()
        {
            var leagues = summoner.GetEntireLeaguesV22();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV22Async_Test()
        {
            var leagues = summoner.GetEntireLeaguesV22Async();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV21_Test()
        {
            var leagues = summoner.GetEntireLeaguesV21();

            Assert.IsNotNull(leagues);
            Assert.IsTrue(leagues.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetEntireLeaguesV21Async_Test()
        {
            var leagues = summoner.GetEntireLeaguesV21Async();

            Assert.IsNotNull(leagues.Result);
            Assert.IsTrue(leagues.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsSummaries_Test()
        {
            var stats = summoner.GetStatsSummaries(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsSummariesAsync_Test()
        {
            var stats = summoner.GetStatsSummariesAsync(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetStatsSummariesV11_Test()
        {
            var stats = summoner.GetStatsSummariesV11(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetStatsSummariesV11Async_Test()
        {
            var stats = summoner.GetStatsSummariesV11Async(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetStatsRanked_Test()
        {
            var stats = summoner.GetStatsRanked(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetStatsRankedAsync_Test()
        {
            var stats = summoner.GetStatsRankedAsync(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsTrue(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Deprecated")]
        public void GetStatsRankedV11_Test()
        {
            var stats = summoner.GetStatsRankedV11(Season.Season3);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async"), TestCategory("Deprecated")]
        public void GetStatsRankedV11Async_Test()
        {
            var stats = summoner.GetStatsRankedV11Async(Season.Season3);

            Assert.IsNotNull(stats.Result);
            Assert.IsNotNull(stats.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner")]
        public void GetTeams_Test()
        {
            var teams = summoner.GetTeams();

            Assert.IsNotNull(teams);
            Assert.IsTrue(teams.Count() > 0);
        }

        [TestMethod]
        [TestCategory("Summoner"), TestCategory("Async")]
        public void GetTeamsAsync_Test()
        {
            var teams = summoner.GetTeamsAsync();

            Assert.IsNotNull(teams.Result);
            Assert.IsTrue(teams.Result.Count() > 0);
        }
    }
}
