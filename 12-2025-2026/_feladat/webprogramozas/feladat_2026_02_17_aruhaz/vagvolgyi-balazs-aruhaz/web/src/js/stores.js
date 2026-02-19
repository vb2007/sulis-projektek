const BASE_URL = "http://localhost:8888";

export const getStore = async (id) => {
    const response = await fetch(`${BASE_URL}/stores`, {
        method: "GET",
        headers: { Accept: "application/json" },
    });

    const result = await response.json();
    const stores = result.data || result;
    return stores.find((s) => s.id == id);
};
