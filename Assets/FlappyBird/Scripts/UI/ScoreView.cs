using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Start()
    {
        FindObjectOfType<ScorePipe>().ChangeScoreEventHandler += OnChangeScore;
    }

    public void OnChangeScore(int value)
    {
        _text.text = value.ToString();
    }
}
