"use client";
import "./profile.scss";
import "../../styles/globals.scss";
import React from "react";
import FormPadrao from "@/components/formPadraoUsuario/form";
import InformacoesImutaveis from "@/components/informacoesImutaveis/informacoesImutaveis";
import usePageProfile from "../../hooks/usePageProfile";
import { Toast } from "primereact/toast";

export default function Profile() {
  
  const { 
    userData,
    setUserData,
    UpdateUserInformations,
    toast
  } = usePageProfile();

  return (
    <section className="ProfileConteiner flexRow">
      <Toast ref={toast} />
      <form
        action="submit"
        className="FormularioProfile"
        onSubmit={UpdateUserInformations}
      >
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
            <InformacoesImutaveis
              IsRegister={false}
              DefaultUserInformations={userData}
              SetUserState={setUserData}
            />
          </div>
          <div className="boxUserInformations">
            <FormPadrao
              IsRegister={false}
              DefaultUserInformations={userData}
              SetUserState={setUserData}
            />
          </div>
        </div>
      </form>
    </section>
  );
}
