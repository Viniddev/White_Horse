"use client";
import React from "react";
import "../styles/home/home_style.scss";
import "../styles/globals.scss";

import Main from "@/components/main_structure/main";

export default function Home() {
  return (
    <section>
      <div className="banner flexRow">
        <img src="./blackFriday.jpg" alt="banner black friday" style={{maxWidth:"100%"}}/>
      </div>

      <Main />
    </section>
  );
}
