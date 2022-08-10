using TMPro;
using UnityEngine;

public class DieMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ScorePipe _score;

    private void Start()
    {
        _score.ChangeScoreEventHandler += SetScore;
    }

    private void SetScore(int value)
    {
        _text.text = value.ToString();
    }
}
