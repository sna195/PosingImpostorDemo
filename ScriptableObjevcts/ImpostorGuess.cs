using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Analytics;

/// <summary>
/// �C���|�X�^�[�̂���\�z���Ǘ�����
/// </summary>
[CreateAssetMenu]
public class ImpostorGuess : ScriptableObject, ISerializationCallbackReceiver
{
    /// <summary>
    /// �W���������̂���̃C���f�b�N�X(0 <= i <= 9)
    /// </summary>
    public int GuessIndex { get; set; }


    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize() { }

    public void SetGuessIndex(int guessIndex) { GuessIndex = guessIndex; }
}
