import { SelectButton } from "primereact/selectbutton";
import React from "react";
import { useState } from "react";

export default function DarkModeButton(){

    const [isMounted, setIsMounted] = useState(false); 
    const [isDarkMode, setIsDarkMode] = useState(false);
    const options = ["Light", "Dark"];
    const [value, setValue] = useState(options[0]);

    React.useEffect(() => {
        setIsMounted(true); // Marca que o componente está montado
        const storedTheme = localStorage.getItem("theme") || "light";
        setIsDarkMode(storedTheme === "dark");
    }, []);


    React.useEffect(() => {
        if (isMounted) {
            const theme = isDarkMode ? "dark" : "light";
            document.documentElement.setAttribute("data-theme", theme);
            localStorage.setItem("theme", theme);
        }
    }, [isDarkMode, isMounted]);


    if (!isMounted) 
        return null; 
    
    return(
         <SelectButton
            value={isDarkMode ? "Dark" : "Light"}
            onChange={(e) => {
            setValue(e.value);
            setIsDarkMode(e.value === "Dark" ? true : false);
            }}
            options={options}
        />
    )    
}