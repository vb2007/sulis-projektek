using KobolduldozokLib.Helpers;
using KobolduldozokLib.Entities.Characters;
using KobolduldozokLib.Entities.Objects;

namespace KobolduldozokLib.UI.Simulation;

public class ActivityLog
{
    private readonly List<string> _events;
    private readonly int _maxEvents;

    private readonly CustomColors _koboldColor = Kobold.Color;
    private readonly CustomColors _angelColor = Angel.Color;
    private readonly CustomColors _coinColor = Coin.Color;
    private readonly CustomColors _houseColor = House.Color;

    public ActivityLog(int maxEvents = 50)
    {
        _events = new List<string>();
        _maxEvents = maxEvents;
    }

    public void Log(string message)
    {
        AddEvent(message);
    }

    public void LogCoinPickup(int koboldCount)
    {
        AddEvent($"{_koboldColor.Colorize("Kobold")} lopott egy {_coinColor.Colorize("érmét")} ({_koboldColor.Colorize("Koboldok")}: {koboldCount})");
    }

    public void LogReproduction(int newKobolds, int totalKobolds)
    {
        AddEvent($"{newKobolds} új {_koboldColor.Colorize("kobold")} osztódott a segély felvétele után (Összesen: {totalKobolds})");
    }

    public void LogHouseArrival(int houseIndex)
    {
        AddEvent($"{_koboldColor.Colorize("Koboldok")} bitorolják a(z) {houseIndex}. {_houseColor.Colorize("házat")}!");
    }

    public void LogAngelsActivated()
    {
        AddEvent($"{_angelColor.Colorize("Angyalok")} értesítve - üldözés megkezdve!");
    }

    public void LogKoboldEliminated(int remainingKobolds)
    {
        AddEvent($"{_angelColor.Colorize("Angyal")} nyakoncsípett egy {_koboldColor.Colorize("koboldot")} (Maradt: {remainingKobolds})");
    }

    public void LogSimulationEnd()
    {
        AddEvent($"{_koboldColor.Colorize("Koboldüldözés")} vége, sikeres akció.");
        AddEvent(_angelColor.Colorize("MAGYAR ÖNVÉDELMI MOZGALOM ÁLTAL VÉDETT TERÜLET."));
        AddEvent("Nyomd meg a 'Q' gombot a kilépéshez.");
    }

    public IReadOnlyList<string> GetRecentEvents(int count)
    {
        int startIndex = Math.Max(0, _events.Count - count);
        int takeCount = Math.Min(count, _events.Count);
        return _events.Skip(startIndex).Take(takeCount).ToList();
    }

    public IReadOnlyList<string> GetAllEvents()
    {
        return _events.AsReadOnly();
    }

    public void Clear()
    {
        _events.Clear();
    }

    private void AddEvent(string message)
    {
        _events.Add(message);

        if (_events.Count > _maxEvents)
        {
            _events.RemoveAt(0);
        }
    }


}
