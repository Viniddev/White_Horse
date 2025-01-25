"use client";
import React from "react";
import "../styles/home/home_style.scss";
import "../styles/globals.scss";

import Main from "@/components/main_structure/main";

export default function Home() {
  return (
    <section className="ConteinerHome">
      <div className="bannerPrincipal flexRow">
        <div className="conteinerTextBanner">
          <p className="textHome">Aqui criamos</p>
          <p className="textHome subText">possibilidades!</p>
        </div>
        <img
          src="./logo_principal_sem_fundo.png"
          alt="logo com texto"
          className="imgBanner"
        />
      </div>

      <Main />
    </section>
  );
}
