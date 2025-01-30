"use client";
import React from "react";
import "../styles/home/homeStyle.scss";
import "../styles/globals.scss";

import Main from "@/components/mainStructure/main";
import FormularioPesquisa from "@/components/formPesquisaPromocoes/formPesquisa";

import { products } from "@/utils/mocks/products";
import BannerHome from "@/components/bannerHome/bannerHome";

export default function Home() {
  return (
    <section className="ConteinerHome">
      <BannerHome />

      <FormularioPesquisa list={products} />

      <Main list={products} />
    </section>
  );
}
