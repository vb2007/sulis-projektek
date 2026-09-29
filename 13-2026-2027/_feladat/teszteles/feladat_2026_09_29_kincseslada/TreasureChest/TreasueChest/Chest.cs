namespace TreasureChest
{
    public class Chest
    {
        public bool IsOpen;
        public bool IsLocked;
        private int _volume;
        private List<Treasure> _contents;
        public int Volume
        {
            get => _volume;
            init
            {
                _volume = value;
            }
        }
        public string Name
        {
            get; init;
        }
        public Chest(string name, int volume) { 
            Volume = volume;
            Name = name;
            IsLocked = true; // alapból legyen bezárva
            IsOpen = false; // alapból legyen lecsukva
            _contents = new();
        }
        public bool Open()
        {
            if (!IsLocked && !IsOpen) { // akkor lehet kinyitni ha nincs zárva és nincs nyitva. Minden más esetben nem lehet

                IsOpen = true;
                return true;
            }
            return false;        }
        public bool Close()
        {
            if (!IsLocked && IsOpen) // akkor lehet becsukni ha nincs zárva és nyitva van. Minden más esetben nem lehet
            {
                IsOpen = false;
                return true;
            }
            return false;
        }
        public bool Lock()
        {
            if (!IsLocked && !IsOpen) // akkor lehet bezárni ha nincs még bezárva és nincs felnyitva. Minden más esetben nem lehet
            {
                IsLocked= true;
                return true;
            }
            return false;
        }
        public bool UnLock()
        {
            if (IsLocked && !IsOpen) // akkor lehet bekinyti ha zárva van és le van csukva Minden más esetben nem lehet
            {
                IsLocked = false;
                return true;
            }
            return false;
        }
        private int FreeSpace
        {
            get=> Volume - _contents.Sum(x => x.Volume);
        }
        public bool Store(Treasure treasure)
        {
            if (treasure.Volume>FreeSpace || !IsOpen) {  return false; }
            _contents.Add(treasure);
            return true;
        }
        public override string ToString()
        {
            string description= Name + " térfogat: " + Volume + " ebből szabad: " + FreeSpace + " ";
            if (_contents.Count == 0) description += "Nincs benne semmi.";
            else
            {
                description += "Tartalma: "+string.Join(", ",_contents.Select(x=>x.Name));
            }
            return description;
        }
        public Treasure? TakeOutLast()
        {
           if (_contents.Count == 0 || !IsOpen) return null;
            Treasure lastTreasure= _contents.Last<Treasure>();
            _contents.RemoveAt(_contents.Count - 1);
            return lastTreasure;
        }
        public Treasure? TakeOut(string name)
        {
            if (_contents.Count == 0 || !IsOpen) return null;
            Treasure? treasure=null;
            int i=0;
            while (i < _contents.Count)
            {
                if (_contents[i].Name == name)
                {
                    treasure = _contents[i];
                    _contents.RemoveAt(i);
                }
                    i++;
            }
            return treasure;
        }

    }
}

