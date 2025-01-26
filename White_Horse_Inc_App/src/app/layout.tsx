import { PrimeReactProvider } from "primereact/api";
import type { Metadata } from "next";

import "primereact/resources/themes/lara-light-purple/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.scss";
import "../styles/globals.scss";
import React from "react";

import Header from "../components/header/header";
import Footer from "../components/footer/footer";
import { AppWrapper } from "@/routes/context";

export const metadata: Metadata = {
  title: "White Horse Inc.",
  description: "A open source organization that helps you build your dreams.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="pt-br">
      <head>
        <link
          href="https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300..800;1,300..800&family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap"
          rel="stylesheet"
        />
      </head>
      <body className="BodyLayout">
        <AppWrapper>
          <Header />
          <PrimeReactProvider>{children}</PrimeReactProvider>
          <Footer />
        </AppWrapper>
      </body>
    </html>
  );
}
