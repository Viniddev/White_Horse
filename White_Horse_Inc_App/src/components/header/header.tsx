"use client";
import "./header.scss";
import React, { useState } from "react";
import Link from "next/link";
import "../../styles/globals.scss";
import { Button } from "primereact/button";
import { PROFILE, HOME, LOGIN } from "../../utils/front_end_urls/urls";
import { SelectButton } from "primereact/selectbutton";

export default function Header(){
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
    return null; // Evita renderização no SSR


  return (
    <section className="headerLayout">
      <nav className="flexRow botoesNavegacao">
        <Link href={HOME}>
          <img
            src="/logo_principal_sem_fundo.png"
            alt="logo"
            className="LogoHeader"
          />
        </Link>

        <Link
          href={"https://www.youtube.com/watch?v=kvVEaln7QNQ"}
          className="HeaderOption"
        >
          <h1 className="titleHeader">Projetos</h1>
        </Link>

        <Link
          href={"https://www.youtube.com/watch?v=kvVEaln7QNQ"}
          className="HeaderOption"
        >
          <h1 className="titleHeader">Sobre nós</h1>
        </Link>
      </nav>

      <nav className="flexRow">
        <Link href={LOGIN}>
          <Button label="Login" outlined />
        </Link>

        <Link href={LOGIN}>
          <Button label="Sair" severity="danger" outlined />
        </Link>

        <SelectButton
          value={isDarkMode ? "Dark" : "Light"}
          onChange={(e) => {
            setValue(e.value);
            setIsDarkMode(e.value === "Dark" ? true : false);
          }}
          options={options}
        />

        <Link href={PROFILE}>
          <img src="/profile.png" alt="profile" className="LogoHeader" />
        </Link>
      </nav>
    </section>
  );
}