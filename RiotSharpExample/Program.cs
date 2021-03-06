﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RiotSharp;

namespace RiotSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //toreplace
            var api = RiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"], false);
            var staticApi = StaticRiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);
            int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            string name = ConfigurationManager.AppSettings["Summoner1Name"];
            int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
            string name2 = ConfigurationManager.AppSettings["Summoner2Name"];

            var league = api.GetChallengerLeague(Region.euw, Queue.RankedSolo5x5);

            //var spell = staticApi.GetSummonerSpell(Region.euw, SummonerSpell.Barrier);

            //spell = staticApi.GetSummonerSpell(Region.euw, SummonerSpell.Barrier);

            //var spells = staticApi.GetSummonerSpells(Region.euw);

            //var item = staticApi.GetItems(Region.euw);

            //var items = staticApi.GetItemsAsync(Region.euw);

            //items = staticApi.GetItemsAsync(Region.euw);

            ////var champ1 = staticApi.GetChampion(Region.euw, 1, ChampionData.none);

            //var champs = staticApi.GetChampions(Region.euw);

            //var champSame = staticApi.GetChampion(Region.euw, 1);

            //var champ = staticApi.GetChampion(Region.euw, 1);

            //champs = staticApi.GetChampions(Region.euw);

            //champs = staticApi.GetChampions(Region.euw, ChampionData.blurb, Language.ko_KR);

            //var masteries = api.GetMasteryPages(Region.euw, new List<int> { id, id2 });

            //var summName = api.GetSummoner(Region.euw, name2);

            //var leagues = summName.GetLeagues();

            //var runePages = summName.GetRunePages();

            //var summNameById = api.GetSummonerName(Region.euw, id);

            //var summNamesById = api.GetSummonersNames(Region.euw, new List<int>() { id, id2 });

            //var summNames = api.GetSummoners(Region.euw, new List<string> { name, name2 });

            //var summs = api.GetSummoners(Region.euw, new List<int> { id, id2 });

            //var summ = api.GetSummoner(Region.euw, id);

            //var games = summ.GetRecentGames();

            //var team = summ.GetTeamsV21();

            //var stats = summ.GetStatsSummaries(Season.Season3);

            //foreach (var stat in stats)
            //{
            //    var aggStat = stat.AggregatedStats;
            //    Console.WriteLine(stat.Losses);
            //    Console.WriteLine(stat.Wins);
            //    Console.WriteLine(stat.ModifyDate);
            //    Console.WriteLine(stat.PlayerStatSummaryType);
            //}

            //var rankedVarus = summ.GetStatsRankedV11(Season.Season3)
            //    .Where((s) => s.Name != null && s.Name.Equals("Varus"))
            //    .FirstOrDefault();
            //Console.WriteLine(rankedVarus.Id);
            //Console.WriteLine(rankedVarus.Name);
            //if (rankedVarus.Stats != null && rankedVarus.Stats.Count > 0)
            //{
            //    foreach (var s in rankedVarus.Stats)
            //    {
            //        Console.WriteLine("    " + s.Count);
            //        Console.WriteLine("    " + s.Name);
            //        Console.WriteLine("    " + s.Id);
            //        Console.WriteLine("    " + s.Value);
            //        Console.WriteLine();
            //    }
            //}
            //Console.WriteLine();

            //var stats = summ.GetStatsSummaries(Season.Season3);
            //foreach (var stat in stats)
            //{
            //    if (stat.AggregatedStats != null && stat.AggregatedStats.Count > 0)
            //    {
            //        foreach (var aStat in stat.AggregatedStats)
            //        {
            //            Console.WriteLine("    " + aStat.Count);
            //            Console.WriteLine("    " + aStat.Id);
            //            Console.WriteLine("    " + aStat.Name);
            //            Console.WriteLine();
            //        }
            //        Console.WriteLine(stat.Losses);
            //        Console.WriteLine(stat.ModifyDate);
            //        Console.WriteLine(stat.ModifyDateString);
            //        Console.WriteLine(stat.PlayerStatSummaryType);
            //        Console.WriteLine(stat.Wins);
            //        Console.WriteLine();
            //    }
            //}

            //var leagues = summ.GetLeagues();
            //foreach (League league in leagues)
            //{
            //    Console.WriteLine(league.Name);
            //    Console.WriteLine(league.Queue);
            //    Console.WriteLine(league.Tier);
            //    foreach (LeagueItem entry in league.Entries)
            //    {
            //        Console.WriteLine("    " + entry.IsFreshBlood);
            //        Console.WriteLine("    " + entry.IsHotStreak);
            //        Console.WriteLine("    " + entry.IsInactive);
            //        Console.WriteLine("    " + entry.IsVeteran);
            //        Console.WriteLine("    " + entry.LastPlayed);
            //        Console.WriteLine("    " + entry.LeagueName);
            //        Console.WriteLine("    " + entry.LeaguePoints);
            //        if (entry.MiniSeries != null)
            //        {
            //            Console.WriteLine("        " + entry.MiniSeries.Losses);
            //            Console.Write("        ");
            //            foreach (var c in entry.MiniSeries.Progress)
            //            {
            //                Console.Write(c);
            //            }
            //            Console.WriteLine();
            //            Console.WriteLine("        " + entry.MiniSeries.Target);
            //            Console.WriteLine("        " + entry.MiniSeries.TimeLeftToPlayMillis);
            //            Console.WriteLine("        " + entry.MiniSeries.Wins);
            //        }
            //        Console.WriteLine("    " + entry.PlayerOrTeamId);
            //        Console.WriteLine("    " + entry.PlayerOrTeamName);
            //        Console.WriteLine("    " + entry.QueueType);
            //        Console.WriteLine("    " + entry.Rank);
            //        Console.WriteLine("    " + entry.Tier);
            //        Console.WriteLine("    " + entry.Wins);
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}

            //var games = summ.GetRecentGames();
            //foreach (Game game in games)
            //{
            //    Console.WriteLine(game.ChampionId);
            //    Console.WriteLine(game.CreateDate);
            //    foreach (var player in game.FellowPlayers)
            //    {
            //        Console.WriteLine("    " + player.ChampionId);
            //        Console.WriteLine("    " + player.SummonerId);
            //        Console.WriteLine("    " + player.TeamId);
            //    }
            //    Console.WriteLine(game.GameId);
            //    Console.WriteLine(game.GameMode);
            //    Console.WriteLine(game.GameType);
            //    Console.WriteLine(game.Invalid);
            //    Console.WriteLine(game.Level);
            //    Console.WriteLine(game.MapId);
            //    Console.WriteLine(game.Spell1);
            //    Console.WriteLine(game.Spell2);
            //    foreach (var stat in game.Statistics)
            //    {
            //        Console.WriteLine("    " + stat.Id);
            //        Console.WriteLine("    " + stat.Name);
            //        Console.WriteLine("    " + stat.Value);
            //    }
            //    Console.WriteLine(game.SubType);
            //    Console.WriteLine(game.TeamId);
            //    Console.WriteLine();
            //}

            //var champs = api.GetChampions(Region.euw);
            //foreach (Champion champ in champs)
            //{
            //    Console.WriteLine(champ.Active);
            //    Console.WriteLine(champ.AttackRank);
            //    Console.WriteLine(champ.BotEnabled);
            //    Console.WriteLine(champ.BotMmEnabled);
            //    Console.WriteLine(champ.DefenseRank);
            //    Console.WriteLine(champ.DifficultyRank);
            //    Console.WriteLine(champ.FreeToPlay);
            //    Console.WriteLine(champ.Id);
            //    Console.WriteLine(champ.MagicRank);
            //    Console.WriteLine(champ.Name);
            //    Console.WriteLine(champ.RankedPlayEnabled);
            //    Console.WriteLine();
            //}

            //var summoner = api.GetSummoners(Region.euw, new List<int> { 42091042 });

            //foreach (SummonerBase parent in summoner)
            //{
            //    Console.WriteLine(parent.Id);
            //    Console.WriteLine(parent.Name);
            //    Console.WriteLine();
            //}

            //var summ = api.GetSummoner(Region.euw, 42091042);
            //var masteries = summ.GetMasteryPages().First();

            //foreach (Talent talent in masteries.Talents)
            //{
            //    Console.WriteLine(talent.Name + " " + talent.Rank);
            //}

            //var pages = summ.GetRunePages();

            //foreach (RunePage page in pages.Take(100))
            //{
            //    if (page.Slots != null && page.Slots.Count > 0)
            //    {
            //        foreach (RuneSlot slot in page.Slots)
            //        {
            //            Console.WriteLine(slot.RuneSlotId);
            //            Console.WriteLine(slot.Rune.Description);
            //            Console.WriteLine(slot.Rune.Tier);
            //            Console.WriteLine(slot.Rune.Name);
            //            Console.WriteLine();
            //        }
            //    }
            //    Console.WriteLine(page.Name);
            //    Console.WriteLine();
            //}

            //Console.WriteLine(summoner.Name);
            //Console.WriteLine(summoner.Level);
            //Console.WriteLine(summoner.Id);
            //Console.WriteLine(summoner.ProfileIconId);
            //Console.WriteLine(summoner.RevisionDate);
            //Console.WriteLine(summoner.RevisionDateString);

            Console.ReadLine();
        }
    }
}
