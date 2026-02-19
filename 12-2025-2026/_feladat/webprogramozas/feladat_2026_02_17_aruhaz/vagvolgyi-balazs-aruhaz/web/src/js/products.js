const BASE_URL = "http://localhost:8888";

export const getProducts = async () => {
    return await fetch(`${BASE_URL}/products`);
};

export const getProduct = async (id) => {
    const products = await fetch(`${BASE_URL}/products`);
    return products.find((p) => p.id == id);
};
