"use client";
import "./header.scss";
import React, { useState } from "react";
import Link from "next/link";
import "../../styles/globals.scss";
import { Button } from "primereact/button";
import { PROFILE, HOME, LOGIN } from "../../utils/front_end_urls/urls";
import { SelectButton } from "primereact/selectbutton";
import { Sidebar } from "primereact/sidebar";
import SidebarHeader from "../sidebar/SebarHeader";
import HeaderDesktop from "../navbar_desktop/navbar";
import LinksNavegacao from "../navegacao/navegacao";

export default function Header(){
  const [visibleRight, setVisibleRight] = useState<boolean>(false);

  return (
    <section className="headerLayout">
      <nav className="flexRow botoesNavegacao">
        <LinksNavegacao/>
      </nav>
      
      <nav className="flexRow headerDesktop">
        <HeaderDesktop/>
      </nav>


      <nav className="headerMobile">
        <Button
          icon="pi pi-bars"
          onClick={() => setVisibleRight(true)}
        />
        <SidebarHeader state={visibleRight} setState={setVisibleRight} />
      </nav>
    </section>
  );
}