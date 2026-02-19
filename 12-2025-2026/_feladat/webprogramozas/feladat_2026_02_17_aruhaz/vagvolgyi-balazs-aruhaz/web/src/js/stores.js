const BASE_URL = "http://localhost:8888";

export const getStore = async (id) => {
    const stores = await fetch(`${BASE_URL}/stores`, {
        method: "GET",
        headers: { Accept: "application/json" },
    }).then((res) => res.json());
    return stores.find((s) => s.id == id);
};
