"use client";
import FormPadrao from "@/components/formPadraoUsuario/form";
import "../../styles/globals.scss";
import "./cadastro.scss";
import React from "react";
import UseCadastro from "@/hooks/useCadastro";

export default function Cadastro() {
  
  const {
    setUserData, 
    userInformations, 
    RegisterInformations 
  } = UseCadastro();

  return (
    <div className="conteinerCadastro">
      <form action="submit" className="formCadastro flexStart" onSubmit={RegisterInformations}>
        <h1>Cadastro:</h1>
        <FormPadrao
          IsRegister={true}
          DefaultUserInformations={userInformations}
          SetUserState={setUserData}
        />
      </form>
    </div>
  );
}
