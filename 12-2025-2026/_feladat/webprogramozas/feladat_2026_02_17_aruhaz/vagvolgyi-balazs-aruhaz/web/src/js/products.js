const BASE_URL = "http://localhost:8888";

export const getProducts = async () => {
    return await fetch(`${BASE_URL}/products`, {
        method: "GET",
        headers: { Accept: "application/json" },
    }).then((res) => res.json());
};

export const getProduct = async (id) => {
    const products = await fetch(`${BASE_URL}/products`, {
        method: "GET",
        headers: { Accept: "application/json" },
    }).then((res) => res.json());
    return products.find((p) => p.id == id);
};
