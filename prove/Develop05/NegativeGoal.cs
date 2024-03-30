public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name,description,points)
    {
        
    }

    public override int RecordEvent()
    {
        int points = GetPoints();

        if (points < 0)
        {
            return points;
        }
        else
        {
            return points * -1;
        }
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal::{GetName()}::{GetDescription()}::{GetPoints()}";
    }
}