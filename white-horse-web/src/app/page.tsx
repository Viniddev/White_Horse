"use client";
import "../styles/home/home_style.scss"
import Header from "../components/header/header";
import Footer from "../components/footer/footer";
import React from "react";
import { MainTitle } from "@/components/custom/title_aplication";
import { HomeLayout } from "../components/custom/home_layout";

export default function Home() {
  return (
    <HomeLayout>
      <Header />
      <main>
        <MainTitle hg="1.5rem" align="left">Aqui teremos o conteudo principal</MainTitle>
      </main>
      <Footer />
    </HomeLayout>
  );
}
