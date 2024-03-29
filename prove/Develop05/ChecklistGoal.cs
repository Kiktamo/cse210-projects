public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed) : base(name, description, points)
    {
        _amountCompleted = completed;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted += 1;

        if (_amountCompleted == _target)
        {
            return GetPoints() + _bonus;
        }
        else
        {
            return GetPoints();
        }
    }

    public override bool IsComplete()
    {
        return (_amountCompleted >= _target);
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal::{GetName()}::{GetDescription()}::{GetPoints()}::{_target}::{_bonus}::{_amountCompleted}";
    }
}