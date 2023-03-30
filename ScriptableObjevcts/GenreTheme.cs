using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu]
public class GenreTheme : ScriptableObject, ISerializationCallbackReceiver
{
    private Dictionary<string, List<string>> GenreThemeDict = new Dictionary<string, List<string>>()
    {
        {
            "スポーツ", new List<string>()
            {
                "野球", 
                "サッカー",
                "テニス",
                "ボクシング",
                "バレーボール",
                "水泳",
                "体操",
                "ゴルフ",
                "バスケットボール",
                "剣道"
            }
        },
        {
            "職業", new List<string>()
            {
                "小説家",
                "プログラマー",
                "医者", 
                "料理人", 
                "芸人",
                "アイドル", 
                "カメラマン", 
                "政治家", 
                "Youtuber", 
                "歌手"
            }
        },
        {
            "アルファベット" , new List<string>()
            {
                "A", 
                "C", 
                "D", 
                "E", 
                "F",
                "I", 
                "J", 
                "K", 
                "L", 
                "M"
            }
        },
        /*
        {
            "像", new List<string>()
            {
                "自由の女神",
                "考える像",
                "キリスト像",
                "ダビデ像", 
                "モアイ像",
                "ミロのヴィーナス",
                "母なる祖国像",
                "阿修羅像",
                "平和記念像",
                "金剛力士像",
            }
        },
        */
        {
            "漫画", new List<string>()
            {
                "ドラゴンボール",
                "ONE PIECE",
                "NARUTO",
                "HUNTERxHUNTER", 
                "鬼滅の刃",
                "呪術廻戦",
                "SLUM DUNK",
                "DEATH NOTE",
                "進撃の巨人",
                "SPY FAMILY"
            }
        },
        {
            "楽器", new List<string>()
            {
                "ピアノ",
                "バイオリン",
                "琴",
                "リコーダー",
                "ギター",
                "ドラム",
                "トランペット",
                "ハープ",
                "木琴",
                "フルート"
            }
        },
        {
            "動物", new List<string>()
            {
                "猿",
                "ゴリラ",
                "犬",
                "パンダ",
                "ダチョウ",
                "ラッコ",
                "蜘蛛",
                "熊",
                "ハムスター",
                "クジャク"
            }
        },
        {
            "日常生活", new List<string>()
            {
                "睡眠",
                "運転",
                "掃除",
                "勉強",
                "通話",
                "風呂",
                "読書",
                "料理",
                "洗濯",
                "歯磨き"
            }
        }
    };


    [SerializeField] private string _initGenre = "動物";

    [SerializeField] private string _initTheme = "ハムスター";


    public string Genre { get; private set; }

    public string Theme { get; private set; }

    public int GenreCount { get; private set; }

    public int ThemeCount { get; private set; } = 10;


    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        Genre = _initGenre;
        Theme = _initTheme;

        GenreCount = GenreThemeDict.Count;
    }

    /// <summary>
    /// ジャンル・テーマを空に初期化する
    /// </summary>
    public void Initialize()
    {
        Genre = string.Empty;
        Theme = string.Empty;
    }

    /// <summary>
    /// ジャンルをランダムで選ぶ
    /// </summary>
    /// <returns></returns>
    public string GetGenreRandom()
    {
        return GenreThemeDict.ElementAt(Random.Range(0, GenreThemeDict.Count)).Key;
    }

    /// <summary>
    /// 与えられたジャンル内のテーマをランダムで選ぶ
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetThemeRandom(string key)
    {
        var themes = GenreThemeDict[key];
        return themes[Random.Range(0, themes.Count)];
    }

    /// <summary>
    /// 与えられたジャンル内のテーマのリストを返す
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public List<string> GetThemeList(string key)
    {
        return GenreThemeDict[key];
    }

    /// <summary>
    /// 現在のジャンル内のテーマをインデックスから取得する
    /// 範囲外なら空
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string GetThemeFromIndex(int index)
    {
        return (0 <= index && index < ThemeCount) ? GenreThemeDict[Genre][index] : string.Empty;
    }

    /// <summary>
    /// インデックスでジャンルを決める
    /// </summary>
    /// <param name="i"></param>
    public void SetGenreFromIndex(int i)
    {
        Assert.IsTrue(0 <= i && i < GenreCount, "負の値またはGenreの個数以上の値が与えられている");

        Genre = GenreThemeDict.ElementAt(i).Key;
    }

    /// <summary>
    /// インデックスでテーマを決める
    /// </summary>
    /// <param name="i"></param>
    public void SetThemeFromIndex(int i)
    {
        Assert.IsTrue(0 <= i && i < ThemeCount, "負の値またはThemeの個数以上の値が与えられている");

        Theme = GenreThemeDict[Genre][i];
    }
}
