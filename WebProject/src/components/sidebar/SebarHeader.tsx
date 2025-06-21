import { SidebarToggle } from "@/@types/components";
import { LOGIN, PROFILE } from "@/utils/frontEndUrls/urls";
import Link from "next/link";
import { Button } from "primereact/button";
import { Sidebar } from "primereact/sidebar";
import DarkModeButton from "../btnDarkMode/btnDarkMode";
import React from "react";
import { IsAuthenticated } from "@/hooks/useIsAuthenticated";

export default function SidebarHeader({ state, setState }: SidebarToggle) {

  let { IsLogged, Sair } = IsAuthenticated();

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