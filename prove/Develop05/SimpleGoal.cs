public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name,description,points)
    {
        _isComplete = false;
    }

    // Creating a constructor with _isComplete for loading purposes from file.
    public SimpleGoal(string name, string description, int points, bool complete) : base(name,description,points)
    {
        _isComplete = complete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal::{GetName()}::{GetDescription()}::{GetPoints()}::{_isComplete}";
    }
}