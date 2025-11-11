using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandExample : MonoBehaviour
{
    [SerializeField] private Button _buttonStraight;
    [SerializeField] private Button _buttonUndo;

    [SerializeField] private float _stepDistance = 1;
    [SerializeField] private Transform _pivotTransform;

    private List<MoveCommand> _moveJournal = new List<MoveCommand>();

    private void OnEnable()
    {
        _buttonStraight.onClick.AddListener(MoveStraight);
        _buttonUndo.onClick.AddListener(Undo);
    }

    private void OnDisable()
    {
        _buttonStraight.onClick.RemoveListener(MoveStraight);
        _buttonUndo.onClick.RemoveListener(Undo);
    }

    private void MoveStraight()
    {
        var move = new MoveStraightCommand(_pivotTransform, _stepDistance);

        move.Execute();

        _moveJournal.Add(move);
    }

    private void Undo()
    {
        if (_moveJournal.Count > 0)
        {
            var lastMove = _moveJournal.Last();

            lastMove.Undo();

            _moveJournal.Remove(lastMove);
        }
    }
}