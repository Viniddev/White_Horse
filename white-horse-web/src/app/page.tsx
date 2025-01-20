"use client";
import React from "react";
import "../styles/home/home_style.scss"
import Header from "../components/header/header";
import Footer from "../components/footer/footer";
import Main from "@/components/main_structure/main";
import { HomeLayout } from "../components/custom/home_layout";

export default function Home() {
  return (
    <HomeLayout>
      <Header />
      <Main />
      <Footer />
    </HomeLayout>
  );
}
