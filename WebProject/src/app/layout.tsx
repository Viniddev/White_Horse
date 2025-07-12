"use client";
import { PrimeReactProvider } from "primereact/api";

import "primereact/resources/themes/lara-light-purple/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.scss";
import "../styles/globals.scss";

import React from "react";
import Header from "../components/header/header";
import Footer from "../components/footer/footer";
import { AppWrapper } from "@/pages/context";
import Login from "./login/page";
import Cadastro from "./cadastro/page";
import UseAuthentication from "@/hooks/useAuthentication";

import * as dotenv from "dotenv";

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode }>) {
  dotenv.config();
  
  var { 
    pageLoaded, 
    autenticado, 
    pathname 
  } = UseAuthentication();

  return (
    <html lang="pt-br">
      <head>
        <link 
          href="https://fonts.googleapis.com/css2?family=M+PLUS+Code+Latin:wght@100..700&family=Open+Sans:ital,wght@0,300..800;1,300..800&family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" 
          rel="stylesheet"
        />
        <link
          href="https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300..800;1,300..800&family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap"
          rel="stylesheet"
        />
        <title>Home</title>
      </head>
      <AppWrapper>
        <PrimeReactProvider>
          <body className="BodyLayout">
            {autenticado ? (
              <div className="mainFrame">
                <Header />
                {children}
                <Footer />
              </div>
            ) : pageLoaded ? (
              <div className="mainFrame">
                <Header />
                {pathname === "/cadastro" ? <Cadastro /> : <Login />}
                <Footer />
              </div>
            ) : null}
          </body>
        </PrimeReactProvider>
      </AppWrapper>
    </html>
  );
}
