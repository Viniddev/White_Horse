"use client";
import React from "react";
import "../styles/home/home_style.scss";
import "../styles/globals.scss";

import Main from "@/components/main_structure/main";
import FormularioPesquisa from "@/components/form_pesquisa_promocoes/form_pesquisa";
import BannerHome from "@/components/banner_home/banner_home";

import { products } from "@/utils/mocks/products";

export default function Home() {
  return (
    <section className="ConteinerHome">
      <BannerHome />

      <FormularioPesquisa list={products} />

      <Main list={products} />
    </section>
  );
}
