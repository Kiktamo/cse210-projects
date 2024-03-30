public class AlternatingGoal : Goal
{
    private string _altName;
    private string _altDescription;
    private int _altPoints;
    private bool _isAlt;
    
    public AlternatingGoal(string name, string description, int points, string altName, string altDescription, int altPoints) : base(name,description,points)
    {
        _altName = altName;
        _altDescription = altDescription;
        _altPoints = altPoints;
        _isAlt = false;
    }

    public override int RecordEvent()
    {

        if (_isAlt)
        {
            _isAlt = false;
            return _altPoints;
        }
        else
        {
            _isAlt = true;
            return GetPoints();
        }
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        if (_isAlt)
        {
            return $"[ ] {_altName} ({_altDescription})";
        }
        else
        {
            return base.GetDetailsString();
        }
    }

    public override string GetStringRepresentation()
    {
        return $"AlternatingGoal::{GetName()}::{GetDescription()}::{GetPoints()}::{_altName}::{_altDescription}::{_altPoints}";
    }

    public override string GetName()
    {
        if (_isAlt)
        {
            return _altName;
        }
        else
        {
            return base.GetName();
        }
    }

}