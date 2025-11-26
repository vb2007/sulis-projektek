import { offers, options } from "./data/data.js";

const createSortOptions = (options) => {
  const optionElements = [];

  options.forEach((option) => {
    const optionElement = document.createElement("option");
    optionElement.textContent = option.label;
    optionElement.value = option.value;

    optionElements.push(optionElement);
  });

  return optionElements;
};

const optionsDropdown = document.getElementById("sort-select");
optionsDropdown.append(...createSortOptions(options));

const isAvailable = (before, after) => {
  const current = Date.now();
  return before > current && after < current;
};

const createAvailableBadge = (isAvailable) => {
  const badgeSpan = document.createElement("span");

  if (isAvailable) {
    badgeSpan.classList.add("badge-new");
    badgeSpan.textContent = "Elérhető";

    return badgeSpan;
  }

  badgeSpan.classList.add("badge-premium");
  badgeSpan.textContent = "Nem elérhető";

  return badgeSpan;
};

const createPriceTag = (cost) => {
  const container = document.createElement("div");

  container.classList.add("price");
  container.textContent =
    cost.toLocaleString("hu-HU", {
      style: "currency",
      currency: "HUF",
      maximumFractionDigits: 0,
    }) + "/fő/éj";

  return container;
};

const createFeatureTags = (features) => {
  const featureTags = [];

  features.forEach((feature) => {
    const featureTag = document.createElement("span");
    featureTag.classList.add("tag");
    featureTag.textContent = feature;

    featureTags.push(featureTag);
  });

  return featureTags;
};

const createFeatureList = (features) => {
  const featuresContainer = document.createElement("div");

  featuresContainer.classList.add("feature-tags");
  featuresContainer.append(createFeatureTags(features));

  return featuresContainer;
};

let filtered = offers;

const loadOffers = () => {
  const offersContainer = document.getElementById("offers");
  offersContainer.innerHTML = "";

  filtered.forEach((offer) => {
    const offerCard = document.createElement("div");
    offerCard.classList.add("offer-card");

    const img = document.createElement("img");
    img.src = `assets/images/${offer.hotel.img}`;
    img.alt = offer.hotel.name;

    const cardBody = document.createElement("div");
    cardBody.classList.add("card-body");

    const available = isAvailable(
      offer.available.before,
      offer.available.after,
    );
    const badge = createAvailableBadge(available);

    const hotelName = document.createElement("h3");
    hotelName.textContent = offer.hotel.name;

    const summary = document.createElement("p");
    summary.textContent = offer.summary;

    const featureList = createFeatureList(offer.hotel.features);
    const priceTag = createPriceTag(offer.cost);

    cardBody.append(badge);
    cardBody.append(hotelName);
    cardBody.append(summary);
    cardBody.append(featureList);
    cardBody.append(priceTag);

    offerCard.append(img);
    offerCard.append(cardBody);

    offersContainer.append(offerCard);
  });
};

const filter = () => {
  const minPriceInput = document.getElementById("min-price");
  const maxPriceInput = document.getElementById("max-price");

  const minPrice = parseInt(minPriceInput.value) || 0;
  const maxPrice = parseInt(maxPriceInput.value) || Infinity;

  filtered = offers.filter((offer) => {
    return offer.cost >= minPrice && offer.cost <= maxPrice;
  });

  loadOffers();
};

const clearFilter = () => {
  document.getElementById("min-price").value = "";
  document.getElementById("max-price").value = "";
  document.getElementById("sort-select").value = "default";

  filtered = offers;
  loadOffers();
};

const sortOffers = () => {
  const sortSelect = document.getElementById("sort-select");
  const sortValue = sortSelect.value;

  if (sortValue === "default") {
    filtered = [...offers];
  } else {
    filtered = [...filtered].sort((a, b) => {
      switch (sortValue) {
        case "price-asc":
          return a.cost - b.cost;
        case "price-desc":
          return b.cost - a.cost;
        case "name-asc":
          return a.hotel.name.localeCompare(b.hotel.name);
        case "name-desc":
          return b.hotel.name.localeCompare(a.hotel.name);
        default:
          return 0;
      }
    });
  }

  loadOffers();
};

document.getElementById("run-filter").addEventListener("click", filter);
document.getElementById("clear-filter").addEventListener("click", clearFilter);
document.getElementById("sort-select").addEventListener("change", sortOffers);

loadOffers();
