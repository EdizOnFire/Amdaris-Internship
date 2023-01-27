import { useState } from "react";

export const useSessionStorage = (user, defaultValue) => {
    const [value, setValue] = useState(() => {
        const storedData = sessionStorage.getItem(user);

        return storedData ? JSON.parse(storedData) : defaultValue;
    });

    const setSessionStorageValue = (newValue) => {
        sessionStorage.setItem(user, JSON.stringify(newValue));

        setValue(newValue);
    };

    return [value, setSessionStorageValue];
};
