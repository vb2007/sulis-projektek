const books = [
    { id: 1, title: "Harry Potter és a bölcsek köve", author: "J.K. Rowling", image: "harry_potter.jpg", read: false },
    { id: 2, title: "1984", author: "George Orwell", image: "1984.jpg", read: true },
    { id: 3, title: "A Gyűrűk Ura", author: "J.R.R. Tolkien", image: "lotr.jpg", read: false },
    { id: 4, title: "Büszkeség és balítélet", author: "Jane Austen", image: "pride_prejudice.jpg", read: true },
    { id: 5, title: "Az arany ember", author: "Jókai Mór", image: "arany_ember.jpg", read: false },
    { id: 6, title: "Sapiens", author: "Yuval Noah Harari", image: "sapiens.jpg", read: true },
    { id: 7, title: "A kis herceg", author: "Antoine de Saint-Exupéry", image: "little_prince.jpg", read: false },
    { id: 8, title: "Dűne", author: "Frank Herbert", image: "dune.jpg", read: false },
    { id: 9, title: "Értéktelen ember", author: "Margaret Atwood", image: "handmaids_tale.jpg", read: true },
    { id: 10, title: "Az alkimista", author: "Paulo Coelho", image: "alchemist.jpg", read: false },
    { id: 11, title: "Egri csillagok", author: "Gárdonyi Géza", image: "egri_csillagok.jpg", read: true },
    { id: 12, title: "A szél árnyéka", author: "Carlos Ruiz Zafón", image: "shadow_wind.jpg", read: false }
  ];
  
  
  document.body.className = 'bg-gray-900';
  
  // Header 

  
  // Main

  
  // Footer
  
  
  // Könyvek megjelenítése
  function renderBooks() {
    
  }
  
  // Törlés
  function deleteBook(id) {

  }
  
  // Olvasva állapot jelölése
  function toggleRead(id) {

  }
  

  renderBooks();




  
  //Ehhez ne nyúljon
  document.querySelectorAll('.bg-green-600').forEach(button => {
    button.addEventListener('click', function() {
      const id = Number(button.dataset.id);
      toggleRead(id);
    });
  });
  
  document.querySelectorAll('.bg-red-600').forEach(button => {
    button.addEventListener('click', function() {
      const id = Number(button.dataset.id);
      deleteBook(id);
    });
  });