"use client";
import FormPadrao from "@/components/formPadraoUsuario/form";
import "../../styles/globals.scss";
import "./cadastro.scss";
import { EMPTY_USER } from "@/utils/constants/consts";

export default function Cadastro(){
    return (
      <div className="conteinerCadastro">
        <form action="" className="formCadastro flexStart">
          <h1>Cadastro:</h1>
          <FormPadrao IsRegister={true} DefaultUserInformations={EMPTY_USER} />
        </form>
      </div>
    );
}