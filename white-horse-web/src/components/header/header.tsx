"use client";
import "./header.scss";
import React from "react";
import Link from "next/link";
import "../../styles/globals.scss";
import { Button } from "primereact/button";
import { InputSwitch } from "primereact/inputswitch";
import { PROFILE, HOME, LOGIN } from "../../utils/front_end_urls/urls";

export default function Header(){
  const [isMounted, setIsMounted] = React.useState(false); 
  const [isDarkMode, setIsDarkMode] = React.useState(false);


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
      <div className="flexRow">
        <Link href={HOME}>
          <img src="/logo_header.png" alt="logo" className="LogoHeader" />
        </Link>
        <h1 className="titleHeader">White Horse Inc.</h1>
      </div>

      <div className="flexRow">
        <Link href={LOGIN}>
          <Button label="Login" outlined />
        </Link>

        <InputSwitch
          checked={isDarkMode}
          onChange={(e) => setIsDarkMode(e.value)}
        />

        <Link href={PROFILE}>
          <img src="/profile.png" alt="profile" className="LogoHeader" />
        </Link>
      </div>
    </section>
  );
}