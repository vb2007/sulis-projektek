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
const title = document.createElement("h1");
title.textContent = "Könyvgyűjtemény";
title.classList.add("text-3xl", "font-bold", "text-center", "text-white", "p-4", "bg-gray-800");

const header = document.getElementById("header");
header.append(title);

// Main
const bookContainer = document.createElement("div");
bookContainer.setAttribute("id" ,"book-container");
bookContainer.classList.add("grid", "gap-6", "p-6", "max-w-4xl", "mx-auto", "grid-cols-1", "md:grid-cols-3");

const main = document.getElementById("main");
main.append(bookContainer);

// Footer
const madeBy = document.createElement("p");
madeBy.textContent = "Készítette: Vágvölgyi Balázs";
madeBy.classList.add("text-center", "p-4", "bg-gray-800", "text-gray-200");

// Könyvek megjelenítése
function renderBooks() {
  const bookContainer = document.getElementById("book-container");

  books.forEach(book => {
    const container = document.createElement("div");
    container.classList.add("bg-gray-800", "p-4", "rounded", "shadow", "flex", "flex-col", "items-start");
    container.setAttribute("data-id", book.id);

    const cover = document.createElement("img");
    cover.setAttribute("src", `img/${book.image}`);
    cover.setAttribute("alt", book.title);
    cover.classList.add("w-full", "h-48", "object-cover", "rounded");

    const text = document.createElement("div");
    text.classList.add("flex", "flex-col");

    const title = document.createElement("span");
    title.textContent = book.title;
    title.classList.add("text-lg", "font-semibold", "text-white");
    if (book.read) {
      title.classList.add("line-through");
    }

    const author = document.createElement("span");
    author.textContent = book.author;
    author.classList.add("text-gray-200");

    const buttons = document.createElement("div");
    buttons.classList.add("flex", "gap-2", "mt-2");

    const readBtn = document.createElement("button");
    readBtn.textContent = "Elolvasva";
    readBtn.classList.add("bg-green-600", "text-white", "p-2", "rounded", "hover:bg-green-700", "transition");
    readBtn.setAttribute("data-id", book.id);

    const deleteBtn = document.createElement("button");
    deleteBtn.textContent = "Törlés";
    deleteBtn.classList.add("bg-red-600", "text-white", "p-2", "rounded", "hover:bg-red-700", "transition");
    deleteBtn.setAttribute("data-id", book.id);

    buttons.append(readBtn, deleteBtn);
    container.append(cover, text, title, author, buttons);
    bookContainer.append(container);
  });
}

// Törlés
function deleteBook(id) {
  const bookContainer = document.getElementById("book-container");
  const bookCard = bookContainer.querySelector(`[data-id="${id}"]`);
  if (bookCard) {
    bookContainer.removeChild(bookCard);
  }
}

// Olvasva állapot jelölése
function toggleRead(id) {
  const bookContainer = document.getElementById("book-container");
  const bookCard = bookContainer.querySelector(`[data-id='${id}']`);
  if (bookCard) {
    const title = bookCard.querySelector(".text-lg");
    if (title) {
      if (title.classList.contains("line-through")) {
        title.classList.remove("line-through");
      }
      else {
        title.classList.add("line-through");
      }
    }
  }
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