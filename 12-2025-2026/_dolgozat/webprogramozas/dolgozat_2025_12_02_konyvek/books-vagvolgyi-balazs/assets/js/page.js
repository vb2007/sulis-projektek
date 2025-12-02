"use strict";

const booksContainer = document.getElementById("books");

const classes = {
  hard: "hard-cover",
  soft: "paperback",
  series: "series",
  adaptation: "adaptation",
};

const createBadge = ({ type, content }) => {
  const span = document.createElement("span");

  span.classList.add("badge");
  span.classList.add(classes[type]);
  span.textContent = content;

  return span;
};

const createBadgeRow = (book) => {
  const div = document.createElement("div");

  div.classList.add("badge-row");
  book.hardCover
    ? div.append(createBadge({ type: "hard", content: "Keménytáblás" }))
    : div.append(createBadge({ type: "soft", content: "Puhatáblás" }));
  book.series != null &&
    div.append(
      createBadge({
        type: "series",
        content: `${book.series} - ${book.sequence}. könyv`,
      }),
    );
  book.adaptation != null &&
    div.append(createBadge({ type: "adaptation", content: book.adaptation }));

  return div;
};

const createBook = (book) => {
  const bookContainer = document.createElement("div");
  bookContainer.classList.add("book");

  const img = document.createElement("img");
  img.src = `assets/img/covers/${book.cover}`;
  img.alt = book.title;
  img.title = book.title;

  const bookContentContainer = document.createElement("div");
  bookContentContainer.classList.add("book-body");

  const h2 = document.createElement("h2");
  h2.textContent = book.title;

  const ul = document.createElement("ul");

  const authorLi = document.createElement("li");
  const authorB = document.createElement("b");
  const authorSpan = document.createElement("span");
  authorB.textContent = "Szerző: ";
  authorSpan.textContent = book.author;
  authorLi.append(authorB, authorSpan);

  const publisherLi = document.createElement("li");
  const publisherB = document.createElement("b");
  const publisherSpan = document.createElement("span");
  publisherB.textContent = "Kiadó: ";
  publisherSpan.textContent = book.publisher;
  publisherLi.append(publisherB, publisherSpan);

  const categoryLi = document.createElement("li");
  const categoryB = document.createElement("b");
  const categorySpan = document.createElement("span");
  categoryB.textContent = "Kategória: ";
  categorySpan.textContent = book.category;
  categoryLi.append(categoryB, categorySpan);

  ul.append(authorLi, publisherLi, categoryLi);

  const price = document.createElement("p");
  price.textContent = book.price.toLocaleString("hu-HU", {
    style: "currency",
    currency: "HUF",
    maximumFractionDigits: 0,
  });

  bookContentContainer.append(h2, ul, price, createBadgeRow(book));
  bookContainer.append(img, bookContentContainer);

  return bookContainer;
};

const renderBooks = (books) => {
  if (books.length === 0) {
    booksContainer.textContent = "Nincs találat.";
  } else {
    booksContainer.textContent = "";
    books.forEach((book) => {
      booksContainer.append(createBook(book));
    });
  }
};

renderBooks(books);

const filterBooks = (event) => {
  event.preventDefault();

  const filterTitle = document.getElementById("filter_title").value;
  const filterMin = document.getElementById("filter_min").value;
  const filterMax = document.getElementById("filter_max").value;

  const filtered = books.filter((book) => {
    if (filterTitle !== "") {
      const titleMatch = book.title
        .toLowerCase()
        .includes(filterTitle.toLowerCase());
      if (!titleMatch) {
        return false;
      }
    }

    if (filterMin !== "") {
      const minPrice = Number(filterMin);
      if (book.price < minPrice) {
        return false;
      }
    }

    if (filterMax !== "") {
      const maxPrice = Number(filterMax);
      if (book.price > maxPrice) {
        return false;
      }
    }

    return true;
  });

  renderBooks(filtered);
};

const filterForm = document.getElementById("books_filter");
filterForm.addEventListener("submit", filterBooks);

const resetFiltersBtn = document.getElementById("reset_filters");
resetFiltersBtn.addEventListener("click", () => {
  filterForm.reset();
  renderBooks(books);
});
