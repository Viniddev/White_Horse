"use client";
import FormPadrao from "@/components/formPadraoUsuario/form";
import "../../styles/globals.scss";
import "./cadastro.scss";
import React from "react";
import UseCadastro from "@/hooks/useCadastro";
import { Toast } from "primereact/toast";

export default function Cadastro() {
  
  const {
    setUserData, 
    userInformations, 
    RegisterInformations,
    toast 
  } = UseCadastro();

  return (
    <div className="conteinerCadastro">
      <Toast ref={toast} />
      <form action="submit" className="formCadastro flexStart" onSubmit={RegisterInformations}>
        <h1>Informações Pessoais:</h1>
        <FormPadrao
          IsRegister={true}
          DefaultUserInformations={userInformations}
          SetUserState={setUserData}
        />
      </form>
    </div>
  );
}
