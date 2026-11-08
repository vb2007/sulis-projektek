namespace Urhajok_VB_Lib;

public class SpaceCommand
{
    public List<Spaceship> Spaceships { get; } = new List<Spaceship>();
    public List<CrewMember> FreeCrew { get; } = new List<CrewMember>();

    public bool Assign(CrewMember member, Spaceship spaceship)
    {
        if (!FreeCrew.Contains(member) || spaceship.Crew.Count >= (spaceship.Capacity ?? 0))
        {
            return false;
        }

        FreeCrew.Remove(member);
        spaceship.Crew.Add(member);
        member.Spaceship = spaceship;
        return true;
    }

    public bool Unassign(CrewMember member)
    {
        if (member.Spaceship == null)
        {
            return false;
        }

        member.Spaceship.Crew.Remove(member);
        member.Spaceship = null;
        FreeCrew.Add(member);
        return true;
    }
}