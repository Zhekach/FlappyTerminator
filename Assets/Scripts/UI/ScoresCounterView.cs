using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoresCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scores;
    
    private ScoresCounter _scoresCounter;

    private void Awake()
    {
        _scores = GetComponent<TMP_Text>();
    }
    
    public void Initialize(ScoresCounter scoresCounter)
    {
        _scoresCounter = scoresCounter;
        _scoresCounter.ScoresCountChanged +=  OnScoresCountChanged;
    }
    
    private void OnScoresCountChanged(int count)
    {
        _scores.text = count.ToString();
    }
}
