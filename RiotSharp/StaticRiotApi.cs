﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class StaticRiotApi
    {
        private const string ChampionRootUrl = "/api/lol/static-data/{0}/v1/champion";
        private const string ChampionsCacheKey = "champions";
        private const string ChampionCacheKey = "champion";

        private const string ItemRootUrl = "/api/lol/static-data/{0}/v1/item";
        private const string ItemsCacheKey = "items";
        private const string ItemCacheKey = "item";

        private const string MasteryRootUrl = "/api/lol/static-data/{0}/v1/mastery";
        private const string MasteriesCacheKey = "masteries";
        private const string MasteryCacheKey = "mastery";

        private const string RuneRootUrl = "/api/lol/static-data/{0}/v1/rune";
        private const string RunesCacheKey = "runes";
        private const string RuneCacheKey = "rune";

        private const string SummonerSpellRootUrl = "/api/lol/static-data/{0}/v1/summoner-spell";
        private const string SummonerSpellsCacheKey = "spells";
        private const string SummonerSpellCacheKey = "spell";

        private const string IdUrl = "/{0}";

        private Requester requester;

        private static StaticRiotApi instance;
        public static StaticRiotApi GetInstance(string apiKey)
        {
            if (instance == null || apiKey != Requester.ApiKey)
            {
                instance = new StaticRiotApi(apiKey);
            }
            return instance;
        }

        private StaticRiotApi(string apiKey)
        {
            requester = Requester.Instance;
            Requester.RootDomain = "prod.api.pvp.net";
            Requester.ApiKey = apiKey;
        }

        public ChampionListStatic GetChampions(Region region, ChampionData championData = ChampionData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , championData == ChampionData.none ? string.Empty 
                            : string.Format("champData={0}", championData.ToString()) });
                var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);
                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                Cache.Add<ChampionListStaticWrapper>(ChampionsCacheKey, wrapper);
            }
            return wrapper.ChampionListStatic;
        }

        public async Task<ChampionListStatic> GetChampionsAsync(Region region
            , ChampionData championData = ChampionData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , championData == ChampionData.none ? string.Empty 
                            : string.Format("champData={0}", championData.ToString()) });
                var champs = await JsonConvert.DeserializeObjectAsync<ChampionListStatic>(json);
                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                Cache.Add<ChampionListStaticWrapper>(ChampionsCacheKey, wrapper);
            }
            return wrapper.ChampionListStatic;
        }

        public ChampionStatic GetChampion(Region region, int championId
            , ChampionData championData = ChampionData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionStaticWrapper>(ChampionCacheKey + championId);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }
            else
            {
                var listWrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.ChampionData == championData)
                {
                    return listWrapper.ChampionListStatic.Champions.Values
                        .Where((c) => c.Key == championId).FirstOrDefault();
                }
                else
                {
                    var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString())
                        + string.Format(IdUrl, championId)
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , championData == ChampionData.none ? string.Empty 
                                : string.Format("champData={0}", championData.ToString()) });
                    var champ = JsonConvert.DeserializeObject<ChampionStatic>(json);
                    Cache.Add<ChampionStaticWrapper>(ChampionCacheKey + championId
                        , new ChampionStaticWrapper(champ, language, championData));
                    return champ;
                }
            }
        }

        public async Task<ChampionStatic> GetChampionAsync(Region region, int championId
            , ChampionData championData = ChampionData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionStaticWrapper>(ChampionCacheKey + championId);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }
            else
            {
                var listWrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.ChampionData == championData)
                {
                    return listWrapper.ChampionListStatic.Champions.Values
                        .Where((c) => c.Key == championId).FirstOrDefault();
                }
                else
                {
                    var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString())
                        + string.Format(IdUrl, championId)
                        , new List<string>() { string.Format("local={0}", language.ToString())
                            , championData == ChampionData.none ? string.Empty 
                                : string.Format("champData={0}", championData.ToString()) });
                    var champ = await JsonConvert.DeserializeObjectAsync<ChampionStatic>(json);
                    Cache.Add<ChampionStaticWrapper>(ChampionCacheKey + championId
                        , new ChampionStaticWrapper(champ, language, championData));
                    return champ;
                }
            }
        }

        public ItemListStatic GetItems(Region region, ItemData itemData = ItemData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var json = requester.CreateRequest(string.Format(ItemRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , itemData == ItemData.none ? string.Empty
                            : string.Format("itemListData={0}", itemData.ToString()) });
                var items = JsonConvert.DeserializeObject<ItemListStatic>(json);
                wrapper = new ItemListStaticWrapper(items, language, itemData);
                Cache.Add<ItemListStaticWrapper>(ItemsCacheKey, wrapper);
            }
            return wrapper.ItemListStatic;
        }

        public async Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var json = await requester.CreateRequestAsync(string.Format(ItemRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , itemData == ItemData.none ? string.Empty
                            : string.Format("itemListData={0}", itemData.ToString()) });
                var items = await JsonConvert.DeserializeObjectAsync<ItemListStatic>(json);
                wrapper = new ItemListStaticWrapper(items, language, itemData);
                Cache.Add<ItemListStaticWrapper>(ItemsCacheKey, wrapper);
            }
            return wrapper.ItemListStatic;
        }

        public ItemStatic GetItem(Region region, int itemId, ItemData itemData = ItemData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemStaticWrapper>(ItemCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }
            else
            {
                var listWrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.ItemData == itemData)
                {
                    if (listWrapper.ItemListStatic.Items.ContainsKey(itemId))
                    {
                        return listWrapper.ItemListStatic.Items[itemId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = requester.CreateRequest(string.Format(ItemRootUrl, region.ToString())
                        + string.Format(IdUrl, itemId)
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , itemData == ItemData.none ? string.Empty
                                : string.Format("itemData={0}", itemData.ToString()) });
                    var item = JsonConvert.DeserializeObject<ItemStatic>(json);
                    Cache.Add<ItemStaticWrapper>(ItemCacheKey + itemId, new ItemStaticWrapper(item, language, itemData));
                    return item;
                }
            }
        }

        public async Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemStaticWrapper>(ItemCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }
            else
            {
                var listWrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.ItemData == itemData)
                {
                    if (listWrapper.ItemListStatic.Items.ContainsKey(itemId))
                    {
                        return listWrapper.ItemListStatic.Items[itemId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = await requester.CreateRequestAsync(string.Format(ItemRootUrl, region.ToString())
                        + string.Format(IdUrl, itemId)
                        , new List<string>() { string.Format("local={0}", language.ToString())
                            , itemData == ItemData.none ? string.Empty
                                : string.Format("itemData={0}", itemData.ToString()) });
                    var item = await JsonConvert.DeserializeObjectAsync<ItemStatic>(json);
                    Cache.Add<ItemStaticWrapper>(ItemCacheKey + itemId, new ItemStaticWrapper(item, language, itemData));
                    return item;
                }
            }
        }

        public MasteryListStatic GetMasteries(Region region, MasteryData masteryData = MasteryData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper == null || language != wrapper.Language || masteryData != wrapper.MasteryData)
            {
                var json = requester.CreateRequest(string.Format(MasteryRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , masteryData == MasteryData.none ? string.Empty
                            : string.Format("masteryListData={0}", masteryData.ToString()) });
                var masteries = JsonConvert.DeserializeObject<MasteryListStatic>(json);
                wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
                Cache.Add<MasteryListStaticWrapper>(MasteriesCacheKey, wrapper);
            }
            return wrapper.MasteryListStatic;
        }

        public async Task<MasteryListStatic> GetMasteriesAsync(Region region
            , MasteryData masteryData = MasteryData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper == null || language != wrapper.Language || masteryData != wrapper.MasteryData)
            {
                var json = await requester.CreateRequestAsync(string.Format(MasteryRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , masteryData == MasteryData.none ? string.Empty
                            : string.Format("masteryListData={0}", masteryData.ToString()) });
                var masteries = await JsonConvert.DeserializeObjectAsync<MasteryListStatic>(json);
                wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
                Cache.Add<MasteryListStaticWrapper>(MasteriesCacheKey, wrapper);
            }
            return wrapper.MasteryListStatic;
        }

        public MasteryStatic GetMastery(Region region, int masteryId, MasteryData masteryData = MasteryData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<MasteryStaticWrapper>(MasteryCacheKey + masteryId);
            if (wrapper != null && wrapper.Language == language && wrapper.MasteryData == masteryData)
            {
                return wrapper.MasteryStatic;
            }
            else
            {
                var listWrapper = Cache.Get<MasteryListStaticWrapper>(MasteriesCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.MasteryData == masteryData)
                {
                    if (listWrapper.MasteryListStatic.Masteries.ContainsKey(masteryId))
                    {
                        return listWrapper.MasteryListStatic.Masteries[masteryId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = requester.CreateRequest(string.Format(MasteryRootUrl, region.ToString())
                        + string.Format(IdUrl, masteryId),
                        new List<string>() { string.Format("locale={0}", language.ToString())
                            , masteryData == MasteryData.none ? string.Empty
                                : string.Format("masteryData={0}", masteryData.ToString()) });
                    var mastery = JsonConvert.DeserializeObject<MasteryStatic>(json);
                    Cache.Add<MasteryStaticWrapper>(MasteryCacheKey + masteryId
                        , new MasteryStaticWrapper(mastery, language, masteryData));
                    return mastery;
                }
            }
        }

        public async Task<MasteryStatic> GetMasteryAsync(Region region, int masteryId
            , MasteryData masteryData = MasteryData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<MasteryStaticWrapper>(MasteryCacheKey + masteryId);
            if (wrapper != null && wrapper.Language == language && wrapper.MasteryData == masteryData)
            {
                return wrapper.MasteryStatic;
            }
            else
            {
                var listWrapper = Cache.Get<MasteryListStaticWrapper>(MasteriesCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.MasteryData == masteryData)
                {
                    if (listWrapper.MasteryListStatic.Masteries.ContainsKey(masteryId))
                    {
                        return listWrapper.MasteryListStatic.Masteries[masteryId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = await requester.CreateRequestAsync(string.Format(MasteryRootUrl, region.ToString())
                        + string.Format(IdUrl, masteryId.ToString())
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , masteryData == MasteryData.none ? string.Empty
                                : string.Format("masteryData={0}", masteryData.ToString()) });
                    var mastery = await JsonConvert.DeserializeObjectAsync<MasteryStatic>(json);
                    Cache.Add<MasteryStaticWrapper>(MasteryCacheKey + masteryId
                        , new MasteryStaticWrapper(mastery, language, masteryData));
                    return mastery;
                }
            }
        }

        public RuneListStatic GetRunes(Region region, RuneData runeData = RuneData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper == null || language != wrapper.Language || runeData != wrapper.RuneData)
            {
                var json = requester.CreateRequest(string.Format(RuneRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , runeData == RuneData.none ? string.Empty
                            : string.Format("runeListData={0}", runeData.ToString()) });
                var runes = JsonConvert.DeserializeObject<RuneListStatic>(json);
                wrapper = new RuneListStaticWrapper(runes, language, runeData);
                Cache.Add<RuneListStaticWrapper>(RunesCacheKey, wrapper);
            }
            return wrapper.RuneListStatic;
        }

        public async Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper == null || language != wrapper.Language | runeData != wrapper.RuneData)
            {
                var json = await requester.CreateRequestAsync(string.Format(RuneRootUrl, region.ToString())
                    , new List<string>() { string.Format("local={0}", language.ToString())
                        , runeData == RuneData.none ? string.Empty
                            : string.Format("runeListData={0}", runeData.ToString()) });
                var runes = await JsonConvert.DeserializeObjectAsync<RuneListStatic>(json);
                wrapper = new RuneListStaticWrapper(runes, language, runeData);
                Cache.Add<RuneListStaticWrapper>(RunesCacheKey, wrapper);
            }
            return wrapper.RuneListStatic;
        }

        public RuneStatic GetRune(Region region, int runeId, RuneData runeData = RuneData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<RuneStaticWrapper>(RuneCacheKey + runeId);
            if(wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.all)
            {
                return wrapper.RuneStatic;
            }
            else
            {
                var listWrapper = Cache.Get<RuneListStaticWrapper>(RunesCacheKey);
                if(listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
                {
                    if(listWrapper.RuneListStatic.Runes.ContainsKey(runeId))
                    {
                        return listWrapper.RuneListStatic.Runes[runeId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = requester.CreateRequest(string.Format(RuneRootUrl, region.ToString())
                        + string.Format(IdUrl, runeId)
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , runeData == RuneData.none ? string.Empty
                                : string.Format("runeData={0}", runeData.ToString()) });
                    var rune = JsonConvert.DeserializeObject<RuneStatic>(json);
                    Cache.Add<RuneStaticWrapper>(RuneCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData));
                    return rune;
                }
            }
        }

        public async Task<RuneStatic> GetRuneAsync(Region region, int runeId, RuneData runeData = RuneData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<RuneStaticWrapper>(RuneCacheKey + runeId);
            if (wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.all)
            {
                return wrapper.RuneStatic;
            }
            else
            {
                var listWrapper = Cache.Get<RuneListStaticWrapper>(RunesCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
                {
                    if (listWrapper.RuneListStatic.Runes.ContainsKey(runeId))
                    {
                        return listWrapper.RuneListStatic.Runes[runeId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = await requester.CreateRequestAsync(string.Format(RuneRootUrl, region.ToString())
                        + string.Format(IdUrl, runeId)
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , runeData == RuneData.none ? string.Empty
                                : string.Format("runeData={0}", runeData.ToString()) });
                    var rune = await JsonConvert.DeserializeObjectAsync<RuneStatic>(json);
                    Cache.Add<RuneStaticWrapper>(RuneCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData));
                    return rune;
                }
            }
        }

        public SummonerSpellListStatic GetSummonerSpells(Region region
            , SummonerSpellData summonerSpellData = SummonerSpellData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper == null || wrapper.Language != language || wrapper.SummonerSpellData != summonerSpellData)
            {
                var json = requester.CreateRequest(string.Format(SummonerSpellRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , summonerSpellData == SummonerSpellData.none ? string.Empty
                            : string.Format("spellData={0}", summonerSpellData.ToString()) });
                var spells = JsonConvert.DeserializeObject<SummonerSpellListStatic>(json);
                wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
                Cache.Add<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey, wrapper);
            }
            return wrapper.SummonerSpellListStatic;
        }

        public async Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region
            , SummonerSpellData summonerSpellData = SummonerSpellData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper == null || wrapper.Language != language || wrapper.SummonerSpellData != summonerSpellData)
            {
                var json = await requester.CreateRequestAsync(string.Format(SummonerSpellRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , summonerSpellData == SummonerSpellData.none ? string.Empty
                            : string.Format("spellData={0}", summonerSpellData.ToString()) });
                var spells = await JsonConvert.DeserializeObjectAsync<SummonerSpellListStatic>(json);
                wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
                Cache.Add<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey, wrapper);
            }
            return wrapper.SummonerSpellListStatic;
        }

        public SummonerSpellStatic GetSummonerSpell(Region region, SummonerSpell summonerSpell
            , SummonerSpellData summonerSpellData = SummonerSpellData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<SummonerSpellStaticWrapper>(SummonerSpellCacheKey + summonerSpell.ToCustomString());
            if (wrapper != null && wrapper.SummonerSpellData == summonerSpellData && wrapper.Language == language)
            {
                return wrapper.SummonerSpellStatic;
            }
            else
            {
                var listWrapper = Cache.Get<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
                if (listWrapper != null && listWrapper.SummonerSpellData == summonerSpellData
                    && listWrapper.Language == language)
                {
                    if (listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpell.ToCustomString()))
                    {
                        return listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpell.ToCustomString()];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = requester.CreateRequest(string.Format(SummonerSpellRootUrl, region.ToString())
                        + string.Format(IdUrl, summonerSpell.ToCustomString())
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , summonerSpellData == SummonerSpellData.none ? string.Empty
                                : string.Format("spellData={0}", summonerSpellData.ToString()) });
                    var spell = JsonConvert.DeserializeObject<SummonerSpellStatic>(json);
                    Cache.Add<SummonerSpellStaticWrapper>(SummonerSpellCacheKey + summonerSpell.ToCustomString()
                        , new SummonerSpellStaticWrapper(spell, language, summonerSpellData));
                    return spell;
                }
            }
        }

        public async Task<SummonerSpellStatic> GetSummonerSpellAsync(Region region, SummonerSpell summonerSpell
            , SummonerSpellData summonerSpellData = SummonerSpellData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<SummonerSpellStaticWrapper>(SummonerSpellCacheKey + summonerSpell.ToCustomString());
            if (wrapper != null && wrapper.SummonerSpellData == summonerSpellData && wrapper.Language == language)
            {
                return wrapper.SummonerSpellStatic;
            }
            else
            {
                var listWrapper = Cache.Get<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
                if (listWrapper != null && listWrapper.SummonerSpellData == summonerSpellData
                    && listWrapper.Language == language)
                {
                    if (listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpell.ToCustomString()))
                    {
                        return listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpell.ToCustomString()];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = await requester.CreateRequestAsync(string.Format(SummonerSpellRootUrl, region.ToString())
                        + string.Format(IdUrl, summonerSpell.ToCustomString())
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , summonerSpellData == SummonerSpellData.none ? string.Empty
                                : string.Format("spellData={0}", summonerSpellData.ToString()) });
                    var spell = await JsonConvert.DeserializeObjectAsync<SummonerSpellStatic>(json);
                    Cache.Add<SummonerSpellStaticWrapper>(SummonerSpellCacheKey + summonerSpell.ToCustomString()
                        , new SummonerSpellStaticWrapper(spell, language, summonerSpellData));
                    return spell;
                }
            }
        }
    }
}
