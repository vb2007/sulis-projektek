const BASE_URL = "http://localhost:8888";

export const getProducts = async () => {
    const response = await fetch(`${BASE_URL}/products`, {
        method: "GET",
        headers: { Accept: "application/json" },
    });

    const result = await response.json();
    return result.data || result;
};

export const getProduct = async (id) => {
    const response = await fetch(`${BASE_URL}/products`, {
        method: "GET",
        headers: { Accept: "application/json" },
    });

    const result = await response.json();
    const products = result.data || result;
    return products.find((p) => p.id == id);
};
