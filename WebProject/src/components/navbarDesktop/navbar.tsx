import { LOGIN, PROFILE } from "@/utils/frontEndUrls/urls";
import Link from "next/link";
import { Button } from "primereact/button";
import React from "react";
import DarkModeButton from "../btnDarkMode/btnDarkMode";
import { IsAuthenticated } from "@/hooks/useIsAuthenticated";

export default function HeaderDesktop() {
  let { IsLogged, Sair } = IsAuthenticated();

  return (
    <nav className="flexRow headerDesktop">
      {!IsLogged ? (
        <Link href={LOGIN}>
          <Button label="Login" outlined />
        </Link>
      ) : (
        ""
      )}
      {IsLogged ? (
        <Button
          label="Sair"
          severity="danger"
          outlined
          type="button"
          onClick={Sair}
        />
      ) : (
        ""
      )}
      <DarkModeButton />
      {IsLogged ? (
        <Link href={PROFILE}>
          <img src="/profile.png" alt="profile" className="LogoHeader" />
        </Link>
      ) : (
        ""
      )}
    </nav>
  );
}
