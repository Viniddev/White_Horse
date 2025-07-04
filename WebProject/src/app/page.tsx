"use client";
import React from "react";

import "../styles/homeStyle.scss";
import "../styles/globals.scss";

import Main from "@/components/mainStructure/main";
import BannerHome from "@/components/bannerHome/bannerHome";

export default function Home() {
  return (
    <section className="ConteinerHome">
      <BannerHome />

      <Main />
    </section>
  );
}
