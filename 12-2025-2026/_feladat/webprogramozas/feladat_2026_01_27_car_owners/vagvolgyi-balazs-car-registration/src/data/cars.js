export const findCarByPlate = (plate) => {
    return new Promise((resolve, reject) => {
        if (!plate) {
            return reject(new Error("Plate is required."));
        }

        const car = cars.find((c) => c.plate === plate);

        if (!car) {
            return reject(new Error(`Car not found: ${plate}`));
        }

        resolve(car);
    });
};

const cars = [
    {
        plate: "ABC-123",
        brand: "Toyota",
        model: "Corolla",
        year: 2018,
        owner_id: 1,
    },
    {
        plate: "XYZ-777",
        brand: "Tesla",
        model: "Model 3",
        year: 2022,
        owner_id: 1,
    },
    {
        plate: "HUN-404",
        brand: "Volkswagen",
        model: "Golf",
        year: 2015,
        owner_id: 3,
    },
    {
        plate: "HUN-500",
        brand: "Volkswagen",
        model: "Golf",
        year: 2015,
    },
];
