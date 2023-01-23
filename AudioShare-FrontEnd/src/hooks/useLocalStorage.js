import { useState } from "react";

export const useLocalStorage = (user, defaultValue) => {
    const [value, setValue] = useState(() => {
        const storedData = localStorage.getItem(user);

        return storedData ? JSON.parse(storedData) : defaultValue;
    });

    const setLocalStorageValue = (newValue) => {
        localStorage.setItem(user, JSON.stringify(newValue));

        setValue(newValue);
    };

    return [value, setLocalStorageValue];
};
