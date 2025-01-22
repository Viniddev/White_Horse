"use client";
import React from "react";
import "../styles/home/home_style.scss";
import "../styles/globals.scss";

import Main from "@/components/main_structure/main";

export default function Home() {
  return (
    <section>
      <div className="banner">
        <div className="line1"><p className="TextBanner">Aqui construimos</p></div>
        <div className="line2"><p className="TextBanner mark">possibilidades.</p></div>
      </div>

      <Main />
    </section>
  );
}
