"use client";
import React from "react";

import "../styles/home/homeStyle.scss";
import "../styles/globals.scss";

import Main from "@/components/mainStructure/main";
import { products } from "@/utils/mocks/products";
import FormularioPesquisa from "@/components/formPesquisaPromocoes/formPesquisa";
import BannerHome from "@/components/bannerHome/bannerHome";

export default function Home() {
  const [produtos, setProdutos] = React.useState(products);

  return (
    <section className="ConteinerHome">
      <BannerHome />

      <FormularioPesquisa list={produtos} setList={setProdutos} />

      <Main list={produtos} setList={setProdutos} />
    </section>
  );
}
