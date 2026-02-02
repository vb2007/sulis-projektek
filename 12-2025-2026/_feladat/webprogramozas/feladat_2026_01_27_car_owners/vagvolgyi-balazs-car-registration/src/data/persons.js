export const findPersonById = (person_id) => {
    return new Promise((resolve, reject) => {
        if (!person_id) {
            return reject(new Error('Parameter "person_id" is required.'));
        }

        const id = Number(person_id);
        const person = persons.find((p) => p.id === id);

        if (!person) {
            return reject(new Error(`Person not found: ${person_id}`));
        }

        resolve(person);
    });
};

const persons = [
    {
        id: 1,
        first_name: "Alex",
        last_name: "Morgan",
        email_address: "alex.morgan@example.com",
    },
    {
        id: 2,
        first_name: "Sam",
        last_name: "Lee",
        email_address: "sam.lee@example.com",
    },
    {
        id: 3,
        first_name: "Pat",
        last_name: "Kim",
        email_address: "pat.kim@example.com",
    },
];
