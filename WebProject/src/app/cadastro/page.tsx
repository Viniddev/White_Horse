"use client";
import FormPadrao from "@/components/formPadraoUsuario/form";
import "../../styles/globals.scss";
import "./cadastro.scss";
import { EMPTY_USER } from "@/utils/constants/consts";
import { FormEvent } from "react";
import { UserInformations } from "@/@types/req";
import React from "react";

export default function Cadastro() {
  const [userData, setUserData] = React.useState<UserInformations>(EMPTY_USER);
  async function teste(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();

    console.log(userData);
  }

  return (
    <div className="conteinerCadastro">
      <form action="submit" className="formCadastro flexStart" onSubmit={teste}>
        <h1>Cadastro:</h1>
        <FormPadrao IsRegister={true} DefaultUserInformations={userData} />
      </form>
    </div>
  );
}
