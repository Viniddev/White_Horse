import { SidebarToggle } from "@/@types/components";
import { LOGIN, PROFILE } from "@/utils/frontEndUrls/urls";
import Link from "next/link";
import { Button } from "primereact/button";
import { Sidebar } from "primereact/sidebar";
import { useState } from "react";
import DarkModeButton from "../btnDarkMode/btnDarkMode";
import React from "react";

export default function SidebarHeader({ state, setState }: SidebarToggle) {
  const [IsLogged, setIsLogged] = React.useState<boolean>(false);

  React.useEffect(() => {
    if (sessionStorage.getItem("Token") != undefined) {
      setIsLogged(true);
    }
  }, []);

  function Sair(){
    sessionStorage.removeItem("Token");
    window.location.href = LOGIN;
  }

  return (
    <Sidebar visible={state} position="right" onHide={() => setState(false)}>
      <div className="navegacaoSidebar">

        {!IsLogged ? (
          <Link href={LOGIN} className="linksSidebar">
            <Button label="Login" outlined className="linksSidebar" />
          </Link>
        ) : (
          ""
        )}

        <Link href={PROFILE} className="linksSidebar">
          <Button label="Perfil" outlined className="linksSidebar" />
        </Link>

        {IsLogged ? (
          <Button
            label="Sair"
            severity="danger"
            outlined
            className="linksSidebar"
            onClick={Sair}
          />
        ) : (
          ""
        )}

        <div className="linksSidebar btnDarkMode">
          <DarkModeButton />
        </div>
      </div>
    </Sidebar>
  );
}