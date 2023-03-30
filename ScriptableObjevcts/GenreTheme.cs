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
            "�X�|�[�c", new List<string>()
            {
                "�싅", 
                "�T�b�J�[",
                "�e�j�X",
                "�{�N�V���O",
                "�o���[�{�[��",
                "���j",
                "�̑�",
                "�S���t",
                "�o�X�P�b�g�{�[��",
                "����"
            }
        },
        {
            "�E��", new List<string>()
            {
                "������",
                "�v���O���}�[",
                "���", 
                "�����l", 
                "�|�l",
                "�A�C�h��", 
                "�J�����}��", 
                "������", 
                "Youtuber", 
                "�̎�"
            }
        },
        {
            "�A���t�@�x�b�g" , new List<string>()
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
            "��", new List<string>()
            {
                "���R�̏��_",
                "�l���鑜",
                "�L���X�g��",
                "�_�r�f��", 
                "���A�C��",
                "�~���̃��B�[�i�X",
                "��Ȃ�c����",
                "���C����",
                "���a�L�O��",
                "�����͎m��",
            }
        },
        */
        {
            "����", new List<string>()
            {
                "�h���S���{�[��",
                "ONE PIECE",
                "NARUTO",
                "HUNTERxHUNTER", 
                "�S�ł̐n",
                "��p����",
                "SLUM DUNK",
                "DEATH NOTE",
                "�i���̋��l",
                "SPY FAMILY"
            }
        },
        {
            "�y��", new List<string>()
            {
                "�s�A�m",
                "�o�C�I����",
                "��",
                "���R�[�_�[",
                "�M�^�[",
                "�h����",
                "�g�����y�b�g",
                "�n�[�v",
                "�؋�",
                "�t���[�g"
            }
        },
        {
            "����", new List<string>()
            {
                "��",
                "�S����",
                "��",
                "�p���_",
                "�_�`���E",
                "���b�R",
                "�w�",
                "�F",
                "�n���X�^�[",
                "�N�W���N"
            }
        },
        {
            "���퐶��", new List<string>()
            {
                "����",
                "�^�]",
                "�|��",
                "�׋�",
                "�ʘb",
                "���C",
                "�Ǐ�",
                "����",
                "����",
                "������"
            }
        }
    };


    [SerializeField] private string _initGenre = "����";

    [SerializeField] private string _initTheme = "�n���X�^�[";


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
    /// �W�������E�e�[�}����ɏ���������
    /// </summary>
    public void Initialize()
    {
        Genre = string.Empty;
        Theme = string.Empty;
    }

    /// <summary>
    /// �W�������������_���őI��
    /// </summary>
    /// <returns></returns>
    public string GetGenreRandom()
    {
        return GenreThemeDict.ElementAt(Random.Range(0, GenreThemeDict.Count)).Key;
    }

    /// <summary>
    /// �^����ꂽ�W���������̃e�[�}�������_���őI��
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetThemeRandom(string key)
    {
        var themes = GenreThemeDict[key];
        return themes[Random.Range(0, themes.Count)];
    }

    /// <summary>
    /// �^����ꂽ�W���������̃e�[�}�̃��X�g��Ԃ�
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public List<string> GetThemeList(string key)
    {
        return GenreThemeDict[key];
    }

    /// <summary>
    /// ���݂̃W���������̃e�[�}���C���f�b�N�X����擾����
    /// �͈͊O�Ȃ��
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string GetThemeFromIndex(int index)
    {
        return (0 <= index && index < ThemeCount) ? GenreThemeDict[Genre][index] : string.Empty;
    }

    /// <summary>
    /// �C���f�b�N�X�ŃW�����������߂�
    /// </summary>
    /// <param name="i"></param>
    public void SetGenreFromIndex(int i)
    {
        Assert.IsTrue(0 <= i && i < GenreCount, "���̒l�܂���Genre�̌��ȏ�̒l���^�����Ă���");

        Genre = GenreThemeDict.ElementAt(i).Key;
    }

    /// <summary>
    /// �C���f�b�N�X�Ńe�[�}�����߂�
    /// </summary>
    /// <param name="i"></param>
    public void SetThemeFromIndex(int i)
    {
        Assert.IsTrue(0 <= i && i < ThemeCount, "���̒l�܂���Theme�̌��ȏ�̒l���^�����Ă���");

        Theme = GenreThemeDict[Genre][i];
    }
}
