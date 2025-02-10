"use client";
import { PrimeReactProvider } from "primereact/api";
import { usePathname } from "next/navigation"; // Importa o hook para capturar a URL atual

import "primereact/resources/themes/lara-light-purple/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.scss";
import "../styles/globals.scss";
import React from "react";

import Header from "../components/header/header";
import Footer from "../components/footer/footer";
import { AppWrapper } from "@/pages/context";
import { LOGIN } from "@/utils/frontEndUrls/urls";
import Login from "./login/page";
import { jwtDecode } from "jwt-decode";
import Cadastro from "./cadastro/page";

const checkAuth = (): boolean => {
	if (sessionStorage.getItem("Token")) {
		const token: string = sessionStorage.getItem("Token")!;
		const decoded: any = jwtDecode(token);

		const currentTime: number = parseInt(new Date().getTime().toString().substring(0, 10));
		const expirationTime: number = parseInt(decoded.exp.toString().substring(0, 10));

    sessionStorage.setItem("Sub", decoded.sub);

		if (currentTime > expirationTime) {
			sessionStorage.removeItem("Token");
			window.location.href = LOGIN;
			return false;
		}

		return true;
	}
	return false;
};

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode }>) {
  const [pageLoaded, setPageLoaded] = React.useState<boolean>(false);
  const [autenticado, setAutenticado] = React.useState<boolean>(false);
  const pathname = usePathname(); // Obtém a URL atual

  React.useEffect(() => {
    setAutenticado(checkAuth());
    setPageLoaded(true);
  }, []);

  return (
    <html lang="pt-br">
      <head>
        <link
          href="https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300..800;1,300..800&family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap"
          rel="stylesheet"
        />
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
