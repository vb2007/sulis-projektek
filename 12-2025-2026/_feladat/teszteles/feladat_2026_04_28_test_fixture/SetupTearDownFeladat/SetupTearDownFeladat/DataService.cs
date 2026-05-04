namespace SetupTearDownFeladat
{
    public class DatabaseService
    {
        private string _dbPath;
        private FileStream _fileLock; // Szimulálja a nyitott adatbázis-kapcsolatot
        public bool IsConnected { get; private set; }

        public DatabaseService(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void OpenConnection()
        {
            if (IsConnected) return;

            // Létrehozunk/Megnyitunk egy fájlt exkluzív hozzáféréssel
            _fileLock = new FileStream(_dbPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            IsConnected = true;
            Console.WriteLine("--- Adatbázis kapcsolat megnyitva. ---");
        }

        public void CloseConnection()
        {
            if (!IsConnected) return;

            _fileLock?.Dispose();
            _fileLock = null;
            IsConnected = false;
            Console.WriteLine("--- Adatbázis kapcsolat lezárva. ---");
        }

        public void AddBook(string title)
        {
            if (!IsConnected) throw new InvalidOperationException("Nincs aktív kapcsolat!");
            
            // Egyszerűen beleírjuk a fájlba a könyv címét
            byte[] info = System.Text.Encoding.UTF8.GetBytes(title + Environment.NewLine);
            _fileLock.Write(info, 0, info.Length);
            _fileLock.Flush();
        }

        public int GetBookCount()
        {
            if (!IsConnected) throw new InvalidOperationException("Nincs aktív kapcsolat!");
            
            _fileLock.Position = 0;
            using (var reader = new StreamReader(_fileLock, leaveOpen: true))
            {
                var content = reader.ReadToEnd();
                return content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }

        public void Clear()
        {
            if (!IsConnected) throw new InvalidOperationException("Nincs aktív kapcsolat!");
            _fileLock.SetLength(0);
        }
    }
}