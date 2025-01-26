import { SidebarToggle } from "@/@types/components";
import { LOGIN, PROFILE } from "@/utils/front_end_urls/urls";
import Link from "next/link";
import { Button } from "primereact/button";
import { Sidebar } from "primereact/sidebar";
import { useState } from "react";
import DarkModeButton from "../btn_dark_mode/btnDarkMode";

export default function SidebarHeader({ state, setState }: SidebarToggle) {

  return (
    <Sidebar
      visible={state}
      position="right"
      onHide={() => setState(false)}
    >
      <div className="navegacaoSidebar">
        <Link href={LOGIN} className="linksSidebar">
          <Button label="Login" outlined className="linksSidebar" />
        </Link>

        <Link href={PROFILE} className="linksSidebar">
          <Button label="Perfil" outlined className="linksSidebar" />
        </Link>

        <Link href={LOGIN} className="linksSidebar">
          <Button
            label="Sair"
            severity="danger"
            outlined
            className="linksSidebar"
          />
        </Link>

        <div className="linksSidebar btnDarkMode">
           <DarkModeButton/>
        </div>
      </div>
    </Sidebar>
  );
}