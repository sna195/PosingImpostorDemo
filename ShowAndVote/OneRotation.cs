using DG.Tweening;
using UnityEngine;


public class OneRotation : MonoBehaviour
{
    [SerializeField] private float _rotationTime = 9f;

    [SerializeField] private enum Group { G14, G23 };

    [SerializeField] private Group _group;


    private Transform _transform;


    private void Awake()
    {
        _transform = transform;
    }

    /// <summary>
    /// Player1,4��Player2,3�����݂�_rotationTime�b������360�x��]������
    /// </summary>
    public void OneRotate()
    {
        Debug.Log("OneRotate");

        DG.Tweening.Sequence sequence = DOTween.Sequence();

        switch (_group)
        {
            case Group.G14:
                sequence.Append(_transform.DORotate(new Vector3(0, 360, 0), _rotationTime, RotateMode.WorldAxisAdd)
                                    .SetEase(Ease.Linear))
                        .AppendInterval(_rotationTime)
                        .SetLoops(30, LoopType.Restart);
                break; 
            
            case Group.G23:
                sequence.AppendInterval(_rotationTime)
                        .Append(_transform.DORotate(new Vector3(0, 360, 0), _rotationTime, RotateMode.WorldAxisAdd)
                                    .SetEase(Ease.Linear))
                        .SetLoops(30, LoopType.Restart);
                break;
        }
        
    }

}
