import type { Metadata } from "next";

import "primereact/resources/themes/lara-light-purple/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.scss";
import "../../styles/globals.scss";
import React from "react";

export const metadata: Metadata = {
  title: "Perfil",
  description: "User profile",
};

export default function ProfileLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <section>
        {children}
    </section>
  )
}