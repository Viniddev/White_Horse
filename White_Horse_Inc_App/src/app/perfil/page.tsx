"use client";
import "./profile.scss";
import "../../styles/globals.scss";
import InputTypeText from "@/components/inputs/input_type_text";
import React from "react";
import { Button } from "primereact/button";
import FormPadrao from "@/components/form_padrao_usuario/form";
import InformacoesImutaveis from "@/components/informacoes_imutaveis/informacoesImutaveis";
import { EMPTY_USER } from "@/utils/constants/consts";

export default function Profile() {
  return (
    <section className="ProfileConteiner flexRow">
      <form action="submit" className="FormularioProfile">
        <div className="sectionProfileImg">
          <div className="headerInformations flexColumn">
            <img
              src="./profile.png"
              alt="profile image"
              className="imgProfile"
            />
          </div>
          <div className="espacoVazio">{/* espaco em branco */}</div>
        </div>
        <div className="sectionUserInformations">
          <div className="headerInformations ajusteEspacamento">
            <InformacoesImutaveis />
          </div>
          <div className="boxUserInformations">
            <FormPadrao IsRegister={false} DefaultUserInformations={EMPTY_USER} />
          </div>
        </div>
      </form>
    </section>
  );
}
